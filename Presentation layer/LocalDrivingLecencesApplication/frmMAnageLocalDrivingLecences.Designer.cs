namespace DVLD_Project_19.Application
{
    partial class frmMAnageLocalDrivingLecences
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMAnageLocalDrivingLecences));
            this.tbSearchbox = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmFilteritem = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRecords = new Guna.UI2.WinForms.Guna2DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmedit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.cmCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmSchedule = new System.Windows.Forms.ToolStripMenuItem();
            this.cmViewTest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmWritingtest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmIssue = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.cmshowlicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonLicenceHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRecord = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmstatus = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btmAddNew = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSearchbox
            // 
            this.tbSearchbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbSearchbox.DefaultText = "";
            this.tbSearchbox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbSearchbox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbSearchbox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSearchbox.DisabledState.Parent = this.tbSearchbox;
            this.tbSearchbox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSearchbox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbSearchbox.FocusedState.Parent = this.tbSearchbox;
            this.tbSearchbox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbSearchbox.HoverState.Parent = this.tbSearchbox;
            this.tbSearchbox.Location = new System.Drawing.Point(280, 245);
            this.tbSearchbox.Name = "tbSearchbox";
            this.tbSearchbox.PasswordChar = '\0';
            this.tbSearchbox.PlaceholderText = "";
            this.tbSearchbox.SelectedText = "";
            this.tbSearchbox.ShadowDecoration.Parent = this.tbSearchbox;
            this.tbSearchbox.Size = new System.Drawing.Size(192, 20);
            this.tbSearchbox.TabIndex = 15;
            this.tbSearchbox.Visible = false;
            this.tbSearchbox.TextChanged += new System.EventHandler(this.tbSearchbox_TextChanged);
            this.tbSearchbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearchbox_KeyPress);
            // 
            // cmFilteritem
            // 
            this.cmFilteritem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmFilteritem.FormattingEnabled = true;
            this.cmFilteritem.Items.AddRange(new object[] {
            "None",
            "ApplicationID",
            "LocalDrivingLicenseApplicationID",
            "ClassName",
            "NationalNo",
            "fullname",
            "Status"});
            this.cmFilteritem.Location = new System.Drawing.Point(123, 244);
            this.cmFilteritem.Name = "cmFilteritem";
            this.cmFilteritem.Size = new System.Drawing.Size(151, 21);
            this.cmFilteritem.TabIndex = 13;
            this.cmFilteritem.SelectedIndexChanged += new System.EventHandler(this.cmFilteritem_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Wide Latin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Filter By";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Wide Latin", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(284, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(621, 29);
            this.label1.TabIndex = 11;
            this.label1.Text = "Local Driving License Service";
            // 
            // dgvRecords
            // 
            this.dgvRecords.AllowUserToAddRows = false;
            this.dgvRecords.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvRecords.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecords.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecords.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRecords.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRecords.ColumnHeadersHeight = 30;
            this.dgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRecords.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecords.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRecords.EnableHeadersVisualStyles = false;
            this.dgvRecords.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRecords.Location = new System.Drawing.Point(12, 279);
            this.dgvRecords.Name = "dgvRecords";
            this.dgvRecords.ReadOnly = true;
            this.dgvRecords.RowHeadersVisible = false;
            this.dgvRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecords.Size = new System.Drawing.Size(1285, 411);
            this.dgvRecords.TabIndex = 9;
            this.dgvRecords.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvRecords.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRecords.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvRecords.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvRecords.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvRecords.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvRecords.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvRecords.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRecords.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvRecords.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRecords.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvRecords.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvRecords.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRecords.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvRecords.ThemeStyle.ReadOnly = true;
            this.dgvRecords.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRecords.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRecords.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvRecords.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvRecords.ThemeStyle.RowsStyle.Height = 22;
            this.dgvRecords.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRecords.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripSeparator1,
            this.cmedit,
            this.cmDelete,
            this.toolStripSeparator5,
            this.cmCancel,
            this.toolStripSeparator2,
            this.cmSchedule,
            this.toolStripSeparator3,
            this.cmIssue,
            this.toolStripSeparator6,
            this.cmshowlicense,
            this.toolStripSeparator4,
            this.showPersonLicenceHistoryToolStripMenuItem});
            this.contextMenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(375, 350);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showDetailsToolStripMenuItem.Image")));
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(374, 36);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripSeparator1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.toolStripSeparator1.Size = new System.Drawing.Size(371, 6);
            // 
            // cmedit
            // 
            this.cmedit.Image = ((System.Drawing.Image)(resources.GetObject("cmedit.Image")));
            this.cmedit.Name = "cmedit";
            this.cmedit.Size = new System.Drawing.Size(374, 36);
            this.cmedit.Text = "Edit applications";
            this.cmedit.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // cmDelete
            // 
            this.cmDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmDelete.Image")));
            this.cmDelete.Name = "cmDelete";
            this.cmDelete.Size = new System.Drawing.Size(374, 36);
            this.cmDelete.Text = "Delete applications";
            this.cmDelete.Click += new System.EventHandler(this.addNewPersonToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(371, 6);
            // 
            // cmCancel
            // 
            this.cmCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmCancel.Image")));
            this.cmCancel.Name = "cmCancel";
            this.cmCancel.Size = new System.Drawing.Size(374, 36);
            this.cmCancel.Text = "Cancel Application";
            this.cmCancel.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripSeparator2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(371, 6);
            // 
            // cmSchedule
            // 
            this.cmSchedule.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmViewTest,
            this.cmWritingtest,
            this.cmStreetTest});
            this.cmSchedule.Image = ((System.Drawing.Image)(resources.GetObject("cmSchedule.Image")));
            this.cmSchedule.Name = "cmSchedule";
            this.cmSchedule.Size = new System.Drawing.Size(374, 36);
            this.cmSchedule.Text = "sechdule tests";
            // 
            // cmViewTest
            // 
            this.cmViewTest.Image = ((System.Drawing.Image)(resources.GetObject("cmViewTest.Image")));
            this.cmViewTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmViewTest.Name = "cmViewTest";
            this.cmViewTest.Size = new System.Drawing.Size(292, 38);
            this.cmViewTest.Text = "Sechdule View Test";
            this.cmViewTest.Click += new System.EventHandler(this.sechduleViewTestToolStripMenuItem_Click);
            // 
            // cmWritingtest
            // 
            this.cmWritingtest.Image = ((System.Drawing.Image)(resources.GetObject("cmWritingtest.Image")));
            this.cmWritingtest.Name = "cmWritingtest";
            this.cmWritingtest.Size = new System.Drawing.Size(292, 38);
            this.cmWritingtest.Text = "Sechdule Writing Test";
            this.cmWritingtest.Click += new System.EventHandler(this.sechduleWritingTestToolStripMenuItem_Click);
            // 
            // cmStreetTest
            // 
            this.cmStreetTest.Image = ((System.Drawing.Image)(resources.GetObject("cmStreetTest.Image")));
            this.cmStreetTest.Name = "cmStreetTest";
            this.cmStreetTest.Size = new System.Drawing.Size(292, 38);
            this.cmStreetTest.Text = "Sechdule Street Test";
            this.cmStreetTest.Click += new System.EventHandler(this.sechduleViewTestToolStripMenuItem1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(371, 6);
            // 
            // cmIssue
            // 
            this.cmIssue.Image = ((System.Drawing.Image)(resources.GetObject("cmIssue.Image")));
            this.cmIssue.Name = "cmIssue";
            this.cmIssue.Size = new System.Drawing.Size(374, 36);
            this.cmIssue.Text = "Issue Driving licence(First time)";
            this.cmIssue.Click += new System.EventHandler(this.cmIssue_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(371, 6);
            // 
            // cmshowlicense
            // 
            this.cmshowlicense.Image = ((System.Drawing.Image)(resources.GetObject("cmshowlicense.Image")));
            this.cmshowlicense.Name = "cmshowlicense";
            this.cmshowlicense.Size = new System.Drawing.Size(374, 36);
            this.cmshowlicense.Text = "Show Licence";
            this.cmshowlicense.Click += new System.EventHandler(this.cmshowlicense_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(371, 6);
            // 
            // showPersonLicenceHistoryToolStripMenuItem
            // 
            this.showPersonLicenceHistoryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showPersonLicenceHistoryToolStripMenuItem.Image")));
            this.showPersonLicenceHistoryToolStripMenuItem.Name = "showPersonLicenceHistoryToolStripMenuItem";
            this.showPersonLicenceHistoryToolStripMenuItem.Size = new System.Drawing.Size(374, 36);
            this.showPersonLicenceHistoryToolStripMenuItem.Text = "Show Person Licence History";
            this.showPersonLicenceHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenceHistoryToolStripMenuItem_Click);
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Wide Latin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.ForeColor = System.Drawing.Color.Black;
            this.lblRecord.Location = new System.Drawing.Point(239, 710);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(29, 19);
            this.lblRecord.TabIndex = 18;
            this.lblRecord.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Wide Latin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(26, 710);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 19);
            this.label3.TabIndex = 17;
            this.label3.Text = "# RECORDS : ";
            // 
            // cmstatus
            // 
            this.cmstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmstatus.FormattingEnabled = true;
            this.cmstatus.Items.AddRange(new object[] {
            "None",
            "New",
            "Cancelled",
            "Completed"});
            this.cmstatus.Location = new System.Drawing.Point(280, 245);
            this.cmstatus.Name = "cmstatus";
            this.cmstatus.Size = new System.Drawing.Size(192, 21);
            this.cmstatus.TabIndex = 20;
            this.cmstatus.Visible = false;
            this.cmstatus.SelectedIndexChanged += new System.EventHandler(this.cmstatus_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(718, 62);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(46, 45);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(573, 696);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 44);
            this.button1.TabIndex = 16;
            this.button1.Text = "Cancel";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btmAddNew
            // 
            this.btmAddNew.Image = ((System.Drawing.Image)(resources.GetObject("btmAddNew.Image")));
            this.btmAddNew.Location = new System.Drawing.Point(1199, 182);
            this.btmAddNew.Name = "btmAddNew";
            this.btmAddNew.Size = new System.Drawing.Size(75, 65);
            this.btmAddNew.TabIndex = 14;
            this.btmAddNew.UseVisualStyleBackColor = true;
            this.btmAddNew.Click += new System.EventHandler(this.btmAddNew_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(458, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(306, 194);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // frmMAnageLocalDrivingLecences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 748);
            this.Controls.Add(this.cmstatus);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbSearchbox);
            this.Controls.Add(this.btmAddNew);
            this.Controls.Add(this.cmFilteritem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvRecords);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMAnageLocalDrivingLecences";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Applications";
            this.Load += new System.EventHandler(this.frmMAnageLocalDrivingLecences_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox tbSearchbox;
        private System.Windows.Forms.Button btmAddNew;
        private System.Windows.Forms.ComboBox cmFilteritem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvRecords;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox cmstatus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmedit;
        private System.Windows.Forms.ToolStripMenuItem cmDelete;
        private System.Windows.Forms.ToolStripMenuItem cmCancel;
        private System.Windows.Forms.ToolStripMenuItem cmSchedule;
        private System.Windows.Forms.ToolStripMenuItem cmIssue;
        private System.Windows.Forms.ToolStripMenuItem cmViewTest;
        private System.Windows.Forms.ToolStripMenuItem cmWritingtest;
        private System.Windows.Forms.ToolStripMenuItem cmStreetTest;
        private System.Windows.Forms.ToolStripMenuItem cmshowlicense;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenceHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    }
}