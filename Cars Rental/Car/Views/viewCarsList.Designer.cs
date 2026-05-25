namespace Cars_Rental.Car.Views
{
    partial class viewCarsList
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
            this.pnlCarsList = new Guna.UI2.WinForms.Guna2Panel();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.pnlCarsList.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCarsList
            // 
            this.pnlCarsList.Controls.Add(this.table);
            this.pnlCarsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCarsList.Location = new System.Drawing.Point(0, 0);
            this.pnlCarsList.Name = "pnlCarsList";
            this.pnlCarsList.Size = new System.Drawing.Size(1081, 541);
            this.pnlCarsList.TabIndex = 0;
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
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 259F));
            this.table.Dock = System.Windows.Forms.DockStyle.Top;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Name = "table";
            this.table.Padding = new System.Windows.Forms.Padding(10);
            this.table.RowCount = 1;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.53543F));
            this.table.Size = new System.Drawing.Size(1081, 20);
            this.table.TabIndex = 1;
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
            // viewCarsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlCarsList);
            this.Name = "viewCarsList";
            this.Size = new System.Drawing.Size(1081, 541);
            this.Load += new System.EventHandler(this.viewCarsList_Load);
            this.pnlCarsList.ResumeLayout(false);
            this.pnlCarsList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlCarsList;
        private System.Windows.Forms.TableLayoutPanel table;
        private Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1;
    }
}
