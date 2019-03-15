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
            this.tsbCloseThisTab = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsddFindScripts = new System.Windows.Forms.ToolStripDropDownButton();
            this.forAllEntitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forEntitiesInSelectedSolutionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExportToCsv = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbShowFilter = new System.Windows.Forms.ToolStripButton();
            this.tsbClearFilter = new System.Windows.Forms.ToolStripButton();
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
            this.tsMain.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.tlpFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCloseThisTab,
            this.toolStripSeparator2,
            this.tsddFindScripts,
            this.toolStripSeparator1,
            this.tsbExportToCsv,
            this.toolStripSeparator3,
            this.tsbShowFilter,
            this.tsbClearFilter});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tsMain.Size = new System.Drawing.Size(1822, 39);
            this.tsMain.TabIndex = 0;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbCloseThisTab
            // 
            this.tsbCloseThisTab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCloseThisTab.Image = ((System.Drawing.Image)(resources.GetObject("tsbCloseThisTab.Image")));
            this.tsbCloseThisTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCloseThisTab.Name = "tsbCloseThisTab";
            this.tsbCloseThisTab.Size = new System.Drawing.Size(36, 36);
            this.tsbCloseThisTab.Text = "Close this tab";
            this.tsbCloseThisTab.Click += new System.EventHandler(this.TsbCloseThisTabClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // tsddFindScripts
            // 
            this.tsddFindScripts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forAllEntitiesToolStripMenuItem,
            this.forEntitiesInSelectedSolutionsToolStripMenuItem});
            this.tsddFindScripts.Image = ((System.Drawing.Image)(resources.GetObject("tsddFindScripts.Image")));
            this.tsddFindScripts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddFindScripts.Name = "tsddFindScripts";
            this.tsddFindScripts.Size = new System.Drawing.Size(262, 36);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbExportToCsv
            // 
            this.tsbExportToCsv.Image = ((System.Drawing.Image)(resources.GetObject("tsbExportToCsv.Image")));
            this.tsbExportToCsv.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportToCsv.Name = "tsbExportToCsv";
            this.tsbExportToCsv.Size = new System.Drawing.Size(187, 36);
            this.tsbExportToCsv.Text = "Export to csv";
            this.tsbExportToCsv.Click += new System.EventHandler(this.TsbExportToCsvClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbShowFilter
            // 
            this.tsbShowFilter.Image = global::MsCrmTools.ScriptsFinder.Properties.Resources.filter;
            this.tsbShowFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowFilter.Name = "tsbShowFilter";
            this.tsbShowFilter.Size = new System.Drawing.Size(179, 36);
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
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Icon.png");
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.tlpFilter);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 39);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1822, 283);
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
            this.tlpFilter.Size = new System.Drawing.Size(1822, 283);
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
            this.lblFilterFormName.Text = "Form Name";
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
            this.lblFilterControl.Location = new System.Drawing.Point(913, 0);
            this.lblFilterControl.Name = "lblFilterControl";
            this.lblFilterControl.Size = new System.Drawing.Size(81, 25);
            this.lblFilterControl.TabIndex = 7;
            this.lblFilterControl.Text = "Control";
            // 
            // lblFilterControlLogicalName
            // 
            this.lblFilterControlLogicalName.AutoSize = true;
            this.lblFilterControlLogicalName.Location = new System.Drawing.Point(913, 40);
            this.lblFilterControlLogicalName.Name = "lblFilterControlLogicalName";
            this.lblFilterControlLogicalName.Size = new System.Drawing.Size(218, 25);
            this.lblFilterControlLogicalName.TabIndex = 8;
            this.lblFilterControlLogicalName.Text = "Control Logical Name";
            // 
            // lblFilterFile
            // 
            this.lblFilterFile.AutoSize = true;
            this.lblFilterFile.Location = new System.Drawing.Point(913, 80);
            this.lblFilterFile.Name = "lblFilterFile";
            this.lblFilterFile.Size = new System.Drawing.Size(47, 25);
            this.lblFilterFile.TabIndex = 9;
            this.lblFilterFile.Text = "File";
            // 
            // lblFilterMethod
            // 
            this.lblFilterMethod.AutoSize = true;
            this.lblFilterMethod.Location = new System.Drawing.Point(913, 120);
            this.lblFilterMethod.Name = "lblFilterMethod";
            this.lblFilterMethod.Size = new System.Drawing.Size(84, 25);
            this.lblFilterMethod.TabIndex = 10;
            this.lblFilterMethod.Text = "Method";
            // 
            // lblFilterPassExecutionContext
            // 
            this.lblFilterPassExecutionContext.AutoSize = true;
            this.lblFilterPassExecutionContext.Location = new System.Drawing.Point(913, 160);
            this.lblFilterPassExecutionContext.Name = "lblFilterPassExecutionContext";
            this.lblFilterPassExecutionContext.Size = new System.Drawing.Size(241, 25);
            this.lblFilterPassExecutionContext.TabIndex = 11;
            this.lblFilterPassExecutionContext.Text = "Pass Execution Context";
            // 
            // lblFilterParameters
            // 
            this.lblFilterParameters.AutoSize = true;
            this.lblFilterParameters.Location = new System.Drawing.Point(913, 200);
            this.lblFilterParameters.Name = "lblFilterParameters";
            this.lblFilterParameters.Size = new System.Drawing.Size(122, 25);
            this.lblFilterParameters.TabIndex = 12;
            this.lblFilterParameters.Text = "Parameters";
            // 
            // lblFilterEnabled
            // 
            this.lblFilterEnabled.AutoSize = true;
            this.lblFilterEnabled.Location = new System.Drawing.Point(913, 240);
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
            this.cbbFilterType.Location = new System.Drawing.Point(458, 3);
            this.cbbFilterType.Name = "cbbFilterType";
            this.cbbFilterType.Size = new System.Drawing.Size(449, 33);
            this.cbbFilterType.TabIndex = 14;
            this.cbbFilterType.SelectedIndexChanged += new System.EventHandler(this.cbbFilter_SelectedIndexChanged);
            // 
            // txtFilterEntity
            // 
            this.txtFilterEntity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilterEntity.Location = new System.Drawing.Point(458, 43);
            this.txtFilterEntity.Name = "txtFilterEntity";
            this.txtFilterEntity.Size = new System.Drawing.Size(449, 31);
            this.txtFilterEntity.TabIndex = 15;
            this.txtFilterEntity.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // txtFilterEntityLogicalName
            // 
            this.txtFilterEntityLogicalName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilterEntityLogicalName.Location = new System.Drawing.Point(458, 83);
            this.txtFilterEntityLogicalName.Name = "txtFilterEntityLogicalName";
            this.txtFilterEntityLogicalName.Size = new System.Drawing.Size(449, 31);
            this.txtFilterEntityLogicalName.TabIndex = 16;
            this.txtFilterEntityLogicalName.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // txtFilterFormName
            // 
            this.txtFilterFormName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilterFormName.Location = new System.Drawing.Point(458, 123);
            this.txtFilterFormName.Name = "txtFilterFormName";
            this.txtFilterFormName.Size = new System.Drawing.Size(449, 31);
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
            this.cbbFilterFormType.Location = new System.Drawing.Point(458, 163);
            this.cbbFilterFormType.Name = "cbbFilterFormType";
            this.cbbFilterFormType.Size = new System.Drawing.Size(449, 33);
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
            this.cbbFilterFormState.Location = new System.Drawing.Point(458, 203);
            this.cbbFilterFormState.Name = "cbbFilterFormState";
            this.cbbFilterFormState.Size = new System.Drawing.Size(449, 33);
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
            this.cbbFilterEvent.Location = new System.Drawing.Point(458, 243);
            this.cbbFilterEvent.Name = "cbbFilterEvent";
            this.cbbFilterEvent.Size = new System.Drawing.Size(449, 33);
            this.cbbFilterEvent.TabIndex = 20;
            this.cbbFilterEvent.SelectedIndexChanged += new System.EventHandler(this.cbbFilter_SelectedIndexChanged);
            // 
            // txtFilterControl
            // 
            this.txtFilterControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilterControl.Location = new System.Drawing.Point(1368, 3);
            this.txtFilterControl.Name = "txtFilterControl";
            this.txtFilterControl.Size = new System.Drawing.Size(451, 31);
            this.txtFilterControl.TabIndex = 21;
            this.txtFilterControl.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // txtFilterControlLogicalName
            // 
            this.txtFilterControlLogicalName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilterControlLogicalName.Location = new System.Drawing.Point(1368, 43);
            this.txtFilterControlLogicalName.Name = "txtFilterControlLogicalName";
            this.txtFilterControlLogicalName.Size = new System.Drawing.Size(451, 31);
            this.txtFilterControlLogicalName.TabIndex = 22;
            this.txtFilterControlLogicalName.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // txtFilterFile
            // 
            this.txtFilterFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilterFile.Location = new System.Drawing.Point(1368, 83);
            this.txtFilterFile.Name = "txtFilterFile";
            this.txtFilterFile.Size = new System.Drawing.Size(451, 31);
            this.txtFilterFile.TabIndex = 23;
            this.txtFilterFile.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // txtFilterMethod
            // 
            this.txtFilterMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilterMethod.Location = new System.Drawing.Point(1368, 123);
            this.txtFilterMethod.Name = "txtFilterMethod";
            this.txtFilterMethod.Size = new System.Drawing.Size(451, 31);
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
            this.cbbFilterPassParameters.Location = new System.Drawing.Point(1368, 163);
            this.cbbFilterPassParameters.Name = "cbbFilterPassParameters";
            this.cbbFilterPassParameters.Size = new System.Drawing.Size(451, 33);
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
            this.cbbFilterEnabled.Location = new System.Drawing.Point(1368, 243);
            this.cbbFilterEnabled.Name = "cbbFilterEnabled";
            this.cbbFilterEnabled.Size = new System.Drawing.Size(451, 33);
            this.cbbFilterEnabled.TabIndex = 26;
            this.cbbFilterEnabled.SelectedIndexChanged += new System.EventHandler(this.cbbFilter_SelectedIndexChanged);
            // 
            // txtFilterParameters
            // 
            this.txtFilterParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilterParameters.Location = new System.Drawing.Point(1368, 203);
            this.txtFilterParameters.Name = "txtFilterParameters";
            this.txtFilterParameters.Size = new System.Drawing.Size(451, 31);
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
            this.lvScripts.Location = new System.Drawing.Point(0, 322);
            this.lvScripts.Margin = new System.Windows.Forms.Padding(6);
            this.lvScripts.Name = "lvScripts";
            this.lvScripts.Size = new System.Drawing.Size(1822, 830);
            this.lvScripts.TabIndex = 3;
            this.lvScripts.UseCompatibleStateImageBehavior = false;
            this.lvScripts.View = System.Windows.Forms.View.Details;
            this.lvScripts.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LvScriptsColumnClick);
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
            this.columnHeader2.Text = "Form name";
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
            // ScriptsFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvScripts);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.tsMain);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ScriptsFinder";
            this.Size = new System.Drawing.Size(1822, 1152);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.tlpFilter.ResumeLayout(false);
            this.tlpFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbCloseThisTab;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
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
    }
}
