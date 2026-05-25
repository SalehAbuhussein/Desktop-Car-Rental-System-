namespace Cars_Rental.Person.Forms
{
    partial class frmAddEditPerson
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
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.gbPersonInfo = new Guna.UI2.WinForms.Guna2GroupBox();
            this.cbGender = new Guna.UI2.WinForms.Guna2ComboBox();
            this.tbAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tbLastname = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tbThirdname = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tbSecondname = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbFirstname = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.guna2GradientPanel1.SuspendLayout();
            this.gbPersonInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // guna2MessageDialog1
            // 
            this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.guna2MessageDialog1.Caption = null;
            this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.None;
            this.guna2MessageDialog1.Parent = this;
            this.guna2MessageDialog1.Style = Guna.UI2.WinForms.MessageDialogStyle.Default;
            this.guna2MessageDialog1.Text = null;
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.guna2ControlBox2);
            this.guna2GradientPanel1.Controls.Add(this.lblTitle);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(125)))), ((int)(((byte)(243)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(79)))), ((int)(((byte)(163)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(644, 90);
            this.guna2GradientPanel1.TabIndex = 3;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.Location = new System.Drawing.Point(599, 0);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox2.TabIndex = 11;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(206, 28);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(232, 34);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Add / Update Person";
            // 
            // gbPersonInfo
            // 
            this.gbPersonInfo.Controls.Add(this.cbGender);
            this.gbPersonInfo.Controls.Add(this.tbAddress);
            this.gbPersonInfo.Controls.Add(this.guna2HtmlLabel6);
            this.gbPersonInfo.Controls.Add(this.guna2HtmlLabel5);
            this.gbPersonInfo.Controls.Add(this.tbLastname);
            this.gbPersonInfo.Controls.Add(this.guna2HtmlLabel4);
            this.gbPersonInfo.Controls.Add(this.tbThirdname);
            this.gbPersonInfo.Controls.Add(this.guna2HtmlLabel3);
            this.gbPersonInfo.Controls.Add(this.tbSecondname);
            this.gbPersonInfo.Controls.Add(this.tbFirstname);
            this.gbPersonInfo.Controls.Add(this.guna2HtmlLabel2);
            this.gbPersonInfo.Controls.Add(this.guna2HtmlLabel1);
            this.gbPersonInfo.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(125)))), ((int)(((byte)(243)))));
            this.gbPersonInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPersonInfo.ForeColor = System.Drawing.Color.White;
            this.gbPersonInfo.Location = new System.Drawing.Point(42, 114);
            this.gbPersonInfo.Name = "gbPersonInfo";
            this.gbPersonInfo.Size = new System.Drawing.Size(563, 390);
            this.gbPersonInfo.TabIndex = 4;
            this.gbPersonInfo.Text = "Personal Information";
            // 
            // cbGender
            // 
            this.cbGender.BackColor = System.Drawing.Color.Transparent;
            this.cbGender.BorderRadius = 4;
            this.cbGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbGender.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbGender.ItemHeight = 30;
            this.cbGender.Location = new System.Drawing.Point(14, 223);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(534, 36);
            this.cbGender.TabIndex = 12;
            // 
            // tbAddress
            // 
            this.tbAddress.Animated = true;
            this.tbAddress.BorderRadius = 4;
            this.tbAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbAddress.DefaultText = "";
            this.tbAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbAddress.Location = new System.Drawing.Point(14, 293);
            this.tbAddress.MaxLength = 100;
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.PasswordChar = '\0';
            this.tbAddress.PlaceholderText = "Enter Address";
            this.tbAddress.SelectedText = "";
            this.tbAddress.Size = new System.Drawing.Size(534, 36);
            this.tbAddress.TabIndex = 11;
            this.tbAddress.Validating += new System.ComponentModel.CancelEventHandler(this.tbAddress_Validating);
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(14, 270);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(41, 15);
            this.guna2HtmlLabel6.TabIndex = 10;
            this.guna2HtmlLabel6.Text = "Address";
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(14, 198);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(38, 15);
            this.guna2HtmlLabel5.TabIndex = 8;
            this.guna2HtmlLabel5.Text = "Gender";
            // 
            // tbLastname
            // 
            this.tbLastname.Animated = true;
            this.tbLastname.BorderRadius = 4;
            this.tbLastname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbLastname.DefaultText = "";
            this.tbLastname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbLastname.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbLastname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbLastname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbLastname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbLastname.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbLastname.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbLastname.Location = new System.Drawing.Point(253, 155);
            this.tbLastname.MaxLength = 50;
            this.tbLastname.Name = "tbLastname";
            this.tbLastname.PasswordChar = '\0';
            this.tbLastname.PlaceholderText = "Enter Last Name";
            this.tbLastname.SelectedText = "";
            this.tbLastname.Size = new System.Drawing.Size(295, 36);
            this.tbLastname.TabIndex = 7;
            this.tbLastname.Validating += new System.ComponentModel.CancelEventHandler(this.tbLastname_Validating);
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(253, 132);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(54, 15);
            this.guna2HtmlLabel4.TabIndex = 6;
            this.guna2HtmlLabel4.Text = "Last Name";
            // 
            // tbThirdname
            // 
            this.tbThirdname.Animated = true;
            this.tbThirdname.BorderRadius = 4;
            this.tbThirdname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbThirdname.DefaultText = "";
            this.tbThirdname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbThirdname.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbThirdname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbThirdname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbThirdname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbThirdname.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbThirdname.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbThirdname.Location = new System.Drawing.Point(14, 155);
            this.tbThirdname.MaxLength = 50;
            this.tbThirdname.Name = "tbThirdname";
            this.tbThirdname.PasswordChar = '\0';
            this.tbThirdname.PlaceholderText = "Enter Third Name";
            this.tbThirdname.SelectedText = "";
            this.tbThirdname.Size = new System.Drawing.Size(214, 36);
            this.tbThirdname.TabIndex = 5;
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(14, 132);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(58, 15);
            this.guna2HtmlLabel3.TabIndex = 4;
            this.guna2HtmlLabel3.Text = "Third Name";
            // 
            // tbSecondname
            // 
            this.tbSecondname.Animated = true;
            this.tbSecondname.BorderRadius = 4;
            this.tbSecondname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbSecondname.DefaultText = "";
            this.tbSecondname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbSecondname.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbSecondname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSecondname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSecondname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbSecondname.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbSecondname.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbSecondname.Location = new System.Drawing.Point(253, 82);
            this.tbSecondname.MaxLength = 50;
            this.tbSecondname.Name = "tbSecondname";
            this.tbSecondname.PasswordChar = '\0';
            this.tbSecondname.PlaceholderText = "Enter Second Name";
            this.tbSecondname.SelectedText = "";
            this.tbSecondname.Size = new System.Drawing.Size(295, 36);
            this.tbSecondname.TabIndex = 3;
            this.tbSecondname.Validating += new System.ComponentModel.CancelEventHandler(this.tbSecondname_Validating);
            // 
            // tbFirstname
            // 
            this.tbFirstname.Animated = true;
            this.tbFirstname.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.tbFirstname.BorderRadius = 4;
            this.tbFirstname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbFirstname.DefaultText = "";
            this.tbFirstname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbFirstname.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbFirstname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbFirstname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbFirstname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbFirstname.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbFirstname.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbFirstname.Location = new System.Drawing.Point(14, 82);
            this.tbFirstname.MaxLength = 50;
            this.tbFirstname.Name = "tbFirstname";
            this.tbFirstname.PasswordChar = '\0';
            this.tbFirstname.PlaceholderText = "Enter First Name";
            this.tbFirstname.SelectedText = "";
            this.tbFirstname.Size = new System.Drawing.Size(214, 36);
            this.tbFirstname.TabIndex = 2;
            this.tbFirstname.Validating += new System.ComponentModel.CancelEventHandler(this.tbFirstname_Validating);
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(253, 59);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(71, 15);
            this.guna2HtmlLabel2.TabIndex = 1;
            this.guna2HtmlLabel2.Text = "Second Name";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(14, 59);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(53, 15);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "First Name";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.btnCancel.ImageSize = new System.Drawing.Size(18, 18);
            this.btnCancel.Location = new System.Drawing.Point(325, 510);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(132, 45);
            this.btnCancel.TabIndex = 39;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Animated = true;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(125)))), ((int)(((byte)(243)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(220)))));
            this.btnSave.ImageSize = new System.Drawing.Size(18, 18);
            this.btnSave.Location = new System.Drawing.Point(176, 510);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(132, 45);
            this.btnSave.TabIndex = 38;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmAddEditPerson
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(644, 588);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbPersonInfo);
            this.Controls.Add(this.guna2GradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAddEditPerson";
            this.Load += new System.EventHandler(this.frmAddEditPerson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.gbPersonInfo.ResumeLayout(false);
            this.gbPersonInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2GroupBox gbPersonInfo;
        private Guna.UI2.WinForms.Guna2ComboBox cbGender;
        private Guna.UI2.WinForms.Guna2TextBox tbAddress;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2TextBox tbLastname;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2TextBox tbThirdname;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2TextBox tbSecondname;
        private Guna.UI2.WinForms.Guna2TextBox tbFirstname;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnSave;
    }
}