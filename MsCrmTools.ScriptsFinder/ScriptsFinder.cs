using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk;
using MsCrmTools.ScriptsFinder.Forms;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace MsCrmTools.ScriptsFinder
{
    public partial class ScriptsFinder : PluginControlBase, IGitHubPlugin, IHelpPlugin
    {
        #region Constructor

        public ScriptsFinder()
        {
            InitializeComponent();
        }

        #endregion Constructor

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
                    var lScripts = new List<ListViewItem>();
                    var solutions = (List<Entity>)e.Argument;

                    var sManager = new ScriptsManager(Service, bw);
                    sManager.Find(solutions, new Version(ConnectionDetail.OrganizationVersion));

                    foreach (var script in sManager.Scripts)
                    {
                        var item = new ListViewItem(script.Type) { Tag = script };
                        item.SubItems.Add(script.EntityName);
                        item.SubItems.Add(script.EntityLogicalName);
                        item.SubItems.Add(script.FormName);
                        item.SubItems.Add(script.FormType);
                        item.SubItems.Add(script.FormState);
                        item.SubItems.Add(script.Event);
                        item.SubItems.Add(script.Attribute);
                        item.SubItems.Add(script.AttributeLogicalName);
                        item.SubItems.Add(script.ScriptLocation);
                        item.SubItems.Add(script.MethodCalled);
                        item.SubItems.Add(script.PassExecutionContext?.ToString() ?? "");
                        item.SubItems.Add(script.Arguments);
                        item.SubItems.Add(script.IsActive?.ToString() ?? "");

                        if (script.HasProblem)
                        {
                            item.ForeColor = Color.Red;
                        }
                        lScripts.Add(item);
                    }

                    e.Result = lScripts;
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
                },
                ProgressChanged = e =>
                {
                    SetWorkingMessage(e.UserState.ToString());
                }
            });
        }

        private void LvScriptsColumnClick(object sender, ColumnClickEventArgs e)
        {
            lvScripts.Sorting = lvScripts.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            lvScripts.ListViewItemSorter = new ListViewItemComparer(e.Column, lvScripts.Sorting);
        }

        private void TsbCloseThisTabClick(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void TsbExportToCsvClick(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                Filter = "CSV file (*.csv)|*.csv",
                Title = "Select a file where to save the list of scripts"
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

                        var line = Encoding.UTF8.GetBytes(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}{14}",
                            script.Type,
                            script.EntityName,
                            script.EntityLogicalName,
                            script.FormName,
                            script.FormType,
                            script.FormState,
                            script.Event,
                            script.Attribute,
                            script.AttributeLogicalName,
                            script.ScriptLocation,
                            script.MethodCalled,
                            script.Arguments?.Replace(",", " "),
                            script.IsActive,
                            script.PassExecutionContext,
                            Environment.NewLine));

                        fs.Write(line, 0, line.Length);
                    }

                    if (MessageBox.Show(this, string.Format("File saved to '{0}'!\r\n\r\nWould you like to open the file now?", sfd.FileName), "Question",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Process.Start(sfd.FileName);
                    }
                }
            }
        }

        public string RepositoryName { get { return "MsCrmTools.ScriptsFinder"; } }
        public string UserName { get { return "MscrmTools"; } }
        public string HelpUrl { get { return "https://github.com/MscrmTools/MsCrmTools.ScriptsFinder/wiki"; } }

        private void forAllEntitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteMethod(FindScripts, true);
        }

        private void forEntitiesInSelectedSolutionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteMethod(FindScripts, false);
        }
    }
}