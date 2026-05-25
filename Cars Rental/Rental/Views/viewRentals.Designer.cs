namespace Cars_Rental.Rental.Views
{
    partial class viewRentals
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
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.viewRentalsList1 = new Cars_Rental.Rental.Views.viewRentalsList();
            this.pnlTabs = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCompletedTab = new Guna.UI2.WinForms.Guna2Button();
            this.btnActiveTab = new Guna.UI2.WinForms.Guna2Button();
            this.popup = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.guna2Panel1.SuspendLayout();
            this.pnlTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Animated = true;
            this.btnAdd.BorderRadius = 8;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(125)))), ((int)(((byte)(243)))));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(963, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(140, 40);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add Rental";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(21, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(83, 34);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Rentals";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.Controls.Add(this.viewRentalsList1);
            this.guna2Panel1.Controls.Add(this.pnlTabs);
            this.guna2Panel1.Location = new System.Drawing.Point(31, 93);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1081, 599);
            this.guna2Panel1.TabIndex = 11;
            // 
            // viewRentalsList1
            // 
            this.viewRentalsList1.BackColor = System.Drawing.Color.White;
            this.viewRentalsList1.Dashboard = null;
            this.viewRentalsList1.Dock = System.Windows.Forms.DockStyle.Top;
            this.viewRentalsList1.Location = new System.Drawing.Point(0, 55);
            this.viewRentalsList1.Name = "viewRentalsList1";
            this.viewRentalsList1.Size = new System.Drawing.Size(1081, 541);
            this.viewRentalsList1.TabIndex = 3;
            // 
            // pnlTabs
            // 
            this.pnlTabs.Controls.Add(this.btnCompletedTab);
            this.pnlTabs.Controls.Add(this.btnActiveTab);
            this.pnlTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTabs.Location = new System.Drawing.Point(0, 0);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Size = new System.Drawing.Size(1081, 55);
            this.pnlTabs.TabIndex = 2;
            // 
            // btnCompletedTab
            // 
            this.btnCompletedTab.Animated = true;
            this.btnCompletedTab.BackColor = System.Drawing.Color.Transparent;
            this.btnCompletedTab.BorderRadius = 10;
            this.btnCompletedTab.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCompletedTab.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCompletedTab.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCompletedTab.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCompletedTab.FillColor = System.Drawing.Color.Transparent;
            this.btnCompletedTab.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompletedTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.btnCompletedTab.Location = new System.Drawing.Point(119, 8);
            this.btnCompletedTab.Name = "btnCompletedTab";
            this.btnCompletedTab.Size = new System.Drawing.Size(110, 38);
            this.btnCompletedTab.TabIndex = 2;
            this.btnCompletedTab.Text = "Completed";
            this.btnCompletedTab.UseTransparentBackground = true;
            this.btnCompletedTab.Click += new System.EventHandler(this.btnCompletedTab_Click);
            // 
            // btnActiveTab
            // 
            this.btnActiveTab.Animated = true;
            this.btnActiveTab.BackColor = System.Drawing.Color.Transparent;
            this.btnActiveTab.BorderRadius = 10;
            this.btnActiveTab.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnActiveTab.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnActiveTab.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnActiveTab.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnActiveTab.FillColor = System.Drawing.Color.Transparent;
            this.btnActiveTab.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnActiveTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.btnActiveTab.Location = new System.Drawing.Point(3, 8);
            this.btnActiveTab.Name = "btnActiveTab";
            this.btnActiveTab.Size = new System.Drawing.Size(110, 38);
            this.btnActiveTab.TabIndex = 0;
            this.btnActiveTab.Text = "Active";
            this.btnActiveTab.UseTransparentBackground = true;
            this.btnActiveTab.Click += new System.EventHandler(this.btnActiveTab_Click);
            // 
            // popup
            // 
            this.popup.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.popup.Caption = null;
            this.popup.Icon = Guna.UI2.WinForms.MessageDialogIcon.None;
            this.popup.Parent = null;
            this.popup.Style = Guna.UI2.WinForms.MessageDialogStyle.Default;
            this.popup.Text = null;
            // 
            // viewRentals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblTitle);
            this.Name = "viewRentals";
            this.Size = new System.Drawing.Size(1125, 767);
            this.Load += new System.EventHandler(this.viewRentals_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.pnlTabs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel pnlTabs;
        private Guna.UI2.WinForms.Guna2Button btnCompletedTab;
        private Guna.UI2.WinForms.Guna2Button btnActiveTab;
        private viewRentalsList viewRentalsList1;
        private Guna.UI2.WinForms.Guna2MessageDialog popup;
    }
}
