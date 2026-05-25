namespace Cars_Rental.User.Roles.Forms
{
    partial class frmRolesManagement
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
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.pnlTable = new Guna.UI2.WinForms.Guna2Panel();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddRole = new Guna.UI2.WinForms.Guna2Button();
            this.popup = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.guna2GradientPanel1.SuspendLayout();
            this.pnlTable.SuspendLayout();
            this.SuspendLayout();
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
            this.guna2GradientPanel1.Size = new System.Drawing.Size(968, 90);
            this.guna2GradientPanel1.TabIndex = 10;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.Location = new System.Drawing.Point(923, -2);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox2.TabIndex = 10;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(406, 28);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(157, 34);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Manage Roles";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // pnlTable
            // 
            this.pnlTable.AutoScroll = true;
            this.pnlTable.BackColor = System.Drawing.Color.White;
            this.pnlTable.Controls.Add(this.table);
            this.pnlTable.Location = new System.Drawing.Point(12, 150);
            this.pnlTable.Name = "pnlTable";
            this.pnlTable.Size = new System.Drawing.Size(944, 334);
            this.pnlTable.TabIndex = 11;
            // 
            // table
            // 
            this.table.AutoScroll = true;
            this.table.AutoSize = true;
            this.table.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.table.ColumnCount = 2;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table.Dock = System.Windows.Forms.DockStyle.Top;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Name = "table";
            this.table.RowCount = 2;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table.Size = new System.Drawing.Size(944, 0);
            this.table.TabIndex = 0;
            // 
            // btnAddRole
            // 
            this.btnAddRole.Animated = true;
            this.btnAddRole.BorderRadius = 8;
            this.btnAddRole.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddRole.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddRole.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddRole.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddRole.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(125)))), ((int)(((byte)(243)))));
            this.btnAddRole.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRole.ForeColor = System.Drawing.Color.White;
            this.btnAddRole.Location = new System.Drawing.Point(816, 104);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(140, 40);
            this.btnAddRole.TabIndex = 12;
            this.btnAddRole.Text = "Add Role";
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // popup
            // 
            this.popup.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.popup.Caption = null;
            this.popup.Icon = Guna.UI2.WinForms.MessageDialogIcon.None;
            this.popup.Parent = this;
            this.popup.Style = Guna.UI2.WinForms.MessageDialogStyle.Default;
            this.popup.Text = null;
            // 
            // frmRolesManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 562);
            this.Controls.Add(this.btnAddRole);
            this.Controls.Add(this.pnlTable);
            this.Controls.Add(this.guna2GradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRolesManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRolesManagement";
            this.Load += new System.EventHandler(this.frmRolesManagement_Load);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.pnlTable.ResumeLayout(false);
            this.pnlTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Panel pnlTable;
        private System.Windows.Forms.TableLayoutPanel table;
        private Guna.UI2.WinForms.Guna2Button btnAddRole;
        private Guna.UI2.WinForms.Guna2MessageDialog popup;
    }
}