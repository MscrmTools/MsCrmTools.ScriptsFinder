using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using MsCrmTools.ScriptsFinder.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace MsCrmTools.ScriptsFinder
{
    public partial class ScriptsFinder : PluginControlBase, IGitHubPlugin, IHelpPlugin
    {
        private Thread _filterThread;
        private List<Entity> _forms;
        private List<Entity> _homePageGrids;
        private List<ListViewItem> _lScripts = new List<ListViewItem>();
        private List<EntityMetadata> _metadata;
        private int _userLcid;
        private List<Entity> _views;
        private bool loadManagedEntities = false;
        public string HelpUrl => "https://github.com/MscrmTools/MsCrmTools.ScriptsFinder/wiki";
        public string RepositoryName => "MsCrmTools.ScriptsFinder";
        public string UserName => "MscrmTools";
        public EntityCollection Webresources { get; private set; }

        #region Constructor

        public ScriptsFinder()
        {
            InitializeComponent();

            var tt = new ToolTip();
            tt.SetToolTip(chkLoadAlsoManagedWebresources, "Load also managed web resources");
        }

        #endregion Constructor

        public static void LoadWebResources(ScriptsFinder finder, bool loadAlsoManaged, IOrganizationService service)
        {
            var query = new QueryExpression("webresource")
            {
                NoLock = true,
                ColumnSet = new ColumnSet("name"),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("webresourcetype", ConditionOperator.Equal, 3),
                        new ConditionExpression("name", ConditionOperator.DoesNotBeginWith, "cc_"),
                    }
                },
                Orders =
                {
                    new OrderExpression("name", OrderType.Ascending)
                }
            };

            if (!loadAlsoManaged)
            {
                query.Criteria.Conditions.Add(new ConditionExpression("ismanaged", ConditionOperator.Equal, false));
            }

            finder.Webresources = service.RetrieveMultiple(query);
        }

        public void FindScripts(bool allEntities)
        {
            lvScripts.Items.Clear();
            tsddFindScripts.Enabled = false;
            tsbExportToCsv.Enabled = false;

            var solutionList = new List<Entity>();

            if (!allEntities)
            {
                var dialog = new SolutionPicker(Service);
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    solutionList = dialog.SelectedSolution;
                }
                else
                {
                    tsddFindScripts.Enabled = true;
                    tsbExportToCsv.Enabled = true;

                    return;
                }
            }

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading scripts (this can take a while...)",
                AsyncArgument = solutionList,
                Work = (bw, e) =>
                {
                    _lScripts = new List<ListViewItem>();
                    var solutions = (List<Entity>)e.Argument;

                    var sManager = new ScriptsManager(Service, bw);
                    sManager.Find(solutions, loadManagedEntities, new Version(ConnectionDetail.OrganizationVersion));
                    _metadata = sManager.Metadata;
                    _forms = sManager.Forms;
                    _views = sManager.Views;
                    _homePageGrids = sManager.HomePageGrids;
                    _userLcid = sManager.UserLcid;

                    foreach (var script in sManager.Scripts)
                    {
                        var item = new ListViewItem(script.Type) { Tag = script };
                        item.SubItems.Add(script.EntityName);
                        item.SubItems.Add(script.EntityLogicalName);
                        item.SubItems.Add(script.ItemName);
                        item.SubItems.Add(script.FormType);
                        item.SubItems.Add(script.FormState);
                        item.SubItems.Add(script.Event);
                        item.SubItems.Add(script.Attribute);
                        item.SubItems.Add(script.AttributeLogicalName);
                        item.SubItems.Add(script.Library);
                        item.SubItems.Add(script.MethodCalled);
                        item.SubItems.Add(script.PassExecutionContext?.ToString() ?? "");
                        item.SubItems.Add(script.Parameters);
                        item.SubItems.Add(script.Enabled?.ToString() ?? "");

                        if (script.HasProblem)
                        {
                            item.ForeColor = Color.Red;
                        }
                        _lScripts.Add(item);
                    }

                    e.Result = _lScripts;
                },
                PostWorkCallBack = e =>
                {
                    tsddFindScripts.Enabled = true;
                    tsbExportToCsv.Enabled = true;

                    if (e.Error != null)
                    {
                        MessageBox.Show(this, e.Error.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    lvScripts.Items.AddRange(((List<ListViewItem>)e.Result).ToArray());
                    tsbApplyChanges.Enabled = lvScripts.Items.Cast<ListViewItem>().Any(i => ((Script)i.Tag).RequiresUpdate);
                },
                ProgressChanged = e =>
                {
                    SetWorkingMessage(e.UserState.ToString());
                }
            });
        }

        private static void SetItemState(Script orderedScript, ListViewItem item)
        {
            if (orderedScript.RequiresUpdate)
            {
                item.Font = new Font(item.Font.FontFamily, item.Font.Size, FontStyle.Bold);
                item.ImageIndex = item.ImageIndex == 1 ? item.ImageIndex : 0;
            }
            else
            {
                item.Font = new Font(item.Font.FontFamily, item.Font.Size, FontStyle.Regular);
                item.ImageIndex = item.ImageIndex == 1 ? item.ImageIndex : -1;
            }

            orderedScript.Action = orderedScript.Action == ScriptAction.Create
                ? ScriptAction.Create
                : ScriptAction.Update;
        }

        private void btnReloadWebResources_Click(object sender, EventArgs e)
        {
            var loadAlsoManaged = chkLoadAlsoManagedWebresources.Checked;
            Enabled = false;
            var bw = new BackgroundWorker();
            bw.DoWork += (s, evt) => { LoadWebResources(this, loadAlsoManaged, Service); };
            bw.RunWorkerCompleted += (s, evt) =>
            {
                Enabled = true;

                if (evt.Error != null)
                {
                    MessageBox.Show(this, $@"An error occured when loading web resources: {evt.Error.Message}",
                        @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var text = cbbLibrary.Text;

                cbbLibrary.Items.Clear();
                cbbLibrary.Items.AddRange(Webresources.Entities.Select(r => r.GetAttributeValue<string>("name")).ToArray());

                cbbLibrary.Text = text;
                //cbbLibrary.SelectedIndex = 0;
            };
            bw.RunWorkerAsync();
        }

        private void cbbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void ClearCurrentValues()
        {
            lblChangeFileCurrentValue.Text = string.Empty;
            lblChangeEnabledCurrentValue.Text = string.Empty;
            lblChangeMethodCurrentValue.Text = string.Empty;
            lblChangeParametersCurrentValue.Text = string.Empty;
            lblChangePassContextCurrentValue.Text = string.Empty;
        }

        private void DisplayChangedValues()
        {
            rdbChangeEnabledFalse.Checked = false;
            rdbChangeEnabledTrue.Checked = false;
            rdbChangePassExecutionFalse.Checked = false;
            rdbChangePassExecutionTrue.Checked = false;

            var scripts = lvScripts.SelectedItems.Cast<ListViewItem>().Select(i => (Script)i.Tag).ToList();
            if (scripts.Count == 0) return;

            bool? newEnabled = null, newPassParams = null;
            bool multipleNewEnable = false, multipleNewPassParams = false, multipleNewFile = false, multipleNewMethod = false, multipleNewParams = false;
            string enabled = null, passParams = null, file = null, newFile = null, method = null, newMethod = null, parameters = null, newParameters = null;

            if (scripts.Count == 1)
            {
                lblChangeOrderCurrentValue.Text = scripts[0].Order.ToString();
                if (scripts[0].NewOrder.HasValue)
                    lblChangeOrderNewValue.Text = scripts[0].NewOrder.Value.ToString();
            }
            else
            {
                lblChangeOrderCurrentValue.Text = "";
                lblChangeOrderNewValue.Text = "";
            }

            foreach (var script in scripts)
            {
                if (enabled == null)
                {
                    enabled = script.Enabled.ToString();
                }
                else if (enabled != script.Enabled.ToString())
                {
                    enabled = "(multiple values)";
                }

                if (passParams == null)
                {
                    passParams = script.PassExecutionContext.ToString();
                }
                else if (passParams != script.PassExecutionContext.ToString())
                {
                    passParams = "(multiple values)";
                }

                if (file == null)
                {
                    file = script.Library;
                }
                else if (file != script.Library)
                {
                    file = "(multiple values)";
                }

                if (method == null)
                {
                    method = script.MethodCalled;
                }
                else if (method != script.MethodCalled)
                {
                    method = "(multiple values)";
                }

                if (parameters == null)
                {
                    parameters = script.Parameters;
                }
                else if (parameters != script.Parameters)
                {
                    parameters = "(multiple values)";
                }

                if (script.NewEnabled.HasValue)
                {
                    if (!newEnabled.HasValue)
                    {
                        newEnabled = script.NewEnabled ?? false;
                    }
                    else if (newEnabled.Value != script.NewEnabled)
                    {
                        multipleNewEnable = true;
                    }
                }

                if (script.NewPassExecutionContext.HasValue)
                {
                    if (!newPassParams.HasValue)
                    {
                        newPassParams = script.NewPassExecutionContext ?? false;
                    }
                    else if (newPassParams.Value != script.NewPassExecutionContext)
                    {
                        multipleNewPassParams = true;
                    }
                }

                if (newFile == null)
                {
                    newFile = script.NewLibrary;
                }
                else if (newFile != script.NewLibrary)
                {
                    multipleNewFile = true;
                }

                if (newMethod == null)
                {
                    newMethod = script.NewMethodCalled;
                }
                else if (newMethod != script.NewMethodCalled)
                {
                    multipleNewMethod = true;
                }

                if (newParameters == null)
                {
                    newParameters = script.NewParameters;
                }
                else if (newParameters != script.NewParameters)
                {
                    multipleNewParams = true;
                }
            }

            lblChangeFileCurrentValue.Text = file;
            lblChangeMethodCurrentValue.Text = method;
            lblChangeParametersCurrentValue.Text = parameters;
            lblChangePassContextCurrentValue.Text = passParams;
            lblChangeEnabledCurrentValue.Text = enabled;

            cbbLibrary.Text = multipleNewFile ? "" : newFile;
            txtChangeMethod.Text = multipleNewMethod ? "" : newMethod;
            txtChangeParameters.Text = multipleNewParams ? "" : newParameters;
            if (newEnabled != null)
            {
                rdbChangeEnabledFalse.Checked = !multipleNewEnable && !newEnabled.Value;
                rdbChangeEnabledTrue.Checked = !multipleNewEnable && newEnabled.Value;
            }

            if (newPassParams != null)
            {
                rdbChangePassExecutionFalse.Checked = !multipleNewPassParams && !newPassParams.Value;
                rdbChangePassExecutionTrue.Checked = !multipleNewPassParams && newPassParams.Value;
            }
        }

        private void Filter()
        {
            Thread.Sleep(500);

            Invoke(new Action(() =>
            {
                lvScripts.Items.Clear();

                var filtered = _lScripts.Where(l =>
                {
                    var s = (Script)l.Tag;

                    return matchNullOrComboboxValue(cbbFilterEvent, s.Event)
                           && matchNullOrComboboxValue(cbbFilterEnabled,
                               s.Enabled.HasValue ? s.Enabled.Value ? "True" : "False" : "(Not specified)")
                           && matchNullOrComboboxValue(cbbFilterFormState, s.FormState)
                           && matchNullOrComboboxValue(cbbFilterFormType, s.FormType)
                           && matchNullOrComboboxValue(cbbFilterPassParameters,
                               s.PassExecutionContext.HasValue
                                   ? s.PassExecutionContext.Value ? "True" : "False"
                                   : "(Not specified)")
                           && matchNullOrComboboxValue(cbbFilterType, s.Type)
                           && matchEmptyOrTextBoxValue(txtFilterControl, s.Attribute)
                           && matchEmptyOrTextBoxValue(txtFilterControlLogicalName, s.AttributeLogicalName)
                           && matchEmptyOrTextBoxValue(txtFilterEntity, s.EntityName)
                           && matchEmptyOrTextBoxValue(txtFilterEntityLogicalName, s.EntityLogicalName)
                           && matchEmptyOrTextBoxValue(txtFilterFile, s.Library)
                           && matchEmptyOrTextBoxValue(txtFilterFormName, s.ItemName)
                           && matchEmptyOrTextBoxValue(txtFilterMethod, s.MethodCalled)
                           && matchEmptyOrTextBoxValue(txtFilterParameters, s.Parameters);
                });

                lvScripts.Items.AddRange(filtered.ToArray());
                gbFilter.Text = $@"Filter ({lvScripts.Items.Count})";
            }));
        }

        private void forAllEntitiesincludedManagedOnesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadManagedEntities = true;
            ExecuteMethod(FindScripts, true);
        }

        private void forAllEntitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadManagedEntities = false;
            ExecuteMethod(FindScripts, true);
        }

        private void forEntitiesInSelectedSolutionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadManagedEntities = false;
            ExecuteMethod(FindScripts, false);
        }

        private void lvScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            gbUpdates.Visible = lvScripts.SelectedItems.Count > 0;
            tsbShowHideChangePanel.Text = gbUpdates.Visible ? "Hide Edit panel" : "Show Edit panel";

            ClearCurrentValues();
            SetChangeControlsState();
            DisplayChangedValues();

            tsbShowErrorMessage.Visible = lvScripts.SelectedItems.Count == 1 &&
                                          ((Script)lvScripts.SelectedItems[0].Tag).UpdateErrorMessage != null;
        }

        private void LvScriptsColumnClick(object sender, ColumnClickEventArgs e)
        {
            lvScripts.Sorting = lvScripts.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            lvScripts.ListViewItemSorter = new ListViewItemComparer(e.Column, lvScripts.Sorting);
        }

        private bool matchEmptyOrTextBoxValue(TextBox txt, string value)
        {
            return string.IsNullOrEmpty(txt.Text) ||
              (value?.ToLower().Contains(txt.Text.ToLower()) ?? false);
        }

        private bool matchNullOrComboboxValue(ComboBox cbb, string value)
        {
            return cbb.SelectedItem == null ||
                   cbb.SelectedItem?.ToString().ToLower() == value?.ToLower() ||
                   cbb.SelectedIndex == cbb.Items.Count - 1 && string.IsNullOrEmpty(value);
        }

        private void SetChangeControlsState()
        {
            var scripts = lvScripts.SelectedItems.Cast<ListViewItem>().Select(i => (Script)i.Tag).ToList();

            txtChangeParameters.Enabled = false;
            pnlLibrary.Enabled = false;
            txtChangeMethod.Enabled = false;
            rdbChangePassExecutionFalse.Enabled = false;
            rdbChangePassExecutionTrue.Enabled = false;
            rdbChangeEnabledFalse.Enabled = false;
            rdbChangeEnabledTrue.Enabled = false;

            if (scripts.All(s => s.Type != "Form event" && s.Type != "Form Library" && s.Type != "Homepage Grid Library" && s.Type != "Subgrid event" && s.Type != "Homepage Grid event" && s.Type != "Grid Icon"))
            {
                return;
            }

            if (scripts.All(s => s.Type == "Grid Icon"))
            {
                pnlLibrary.Enabled = true;
                txtChangeMethod.Enabled = true;
            }

            if (scripts.All(s => s.Type == "Form event" || s.Type == "Subgrid event" || s.Type == "Homepage Grid event"))
            {
                txtChangeParameters.Enabled = true;
                pnlLibrary.Enabled = true;
                txtChangeMethod.Enabled = true;
                rdbChangePassExecutionFalse.Enabled = true;
                rdbChangePassExecutionTrue.Enabled = true;
                rdbChangeEnabledFalse.Enabled = true;
                rdbChangeEnabledTrue.Enabled = true;
            }
            else if (scripts.Any(s => s.Type == "Form event" || s.Type == "Subgrid event" || s.Type == "Form Library" || s.Type == "Homepage Grid Library" || s.Type == "Homepage Grid event"))
            {
                pnlLibrary.Enabled = true;
            }
        }

        private void tsbApplyChanges_Click(object sender, EventArgs e)
        {
            var scripts = lvScripts.Items.Cast<ListViewItem>().Where(i => i.Tag is Script s && (s.Action == ScriptAction.Create || s.Action == ScriptAction.Delete || s.RequiresUpdate))
                .Select(i => (Script)i.Tag).ToList();

            int createLibrary = scripts.Count(s => (s.Type == "Form Library" || s.Type == "Homepage Grid Library") && s.Action == ScriptAction.Create);
            int updateLibrary = scripts.Count(s => (s.Type == "Form Library" || s.Type == "Homepage Grid Library") && s.Action == ScriptAction.Update);
            int deleteLibrary = scripts.Count(s => (s.Type == "Form Library" || s.Type == "Homepage Grid Library") && s.Action == ScriptAction.Delete);
            int createScript = scripts.Count(s => s.Type != "Form Library" && s.Type != "Homepage Grid Library" && s.Action == ScriptAction.Create);
            int updateScript = scripts.Count(s => s.Type != "Form Library" && s.Type != "Homepage Grid Library" && s.Action == ScriptAction.Update);
            int deleteScript = scripts.Count(s => s.Type != "Form Library" && s.Type != "Homepage Grid Library" && s.Action == ScriptAction.Delete);

            var message = $@"Are you sure you want to apply the following changes:
Form Libraries:
    - {createLibrary} create
    - {updateLibrary} update
    - {deleteLibrary} delete
Events:
    - {createScript} create
    - {updateScript} update
    - {deleteScript} delete";
            if (MessageBox.Show(this, message, @"Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes)
                return;

            foreach (var script in scripts)
            {
                script.UiItem.Attributes.Remove(script.ItemUpdateAttribute);
            }

            var orderedScripts = scripts.OrderBy(s => s.Order).ToList();
            foreach (var script in orderedScripts)
            {
                script.ProcessChanges(orderedScripts);
            }

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Updating forms...",
                Work = (bw, evt) =>
                {
                    var manager = new ScriptsManager(Service, bw);
                    manager.UpdateForms(scripts);
                },
                PostWorkCallBack = evt =>
                {
                    foreach (var script in scripts)
                    {
                        var lvi = lvScripts.Items.Cast<ListViewItem>().First(i => i.Tag == script);

                        switch (script.Action)
                        {
                            case ScriptAction.Create:
                                lvi.Font = new Font(lvi.Font.FontFamily, lvi.Font.Size,
                                    script.RequiresUpdate ? FontStyle.Bold : FontStyle.Regular);

                                lvi.ForeColor = script.UpdateErrorMessage == null ? DefaultForeColor : Color.Red;
                                lvi.ImageIndex = script.UpdateErrorMessage == null ? -1 : lvi.ImageIndex;
                                break;

                            case ScriptAction.Update:
                                lvi.Font = new Font(lvi.Font.FontFamily, lvi.Font.Size,
                                    script.RequiresUpdate ? FontStyle.Bold : FontStyle.Regular);

                                lvi.SubItems[9].Text = script.Library;
                                lvi.SubItems[10].Text = script.MethodCalled;
                                lvi.SubItems[11].Text = script.PassExecutionContext?.ToString() ?? "";
                                lvi.SubItems[12].Text = script.Parameters;
                                lvi.SubItems[13].Text = script.Enabled?.ToString() ?? "";

                                lvi.ForeColor = script.UpdateErrorMessage == null ? DefaultForeColor : Color.Red;
                                lvi.ImageIndex = script.UpdateErrorMessage == null ? -1 : lvi.ImageIndex;
                                break;

                            case ScriptAction.Delete:
                                lvScripts.Items.Remove(lvi);
                                _lScripts.Remove(lvi);
                                break;
                        }

                        script.Action = script.UpdateErrorMessage == null ? ScriptAction.None : script.Action;
                    }

                    tsbApplyChanges.Enabled = lvScripts.SelectedItems.Cast<ListViewItem>().Any(i => i.Tag is Script s && (s.Action == ScriptAction.Create || s.Action == ScriptAction.Delete || s.RequiresUpdate));

                    lvScripts_SelectedIndexChanged(null, null);

                    if (evt.Error != null)
                    {
                        MessageBox.Show(this, $@"An error occured: {evt.Error.Message}", @"Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            });
        }

        private void tsbChangeSave_Click(object sender, EventArgs e)
        {
            var scripts = lvScripts.SelectedItems.Cast<ListViewItem>().Select(i => (Script)i.Tag).ToList();
            if (scripts.Count == 0) return;

            foreach (var script in scripts)
            {
                var item = lvScripts.Items.Cast<ListViewItem>().First(i => i.Tag == script);

                if (cbbLibrary.Text.Length > 0 && script.Library.ToLower() != cbbLibrary.Text.ToLower())
                {
                    script.NewLibrary = cbbLibrary.Text;

                    if (script.Action == ScriptAction.Create)
                    {
                        item.SubItems[9].Text = script.NewLibrary;
                        script.Library = script.NewLibrary;
                    }
                }
                else
                {
                    script.NewLibrary = null;
                }

                if (txtChangeMethod.Text.Length > 0 && script.MethodCalled != txtChangeMethod.Text)
                {
                    script.NewMethodCalled = txtChangeMethod.Text;

                    if (script.Action == ScriptAction.Create)
                    {
                        item.SubItems[10].Text = script.NewMethodCalled;
                        script.MethodCalled = script.NewMethodCalled;
                    }
                }
                else
                {
                    script.NewMethodCalled = null;
                }

                if (txtChangeParameters.Text.Length > 0 && script.Parameters != txtChangeParameters.Text)
                {
                    script.NewParameters = txtChangeParameters.Text;

                    if (script.Action == ScriptAction.Create)
                    {
                        item.SubItems[12].Text = script.NewParameters;
                        script.Parameters = script.NewParameters;
                    }
                }
                else
                {
                    script.NewParameters = null;
                }

                if (rdbChangePassExecutionFalse.Checked)
                {
                    script.NewPassExecutionContext = false;
                }
                else if (rdbChangePassExecutionTrue.Checked)
                {
                    script.NewPassExecutionContext = true;
                }

                if (script.NewPassExecutionContext.HasValue && script.Action == ScriptAction.Create)
                {
                    item.SubItems[11].Text = script.NewPassExecutionContext?.ToString();
                    script.PassExecutionContext = script.NewPassExecutionContext;
                }

                if (rdbChangeEnabledFalse.Checked)
                {
                    script.NewEnabled = false;
                }
                else if (rdbChangeEnabledTrue.Checked)
                {
                    script.NewEnabled = true;
                }

                if (script.NewEnabled.HasValue && script.Action == ScriptAction.Create)
                {
                    item.SubItems[13].Text = script.NewEnabled?.ToString();
                    script.Enabled = script.NewEnabled;
                }

                SetItemState(script, item);
            }

            tsbApplyChanges.Enabled = lvScripts.Items.Cast<ListViewItem>().Any(i => i.Tag is Script s && (s.Action == ScriptAction.Create || s.Action == ScriptAction.Delete || s.RequiresUpdate));
            tssdDiscardChanges.Enabled = lvScripts.Items.Cast<ListViewItem>().Any(i => i.Tag is Script s && (s.Action == ScriptAction.Create || s.Action == ScriptAction.Delete || s.RequiresUpdate));
        }

        private void tsbClearFilter_Click(object sender, EventArgs e)
        {
            foreach (var ctrl in Controls.OfType<ComboBox>())
            {
                ctrl.SelectedIndexChanged -= cbbFilter_SelectedIndexChanged;
            }

            foreach (var ctrl in Controls.OfType<TextBox>())
            {
                ctrl.TextChanged -= txtFilter_TextChanged;
            }

            txtFilterControl.Text = string.Empty;
            txtFilterControlLogicalName.Text = string.Empty;
            txtFilterEntity.Text = string.Empty;
            txtFilterEntityLogicalName.Text = string.Empty;
            txtFilterFile.Text = string.Empty;
            txtFilterFormName.Text = string.Empty;
            txtFilterMethod.Text = string.Empty;
            txtFilterParameters.Text = string.Empty;
            cbbFilterEvent.SelectedIndex = -1;
            cbbFilterEnabled.SelectedIndex = -1;
            cbbFilterFormState.SelectedIndex = -1;
            cbbFilterFormType.SelectedIndex = -1;
            cbbFilterPassParameters.SelectedIndex = -1;
            cbbFilterType.SelectedIndex = -1;

            foreach (var ctrl in Controls.OfType<ComboBox>())
            {
                ctrl.SelectedIndexChanged += cbbFilter_SelectedIndexChanged;
            }

            foreach (var ctrl in Controls.OfType<TextBox>())
            {
                ctrl.TextChanged += txtFilter_TextChanged;
            }

            Filter();
        }

        private void tsbCreate_Click(object sender, EventArgs e)
        {
            if (_metadata == null)
            {
                MessageBox.Show(this, @"Please load scripts first", @"Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            var dialog = new CreateEventDialog(this, _metadata, _forms, _homePageGrids, _views, _userLcid, Service);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                foreach (var script in dialog.CreatedScripts)
                {
                    if (script.Type == "Form Library")
                    {
                        if (lvScripts.Items.Cast<ListViewItem>().Select(i => (Script)i.Tag).Any(s =>
                               s.Type == "Form Library" && s.UiItem.Id == script.UiItem.Id && s.Library == script.Library))
                        {
                            continue;
                        }
                    }

                    var item = new ListViewItem(script.Type) { Tag = script };
                    item.SubItems.Add(script.EntityName);
                    item.SubItems.Add(script.EntityLogicalName);
                    item.SubItems.Add(script.ItemName);
                    item.SubItems.Add(script.FormType);
                    item.SubItems.Add(script.FormState);
                    item.SubItems.Add(script.Event?.ToLower());
                    item.SubItems.Add(script.Attribute);
                    item.SubItems.Add(script.AttributeLogicalName);
                    item.SubItems.Add(script.Library);
                    item.SubItems.Add(script.MethodCalled);
                    item.SubItems.Add(script.PassExecutionContext?.ToString() ?? "");
                    item.SubItems.Add(script.Parameters);
                    item.SubItems.Add(script.Enabled?.ToString() ?? "");
                    item.Tag = script;
                    item.ImageIndex = 1;
                    item.Font = new Font(item.Font.FontFamily, item.Font.Size, FontStyle.Bold);

                    _lScripts.Add(item);
                    lvScripts.Items.Add(item);
                }

                lvScripts.Sort();
                tsbApplyChanges.Enabled = lvScripts.Items.Cast<ListViewItem>().Any(i => i.Tag is Script s && (s.Action == ScriptAction.Create || s.Action == ScriptAction.Delete || s.RequiresUpdate));
                tssdDiscardChanges.Enabled = lvScripts.Items.Cast<ListViewItem>().Any(i => i.Tag is Script s && (s.Action == ScriptAction.Create || s.Action == ScriptAction.Delete || s.RequiresUpdate));
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            var items = lvScripts.SelectedItems.Cast<ListViewItem>().ToList();
            if (items.Count == 0) return;

            bool markDependentItems = false;
            if (items.Any(i => i.Tag is Script s && s.Type?.IndexOf("Library") > 0))
            {
                var message =
                    @"When marking a library for deletion, all associated events will also be marked for deletion. Do you want to continue?";

                if (MessageBox.Show(this, message, @"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    markDependentItems = true;
                }
                else
                {
                    return;
                }
            }

            if (markDependentItems)
            {
                var librariesScripts = items
                    .Where(i => ((Script)i.Tag).Type?.IndexOf("Library") > 0)
                    .Select(i => (Script)i.Tag).ToList();

                var dependentItems = lvScripts.Items.Cast<ListViewItem>()
                    .Except(items)
                    .Where(i => i.Tag is Script s
                                && librariesScripts.Select(ls => ls.UiItem.Id).Contains(s.UiItem.Id)
                                && librariesScripts.Select(ls => ls.Library.ToLower()).Contains(s.Library.ToLower()))
                    .ToList();

                items.AddRange(dependentItems);
            }

            items.ForEach(i =>
            {
                var script = (Script)i.Tag;
                if (script.Action == ScriptAction.Create)
                {
                    lvScripts.Items.Remove(i);
                }

                script.Action = ScriptAction.Delete;

                i.ImageIndex = 2;
                i.Font = new Font(i.Font.FontFamily, i.Font.Size, FontStyle.Bold);
            });

            tsbApplyChanges.Enabled = lvScripts.Items.Cast<ListViewItem>().Any(i => i.Tag is Script s && (s.Action == ScriptAction.Create || s.Action == ScriptAction.Delete || s.RequiresUpdate));
            tssdDiscardChanges.Enabled = lvScripts.Items.Cast<ListViewItem>().Any(i => i.Tag is Script s && (s.Action == ScriptAction.Create || s.Action == ScriptAction.Delete || s.RequiresUpdate));
        }

        private void TsbExportToCsvClick(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                Filter = @"CSV file (*.csv)|*.csv",
                Title = @"Select a file where to save the list of scripts"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    var preamble = new UTF8Encoding(true).GetPreamble();
                    fs.Write(preamble, 0, preamble.Length);

                    var header = Encoding.UTF8.GetBytes(
                        "Type,Entity Display Name,Entity Logical Name,Form name,Form Type,Form State,Event,Control,Control Logical Name,Script Location,Method Called,Parameters,Enabled,Pass Execution context" +
                        Environment.NewLine);
                    fs.Write(header, 0, header.Length);

                    foreach (ListViewItem item in lvScripts.Items)
                    {
                        var script = (Script)item.Tag;

                        var line = Encoding.UTF8.GetBytes(
                            $"\"{script.Type}\",\"{script.EntityName}\",\"{script.EntityLogicalName}\",\"{script.ItemName}\",\"{script.FormType}\",\"{script.FormState}\",\"{script.Event}\",\"{script.Attribute}\",\"{script.AttributeLogicalName}\",\"{script.Library}\",\"{script.MethodCalled}\",\"{script.Parameters?.Replace(",", " ")}\",\"{script.Enabled}\",\"{script.PassExecutionContext}\"{Environment.NewLine}");

                        fs.Write(line, 0, line.Length);
                    }

                    if (MessageBox.Show(this,
                            $@"File saved to '{sfd.FileName}'!

Would you like to open the file now?", @"Question",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Process.Start(sfd.FileName);
                    }
                }
            }
        }

        private void tsbOrder_Click(object sender, EventArgs e)
        {
            if (lvScripts.SelectedItems.Count != 1) return;

            var script = (Script)lvScripts.SelectedItems[0].Tag;
            List<Script> scriptsToOrder;
            if (script.Type.Contains("Library"))
            {
                scriptsToOrder = _lScripts
                    .Where(i => i.Tag is Script s
                                && s.UiItem.Id == script.UiItem.Id
                                && s.Type == script.Type)
                    .Select(i => (Script)i.Tag)
                    .ToList();
            }
            else
            {
                scriptsToOrder = _lScripts
                    .Where(i => i.Tag is Script s
                                && s.UiItem.Id == script.UiItem.Id
                                && s.Event == script.Event
                                && s.AttributeLogicalName == script.AttributeLogicalName)
                    .Select(i => (Script)i.Tag)
                    .ToList();
            }

            if (scriptsToOrder.Count >= 2)
            {
                var dialog = new OrderDialog(scriptsToOrder);
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    foreach (var orderedScript in scriptsToOrder)
                    {
                        var item = lvScripts.Items.Cast<ListViewItem>().First(i => i.Tag == orderedScript);

                        SetItemState(orderedScript, item);
                    }

                    tsbApplyChanges.Enabled = lvScripts.Items.Cast<ListViewItem>().Any(i => i.Tag is Script s && (s.Action == ScriptAction.Create || s.Action == ScriptAction.Delete || s.RequiresUpdate));
                    tssdDiscardChanges.Enabled = lvScripts.Items.Cast<ListViewItem>().Any(i => i.Tag is Script s && (s.Action == ScriptAction.Create || s.Action == ScriptAction.Delete || s.RequiresUpdate));
                }
            }
        }

        private void tsbShowErrorMessage_Click(object sender, EventArgs e)
        {
            if (lvScripts.SelectedItems.Count == 0) return;
            var script = (Script)lvScripts.SelectedItems[0].Tag;

            MessageBox.Show(this, script.UpdateErrorMessage, @"Last Update Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void tsbShowFilter_Click(object sender, EventArgs e)
        {
            pnlFilter.Visible = tsbShowFilter.Text == @"Show Filters";
            gbFilter.Visible = tsbShowFilter.Text == @"Show Filters";
            tsbClearFilter.Visible = pnlFilter.Visible;
            tsbShowFilter.Text = tsbShowFilter.Text == @"Show Filters" ? @"Hide Filters" : @"Show Filters";
            gbFilter.Text = $@"Filter ({lvScripts.Items.Count})";
        }

        private void tsbShowHideChangePanel_Click(object sender, EventArgs e)
        {
            tsbShowHideChangePanel.Text = tsbShowHideChangePanel.Text == @"Show Edit panel"
                ? "Hide Edit panel"
                : "Show Edit panel";

            var visible = tsbShowHideChangePanel.Text == @"Hide Edit panel";
            gbUpdates.Visible = visible;
        }

        private void tssdDiscardChanges_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var scripts = e.ClickedItem == tsmiDiscardAllChanges
                ? lvScripts.Items.Cast<ListViewItem>().Where(i => i.Tag is Script s && (s.Action == ScriptAction.Create || s.Action == ScriptAction.Delete || s.RequiresUpdate))
                    .Select(i => (Script)i.Tag).ToList()
                : lvScripts.SelectedItems.Cast<ListViewItem>().Select(i => (Script)i.Tag).ToList();

            foreach (var script in scripts)
            {
                script.NewLibrary = null;
                script.NewMethodCalled = null;
                script.NewParameters = null;
                script.NewPassExecutionContext = null;
                script.NewEnabled = null;
                script.UpdateErrorMessage = null;
                script.Action = ScriptAction.None;

                var item = lvScripts.Items.Cast<ListViewItem>().First(i => i.Tag == script);
                item.Font = new Font(item.Font.FontFamily, item.Font.Size, FontStyle.Regular);
                item.ForeColor = DefaultForeColor;
                item.ImageIndex = -1;
            }

            cbbLibrary.Text = string.Empty;
            txtChangeMethod.Text = string.Empty;
            txtChangeParameters.Text = string.Empty;

            rdbChangePassExecutionFalse.Checked = false;
            rdbChangePassExecutionTrue.Checked = false;
            rdbChangeEnabledFalse.Checked = false;
            rdbChangeEnabledTrue.Checked = false;

            tsbApplyChanges.Enabled = lvScripts.Items.Cast<ListViewItem>().Any(i => i.Tag is Script s && (s.Action == ScriptAction.Create || s.Action == ScriptAction.Delete || s.RequiresUpdate));
            tssdDiscardChanges.Enabled = lvScripts.Items.Cast<ListViewItem>().Any(i => i.Tag is Script s && (s.Action == ScriptAction.Create || s.Action == ScriptAction.Delete || s.RequiresUpdate));
            tsbShowErrorMessage.Visible = lvScripts.SelectedItems.Count == 1 && ((Script)lvScripts.SelectedItems[0].Tag).UpdateErrorMessage != null;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _filterThread?.Abort();
            _filterThread = new Thread(Filter);
            _filterThread.Start();
        }
    }
}