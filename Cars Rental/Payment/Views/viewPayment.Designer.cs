namespace Cars_Rental.Payment.Views
{
    partial class viewPayment
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
            this.pnlPayments = new Guna.UI2.WinForms.Guna2Panel();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.cbTypeFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlPayments.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(21, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(109, 34);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Payments";
            // 
            // pnlPayments
            // 
            this.pnlPayments.BackColor = System.Drawing.Color.White;
            this.pnlPayments.BorderRadius = 6;
            this.pnlPayments.BorderThickness = 1;
            this.pnlPayments.Controls.Add(this.table);
            this.pnlPayments.Location = new System.Drawing.Point(21, 63);
            this.pnlPayments.Name = "pnlPayments";
            this.pnlPayments.Size = new System.Drawing.Size(1081, 649);
            this.pnlPayments.TabIndex = 10;
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
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 260F));
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
            // cbTypeFilter
            // 
            this.cbTypeFilter.BackColor = System.Drawing.Color.Transparent;
            this.cbTypeFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTypeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeFilter.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbTypeFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbTypeFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbTypeFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbTypeFilter.ItemHeight = 30;
            this.cbTypeFilter.Items.AddRange(new object[] {
            "All",
            "Initial",
            "Return"});
            this.cbTypeFilter.Location = new System.Drawing.Point(929, 21);
            this.cbTypeFilter.Name = "cbTypeFilter";
            this.cbTypeFilter.Size = new System.Drawing.Size(173, 36);
            this.cbTypeFilter.TabIndex = 11;
            this.cbTypeFilter.SelectedIndexChanged += new System.EventHandler(this.cbTypeFilter_SelectedIndexChanged);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(844, 32);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(66, 15);
            this.guna2HtmlLabel1.TabIndex = 12;
            this.guna2HtmlLabel1.Text = "Filter by Type";
            // 
            // viewPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.cbTypeFilter);
            this.Controls.Add(this.pnlPayments);
            this.Controls.Add(this.lblTitle);
            this.Name = "viewPayment";
            this.Size = new System.Drawing.Size(1125, 767);
            this.pnlPayments.ResumeLayout(false);
            this.pnlPayments.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlPayments;
        private System.Windows.Forms.TableLayoutPanel table;
        private Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1;
        private Guna.UI2.WinForms.Guna2ComboBox cbTypeFilter;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}
