namespace Cars_Rental.Car.Views
{
    partial class viewCars
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
            this.pnlUsers = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlTabs = new Guna.UI2.WinForms.Guna2Panel();
            this.btnYearsTab = new Guna.UI2.WinForms.Guna2Button();
            this.btnTransmissionTab = new Guna.UI2.WinForms.Guna2Button();
            this.btnFuelTypesTab = new Guna.UI2.WinForms.Guna2Button();
            this.btnModelsTab = new Guna.UI2.WinForms.Guna2Button();
            this.btnMakesTab = new Guna.UI2.WinForms.Guna2Button();
            this.btnCarsTab = new Guna.UI2.WinForms.Guna2Button();
            this.guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.viewFuelTypesList1 = new Cars_Rental.Car.Views.viewFuelTypesList();
            this.viewTransmissionsList1 = new Cars_Rental.Car.Views.viewTransmissionsList();
            this.viewYears1 = new Cars_Rental.Car.Views.viewYearsList();
            this.viewModelsList1 = new Cars_Rental.Car.Views.viewModelsList();
            this.viewMakesList1 = new Cars_Rental.Car.Views.viewMakesList();
            this.viewCarsList1 = new Cars_Rental.Car.Views.viewCarsList();
            this.pnlUsers.SuspendLayout();
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
            this.btnAdd.Location = new System.Drawing.Point(945, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(158, 40);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add Car";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(21, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(50, 34);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "Cars";
            // 
            // pnlUsers
            // 
            this.pnlUsers.BackColor = System.Drawing.Color.White;
            this.pnlUsers.BorderRadius = 6;
            this.pnlUsers.BorderThickness = 1;
            this.pnlUsers.Controls.Add(this.viewFuelTypesList1);
            this.pnlUsers.Controls.Add(this.viewTransmissionsList1);
            this.pnlUsers.Controls.Add(this.viewYears1);
            this.pnlUsers.Controls.Add(this.viewModelsList1);
            this.pnlUsers.Controls.Add(this.viewMakesList1);
            this.pnlUsers.Controls.Add(this.viewCarsList1);
            this.pnlUsers.Controls.Add(this.pnlTabs);
            this.pnlUsers.Location = new System.Drawing.Point(21, 77);
            this.pnlUsers.Name = "pnlUsers";
            this.pnlUsers.Size = new System.Drawing.Size(1081, 599);
            this.pnlUsers.TabIndex = 9;
            // 
            // pnlTabs
            // 
            this.pnlTabs.Controls.Add(this.btnYearsTab);
            this.pnlTabs.Controls.Add(this.btnTransmissionTab);
            this.pnlTabs.Controls.Add(this.btnFuelTypesTab);
            this.pnlTabs.Controls.Add(this.btnModelsTab);
            this.pnlTabs.Controls.Add(this.btnMakesTab);
            this.pnlTabs.Controls.Add(this.btnCarsTab);
            this.pnlTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTabs.Location = new System.Drawing.Point(0, 0);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Size = new System.Drawing.Size(1081, 55);
            this.pnlTabs.TabIndex = 1;
            // 
            // btnYearsTab
            // 
            this.btnYearsTab.Animated = true;
            this.btnYearsTab.BackColor = System.Drawing.Color.Transparent;
            this.btnYearsTab.BorderRadius = 10;
            this.btnYearsTab.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnYearsTab.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnYearsTab.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnYearsTab.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnYearsTab.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnYearsTab.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYearsTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.btnYearsTab.Location = new System.Drawing.Point(351, 8);
            this.btnYearsTab.Name = "btnYearsTab";
            this.btnYearsTab.Size = new System.Drawing.Size(110, 38);
            this.btnYearsTab.TabIndex = 5;
            this.btnYearsTab.Text = "Years";
            this.btnYearsTab.UseTransparentBackground = true;
            this.btnYearsTab.Click += new System.EventHandler(this.btnYearTab_Click);
            // 
            // btnTransmissionTab
            // 
            this.btnTransmissionTab.Animated = true;
            this.btnTransmissionTab.BackColor = System.Drawing.Color.Transparent;
            this.btnTransmissionTab.BorderRadius = 10;
            this.btnTransmissionTab.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTransmissionTab.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTransmissionTab.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTransmissionTab.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTransmissionTab.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnTransmissionTab.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransmissionTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.btnTransmissionTab.Location = new System.Drawing.Point(583, 8);
            this.btnTransmissionTab.Name = "btnTransmissionTab";
            this.btnTransmissionTab.Size = new System.Drawing.Size(129, 38);
            this.btnTransmissionTab.TabIndex = 4;
            this.btnTransmissionTab.Text = "Transmissions";
            this.btnTransmissionTab.UseTransparentBackground = true;
            this.btnTransmissionTab.Click += new System.EventHandler(this.btnTransmissionTab_Click);
            // 
            // btnFuelTypesTab
            // 
            this.btnFuelTypesTab.Animated = true;
            this.btnFuelTypesTab.BackColor = System.Drawing.Color.Transparent;
            this.btnFuelTypesTab.BorderRadius = 10;
            this.btnFuelTypesTab.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFuelTypesTab.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFuelTypesTab.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFuelTypesTab.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFuelTypesTab.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnFuelTypesTab.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFuelTypesTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.btnFuelTypesTab.Location = new System.Drawing.Point(467, 8);
            this.btnFuelTypesTab.Name = "btnFuelTypesTab";
            this.btnFuelTypesTab.Size = new System.Drawing.Size(110, 38);
            this.btnFuelTypesTab.TabIndex = 3;
            this.btnFuelTypesTab.Text = "Fuel Types";
            this.btnFuelTypesTab.UseTransparentBackground = true;
            this.btnFuelTypesTab.Click += new System.EventHandler(this.btnFuelTypesTab_Click);
            // 
            // btnModelsTab
            // 
            this.btnModelsTab.Animated = true;
            this.btnModelsTab.BackColor = System.Drawing.Color.Transparent;
            this.btnModelsTab.BorderRadius = 10;
            this.btnModelsTab.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnModelsTab.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnModelsTab.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnModelsTab.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnModelsTab.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnModelsTab.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModelsTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.btnModelsTab.Location = new System.Drawing.Point(235, 8);
            this.btnModelsTab.Name = "btnModelsTab";
            this.btnModelsTab.Size = new System.Drawing.Size(110, 38);
            this.btnModelsTab.TabIndex = 2;
            this.btnModelsTab.Text = "Models";
            this.btnModelsTab.UseTransparentBackground = true;
            this.btnModelsTab.Click += new System.EventHandler(this.btnModelsTab_Click);
            // 
            // btnMakesTab
            // 
            this.btnMakesTab.Animated = true;
            this.btnMakesTab.BackColor = System.Drawing.Color.Transparent;
            this.btnMakesTab.BorderRadius = 10;
            this.btnMakesTab.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMakesTab.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMakesTab.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMakesTab.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMakesTab.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnMakesTab.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMakesTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.btnMakesTab.Location = new System.Drawing.Point(119, 8);
            this.btnMakesTab.Name = "btnMakesTab";
            this.btnMakesTab.Size = new System.Drawing.Size(110, 38);
            this.btnMakesTab.TabIndex = 1;
            this.btnMakesTab.Text = "Makes";
            this.btnMakesTab.UseTransparentBackground = true;
            this.btnMakesTab.Click += new System.EventHandler(this.btnMakesTab_Click);
            // 
            // btnCarsTab
            // 
            this.btnCarsTab.Animated = true;
            this.btnCarsTab.BackColor = System.Drawing.Color.Transparent;
            this.btnCarsTab.BorderRadius = 10;
            this.btnCarsTab.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCarsTab.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCarsTab.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCarsTab.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCarsTab.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnCarsTab.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarsTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.btnCarsTab.Location = new System.Drawing.Point(3, 8);
            this.btnCarsTab.Name = "btnCarsTab";
            this.btnCarsTab.Size = new System.Drawing.Size(110, 38);
            this.btnCarsTab.TabIndex = 0;
            this.btnCarsTab.Text = "Cars";
            this.btnCarsTab.UseTransparentBackground = true;
            this.btnCarsTab.Click += new System.EventHandler(this.btnCarsTab_Click);
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
            // viewFuelTypesList1
            // 
            this.viewFuelTypesList1.Dashboard = null;
            this.viewFuelTypesList1.Dock = System.Windows.Forms.DockStyle.Top;
            this.viewFuelTypesList1.Location = new System.Drawing.Point(0, 2760);
            this.viewFuelTypesList1.Name = "viewFuelTypesList1";
            this.viewFuelTypesList1.Size = new System.Drawing.Size(1081, 541);
            this.viewFuelTypesList1.TabIndex = 7;
            // 
            // viewTransmissionsList1
            // 
            this.viewTransmissionsList1.AutoScroll = true;
            this.viewTransmissionsList1.Dashboard = null;
            this.viewTransmissionsList1.Dock = System.Windows.Forms.DockStyle.Top;
            this.viewTransmissionsList1.Location = new System.Drawing.Point(0, 2219);
            this.viewTransmissionsList1.Name = "viewTransmissionsList1";
            this.viewTransmissionsList1.Size = new System.Drawing.Size(1081, 541);
            this.viewTransmissionsList1.TabIndex = 6;
            // 
            // viewYears1
            // 
            this.viewYears1.AutoScroll = true;
            this.viewYears1.Dashboard = null;
            this.viewYears1.Dock = System.Windows.Forms.DockStyle.Top;
            this.viewYears1.Location = new System.Drawing.Point(0, 1678);
            this.viewYears1.Name = "viewYears1";
            this.viewYears1.Size = new System.Drawing.Size(1081, 541);
            this.viewYears1.TabIndex = 5;
            // 
            // viewModelsList1
            // 
            this.viewModelsList1.AutoScroll = true;
            this.viewModelsList1.Dashboard = null;
            this.viewModelsList1.Dock = System.Windows.Forms.DockStyle.Top;
            this.viewModelsList1.Location = new System.Drawing.Point(0, 1137);
            this.viewModelsList1.Name = "viewModelsList1";
            this.viewModelsList1.Size = new System.Drawing.Size(1081, 541);
            this.viewModelsList1.TabIndex = 4;
            // 
            // viewMakesList1
            // 
            this.viewMakesList1.AutoScroll = true;
            this.viewMakesList1.Dashboard = null;
            this.viewMakesList1.Dock = System.Windows.Forms.DockStyle.Top;
            this.viewMakesList1.Location = new System.Drawing.Point(0, 596);
            this.viewMakesList1.Name = "viewMakesList1";
            this.viewMakesList1.Size = new System.Drawing.Size(1081, 541);
            this.viewMakesList1.TabIndex = 3;
            this.viewMakesList1.Visible = false;
            // 
            // viewCarsList1
            // 
            this.viewCarsList1.AutoScroll = true;
            this.viewCarsList1.Dashboard = null;
            this.viewCarsList1.Dock = System.Windows.Forms.DockStyle.Top;
            this.viewCarsList1.Location = new System.Drawing.Point(0, 55);
            this.viewCarsList1.Name = "viewCarsList1";
            this.viewCarsList1.Size = new System.Drawing.Size(1081, 541);
            this.viewCarsList1.TabIndex = 2;
            // 
            // viewCars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.pnlUsers);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblTitle);
            this.Name = "viewCars";
            this.Size = new System.Drawing.Size(1125, 767);
            this.Load += new System.EventHandler(this.viewCars_Load);
            this.pnlUsers.ResumeLayout(false);
            this.pnlTabs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlUsers;
        private Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1;
        private Guna.UI2.WinForms.Guna2Panel pnlTabs;
        private Guna.UI2.WinForms.Guna2Button btnCarsTab;
        private Guna.UI2.WinForms.Guna2Button btnModelsTab;
        private Guna.UI2.WinForms.Guna2Button btnMakesTab;
        private viewCarsList viewCarsList1;
        private viewMakesList viewMakesList1;
        private viewModelsList viewModelsList1;
        private Guna.UI2.WinForms.Guna2Button btnFuelTypesTab;
        private Guna.UI2.WinForms.Guna2Button btnTransmissionTab;
        private Guna.UI2.WinForms.Guna2Button btnYearsTab;
        private viewYearsList viewYears1;
        private viewTransmissionsList viewTransmissionsList1;
        private viewFuelTypesList viewFuelTypesList1;
    }
}
