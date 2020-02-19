using System.Windows.Forms;

namespace MsCrmTools.ScriptsFinder
{
    partial class ScriptsFinder
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptsFinder));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tssChange = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tssApply = new System.Windows.Forms.ToolStripSeparator();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.tlpFilter = new System.Windows.Forms.TableLayoutPanel();
            this.lblFilterType = new System.Windows.Forms.Label();
            this.lblFilterEntity = new System.Windows.Forms.Label();
            this.lblFilterEntityLogicalName = new System.Windows.Forms.Label();
            this.lblFilterFormName = new System.Windows.Forms.Label();
            this.lblFilterFormType = new System.Windows.Forms.Label();
            this.lblFilterFormState = new System.Windows.Forms.Label();
            this.lblFilterEvent = new System.Windows.Forms.Label();
            this.lblFilterControl = new System.Windows.Forms.Label();
            this.lblFilterControlLogicalName = new System.Windows.Forms.Label();
            this.lblFilterFile = new System.Windows.Forms.Label();
            this.lblFilterMethod = new System.Windows.Forms.Label();
            this.lblFilterPassExecutionContext = new System.Windows.Forms.Label();
            this.lblFilterParameters = new System.Windows.Forms.Label();
            this.lblFilterEnabled = new System.Windows.Forms.Label();
            this.cbbFilterType = new System.Windows.Forms.ComboBox();
            this.txtFilterEntity = new System.Windows.Forms.TextBox();
            this.txtFilterEntityLogicalName = new System.Windows.Forms.TextBox();
            this.txtFilterFormName = new System.Windows.Forms.TextBox();
            this.cbbFilterFormType = new System.Windows.Forms.ComboBox();
            this.cbbFilterFormState = new System.Windows.Forms.ComboBox();
            this.cbbFilterEvent = new System.Windows.Forms.ComboBox();
            this.txtFilterControl = new System.Windows.Forms.TextBox();
            this.txtFilterControlLogicalName = new System.Windows.Forms.TextBox();
            this.txtFilterFile = new System.Windows.Forms.TextBox();
            this.txtFilterMethod = new System.Windows.Forms.TextBox();
            this.cbbFilterPassParameters = new System.Windows.Forms.ComboBox();
            this.cbbFilterEnabled = new System.Windows.Forms.ComboBox();
            this.txtFilterParameters = new System.Windows.Forms.TextBox();
            this.lvScripts = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.actionImageList = new System.Windows.Forms.ImageList(this.components);
            this.gbUpdates = new System.Windows.Forms.GroupBox();
            this.tlpChange = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLibrary = new System.Windows.Forms.Panel();
            this.cbbLibrary = new System.Windows.Forms.ComboBox();
            this.lblHeaderProperty = new System.Windows.Forms.Label();
            this.lblHeaderCurrentValue = new System.Windows.Forms.Label();
            this.lblHeaderNewValue = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.lblMethod = new System.Windows.Forms.Label();
            this.lblPassExecutionContext = new System.Windows.Forms.Label();
            this.lblParameters = new System.Windows.Forms.Label();
            this.lblEnabled = new System.Windows.Forms.Label();
            this.lblChangeFileCurrentValue = new System.Windows.Forms.Label();
            this.lblChangeMethodCurrentValue = new System.Windows.Forms.Label();
            this.lblChangePassContextCurrentValue = new System.Windows.Forms.Label();
            this.lblChangeParametersCurrentValue = new System.Windows.Forms.Label();
            this.lblChangeEnabledCurrentValue = new System.Windows.Forms.Label();
            this.txtChangeMethod = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdbChangePassExecutionFalse = new System.Windows.Forms.RadioButton();
            this.rdbChangePassExecutionTrue = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdbChangeEnabledFalse = new System.Windows.Forms.RadioButton();
            this.rdbChangeEnabledTrue = new System.Windows.Forms.RadioButton();
            this.txtChangeParameters = new System.Windows.Forms.TextBox();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.btnReloadWebResources = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.tsddFindScripts = new System.Windows.Forms.ToolStripDropDownButton();
            this.forAllEntitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forEntitiesInSelectedSolutionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbExportToCsv = new System.Windows.Forms.ToolStripButton();
            this.tsbShowFilter = new System.Windows.Forms.ToolStripButton();
            this.tsbClearFilter = new System.Windows.Forms.ToolStripButton();
            this.tsbShowHideChangePanel = new System.Windows.Forms.ToolStripButton();
            this.tsbCreate = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbOrder = new System.Windows.Forms.ToolStripButton();
            this.tssdDiscardChanges = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiDiscardChanges = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDiscardAllChanges = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbApplyChanges = new System.Windows.Forms.ToolStripButton();
            this.tsbShowErrorMessage = new System.Windows.Forms.ToolStripButton();
            this.lblChangeOrderCurrentValue = new System.Windows.Forms.Label();
            this.lblChangeOrderNewValue = new System.Windows.Forms.Label();
            this.lblChangeOrder = new System.Windows.Forms.Label();
            this.tsMain.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.tlpFilter.SuspendLayout();
            this.gbUpdates.SuspendLayout();
            this.tlpChange.SuspendLayout();
            this.pnlLibrary.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbFilter.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.Dock = System.Windows.Forms.DockStyle.None;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddFindScripts,
            this.toolStripSeparator1,
            this.tsbExportToCsv,
            this.toolStripSeparator3,
            this.tsbShowFilter,
            this.tsbClearFilter,
            this.tssChange,
            this.tsbShowHideChangePanel,
            this.toolStripSeparator4,
            this.tsbCreate,
            this.tsbDelete,
            this.tsbOrder,
            this.tssApply,
            this.tssdDiscardChanges,
            this.tsbApplyChanges,
            this.tsbShowErrorMessage});
            this.tsMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsMain.Location = new System.Drawing.Point(3, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1483, 39);
            this.tsMain.TabIndex = 0;
            this.tsMain.Text = "tsMain";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // tssChange
            // 
            this.tssChange.Name = "tssChange";
            this.tssChange.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // tssApply
            // 
            this.tssApply.Name = "tssApply";
            this.tssApply.Size = new System.Drawing.Size(6, 39);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Icon.png");
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.tlpFilter);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFilter.Location = new System.Drawing.Point(3, 27);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1816, 283);
            this.pnlFilter.TabIndex = 2;
            this.pnlFilter.Visible = false;
            // 
            // tlpFilter
            // 
            this.tlpFilter.ColumnCount = 4;
            this.tlpFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpFilter.Controls.Add(this.lblFilterType, 0, 0);
            this.tlpFilter.Controls.Add(this.lblFilterEntity, 0, 1);
            this.tlpFilter.Controls.Add(this.lblFilterEntityLogicalName, 0, 2);
            this.tlpFilter.Controls.Add(this.lblFilterFormName, 0, 3);
            this.tlpFilter.Controls.Add(this.lblFilterFormType, 0, 4);
            this.tlpFilter.Controls.Add(this.lblFilterFormState, 0, 5);
            this.tlpFilter.Controls.Add(this.lblFilterEvent, 0, 6);
            this.tlpFilter.Controls.Add(this.lblFilterControl, 2, 0);
            this.tlpFilter.Controls.Add(this.lblFilterControlLogicalName, 2, 1);
            this.tlpFilter.Controls.Add(this.lblFilterFile, 2, 2);
            this.tlpFilter.Controls.Add(this.lblFilterMethod, 2, 3);
            this.tlpFilter.Controls.Add(this.lblFilterPassExecutionContext, 2, 4);
            this.tlpFilter.Controls.Add(this.lblFilterParameters, 2, 5);
            this.tlpFilter.Controls.Add(this.lblFilterEnabled, 2, 6);
            this.tlpFilter.Controls.Add(this.cbbFilterType, 1, 0);
            this.tlpFilter.Controls.Add(this.txtFilterEntity, 1, 1);
            this.tlpFilter.Controls.Add(this.txtFilterEntityLogicalName, 1, 2);
            this.tlpFilter.Controls.Add(this.txtFilterFormName, 1, 3);
            this.tlpFilter.Controls.Add(this.cbbFilterFormType, 1, 4);
            this.tlpFilter.Controls.Add(this.cbbFilterFormState, 1, 5);
            this.tlpFilter.Controls.Add(this.cbbFilterEvent, 1, 6);
            this.tlpFilter.Controls.Add(this.txtFilterControl, 3, 0);
            this.tlpFilter.Controls.Add(this.txtFilterControlLogicalName, 3, 1);
            this.tlpFilter.Controls.Add(this.txtFilterFile, 3, 2);
            this.tlpFilter.Controls.Add(this.txtFilterMethod, 3, 3);
            this.tlpFilter.Controls.Add(this.cbbFilterPassParameters, 3, 4);
            this.tlpFilter.Controls.Add(this.cbbFilterEnabled, 3, 6);
            this.tlpFilter.Controls.Add(this.txtFilterParameters, 3, 5);
            this.tlpFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFilter.Location = new System.Drawing.Point(0, 0);
            this.tlpFilter.Name = "tlpFilter";
            this.tlpFilter.RowCount = 7;
            this.tlpFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFilter.Size = new System.Drawing.Size(1816, 283);
            this.tlpFilter.TabIndex = 0;
            // 
            // lblFilterType
            // 
            this.lblFilterType.AutoSize = true;
            this.lblFilterType.Location = new System.Drawing.Point(3, 0);
            this.lblFilterType.Name = "lblFilterType";
            this.lblFilterType.Size = new System.Drawing.Size(60, 25);
            this.lblFilterType.TabIndex = 0;
            this.lblFilterType.Text = "Type";
            // 
            // lblFilterEntity
            // 
            this.lblFilterEntity.AutoSize = true;
            this.lblFilterEntity.Location = new System.Drawing.Point(3, 40);
            this.lblFilterEntity.Name = "lblFilterEntity";
            this.lblFilterEntity.Size = new System.Drawing.Size(66, 25);
            this.lblFilterEntity.TabIndex = 1;
            this.lblFilterEntity.Text = "Entity";
            // 
            // lblFilterEntityLogicalName
            // 
            this.lblFilterEntityLogicalName.AutoSize = true;
            this.lblFilterEntityLogicalName.Location = new System.Drawing.Point(3, 80);
            this.lblFilterEntityLogicalName.Name = "lblFilterEntityLogicalName";
            this.lblFilterEntityLogicalName.Size = new System.Drawing.Size(203, 25);
            this.lblFilterEntityLogicalName.TabIndex = 2;
            this.lblFilterEntityLogicalName.Text = "Entity Logical Name";
            // 
            // lblFilterFormName
            // 
            this.lblFilterFormName.AutoSize = true;
            this.lblFilterFormName.Location = new System.Drawing.Point(3, 120);
            this.lblFilterFormName.Name = "lblFilterFormName";
            this.lblFilterFormName.Size = new System.Drawing.Size(123, 25);
            this.lblFilterFormName.TabIndex = 3;
            this.lblFilterFormName.Text = "Item Name";
            // 
            // lblFilterFormType
            // 
            this.lblFilterFormType.AutoSize = true;
            this.lblFilterFormType.Location = new System.Drawing.Point(3, 160);
            this.lblFilterFormType.Name = "lblFilterFormType";
            this.lblFilterFormType.Size = new System.Drawing.Size(115, 25);
            this.lblFilterFormType.TabIndex = 4;
            this.lblFilterFormType.Text = "Form Type";
            // 
            // lblFilterFormState
            // 
            this.lblFilterFormState.AutoSize = true;
            this.lblFilterFormState.Location = new System.Drawing.Point(3, 200);
            this.lblFilterFormState.Name = "lblFilterFormState";
            this.lblFilterFormState.Size = new System.Drawing.Size(117, 25);
            this.lblFilterFormState.TabIndex = 5;
            this.lblFilterFormState.Text = "Form State";
            // 
            // lblFilterEvent
            // 
            this.lblFilterEvent.AutoSize = true;
            this.lblFilterEvent.Location = new System.Drawing.Point(3, 240);
            this.lblFilterEvent.Name = "lblFilterEvent";
            this.lblFilterEvent.Size = new System.Drawing.Size(67, 25);
            this.lblFilterEvent.TabIndex = 6;
            this.lblFilterEvent.Text = "Event";
            // 
            // lblFilterControl
            // 
            this.lblFilterControl.AutoSize = true;
            this.lblFilterControl.Location = new System.Drawing.Point(911, 0);
            this.lblFilterControl.Name = "lblFilterControl";
            this.lblFilterControl.Size = new System.Drawing.Size(81, 25);
            this.lblFilterControl.TabIndex = 7;
            this.lblFilterControl.Text = "Control";
            // 
            // lblFilterControlLogicalName
            // 
            this.lblFilterControlLogicalName.AutoSize = true;
            this.lblFilterControlLogicalName.Location = new System.Drawing.Point(911, 40);
            this.lblFilterControlLogicalName.Name = "lblFilterControlLogicalName";
            this.lblFilterControlLogicalName.Size = new System.Drawing.Size(218, 25);
            this.lblFilterControlLogicalName.TabIndex = 8;
            this.lblFilterControlLogicalName.Text = "Control Logical Name";
            // 
            // lblFilterFile
            // 
            this.lblFilterFile.AutoSize = true;
            this.lblFilterFile.Location = new System.Drawing.Point(911, 80);
            this.lblFilterFile.Name = "lblFilterFile";
            this.lblFilterFile.Size = new System.Drawing.Size(47, 25);
            this.lblFilterFile.TabIndex = 9;
            this.lblFilterFile.Text = "File";
            // 
            // lblFilterMethod
            // 
            this.lblFilterMethod.AutoSize = true;
            this.lblFilterMethod.Location = new System.Drawing.Point(911, 120);
            this.lblFilterMethod.Name = "lblFilterMethod";
            this.lblFilterMethod.Size = new System.Drawing.Size(84, 25);
            this.lblFilterMethod.TabIndex = 10;
            this.lblFilterMethod.Text = "Method";
            // 
            // lblFilterPassExecutionContext
            // 
            this.lblFilterPassExecutionContext.AutoSize = true;
            this.lblFilterPassExecutionContext.Location = new System.Drawing.Point(911, 160);
            this.lblFilterPassExecutionContext.Name = "lblFilterPassExecutionContext";
            this.lblFilterPassExecutionContext.Size = new System.Drawing.Size(241, 25);
            this.lblFilterPassExecutionContext.TabIndex = 11;
            this.lblFilterPassExecutionContext.Text = "Pass Execution Context";
            // 
            // lblFilterParameters
            // 
            this.lblFilterParameters.AutoSize = true;
            this.lblFilterParameters.Location = new System.Drawing.Point(911, 200);
            this.lblFilterParameters.Name = "lblFilterParameters";
            this.lblFilterParameters.Size = new System.Drawing.Size(122, 25);
            this.lblFilterParameters.TabIndex = 12;
            this.lblFilterParameters.Text = "Parameters";
            // 
            // lblFilterEnabled
            // 
            this.lblFilterEnabled.AutoSize = true;
            this.lblFilterEnabled.Location = new System.Drawing.Point(911, 240);
            this.lblFilterEnabled.Name = "lblFilterEnabled";
            this.lblFilterEnabled.Size = new System.Drawing.Size(91, 25);
            this.lblFilterEnabled.TabIndex = 13;
            this.lblFilterEnabled.Text = "Enabled";
            // 
            // cbbFilterType
            // 
            this.cbbFilterType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFilterType.FormattingEnabled = true;
            this.cbbFilterType.Items.AddRange(new object[] {
            "Form Event",
            "Form Library",
            "Ribbon Command",
            "Ribbon Custom Rule",
            "Subgrid Event",
            "(Not specified)"});
            this.cbbFilterType.Location = new System.Drawing.Point(457, 3);
            this.cbbFilterType.Name = "cbbFilterType";
            this.cbbFilterType.Size = new System.Drawing.Size(448, 33);
            this.cbbFilterType.TabIndex = 14;
            this.cbbFilterType.SelectedIndexChanged += new System.EventHandler(this.cbbFilter_SelectedIndexChanged);
            // 
            // txtFilterEntity
            // 
            this.txtFilterEntity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilterEntity.Location = new System.Drawing.Point(457, 43);
            this.txtFilterEntity.Name = "txtFilterEntity";
            this.txtFilterEntity.Size = new System.Drawing.Size(448, 31);
            this.txtFilterEntity.TabIndex = 15;
            this.txtFilterEntity.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // txtFilterEntityLogicalName
            // 
            this.txtFilterEntityLogicalName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilterEntityLogicalName.Location = new System.Drawing.Point(457, 83);
            this.txtFilterEntityLogicalName.Name = "txtFilterEntityLogicalName";
            this.txtFilterEntityLogicalName.Size = new System.Drawing.Size(448, 31);
            this.txtFilterEntityLogicalName.TabIndex = 16;
            this.txtFilterEntityLogicalName.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // txtFilterFormName
            // 
            this.txtFilterFormName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilterFormName.Location = new System.Drawing.Point(457, 123);
            this.txtFilterFormName.Name = "txtFilterFormName";
            this.txtFilterFormName.Size = new System.Drawing.Size(448, 31);
            this.txtFilterFormName.TabIndex = 17;
            this.txtFilterFormName.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // cbbFilterFormType
            // 
            this.cbbFilterFormType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbFilterFormType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFilterFormType.FormattingEnabled = true;
            this.cbbFilterFormType.Items.AddRange(new object[] {
            "Main",
            "Quick Create",
            "(Not specified)"});
            this.cbbFilterFormType.Location = new System.Drawing.Point(457, 163);
            this.cbbFilterFormType.Name = "cbbFilterFormType";
            this.cbbFilterFormType.Size = new System.Drawing.Size(448, 33);
            this.cbbFilterFormType.TabIndex = 18;
            this.cbbFilterFormType.SelectedIndexChanged += new System.EventHandler(this.cbbFilter_SelectedIndexChanged);
            // 
            // cbbFilterFormState
            // 
            this.cbbFilterFormState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbFilterFormState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFilterFormState.FormattingEnabled = true;
            this.cbbFilterFormState.Items.AddRange(new object[] {
            "Active",
            "Inactive",
            "(Not specified)"});
            this.cbbFilterFormState.Location = new System.Drawing.Point(457, 203);
            this.cbbFilterFormState.Name = "cbbFilterFormState";
            this.cbbFilterFormState.Size = new System.Drawing.Size(448, 33);
            this.cbbFilterFormState.TabIndex = 19;
            this.cbbFilterFormState.SelectedIndexChanged += new System.EventHandler(this.cbbFilter_SelectedIndexChanged);
            // 
            // cbbFilterEvent
            // 
            this.cbbFilterEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbFilterEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFilterEvent.FormattingEnabled = true;
            this.cbbFilterEvent.Items.AddRange(new object[] {
            "OnLoad",
            "OnSave",
            "OnChange",
            "OnTabStateChange",
            "OnRecordSelected",
            "(Not specified)"});
            this.cbbFilterEvent.Location = new System.Drawing.Point(457, 243);
            this.cbbFilterEvent.Name = "cbbFilterEvent";
            this.cbbFilterEvent.Size = new System.Drawing.Size(448, 33);
            this.cbbFilterEvent.TabIndex = 20;
            this.cbbFilterEvent.SelectedIndexChanged += new System.EventHandler(this.cbbFilter_SelectedIndexChanged);
            // 
            // txtFilterControl
            // 
            this.txtFilterControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilterControl.Location = new System.Drawing.Point(1365, 3);
            this.txtFilterControl.Name = "txtFilterControl";
            this.txtFilterControl.Size = new System.Drawing.Size(448, 31);
            this.txtFilterControl.TabIndex = 21;
            this.txtFilterControl.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // txtFilterControlLogicalName
            // 
            this.txtFilterControlLogicalName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilterControlLogicalName.Location = new System.Drawing.Point(1365, 43);
            this.txtFilterControlLogicalName.Name = "txtFilterControlLogicalName";
            this.txtFilterControlLogicalName.Size = new System.Drawing.Size(448, 31);
            this.txtFilterControlLogicalName.TabIndex = 22;
            this.txtFilterControlLogicalName.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // txtFilterFile
            // 
            this.txtFilterFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilterFile.Location = new System.Drawing.Point(1365, 83);
            this.txtFilterFile.Name = "txtFilterFile";
            this.txtFilterFile.Size = new System.Drawing.Size(448, 31);
            this.txtFilterFile.TabIndex = 23;
            this.txtFilterFile.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // txtFilterMethod
            // 
            this.txtFilterMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilterMethod.Location = new System.Drawing.Point(1365, 123);
            this.txtFilterMethod.Name = "txtFilterMethod";
            this.txtFilterMethod.Size = new System.Drawing.Size(448, 31);
            this.txtFilterMethod.TabIndex = 24;
            this.txtFilterMethod.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // cbbFilterPassParameters
            // 
            this.cbbFilterPassParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbFilterPassParameters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFilterPassParameters.FormattingEnabled = true;
            this.cbbFilterPassParameters.Items.AddRange(new object[] {
            "False",
            "True",
            "(Not specified)"});
            this.cbbFilterPassParameters.Location = new System.Drawing.Point(1365, 163);
            this.cbbFilterPassParameters.Name = "cbbFilterPassParameters";
            this.cbbFilterPassParameters.Size = new System.Drawing.Size(448, 33);
            this.cbbFilterPassParameters.TabIndex = 25;
            this.cbbFilterPassParameters.SelectedIndexChanged += new System.EventHandler(this.cbbFilter_SelectedIndexChanged);
            // 
            // cbbFilterEnabled
            // 
            this.cbbFilterEnabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbFilterEnabled.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFilterEnabled.FormattingEnabled = true;
            this.cbbFilterEnabled.Items.AddRange(new object[] {
            "False",
            "True",
            "(Not specified)"});
            this.cbbFilterEnabled.Location = new System.Drawing.Point(1365, 243);
            this.cbbFilterEnabled.Name = "cbbFilterEnabled";
            this.cbbFilterEnabled.Size = new System.Drawing.Size(448, 33);
            this.cbbFilterEnabled.TabIndex = 26;
            this.cbbFilterEnabled.SelectedIndexChanged += new System.EventHandler(this.cbbFilter_SelectedIndexChanged);
            // 
            // txtFilterParameters
            // 
            this.txtFilterParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilterParameters.Location = new System.Drawing.Point(1365, 203);
            this.txtFilterParameters.Name = "txtFilterParameters";
            this.txtFilterParameters.Size = new System.Drawing.Size(448, 31);
            this.txtFilterParameters.TabIndex = 27;
            this.txtFilterParameters.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // lvScripts
            // 
            this.lvScripts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader1,
            this.columnHeader7,
            this.columnHeader2,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader8,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader12,
            this.columnHeader11,
            this.columnHeader10});
            this.lvScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvScripts.FullRowSelect = true;
            this.lvScripts.HideSelection = false;
            this.lvScripts.Location = new System.Drawing.Point(0, 313);
            this.lvScripts.Margin = new System.Windows.Forms.Padding(6);
            this.lvScripts.Name = "lvScripts";
            this.lvScripts.Size = new System.Drawing.Size(1822, 446);
            this.lvScripts.SmallImageList = this.actionImageList;
            this.lvScripts.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvScripts.TabIndex = 3;
            this.lvScripts.UseCompatibleStateImageBehavior = false;
            this.lvScripts.View = System.Windows.Forms.View.Details;
            this.lvScripts.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LvScriptsColumnClick);
            this.lvScripts.SelectedIndexChanged += new System.EventHandler(this.lvScripts_SelectedIndexChanged);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Type";
            this.columnHeader9.Width = 100;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Entity";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Entity Logical name";
            this.columnHeader7.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Item name";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Form Type";
            this.columnHeader13.Width = 100;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Form State";
            this.columnHeader14.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Event";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Control";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Control Logical name";
            this.columnHeader8.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "File";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Method";
            this.columnHeader6.Width = 150;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Pass execution context";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Parameters";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Enabled";
            this.columnHeader10.Width = 100;
            // 
            // actionImageList
            // 
            this.actionImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("actionImageList.ImageStream")));
            this.actionImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.actionImageList.Images.SetKeyName(0, "pencil.png");
            this.actionImageList.Images.SetKeyName(1, "plus.png");
            this.actionImageList.Images.SetKeyName(2, "minus-icon.png");
            // 
            // gbUpdates
            // 
            this.gbUpdates.Controls.Add(this.tlpChange);
            this.gbUpdates.Controls.Add(this.btnSaveChanges);
            this.gbUpdates.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbUpdates.Location = new System.Drawing.Point(0, 759);
            this.gbUpdates.Name = "gbUpdates";
            this.gbUpdates.Size = new System.Drawing.Size(1822, 354);
            this.gbUpdates.TabIndex = 4;
            this.gbUpdates.TabStop = false;
            this.gbUpdates.Text = "Update Properties";
            this.gbUpdates.Visible = false;
            // 
            // tlpChange
            // 
            this.tlpChange.ColumnCount = 3;
            this.tlpChange.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tlpChange.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpChange.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpChange.Controls.Add(this.lblChangeOrder, 0, 6);
            this.tlpChange.Controls.Add(this.lblChangeOrderNewValue, 0, 6);
            this.tlpChange.Controls.Add(this.lblChangeOrderCurrentValue, 0, 6);
            this.tlpChange.Controls.Add(this.pnlLibrary, 2, 1);
            this.tlpChange.Controls.Add(this.lblHeaderProperty, 0, 0);
            this.tlpChange.Controls.Add(this.lblHeaderCurrentValue, 1, 0);
            this.tlpChange.Controls.Add(this.lblHeaderNewValue, 2, 0);
            this.tlpChange.Controls.Add(this.lblFile, 0, 1);
            this.tlpChange.Controls.Add(this.lblMethod, 0, 2);
            this.tlpChange.Controls.Add(this.lblPassExecutionContext, 0, 3);
            this.tlpChange.Controls.Add(this.lblParameters, 0, 4);
            this.tlpChange.Controls.Add(this.lblEnabled, 0, 5);
            this.tlpChange.Controls.Add(this.lblChangeFileCurrentValue, 1, 1);
            this.tlpChange.Controls.Add(this.lblChangeMethodCurrentValue, 1, 2);
            this.tlpChange.Controls.Add(this.lblChangePassContextCurrentValue, 1, 3);
            this.tlpChange.Controls.Add(this.lblChangeParametersCurrentValue, 1, 4);
            this.tlpChange.Controls.Add(this.lblChangeEnabledCurrentValue, 1, 5);
            this.tlpChange.Controls.Add(this.txtChangeMethod, 2, 2);
            this.tlpChange.Controls.Add(this.panel1, 2, 3);
            this.tlpChange.Controls.Add(this.panel2, 2, 5);
            this.tlpChange.Controls.Add(this.txtChangeParameters, 2, 4);
            this.tlpChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpChange.Location = new System.Drawing.Point(3, 27);
            this.tlpChange.Name = "tlpChange";
            this.tlpChange.RowCount = 7;
            this.tlpChange.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpChange.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpChange.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpChange.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpChange.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpChange.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpChange.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpChange.Size = new System.Drawing.Size(1716, 324);
            this.tlpChange.TabIndex = 0;
            // 
            // pnlLibrary
            // 
            this.pnlLibrary.Controls.Add(this.cbbLibrary);
            this.pnlLibrary.Controls.Add(this.btnReloadWebResources);
            this.pnlLibrary.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLibrary.Location = new System.Drawing.Point(1011, 49);
            this.pnlLibrary.Name = "pnlLibrary";
            this.pnlLibrary.Size = new System.Drawing.Size(702, 37);
            this.pnlLibrary.TabIndex = 21;
            // 
            // cbbLibrary
            // 
            this.cbbLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbLibrary.FormattingEnabled = true;
            this.cbbLibrary.Location = new System.Drawing.Point(0, 0);
            this.cbbLibrary.Name = "cbbLibrary";
            this.cbbLibrary.Size = new System.Drawing.Size(663, 33);
            this.cbbLibrary.TabIndex = 1;
            // 
            // lblHeaderProperty
            // 
            this.lblHeaderProperty.AutoSize = true;
            this.lblHeaderProperty.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderProperty.Location = new System.Drawing.Point(3, 0);
            this.lblHeaderProperty.Name = "lblHeaderProperty";
            this.lblHeaderProperty.Size = new System.Drawing.Size(101, 25);
            this.lblHeaderProperty.TabIndex = 0;
            this.lblHeaderProperty.Text = "Property";
            // 
            // lblHeaderCurrentValue
            // 
            this.lblHeaderCurrentValue.AutoSize = true;
            this.lblHeaderCurrentValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderCurrentValue.Location = new System.Drawing.Point(303, 0);
            this.lblHeaderCurrentValue.Name = "lblHeaderCurrentValue";
            this.lblHeaderCurrentValue.Size = new System.Drawing.Size(154, 25);
            this.lblHeaderCurrentValue.TabIndex = 1;
            this.lblHeaderCurrentValue.Text = "Current value";
            // 
            // lblHeaderNewValue
            // 
            this.lblHeaderNewValue.AutoSize = true;
            this.lblHeaderNewValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderNewValue.Location = new System.Drawing.Point(1011, 0);
            this.lblHeaderNewValue.Name = "lblHeaderNewValue";
            this.lblHeaderNewValue.Size = new System.Drawing.Size(121, 25);
            this.lblHeaderNewValue.TabIndex = 2;
            this.lblHeaderNewValue.Text = "New value";
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFile.Location = new System.Drawing.Point(3, 46);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(51, 25);
            this.lblFile.TabIndex = 3;
            this.lblFile.Text = "File";
            // 
            // lblMethod
            // 
            this.lblMethod.AutoSize = true;
            this.lblMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMethod.Location = new System.Drawing.Point(3, 92);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(90, 25);
            this.lblMethod.TabIndex = 4;
            this.lblMethod.Text = "Method";
            // 
            // lblPassExecutionContext
            // 
            this.lblPassExecutionContext.AutoSize = true;
            this.lblPassExecutionContext.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassExecutionContext.Location = new System.Drawing.Point(3, 138);
            this.lblPassExecutionContext.Name = "lblPassExecutionContext";
            this.lblPassExecutionContext.Size = new System.Drawing.Size(263, 25);
            this.lblPassExecutionContext.TabIndex = 5;
            this.lblPassExecutionContext.Text = "Pass Execution Context";
            // 
            // lblParameters
            // 
            this.lblParameters.AutoSize = true;
            this.lblParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParameters.Location = new System.Drawing.Point(3, 184);
            this.lblParameters.Name = "lblParameters";
            this.lblParameters.Size = new System.Drawing.Size(132, 25);
            this.lblParameters.TabIndex = 6;
            this.lblParameters.Text = "Parameters";
            // 
            // lblEnabled
            // 
            this.lblEnabled.AutoSize = true;
            this.lblEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnabled.Location = new System.Drawing.Point(3, 230);
            this.lblEnabled.Name = "lblEnabled";
            this.lblEnabled.Size = new System.Drawing.Size(98, 25);
            this.lblEnabled.TabIndex = 7;
            this.lblEnabled.Text = "Enabled";
            // 
            // lblChangeFileCurrentValue
            // 
            this.lblChangeFileCurrentValue.AutoSize = true;
            this.lblChangeFileCurrentValue.Location = new System.Drawing.Point(303, 46);
            this.lblChangeFileCurrentValue.Name = "lblChangeFileCurrentValue";
            this.lblChangeFileCurrentValue.Size = new System.Drawing.Size(0, 25);
            this.lblChangeFileCurrentValue.TabIndex = 8;
            // 
            // lblChangeMethodCurrentValue
            // 
            this.lblChangeMethodCurrentValue.AutoSize = true;
            this.lblChangeMethodCurrentValue.Location = new System.Drawing.Point(303, 92);
            this.lblChangeMethodCurrentValue.Name = "lblChangeMethodCurrentValue";
            this.lblChangeMethodCurrentValue.Size = new System.Drawing.Size(0, 25);
            this.lblChangeMethodCurrentValue.TabIndex = 9;
            // 
            // lblChangePassContextCurrentValue
            // 
            this.lblChangePassContextCurrentValue.AutoSize = true;
            this.lblChangePassContextCurrentValue.Location = new System.Drawing.Point(303, 138);
            this.lblChangePassContextCurrentValue.Name = "lblChangePassContextCurrentValue";
            this.lblChangePassContextCurrentValue.Size = new System.Drawing.Size(0, 25);
            this.lblChangePassContextCurrentValue.TabIndex = 10;
            // 
            // lblChangeParametersCurrentValue
            // 
            this.lblChangeParametersCurrentValue.AutoSize = true;
            this.lblChangeParametersCurrentValue.Location = new System.Drawing.Point(303, 184);
            this.lblChangeParametersCurrentValue.Name = "lblChangeParametersCurrentValue";
            this.lblChangeParametersCurrentValue.Size = new System.Drawing.Size(0, 25);
            this.lblChangeParametersCurrentValue.TabIndex = 11;
            // 
            // lblChangeEnabledCurrentValue
            // 
            this.lblChangeEnabledCurrentValue.AutoSize = true;
            this.lblChangeEnabledCurrentValue.Location = new System.Drawing.Point(303, 230);
            this.lblChangeEnabledCurrentValue.Name = "lblChangeEnabledCurrentValue";
            this.lblChangeEnabledCurrentValue.Size = new System.Drawing.Size(0, 25);
            this.lblChangeEnabledCurrentValue.TabIndex = 12;
            // 
            // txtChangeMethod
            // 
            this.txtChangeMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChangeMethod.Enabled = false;
            this.txtChangeMethod.Location = new System.Drawing.Point(1011, 95);
            this.txtChangeMethod.Name = "txtChangeMethod";
            this.txtChangeMethod.Size = new System.Drawing.Size(702, 31);
            this.txtChangeMethod.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbChangePassExecutionFalse);
            this.panel1.Controls.Add(this.rdbChangePassExecutionTrue);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1011, 141);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 40);
            this.panel1.TabIndex = 15;
            // 
            // rdbChangePassExecutionFalse
            // 
            this.rdbChangePassExecutionFalse.AutoSize = true;
            this.rdbChangePassExecutionFalse.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdbChangePassExecutionFalse.Enabled = false;
            this.rdbChangePassExecutionFalse.Location = new System.Drawing.Point(87, 0);
            this.rdbChangePassExecutionFalse.Name = "rdbChangePassExecutionFalse";
            this.rdbChangePassExecutionFalse.Size = new System.Drawing.Size(96, 40);
            this.rdbChangePassExecutionFalse.TabIndex = 1;
            this.rdbChangePassExecutionFalse.TabStop = true;
            this.rdbChangePassExecutionFalse.Text = "False";
            this.rdbChangePassExecutionFalse.UseVisualStyleBackColor = true;
            // 
            // rdbChangePassExecutionTrue
            // 
            this.rdbChangePassExecutionTrue.AutoSize = true;
            this.rdbChangePassExecutionTrue.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdbChangePassExecutionTrue.Enabled = false;
            this.rdbChangePassExecutionTrue.Location = new System.Drawing.Point(0, 0);
            this.rdbChangePassExecutionTrue.Name = "rdbChangePassExecutionTrue";
            this.rdbChangePassExecutionTrue.Size = new System.Drawing.Size(87, 40);
            this.rdbChangePassExecutionTrue.TabIndex = 0;
            this.rdbChangePassExecutionTrue.TabStop = true;
            this.rdbChangePassExecutionTrue.Text = "True";
            this.rdbChangePassExecutionTrue.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdbChangeEnabledFalse);
            this.panel2.Controls.Add(this.rdbChangeEnabledTrue);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1011, 233);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(702, 40);
            this.panel2.TabIndex = 16;
            // 
            // rdbChangeEnabledFalse
            // 
            this.rdbChangeEnabledFalse.AutoSize = true;
            this.rdbChangeEnabledFalse.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdbChangeEnabledFalse.Enabled = false;
            this.rdbChangeEnabledFalse.Location = new System.Drawing.Point(87, 0);
            this.rdbChangeEnabledFalse.Name = "rdbChangeEnabledFalse";
            this.rdbChangeEnabledFalse.Size = new System.Drawing.Size(96, 40);
            this.rdbChangeEnabledFalse.TabIndex = 1;
            this.rdbChangeEnabledFalse.TabStop = true;
            this.rdbChangeEnabledFalse.Text = "False";
            this.rdbChangeEnabledFalse.UseVisualStyleBackColor = true;
            // 
            // rdbChangeEnabledTrue
            // 
            this.rdbChangeEnabledTrue.AutoSize = true;
            this.rdbChangeEnabledTrue.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdbChangeEnabledTrue.Enabled = false;
            this.rdbChangeEnabledTrue.Location = new System.Drawing.Point(0, 0);
            this.rdbChangeEnabledTrue.Name = "rdbChangeEnabledTrue";
            this.rdbChangeEnabledTrue.Size = new System.Drawing.Size(87, 40);
            this.rdbChangeEnabledTrue.TabIndex = 0;
            this.rdbChangeEnabledTrue.TabStop = true;
            this.rdbChangeEnabledTrue.Text = "True";
            this.rdbChangeEnabledTrue.UseVisualStyleBackColor = true;
            // 
            // txtChangeParameters
            // 
            this.txtChangeParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChangeParameters.Enabled = false;
            this.txtChangeParameters.Location = new System.Drawing.Point(1011, 187);
            this.txtChangeParameters.Name = "txtChangeParameters";
            this.txtChangeParameters.Size = new System.Drawing.Size(702, 31);
            this.txtChangeParameters.TabIndex = 17;
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.pnlFilter);
            this.gbFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbFilter.Location = new System.Drawing.Point(0, 0);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(1822, 313);
            this.gbFilter.TabIndex = 6;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            this.gbFilter.Visible = false;
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.lvScripts);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.gbUpdates);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.gbFilter);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1822, 1113);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(1822, 1152);
            this.toolStripContainer1.TabIndex = 7;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tsMain);
            // 
            // btnReloadWebResources
            // 
            this.btnReloadWebResources.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnReloadWebResources.Image = global::MsCrmTools.ScriptsFinder.Properties.Resources.arrow_refresh;
            this.btnReloadWebResources.Location = new System.Drawing.Point(663, 0);
            this.btnReloadWebResources.Name = "btnReloadWebResources";
            this.btnReloadWebResources.Size = new System.Drawing.Size(39, 37);
            this.btnReloadWebResources.TabIndex = 0;
            this.btnReloadWebResources.UseVisualStyleBackColor = true;
            this.btnReloadWebResources.Click += new System.EventHandler(this.btnReloadWebResources_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSaveChanges.Image = global::MsCrmTools.ScriptsFinder.Properties.Resources.Save32;
            this.btnSaveChanges.Location = new System.Drawing.Point(1719, 27);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(100, 324);
            this.btnSaveChanges.TabIndex = 1;
            this.btnSaveChanges.Text = "Save";
            this.btnSaveChanges.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveChanges.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.tsbChangeSave_Click);
            // 
            // tsddFindScripts
            // 
            this.tsddFindScripts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forAllEntitiesToolStripMenuItem,
            this.forEntitiesInSelectedSolutionsToolStripMenuItem});
            this.tsddFindScripts.Image = ((System.Drawing.Image)(resources.GetObject("tsddFindScripts.Image")));
            this.tsddFindScripts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddFindScripts.Name = "tsddFindScripts";
            this.tsddFindScripts.Size = new System.Drawing.Size(246, 36);
            this.tsddFindScripts.Text = "Find Scripts usage";
            // 
            // forAllEntitiesToolStripMenuItem
            // 
            this.forAllEntitiesToolStripMenuItem.Name = "forAllEntitiesToolStripMenuItem";
            this.forAllEntitiesToolStripMenuItem.Size = new System.Drawing.Size(472, 38);
            this.forAllEntitiesToolStripMenuItem.Text = "For all entities";
            this.forAllEntitiesToolStripMenuItem.Click += new System.EventHandler(this.forAllEntitiesToolStripMenuItem_Click);
            // 
            // forEntitiesInSelectedSolutionsToolStripMenuItem
            // 
            this.forEntitiesInSelectedSolutionsToolStripMenuItem.Name = "forEntitiesInSelectedSolutionsToolStripMenuItem";
            this.forEntitiesInSelectedSolutionsToolStripMenuItem.Size = new System.Drawing.Size(472, 38);
            this.forEntitiesInSelectedSolutionsToolStripMenuItem.Text = "For entities in selected solution(s)";
            this.forEntitiesInSelectedSolutionsToolStripMenuItem.Click += new System.EventHandler(this.forEntitiesInSelectedSolutionsToolStripMenuItem_Click);
            // 
            // tsbExportToCsv
            // 
            this.tsbExportToCsv.Image = ((System.Drawing.Image)(resources.GetObject("tsbExportToCsv.Image")));
            this.tsbExportToCsv.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportToCsv.Name = "tsbExportToCsv";
            this.tsbExportToCsv.Size = new System.Drawing.Size(171, 36);
            this.tsbExportToCsv.Text = "Export to csv";
            this.tsbExportToCsv.Click += new System.EventHandler(this.TsbExportToCsvClick);
            // 
            // tsbShowFilter
            // 
            this.tsbShowFilter.Image = global::MsCrmTools.ScriptsFinder.Properties.Resources.filter;
            this.tsbShowFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowFilter.Name = "tsbShowFilter";
            this.tsbShowFilter.Size = new System.Drawing.Size(163, 36);
            this.tsbShowFilter.Text = "Show Filters";
            this.tsbShowFilter.Click += new System.EventHandler(this.tsbShowFilter_Click);
            // 
            // tsbClearFilter
            // 
            this.tsbClearFilter.Image = global::MsCrmTools.ScriptsFinder.Properties.Resources.filter_clear;
            this.tsbClearFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClearFilter.Name = "tsbClearFilter";
            this.tsbClearFilter.Size = new System.Drawing.Size(165, 36);
            this.tsbClearFilter.Text = "Clear Filter";
            this.tsbClearFilter.Visible = false;
            this.tsbClearFilter.Click += new System.EventHandler(this.tsbClearFilter_Click);
            // 
            // tsbShowHideChangePanel
            // 
            this.tsbShowHideChangePanel.Image = global::MsCrmTools.ScriptsFinder.Properties.Resources.script_edit;
            this.tsbShowHideChangePanel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowHideChangePanel.Name = "tsbShowHideChangePanel";
            this.tsbShowHideChangePanel.Size = new System.Drawing.Size(206, 36);
            this.tsbShowHideChangePanel.Text = "Show Edit panel";
            this.tsbShowHideChangePanel.Click += new System.EventHandler(this.tsbShowHideChangePanel_Click);
            // 
            // tsbCreate
            // 
            this.tsbCreate.Image = global::MsCrmTools.ScriptsFinder.Properties.Resources.plus;
            this.tsbCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCreate.Name = "tsbCreate";
            this.tsbCreate.Size = new System.Drawing.Size(83, 36);
            this.tsbCreate.Text = "New";
            this.tsbCreate.ToolTipText = "Add a new event record";
            this.tsbCreate.Click += new System.EventHandler(this.tsbCreate_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = global::MsCrmTools.ScriptsFinder.Properties.Resources.minus_icon;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(105, 36);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.ToolTipText = "Mark the selected line(s) to be deleted";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbOrder
            // 
            this.tsbOrder.Image = global::MsCrmTools.ScriptsFinder.Properties.Resources._16_sort;
            this.tsbOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOrder.Name = "tsbOrder";
            this.tsbOrder.Size = new System.Drawing.Size(78, 36);
            this.tsbOrder.Text = "Sort";
            this.tsbOrder.ToolTipText = "Allows to sort libraries or events. Select one library or event to sort all items" +
    " under the same parent";
            this.tsbOrder.Click += new System.EventHandler(this.tsbOrder_Click);
            // 
            // tssdDiscardChanges
            // 
            this.tssdDiscardChanges.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssdDiscardChanges.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDiscardChanges,
            this.tsmiDiscardAllChanges});
            this.tssdDiscardChanges.Enabled = false;
            this.tssdDiscardChanges.Image = ((System.Drawing.Image)(resources.GetObject("tssdDiscardChanges.Image")));
            this.tssdDiscardChanges.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssdDiscardChanges.Name = "tssdDiscardChanges";
            this.tssdDiscardChanges.Size = new System.Drawing.Size(214, 36);
            this.tssdDiscardChanges.Text = "Discard Changes";
            this.tssdDiscardChanges.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tssdDiscardChanges_DropDownItemClicked);
            // 
            // tsmiDiscardChanges
            // 
            this.tsmiDiscardChanges.Name = "tsmiDiscardChanges";
            this.tsmiDiscardChanges.Size = new System.Drawing.Size(334, 38);
            this.tsmiDiscardChanges.Text = "for selected rows";
            // 
            // tsmiDiscardAllChanges
            // 
            this.tsmiDiscardAllChanges.Name = "tsmiDiscardAllChanges";
            this.tsmiDiscardAllChanges.Size = new System.Drawing.Size(334, 38);
            this.tsmiDiscardAllChanges.Text = "for all modified rows";
            // 
            // tsbApplyChanges
            // 
            this.tsbApplyChanges.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbApplyChanges.Enabled = false;
            this.tsbApplyChanges.Image = ((System.Drawing.Image)(resources.GetObject("tsbApplyChanges.Image")));
            this.tsbApplyChanges.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbApplyChanges.Name = "tsbApplyChanges";
            this.tsbApplyChanges.Size = new System.Drawing.Size(175, 36);
            this.tsbApplyChanges.Text = "Apply changes";
            this.tsbApplyChanges.Click += new System.EventHandler(this.tsbApplyChanges_Click);
            // 
            // tsbShowErrorMessage
            // 
            this.tsbShowErrorMessage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbShowErrorMessage.Image = ((System.Drawing.Image)(resources.GetObject("tsbShowErrorMessage.Image")));
            this.tsbShowErrorMessage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowErrorMessage.Name = "tsbShowErrorMessage";
            this.tsbShowErrorMessage.Size = new System.Drawing.Size(235, 36);
            this.tsbShowErrorMessage.Text = "Show Error Message";
            this.tsbShowErrorMessage.Visible = false;
            this.tsbShowErrorMessage.Click += new System.EventHandler(this.tsbShowErrorMessage_Click);
            // 
            // lblChangeOrderCurrentValue
            // 
            this.lblChangeOrderCurrentValue.AutoSize = true;
            this.lblChangeOrderCurrentValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeOrderCurrentValue.Location = new System.Drawing.Point(303, 276);
            this.lblChangeOrderCurrentValue.Name = "lblChangeOrderCurrentValue";
            this.lblChangeOrderCurrentValue.Size = new System.Drawing.Size(0, 25);
            this.lblChangeOrderCurrentValue.TabIndex = 22;
            // 
            // lblChangeOrderNewValue
            // 
            this.lblChangeOrderNewValue.AutoSize = true;
            this.lblChangeOrderNewValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeOrderNewValue.Location = new System.Drawing.Point(1011, 276);
            this.lblChangeOrderNewValue.Name = "lblChangeOrderNewValue";
            this.lblChangeOrderNewValue.Size = new System.Drawing.Size(0, 25);
            this.lblChangeOrderNewValue.TabIndex = 23;
            // 
            // lblChangeOrder
            // 
            this.lblChangeOrder.AutoSize = true;
            this.lblChangeOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeOrder.Location = new System.Drawing.Point(3, 276);
            this.lblChangeOrder.Name = "lblChangeOrder";
            this.lblChangeOrder.Size = new System.Drawing.Size(71, 25);
            this.lblChangeOrder.TabIndex = 24;
            this.lblChangeOrder.Text = "Order";
            // 
            // ScriptsFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ScriptsFinder";
            this.Size = new System.Drawing.Size(1822, 1152);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.tlpFilter.ResumeLayout(false);
            this.tlpFilter.PerformLayout();
            this.gbUpdates.ResumeLayout(false);
            this.tlpChange.ResumeLayout(false);
            this.tlpChange.PerformLayout();
            this.pnlLibrary.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gbFilter.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator tssApply;
        private System.Windows.Forms.ToolStripButton tsbExportToCsv;
        private System.Windows.Forms.ToolStripDropDownButton tsddFindScripts;
        private System.Windows.Forms.ToolStripMenuItem forAllEntitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forEntitiesInSelectedSolutionsToolStripMenuItem;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.ListView lvScripts;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.TableLayoutPanel tlpFilter;
        private System.Windows.Forms.Label lblFilterType;
        private System.Windows.Forms.Label lblFilterEntity;
        private System.Windows.Forms.Label lblFilterEntityLogicalName;
        private System.Windows.Forms.Label lblFilterFormName;
        private System.Windows.Forms.Label lblFilterFormType;
        private System.Windows.Forms.Label lblFilterFormState;
        private System.Windows.Forms.Label lblFilterEvent;
        private System.Windows.Forms.Label lblFilterControl;
        private System.Windows.Forms.Label lblFilterControlLogicalName;
        private System.Windows.Forms.Label lblFilterFile;
        private System.Windows.Forms.Label lblFilterMethod;
        private System.Windows.Forms.Label lblFilterPassExecutionContext;
        private System.Windows.Forms.Label lblFilterParameters;
        private System.Windows.Forms.Label lblFilterEnabled;
        private System.Windows.Forms.ComboBox cbbFilterType;
        private System.Windows.Forms.TextBox txtFilterEntity;
        private System.Windows.Forms.TextBox txtFilterEntityLogicalName;
        private System.Windows.Forms.TextBox txtFilterFormName;
        private System.Windows.Forms.ComboBox cbbFilterFormType;
        private System.Windows.Forms.ComboBox cbbFilterFormState;
        private System.Windows.Forms.ComboBox cbbFilterEvent;
        private System.Windows.Forms.TextBox txtFilterControl;
        private System.Windows.Forms.TextBox txtFilterControlLogicalName;
        private System.Windows.Forms.TextBox txtFilterFile;
        private System.Windows.Forms.TextBox txtFilterMethod;
        private System.Windows.Forms.ComboBox cbbFilterPassParameters;
        private System.Windows.Forms.ComboBox cbbFilterEnabled;
        private System.Windows.Forms.TextBox txtFilterParameters;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbShowFilter;
        private System.Windows.Forms.ToolStripButton tsbClearFilter;
        private System.Windows.Forms.GroupBox gbUpdates;
        private System.Windows.Forms.TableLayoutPanel tlpChange;
        private System.Windows.Forms.Label lblHeaderProperty;
        private System.Windows.Forms.Label lblHeaderCurrentValue;
        private System.Windows.Forms.Label lblHeaderNewValue;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.Label lblPassExecutionContext;
        private System.Windows.Forms.Label lblParameters;
        private System.Windows.Forms.Label lblEnabled;
        private System.Windows.Forms.Label lblChangeFileCurrentValue;
        private System.Windows.Forms.Label lblChangeMethodCurrentValue;
        private System.Windows.Forms.Label lblChangePassContextCurrentValue;
        private System.Windows.Forms.Label lblChangeParametersCurrentValue;
        private System.Windows.Forms.Label lblChangeEnabledCurrentValue;
        private System.Windows.Forms.TextBox txtChangeMethod;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdbChangePassExecutionFalse;
        private System.Windows.Forms.RadioButton rdbChangePassExecutionTrue;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdbChangeEnabledFalse;
        private System.Windows.Forms.RadioButton rdbChangeEnabledTrue;
        private System.Windows.Forms.TextBox txtChangeParameters;
        private System.Windows.Forms.ToolStripSeparator tssChange;
        private System.Windows.Forms.ToolStripButton tsbShowHideChangePanel;
        private System.Windows.Forms.ToolStripButton tsbShowErrorMessage;
        private System.Windows.Forms.ImageList actionImageList;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbApplyChanges;
        private System.Windows.Forms.ToolStripDropDownButton tssdDiscardChanges;
        private System.Windows.Forms.ToolStripMenuItem tsmiDiscardChanges;
        private System.Windows.Forms.ToolStripMenuItem tsmiDiscardAllChanges;
        private System.Windows.Forms.ToolStripButton tsbCreate;
        private GroupBox gbFilter;
        private ToolStripContainer toolStripContainer1;
        private Panel pnlLibrary;
        private ComboBox cbbLibrary;
        private Button btnReloadWebResources;
        private Button btnSaveChanges;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton tsbOrder;
        private Label lblChangeOrder;
        private Label lblChangeOrderNewValue;
        private Label lblChangeOrderCurrentValue;
    }
}
