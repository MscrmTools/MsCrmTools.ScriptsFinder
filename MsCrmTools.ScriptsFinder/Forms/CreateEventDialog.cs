using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using MsCrmTools.ScriptsFinder.AppCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace MsCrmTools.ScriptsFinder.Forms
{
    public partial class CreateEventDialog : Form
    {
        private readonly List<EntityMetadata> _emds;
        private readonly ScriptsFinder _finder;
        private readonly List<Entity> _forms;
        private readonly List<Entity> _homepageGrids;
        private readonly IOrganizationService _service;
        private readonly int _userLcid;
        private readonly List<Entity> _views;

        public CreateEventDialog(ScriptsFinder finder, List<EntityMetadata> emds, List<Entity> forms, List<Entity> homepageGrids, List<Entity> views, int userLcid, IOrganizationService service)
        {
            InitializeComponent();

            _emds = emds.OrderBy(e => e.DisplayName?.UserLocalizedLabel?.Label ?? "N/A").ToList();
            _forms = forms;
            _views = views;
            _homepageGrids = homepageGrids;
            _userLcid = userLcid;
            _service = service;
            _finder = finder;

            if (finder.Webresources != null)
            {
                cbbLibrary.Items.AddRange(_finder.Webresources.Entities.Select(r => r.GetAttributeValue<string>("name")).Cast<object>().ToArray());
                cbbLibrary.SelectedIndex = 0;
            }

            var tt = new ToolTip();
            tt.SetToolTip(chkLoadAlsoManagedWebresources, "Load also managed web resources");
        }

        public List<Script> CreatedScripts { get; } = new List<Script>();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var uiItem = cbbUiItems.SelectedItem as IUiUtem ?? cbbUiItems.SelectedItem as IUiUtem;
            if (uiItem == null) return;

            var logicalName = cbbEntity.SelectedItem.ToString().Split('(')[1];
            logicalName = logicalName.Substring(0, logicalName.Length - 1);

            Script eventScript = null;
            Script libraryScript = null;

            if (rdbRegisterLibrary.Checked)
            {
                eventScript = new Script
                {
                    Action = ScriptAction.Create,
                    UiItem = uiItem.Item,
                    ItemName = uiItem is CdsForm form ? form.Item.GetAttributeValue<string>("name") : "",
                    FormType = uiItem is CdsForm cdsForm ? cdsForm.Item.FormattedValues["type"] : "",
                    FormState = uiItem is CdsForm item ? (item.Item.FormattedValues.Contains("formactivationstate") ? item.Item.FormattedValues["formactivationstate"] : "") : "",
                    NewLibrary = cbbLibrary.SelectedItem?.ToString() ?? cbbLibrary.Text,
                    Library = cbbLibrary.SelectedItem?.ToString() ?? cbbLibrary.Text,
                    Type = uiItem is CdsForm ? "Form Library" : "Homepage Grid Library",
                    EntityLogicalName = logicalName,
                    EntityName = _emds.First(emd => emd.LogicalName == logicalName).DisplayName
                        ?.UserLocalizedLabel?.Label,
                    Order = 999
                };

                CreatedScripts.Add(eventScript);
            }
            else
            {
                var control = (CdsFormControl)cbbControl.SelectedItem;
                eventScript = new Script
                {
                    Action = ScriptAction.Create,
                    UiItem = uiItem.Item,
                    ItemName = uiItem is CdsForm || uiItem is CdsView
                        ? uiItem.Item.GetAttributeValue<string>("name")
                        : "",
                    FormType = uiItem is CdsForm ? uiItem.Item.FormattedValues["type"] : "",
                    FormState = uiItem is CdsForm ? (uiItem.Item.FormattedValues.Contains("formactivationstate") ? uiItem.Item.FormattedValues["formactivationstate"] : "") : "",
                    Event = cbbEvent.SelectedItem.ToString().ToLower(),
                    NewLibrary = cbbLibrary.SelectedItem?.ToString() ?? cbbLibrary.Text,
                    Library = cbbLibrary.SelectedItem?.ToString() ?? cbbLibrary.Text,
                    NewParameters = uiItem is CdsView ? "" : txtParameters.Text,
                    Parameters = uiItem is CdsView ? "" : txtParameters.Text,
                    NewEnabled = chkEnabled.Checked,
                    Enabled = chkEnabled.Checked,
                    NewMethodCalled = txtMethod.Text,
                    MethodCalled = txtMethod.Text,
                    NewPassExecutionContext = chkPassExecutionContext.Checked,
                    PassExecutionContext = chkPassExecutionContext.Checked,
                    AttributeLogicalName = "",
                    Attribute = "",
                    Order = 999,
                    Type = control.Type == CdsFormControlType.Grid ? "Subgrid event" :
                        control.Type == CdsFormControlType.HomepageGrid ? "Homepage Grid event" :
                        control.Type == CdsFormControlType.View ? "Grid Icon" : "Form event",
                    EntityLogicalName = logicalName,
                    EntityName = _emds.First(emd => emd.LogicalName == logicalName).DisplayName
                        ?.UserLocalizedLabel?.Label
                };

                if (eventScript.Type == "Subgrid event")
                {
                    if (eventScript.Event == "onchange")
                    {
                        eventScript.AttributeLogicalName = $"{control.Id}:{txtField.Text}";
                        eventScript.Attribute = $"{control.Name} / {txtField.Text}";
                    }
                    else
                    {
                        eventScript.AttributeLogicalName = $"{control.Id}";
                        eventScript.Attribute = $"{control.Name}";
                    }
                }
                else if (eventScript.Event == "ontabstatechange")
                {
                    eventScript.AttributeLogicalName = control.Id;
                    eventScript.Attribute = control.Name;
                }
                else if (eventScript.Event == "n/a")
                {
                    eventScript.AttributeLogicalName = control.Id;
                    eventScript.Attribute = control.Name;
                }
                else
                {
                    if (eventScript.Event == "onchange")
                    {
                        eventScript.AttributeLogicalName = string.IsNullOrEmpty(txtField.Text) ? control.Id : txtField.Text;
                        eventScript.Attribute = _emds.FirstOrDefault(emd => emd.LogicalName == logicalName)?.Attributes
                            .FirstOrDefault(a => a.LogicalName == eventScript.AttributeLogicalName)?.DisplayName
                            ?.UserLocalizedLabel?.Label;

                        if (eventScript.Attribute == null)
                        {
                            MessageBox.Show(this, @"Please ensure the attribute logical name is correct", @"Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                CreatedScripts.Add(eventScript);

                if (uiItem is CdsView) return;

                if (!uiItem.Libraries.Select(l => l?.ToLower())
                    .Contains((cbbLibrary.SelectedItem?.ToString() ?? cbbLibrary.Text).ToLower()))
                {
                    libraryScript = new Script
                    {
                        Action = ScriptAction.Create,
                        UiItem = uiItem.Item,
                        NewLibrary = cbbLibrary.SelectedItem?.ToString() ?? cbbLibrary.Text,
                        Library = cbbLibrary.SelectedItem?.ToString() ?? cbbLibrary.Text,
                        ItemName = uiItem is CdsForm form ? form.Item.GetAttributeValue<string>("name") : "",
                        FormType = uiItem is CdsForm cdsForm ? cdsForm.Item.FormattedValues["type"] : "",
                        FormState = uiItem is CdsForm item
                            ? (uiItem.Item.FormattedValues.Contains("formactivationstate") ? uiItem.Item.FormattedValues["formactivationstate"] : "")
                            : "",
                        Type = uiItem is CdsForm ? "Form Library" : "Homepage Grid Library",
                        EntityName = eventScript.EntityName,
                        EntityLogicalName = eventScript.EntityLogicalName,
                        Order = 999
                    };

                    CreatedScripts.Add(libraryScript);
                }
            }

            if (libraryScript != null)
            {
                if (lvNewScripts.Items.Cast<ListViewItem>().Select(i => (Script)i.Tag).Any(s =>
                       s.Type == "Form Library" && s.UiItem.Id == libraryScript.UiItem.Id && s.Library == libraryScript.Library))
                {
                }
                else
                {
                    var item = new ListViewItem(libraryScript.Type) { Tag = libraryScript };
                    item.SubItems.Add(libraryScript.EntityName);
                    item.SubItems.Add(libraryScript.ItemName);
                    item.SubItems.Add(libraryScript.Event?.ToLower());
                    item.SubItems.Add(libraryScript.Attribute);
                    item.SubItems.Add(libraryScript.Library);
                    item.SubItems.Add(libraryScript.MethodCalled);
                    item.SubItems.Add(libraryScript.PassExecutionContext?.ToString() ?? "");
                    item.SubItems.Add(libraryScript.Parameters);
                    item.SubItems.Add(libraryScript.Enabled?.ToString() ?? "");
                    item.Tag = libraryScript;

                    lvNewScripts.Items.Add(item);
                }
            }

            if (eventScript != null)
            {
                var item = new ListViewItem(eventScript.Type) { Tag = libraryScript };
                item.SubItems.Add(eventScript.EntityName);
                item.SubItems.Add(eventScript.ItemName);
                item.SubItems.Add(eventScript.Event?.ToLower());
                item.SubItems.Add(eventScript.Attribute);
                item.SubItems.Add(eventScript.Library);
                item.SubItems.Add(eventScript.MethodCalled);
                item.SubItems.Add(eventScript.PassExecutionContext?.ToString() ?? "");
                item.SubItems.Add(eventScript.Parameters);
                item.SubItems.Add(eventScript.Enabled?.ToString() ?? "");
                item.Tag = eventScript;

                lvNewScripts.Items.Add(item);
            }
        }

        private void btnReloadWebResources_Click(object sender, EventArgs e)
        {
            Enabled = false;
            cbbLibrary.Items.Clear();
            var loadManaged = chkLoadAlsoManagedWebresources.Checked;

            var bw = new BackgroundWorker();
            bw.DoWork += (s, evt) =>
            {
                ScriptsFinder.LoadWebResources(_finder, loadManaged, _service);
            };
            bw.RunWorkerCompleted += (s, evt) =>
            {
                Enabled = true;

                if (evt.Error != null)
                {
                    MessageBox.Show(this, $@"An error occured when loading web resources: {evt.Error.Message}",
                        @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cbbLibrary.Items.AddRange(_finder.Webresources.Entities.Select(r => r.GetAttributeValue<string>("name")).Cast<object>().ToArray());
                cbbLibrary.SelectedIndex = 0;
            };
            bw.RunWorkerAsync();
        }

        private void btnSolutionPickerValidate_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cbbControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var control = (CdsFormControl)cbbControl.SelectedItem;

            cbbEvent.Items.Clear();
            cbbEvent.Items.AddRange(control.GetEvents().Cast<object>().ToArray());
            cbbEvent.SelectedIndex = 0;
        }

        private void cbbEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            var logicalName = cbbEntity.SelectedItem.ToString().Split('(')[1];
            logicalName = logicalName.Substring(0, logicalName.Length - 1);
            var emd = _emds.First(em => em.LogicalName == logicalName);

            var forms = _forms.Where(f => f.GetAttributeValue<string>("objecttypecode") == logicalName
                                          && (f.GetAttributeValue<OptionSetValue>("type").Value == 2
                                          || f.GetAttributeValue<OptionSetValue>("type").Value == 7));

            var homepageGrids =
                _homepageGrids.Where(h => h.GetAttributeValue<string>("primaryentitytypecode") == logicalName);

            var views = _views.Where(v => v.GetAttributeValue<string>("returnedtypecode") == logicalName);

            cbbUiItems.Items.Clear();
            cbbUiItems.Items.AddRange(forms.Select(f => new CdsForm(f)).Cast<object>().ToArray());
            cbbUiItems.Items.AddRange(homepageGrids.Select(h => new CdsHomePageGrid(h)).Cast<object>().ToArray());
            cbbUiItems.Items.AddRange(views.Where(v => !string.IsNullOrEmpty(v.GetAttributeValue<string>("layoutxml"))).Select(v => new CdsView(v, emd)).Cast<object>().ToArray());
            cbbUiItems.SelectedIndex = 0;
        }

        private void cbbEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            var control = (CdsFormControl)cbbControl.SelectedItem;
            var eventName = cbbEvent.SelectedItem.ToString();
            var showFieldControls = eventName == "OnChange" && (control.Type == CdsFormControlType.Grid || control.Type == CdsFormControlType.HomepageGrid);

            txtField.Visible = showFieldControls;
            lblField.Visible = showFieldControls;
        }

        private void cbbForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbControl.Items.Clear();
            cbbControl.Items.AddRange(((IUiUtem)cbbUiItems.SelectedItem).GetControls(_userLcid).Cast<object>().ToArray());
            cbbControl.SelectedIndex = 0;

            var isView = cbbUiItems.SelectedItem is CdsView;
            lblEvent.Visible = !isView;
            cbbEvent.Visible = !isView;
            lblPassExecutionContext.Visible = !isView;
            chkPassExecutionContext.Visible = !isView;
            lblParameters.Visible = !isView;
            txtParameters.Visible = !isView;
            lblEnabled.Visible = !isView;
            chkEnabled.Visible = !isView;
        }

        private void CreateEventDialog_Load(object sender, EventArgs e)
        {
            cbbEntity.Items.AddRange(_emds.Select(emd => $"{emd.DisplayName?.UserLocalizedLabel?.Label ?? "N/A"} ({emd.LogicalName})").Cast<object>().ToArray());
            cbbEntity.SelectedIndex = 0;

            rdbRegisterEvent_CheckedChanged(rdbRegisterEvent, new EventArgs());
        }

        private void lvNewScripts_DoubleClick(object sender, EventArgs e)
        {
            var lvi = lvNewScripts.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
            if (lvi == null) return;

            lvNewScripts.Items.Remove(lvi);
            CreatedScripts.Remove((Script)lvi.Tag);
        }

        private void rdbRegisterEvent_CheckedChanged(object sender, EventArgs e)
        {
            var isEvent = ((RadioButton)sender).Checked;

            var control = (CdsFormControl)cbbControl.SelectedItem;
            var eventName = cbbEvent.SelectedItem.ToString();
            var showFieldControls = eventName == "OnChange" && (control.Type == CdsFormControlType.Grid || control.Type == CdsFormControlType.HomepageGrid);

            lblControl.Visible = isEvent;
            cbbControl.Visible = isEvent;
            lblEvent.Visible = isEvent;
            cbbEvent.Visible = isEvent;
            txtField.Visible = isEvent && showFieldControls;
            lblField.Visible = isEvent && showFieldControls;
            lblMethod.Visible = isEvent;
            txtMethod.Visible = isEvent;
            lblPassExecutionContext.Visible = isEvent;
            chkPassExecutionContext.Visible = isEvent;
            lblParameters.Visible = isEvent;
            txtParameters.Visible = isEvent;
            lblEnabled.Visible = isEvent;
            chkEnabled.Visible = isEvent;

            //Height = isEvent ? 550 : 350;
        }
    }
}