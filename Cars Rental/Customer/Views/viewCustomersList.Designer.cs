namespace Cars_Rental.Customer.Views
{
    partial class viewCustomersList
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
            this.btnAddCustomer = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlCustomers = new Guna.UI2.WinForms.Guna2Panel();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.pnlCustomers.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Animated = true;
            this.btnAddCustomer.BorderRadius = 8;
            this.btnAddCustomer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddCustomer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddCustomer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(125)))), ((int)(((byte)(243)))));
            this.btnAddCustomer.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCustomer.ForeColor = System.Drawing.Color.White;
            this.btnAddCustomer.Location = new System.Drawing.Point(939, 19);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(164, 40);
            this.btnAddCustomer.TabIndex = 8;
            this.btnAddCustomer.Text = "Add Customer";
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click_1);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(21, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(118, 34);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "Customers";
            // 
            // pnlCustomers
            // 
            this.pnlCustomers.BackColor = System.Drawing.Color.White;
            this.pnlCustomers.BorderRadius = 6;
            this.pnlCustomers.BorderThickness = 1;
            this.pnlCustomers.Controls.Add(this.table);
            this.pnlCustomers.Location = new System.Drawing.Point(21, 77);
            this.pnlCustomers.Name = "pnlCustomers";
            this.pnlCustomers.Size = new System.Drawing.Size(1081, 605);
            this.pnlCustomers.TabIndex = 9;
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
            // guna2MessageDialog1
            // 
            this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.guna2MessageDialog1.Caption = null;
            this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.None;
            this.guna2MessageDialog1.Parent = null;
            this.guna2MessageDialog1.Style = Guna.UI2.WinForms.MessageDialogStyle.Default;
            this.guna2MessageDialog1.Text = null;
            // 
            // viewCustomersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlCustomers);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.lblTitle);
            this.Name = "viewCustomersList";
            this.Size = new System.Drawing.Size(1125, 767);
            this.Load += new System.EventHandler(this.viewCustomersList_Load);
            this.pnlCustomers.ResumeLayout(false);
            this.pnlCustomers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnAddCustomer;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlCustomers;
        private System.Windows.Forms.TableLayoutPanel table;
        private Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1;
    }
}
