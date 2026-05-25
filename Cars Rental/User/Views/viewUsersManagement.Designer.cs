namespace Cars_Rental.User
{
    partial class viewUsersManagement
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
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlUsers = new Guna.UI2.WinForms.Guna2Panel();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddUser = new Guna.UI2.WinForms.Guna2Button();
            this.guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.btnRoles = new Guna.UI2.WinForms.Guna2Button();
            this.pnlUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(21, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(62, 34);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Users";
            // 
            // pnlUsers
            // 
            this.pnlUsers.BackColor = System.Drawing.Color.White;
            this.pnlUsers.BorderRadius = 6;
            this.pnlUsers.BorderThickness = 1;
            this.pnlUsers.Controls.Add(this.table);
            this.pnlUsers.Location = new System.Drawing.Point(21, 77);
            this.pnlUsers.Name = "pnlUsers";
            this.pnlUsers.Size = new System.Drawing.Size(1081, 605);
            this.pnlUsers.TabIndex = 5;
            // 
            // table
            // 
            this.table.AutoSize = true;
            this.table.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.table.ColumnCount = 5;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.95699F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.04301F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 169F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 187F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 256F));
            this.table.Dock = System.Windows.Forms.DockStyle.Top;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Name = "table";
            this.table.Padding = new System.Windows.Forms.Padding(10);
            this.table.RowCount = 1;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.53543F));
            this.table.Size = new System.Drawing.Size(1081, 20);
            this.table.TabIndex = 0;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Animated = true;
            this.btnAddUser.BorderRadius = 8;
            this.btnAddUser.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddUser.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddUser.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(125)))), ((int)(((byte)(243)))));
            this.btnAddUser.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.ForeColor = System.Drawing.Color.White;
            this.btnAddUser.Location = new System.Drawing.Point(962, 22);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(140, 40);
            this.btnAddUser.TabIndex = 6;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // guna2MessageDialog1
            // 
            this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.guna2MessageDialog1.Caption = null;
            this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.None;
            this.guna2MessageDialog1.Parent = null;
            this.guna2MessageDialog1.Style = Guna.UI2.WinForms.MessageDialogStyle.Default;
            this.guna2MessageDialog1.Text = null;
            // 
            // btnRoles
            // 
            this.btnRoles.Animated = true;
            this.btnRoles.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(125)))), ((int)(((byte)(243)))));
            this.btnRoles.BorderRadius = 8;
            this.btnRoles.BorderThickness = 1;
            this.btnRoles.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRoles.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRoles.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRoles.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRoles.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnRoles.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(125)))), ((int)(((byte)(243)))));
            this.btnRoles.Location = new System.Drawing.Point(761, 22);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(171, 40);
            this.btnRoles.TabIndex = 7;
            this.btnRoles.Text = "Manage Roles";
            this.btnRoles.Click += new System.EventHandler(this.btnRoles_Click);
            // 
            // viewUsersManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.btnRoles);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.pnlUsers);
            this.Controls.Add(this.lblTitle);
            this.Name = "viewUsersManagement";
            this.Size = new System.Drawing.Size(1125, 767);
            this.Load += new System.EventHandler(this.ctrlUsersManagement_Load);
            this.pnlUsers.ResumeLayout(false);
            this.pnlUsers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlUsers;
        private System.Windows.Forms.TableLayoutPanel table;
        private Guna.UI2.WinForms.Guna2Button btnAddUser;
        private Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1;
        private Guna.UI2.WinForms.Guna2Button btnRoles;
    }
}
