namespace MsCrmTools.ScriptsFinder.Forms
{
    partial class CreateEventDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderDesc = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnSolutionPickerCancel = new System.Windows.Forms.Button();
            this.btnSolutionPickerValidate = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.lblEnabled = new System.Windows.Forms.Label();
            this.txtParameters = new System.Windows.Forms.TextBox();
            this.lblParameters = new System.Windows.Forms.Label();
            this.chkPassExecutionContext = new System.Windows.Forms.CheckBox();
            this.lblPassExecutionContext = new System.Windows.Forms.Label();
            this.txtMethod = new System.Windows.Forms.TextBox();
            this.lblMethod = new System.Windows.Forms.Label();
            this.pnlLibrary = new System.Windows.Forms.Panel();
            this.cbbLibrary = new System.Windows.Forms.ComboBox();
            this.btnReloadWebResources = new System.Windows.Forms.Button();
            this.chkLoadAlsoManagedWebresources = new System.Windows.Forms.CheckBox();
            this.lblLibrary = new System.Windows.Forms.Label();
            this.txtField = new System.Windows.Forms.TextBox();
            this.lblField = new System.Windows.Forms.Label();
            this.cbbEvent = new System.Windows.Forms.ComboBox();
            this.lblEvent = new System.Windows.Forms.Label();
            this.cbbControl = new System.Windows.Forms.ComboBox();
            this.lblControl = new System.Windows.Forms.Label();
            this.cbbUiItems = new System.Windows.Forms.ComboBox();
            this.lblUiItem = new System.Windows.Forms.Label();
            this.cbbEntity = new System.Windows.Forms.ComboBox();
            this.lblEntity = new System.Windows.Forms.Label();
            this.pnlAction = new System.Windows.Forms.Panel();
            this.rdbRegisterLibrary = new System.Windows.Forms.RadioButton();
            this.rdbRegisterEvent = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.lvNewScripts = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlLibrary.SuspendLayout();
            this.pnlAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblHeaderDesc);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1992, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeaderDesc
            // 
            this.lblHeaderDesc.AutoSize = true;
            this.lblHeaderDesc.Font = new System.Drawing.Font("Segoe UI Light", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderDesc.Location = new System.Drawing.Point(14, 46);
            this.lblHeaderDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeaderDesc.Name = "lblHeaderDesc";
            this.lblHeaderDesc.Size = new System.Drawing.Size(333, 21);
            this.lblHeaderDesc.TabIndex = 1;
            this.lblHeaderDesc.Text = "Provide information below to register a new item";
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderTitle.Location = new System.Drawing.Point(11, 10);
            this.lblHeaderTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(321, 32);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Register a new event or library";
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnSolutionPickerCancel);
            this.pnlFooter.Controls.Add(this.btnSolutionPickerValidate);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 772);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(2);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1992, 51);
            this.pnlFooter.TabIndex = 1;
            // 
            // btnSolutionPickerCancel
            // 
            this.btnSolutionPickerCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSolutionPickerCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSolutionPickerCancel.Location = new System.Drawing.Point(1867, 8);
            this.btnSolutionPickerCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSolutionPickerCancel.Name = "btnSolutionPickerCancel";
            this.btnSolutionPickerCancel.Size = new System.Drawing.Size(112, 35);
            this.btnSolutionPickerCancel.TabIndex = 6;
            this.btnSolutionPickerCancel.Text = "Cancel";
            this.btnSolutionPickerCancel.UseVisualStyleBackColor = true;
            // 
            // btnSolutionPickerValidate
            // 
            this.btnSolutionPickerValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSolutionPickerValidate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSolutionPickerValidate.Location = new System.Drawing.Point(1746, 8);
            this.btnSolutionPickerValidate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSolutionPickerValidate.Name = "btnSolutionPickerValidate";
            this.btnSolutionPickerValidate.Size = new System.Drawing.Size(112, 35);
            this.btnSolutionPickerValidate.TabIndex = 5;
            this.btnSolutionPickerValidate.Text = "OK";
            this.btnSolutionPickerValidate.UseVisualStyleBackColor = true;
            this.btnSolutionPickerValidate.Click += new System.EventHandler(this.btnSolutionPickerValidate_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnAdd);
            this.pnlMain.Controls.Add(this.chkEnabled);
            this.pnlMain.Controls.Add(this.lblEnabled);
            this.pnlMain.Controls.Add(this.txtParameters);
            this.pnlMain.Controls.Add(this.lblParameters);
            this.pnlMain.Controls.Add(this.chkPassExecutionContext);
            this.pnlMain.Controls.Add(this.lblPassExecutionContext);
            this.pnlMain.Controls.Add(this.txtMethod);
            this.pnlMain.Controls.Add(this.lblMethod);
            this.pnlMain.Controls.Add(this.pnlLibrary);
            this.pnlMain.Controls.Add(this.lblLibrary);
            this.pnlMain.Controls.Add(this.txtField);
            this.pnlMain.Controls.Add(this.lblField);
            this.pnlMain.Controls.Add(this.cbbEvent);
            this.pnlMain.Controls.Add(this.lblEvent);
            this.pnlMain.Controls.Add(this.cbbControl);
            this.pnlMain.Controls.Add(this.lblControl);
            this.pnlMain.Controls.Add(this.cbbUiItems);
            this.pnlMain.Controls.Add(this.lblUiItem);
            this.pnlMain.Controls.Add(this.cbbEntity);
            this.pnlMain.Controls.Add(this.lblEntity);
            this.pnlMain.Controls.Add(this.pnlAction);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(8);
            this.pnlMain.Size = new System.Drawing.Size(367, 692);
            this.pnlMain.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAdd.Location = new System.Drawing.Point(8, 642);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(351, 42);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkEnabled.Location = new System.Drawing.Point(8, 595);
            this.chkEnabled.Margin = new System.Windows.Forms.Padding(2);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(351, 21);
            this.chkEnabled.TabIndex = 17;
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // lblEnabled
            // 
            this.lblEnabled.AutoSize = true;
            this.lblEnabled.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEnabled.Location = new System.Drawing.Point(8, 567);
            this.lblEnabled.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEnabled.Name = "lblEnabled";
            this.lblEnabled.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblEnabled.Size = new System.Drawing.Size(68, 28);
            this.lblEnabled.TabIndex = 16;
            this.lblEnabled.Text = "Enabled";
            // 
            // txtParameters
            // 
            this.txtParameters.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtParameters.Location = new System.Drawing.Point(8, 541);
            this.txtParameters.Margin = new System.Windows.Forms.Padding(2);
            this.txtParameters.Name = "txtParameters";
            this.txtParameters.Size = new System.Drawing.Size(351, 26);
            this.txtParameters.TabIndex = 15;
            // 
            // lblParameters
            // 
            this.lblParameters.AutoSize = true;
            this.lblParameters.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblParameters.Location = new System.Drawing.Point(8, 513);
            this.lblParameters.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblParameters.Name = "lblParameters";
            this.lblParameters.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblParameters.Size = new System.Drawing.Size(91, 28);
            this.lblParameters.TabIndex = 14;
            this.lblParameters.Text = "Parameters";
            // 
            // chkPassExecutionContext
            // 
            this.chkPassExecutionContext.AutoSize = true;
            this.chkPassExecutionContext.Checked = true;
            this.chkPassExecutionContext.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPassExecutionContext.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkPassExecutionContext.Location = new System.Drawing.Point(8, 492);
            this.chkPassExecutionContext.Margin = new System.Windows.Forms.Padding(2);
            this.chkPassExecutionContext.Name = "chkPassExecutionContext";
            this.chkPassExecutionContext.Size = new System.Drawing.Size(351, 21);
            this.chkPassExecutionContext.TabIndex = 13;
            this.chkPassExecutionContext.UseVisualStyleBackColor = true;
            // 
            // lblPassExecutionContext
            // 
            this.lblPassExecutionContext.AutoSize = true;
            this.lblPassExecutionContext.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPassExecutionContext.Location = new System.Drawing.Point(8, 464);
            this.lblPassExecutionContext.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassExecutionContext.Name = "lblPassExecutionContext";
            this.lblPassExecutionContext.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblPassExecutionContext.Size = new System.Drawing.Size(177, 28);
            this.lblPassExecutionContext.TabIndex = 12;
            this.lblPassExecutionContext.Text = "Pass Execution Context";
            // 
            // txtMethod
            // 
            this.txtMethod.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtMethod.Location = new System.Drawing.Point(8, 438);
            this.txtMethod.Margin = new System.Windows.Forms.Padding(2);
            this.txtMethod.Name = "txtMethod";
            this.txtMethod.Size = new System.Drawing.Size(351, 26);
            this.txtMethod.TabIndex = 11;
            // 
            // lblMethod
            // 
            this.lblMethod.AutoSize = true;
            this.lblMethod.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMethod.Location = new System.Drawing.Point(8, 410);
            this.lblMethod.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblMethod.Size = new System.Drawing.Size(63, 28);
            this.lblMethod.TabIndex = 10;
            this.lblMethod.Text = "Method";
            // 
            // pnlLibrary
            // 
            this.pnlLibrary.Controls.Add(this.cbbLibrary);
            this.pnlLibrary.Controls.Add(this.btnReloadWebResources);
            this.pnlLibrary.Controls.Add(this.chkLoadAlsoManagedWebresources);
            this.pnlLibrary.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLibrary.Location = new System.Drawing.Point(8, 378);
            this.pnlLibrary.Margin = new System.Windows.Forms.Padding(2);
            this.pnlLibrary.Name = "pnlLibrary";
            this.pnlLibrary.Size = new System.Drawing.Size(351, 32);
            this.pnlLibrary.TabIndex = 20;
            // 
            // cbbLibrary
            // 
            this.cbbLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbLibrary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLibrary.FormattingEnabled = true;
            this.cbbLibrary.Location = new System.Drawing.Point(0, 0);
            this.cbbLibrary.Margin = new System.Windows.Forms.Padding(2, 2, 2, 4);
            this.cbbLibrary.Name = "cbbLibrary";
            this.cbbLibrary.Size = new System.Drawing.Size(300, 28);
            this.cbbLibrary.TabIndex = 1;
            // 
            // btnReloadWebResources
            // 
            this.btnReloadWebResources.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnReloadWebResources.Image = global::MsCrmTools.ScriptsFinder.Properties.Resources.arrow_refresh;
            this.btnReloadWebResources.Location = new System.Drawing.Point(300, 0);
            this.btnReloadWebResources.Margin = new System.Windows.Forms.Padding(2);
            this.btnReloadWebResources.Name = "btnReloadWebResources";
            this.btnReloadWebResources.Size = new System.Drawing.Size(29, 32);
            this.btnReloadWebResources.TabIndex = 0;
            this.btnReloadWebResources.UseVisualStyleBackColor = true;
            this.btnReloadWebResources.Click += new System.EventHandler(this.btnReloadWebResources_Click);
            // 
            // chkLoadAlsoManagedWebresources
            // 
            this.chkLoadAlsoManagedWebresources.AutoSize = true;
            this.chkLoadAlsoManagedWebresources.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkLoadAlsoManagedWebresources.Location = new System.Drawing.Point(329, 0);
            this.chkLoadAlsoManagedWebresources.Name = "chkLoadAlsoManagedWebresources";
            this.chkLoadAlsoManagedWebresources.Size = new System.Drawing.Size(22, 32);
            this.chkLoadAlsoManagedWebresources.TabIndex = 3;
            this.chkLoadAlsoManagedWebresources.UseVisualStyleBackColor = true;
            // 
            // lblLibrary
            // 
            this.lblLibrary.AutoSize = true;
            this.lblLibrary.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLibrary.Location = new System.Drawing.Point(8, 350);
            this.lblLibrary.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLibrary.Name = "lblLibrary";
            this.lblLibrary.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblLibrary.Size = new System.Drawing.Size(56, 28);
            this.lblLibrary.TabIndex = 8;
            this.lblLibrary.Text = "Library";
            // 
            // txtField
            // 
            this.txtField.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtField.Location = new System.Drawing.Point(8, 324);
            this.txtField.Margin = new System.Windows.Forms.Padding(2);
            this.txtField.Name = "txtField";
            this.txtField.Size = new System.Drawing.Size(351, 26);
            this.txtField.TabIndex = 19;
            this.txtField.Visible = false;
            // 
            // lblField
            // 
            this.lblField.AutoSize = true;
            this.lblField.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblField.Location = new System.Drawing.Point(8, 296);
            this.lblField.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblField.Name = "lblField";
            this.lblField.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblField.Size = new System.Drawing.Size(43, 28);
            this.lblField.TabIndex = 18;
            this.lblField.Text = "Field";
            this.lblField.Visible = false;
            // 
            // cbbEvent
            // 
            this.cbbEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbbEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbEvent.FormattingEnabled = true;
            this.cbbEvent.Location = new System.Drawing.Point(8, 268);
            this.cbbEvent.Margin = new System.Windows.Forms.Padding(2);
            this.cbbEvent.Name = "cbbEvent";
            this.cbbEvent.Size = new System.Drawing.Size(351, 28);
            this.cbbEvent.TabIndex = 7;
            this.cbbEvent.SelectedIndexChanged += new System.EventHandler(this.cbbEvent_SelectedIndexChanged);
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEvent.Location = new System.Drawing.Point(8, 240);
            this.lblEvent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblEvent.Size = new System.Drawing.Size(50, 28);
            this.lblEvent.TabIndex = 6;
            this.lblEvent.Text = "Event";
            // 
            // cbbControl
            // 
            this.cbbControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbbControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbControl.FormattingEnabled = true;
            this.cbbControl.Location = new System.Drawing.Point(8, 212);
            this.cbbControl.Margin = new System.Windows.Forms.Padding(2);
            this.cbbControl.Name = "cbbControl";
            this.cbbControl.Size = new System.Drawing.Size(351, 28);
            this.cbbControl.TabIndex = 5;
            this.cbbControl.SelectedIndexChanged += new System.EventHandler(this.cbbControl_SelectedIndexChanged);
            // 
            // lblControl
            // 
            this.lblControl.AutoSize = true;
            this.lblControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblControl.Location = new System.Drawing.Point(8, 184);
            this.lblControl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblControl.Name = "lblControl";
            this.lblControl.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblControl.Size = new System.Drawing.Size(60, 28);
            this.lblControl.TabIndex = 4;
            this.lblControl.Text = "Control";
            // 
            // cbbUiItems
            // 
            this.cbbUiItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbbUiItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUiItems.FormattingEnabled = true;
            this.cbbUiItems.Location = new System.Drawing.Point(8, 156);
            this.cbbUiItems.Margin = new System.Windows.Forms.Padding(2);
            this.cbbUiItems.Name = "cbbUiItems";
            this.cbbUiItems.Size = new System.Drawing.Size(351, 28);
            this.cbbUiItems.TabIndex = 3;
            this.cbbUiItems.SelectedIndexChanged += new System.EventHandler(this.cbbForm_SelectedIndexChanged);
            // 
            // lblUiItem
            // 
            this.lblUiItem.AutoSize = true;
            this.lblUiItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUiItem.Location = new System.Drawing.Point(8, 128);
            this.lblUiItem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUiItem.Name = "lblUiItem";
            this.lblUiItem.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblUiItem.Size = new System.Drawing.Size(60, 28);
            this.lblUiItem.TabIndex = 2;
            this.lblUiItem.Text = "UI item";
            // 
            // cbbEntity
            // 
            this.cbbEntity.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbbEntity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbEntity.FormattingEnabled = true;
            this.cbbEntity.Location = new System.Drawing.Point(8, 100);
            this.cbbEntity.Margin = new System.Windows.Forms.Padding(2);
            this.cbbEntity.Name = "cbbEntity";
            this.cbbEntity.Size = new System.Drawing.Size(351, 28);
            this.cbbEntity.TabIndex = 1;
            this.cbbEntity.SelectedIndexChanged += new System.EventHandler(this.cbbEntity_SelectedIndexChanged);
            // 
            // lblEntity
            // 
            this.lblEntity.AutoSize = true;
            this.lblEntity.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEntity.Location = new System.Drawing.Point(8, 72);
            this.lblEntity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEntity.Name = "lblEntity";
            this.lblEntity.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblEntity.Size = new System.Drawing.Size(49, 28);
            this.lblEntity.TabIndex = 0;
            this.lblEntity.Text = "Entity";
            // 
            // pnlAction
            // 
            this.pnlAction.Controls.Add(this.rdbRegisterLibrary);
            this.pnlAction.Controls.Add(this.rdbRegisterEvent);
            this.pnlAction.Controls.Add(this.label1);
            this.pnlAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAction.Location = new System.Drawing.Point(8, 8);
            this.pnlAction.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Size = new System.Drawing.Size(351, 64);
            this.pnlAction.TabIndex = 21;
            // 
            // rdbRegisterLibrary
            // 
            this.rdbRegisterLibrary.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdbRegisterLibrary.Location = new System.Drawing.Point(187, 0);
            this.rdbRegisterLibrary.Margin = new System.Windows.Forms.Padding(2);
            this.rdbRegisterLibrary.Name = "rdbRegisterLibrary";
            this.rdbRegisterLibrary.Size = new System.Drawing.Size(112, 64);
            this.rdbRegisterLibrary.TabIndex = 3;
            this.rdbRegisterLibrary.Text = "A Library";
            this.rdbRegisterLibrary.UseVisualStyleBackColor = true;
            // 
            // rdbRegisterEvent
            // 
            this.rdbRegisterEvent.Checked = true;
            this.rdbRegisterEvent.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdbRegisterEvent.Location = new System.Drawing.Point(75, 0);
            this.rdbRegisterEvent.Margin = new System.Windows.Forms.Padding(2);
            this.rdbRegisterEvent.Name = "rdbRegisterEvent";
            this.rdbRegisterEvent.Size = new System.Drawing.Size(112, 64);
            this.rdbRegisterEvent.TabIndex = 2;
            this.rdbRegisterEvent.TabStop = true;
            this.rdbRegisterEvent.Text = "An Event";
            this.rdbRegisterEvent.UseVisualStyleBackColor = true;
            this.rdbRegisterEvent.CheckedChanged += new System.EventHandler(this.rdbRegisterEvent_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "Register";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMain.Location = new System.Drawing.Point(0, 80);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.pnlMain);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.lvNewScripts);
            this.scMain.Size = new System.Drawing.Size(1992, 692);
            this.scMain.SplitterDistance = 367;
            this.scMain.TabIndex = 3;
            // 
            // lvNewScripts
            // 
            this.lvNewScripts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader12,
            this.columnHeader11,
            this.columnHeader10});
            this.lvNewScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvNewScripts.FullRowSelect = true;
            this.lvNewScripts.HideSelection = false;
            this.lvNewScripts.Location = new System.Drawing.Point(0, 0);
            this.lvNewScripts.MultiSelect = false;
            this.lvNewScripts.Name = "lvNewScripts";
            this.lvNewScripts.Size = new System.Drawing.Size(1621, 692);
            this.lvNewScripts.TabIndex = 0;
            this.lvNewScripts.UseCompatibleStateImageBehavior = false;
            this.lvNewScripts.View = System.Windows.Forms.View.Details;
            this.lvNewScripts.DoubleClick += new System.EventHandler(this.lvNewScripts_DoubleClick);
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
            // columnHeader2
            // 
            this.columnHeader2.Text = "Item name";
            this.columnHeader2.Width = 150;
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
            // CreateEventDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1992, 823);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CreateEventDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New registration";
            this.Load += new System.EventHandler(this.CreateEventDialog_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlLibrary.ResumeLayout(false);
            this.pnlLibrary.PerformLayout();
            this.pnlAction.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ComboBox cbbEntity;
        private System.Windows.Forms.Label lblEntity;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Label lblEnabled;
        private System.Windows.Forms.TextBox txtParameters;
        private System.Windows.Forms.Label lblParameters;
        private System.Windows.Forms.CheckBox chkPassExecutionContext;
        private System.Windows.Forms.Label lblPassExecutionContext;
        private System.Windows.Forms.TextBox txtMethod;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.Label lblLibrary;
        private System.Windows.Forms.ComboBox cbbEvent;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.ComboBox cbbControl;
        private System.Windows.Forms.Label lblControl;
        private System.Windows.Forms.ComboBox cbbUiItems;
        private System.Windows.Forms.Label lblUiItem;
        private System.Windows.Forms.TextBox txtField;
        private System.Windows.Forms.Label lblField;
        private System.Windows.Forms.Label lblHeaderDesc;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Button btnSolutionPickerCancel;
        private System.Windows.Forms.Button btnSolutionPickerValidate;
        private System.Windows.Forms.Panel pnlLibrary;
        private System.Windows.Forms.Button btnReloadWebResources;
        private System.Windows.Forms.ComboBox cbbLibrary;
        private System.Windows.Forms.Panel pnlAction;
        private System.Windows.Forms.RadioButton rdbRegisterLibrary;
        private System.Windows.Forms.RadioButton rdbRegisterEvent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkLoadAlsoManagedWebresources;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.ListView lvNewScripts;
         private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader10;
    }
}