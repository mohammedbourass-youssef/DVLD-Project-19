namespace DVLD_Project_19.people
{
    partial class ctrlFindPersoncs
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlFindPersoncs));
            this.cmfilteritems = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSearchbox = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btmAddPerson = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmfilteritems
            // 
            this.cmfilteritems.BackColor = System.Drawing.Color.Transparent;
            this.cmfilteritems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmfilteritems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmfilteritems.FocusedColor = System.Drawing.Color.Empty;
            this.cmfilteritems.FocusedState.Parent = this.cmfilteritems;
            this.cmfilteritems.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmfilteritems.ForeColor = System.Drawing.Color.Black;
            this.cmfilteritems.FormattingEnabled = true;
            this.cmfilteritems.HoverState.Parent = this.cmfilteritems;
            this.cmfilteritems.ItemHeight = 30;
            this.cmfilteritems.Items.AddRange(new object[] {
            "None",
            "PersonID",
            "NationalNo",
            "FirstName",
            "LastName"});
            this.cmfilteritems.ItemsAppearance.Parent = this.cmfilteritems;
            this.cmfilteritems.Location = new System.Drawing.Point(171, 20);
            this.cmfilteritems.Name = "cmfilteritems";
            this.cmfilteritems.ShadowDecoration.Parent = this.cmfilteritems;
            this.cmfilteritems.Size = new System.Drawing.Size(211, 36);
            this.cmfilteritems.TabIndex = 0;
            this.cmfilteritems.SelectedIndexChanged += new System.EventHandler(this.cmfilteritems_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "Filter By : ";
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
            this.tbSearchbox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchbox.ForeColor = System.Drawing.Color.Black;
            this.tbSearchbox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbSearchbox.HoverState.Parent = this.tbSearchbox;
            this.tbSearchbox.Location = new System.Drawing.Point(400, 20);
            this.tbSearchbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSearchbox.Name = "tbSearchbox";
            this.tbSearchbox.PasswordChar = '\0';
            this.tbSearchbox.PlaceholderText = "";
            this.tbSearchbox.SelectedText = "";
            this.tbSearchbox.ShadowDecoration.Parent = this.tbSearchbox;
            this.tbSearchbox.Size = new System.Drawing.Size(235, 36);
            this.tbSearchbox.TabIndex = 3;
            this.tbSearchbox.Visible = false;
            this.tbSearchbox.TextChanged += new System.EventHandler(this.tbSearchbox_TextChanged);
            this.tbSearchbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearchbox_KeyPress);
            // 
            // btnFind
            // 
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.Location = new System.Drawing.Point(729, 20);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(54, 36);
            this.btnFind.TabIndex = 4;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btmAddPerson
            // 
            this.btmAddPerson.Image = ((System.Drawing.Image)(resources.GetObject("btmAddPerson.Image")));
            this.btmAddPerson.Location = new System.Drawing.Point(840, 20);
            this.btmAddPerson.Name = "btmAddPerson";
            this.btmAddPerson.Size = new System.Drawing.Size(54, 36);
            this.btmAddPerson.TabIndex = 5;
            this.btmAddPerson.UseVisualStyleBackColor = true;
            this.btmAddPerson.Click += new System.EventHandler(this.btmAddPerson_Click);
            // 
            // ctrlFindPersoncs
            // 
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Controls.Add(this.btmAddPerson);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.tbSearchbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmfilteritems);
            this.Name = "ctrlFindPersoncs";
            this.Size = new System.Drawing.Size(970, 71);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        
        
        private System.Windows.Forms.Button btmAddNew;
        private Guna.UI2.WinForms.Guna2ComboBox cmfilteritems;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox tbSearchbox;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btmAddPerson;
    }
}
