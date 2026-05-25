namespace Cars_Rental.Shared.Controls
{
    partial class ctrlImageUploader
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlEmptyState = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnRemoveImage = new Guna.UI2.WinForms.Guna2Button();
            this.btnUploadImage = new Guna.UI2.WinForms.Guna2Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.pnlEmptyState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderRadius = 12;
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel2);
            this.guna2Panel1.Controls.Add(this.btnRemoveImage);
            this.guna2Panel1.Controls.Add(this.btnUploadImage);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(399, 217);
            this.guna2Panel1.TabIndex = 0;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(221)))), ((int)(((byte)(234)))));
            this.guna2Panel2.BorderRadius = 12;
            this.guna2Panel2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.pnlEmptyState);
            this.guna2Panel2.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(245)))));
            this.guna2Panel2.Location = new System.Drawing.Point(15, 48);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(365, 100);
            this.guna2Panel2.TabIndex = 4;
            // 
            // pnlEmptyState
            // 
            this.pnlEmptyState.BackColor = System.Drawing.Color.Transparent;
            this.pnlEmptyState.Controls.Add(this.guna2HtmlLabel1);
            this.pnlEmptyState.Controls.Add(this.iconPictureBox1);
            this.pnlEmptyState.Location = new System.Drawing.Point(86, 21);
            this.pnlEmptyState.Name = "pnlEmptyState";
            this.pnlEmptyState.Size = new System.Drawing.Size(215, 59);
            this.pnlEmptyState.TabIndex = 1;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(137)))), ((int)(((byte)(166)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(85, 18);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(78, 23);
            this.guna2HtmlLabel1.TabIndex = 4;
            this.guna2HtmlLabel1.Text = "No Image";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(15, 3);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(103, 22);
            this.guna2HtmlLabel2.TabIndex = 3;
            this.guna2HtmlLabel2.Text = "Image Preview";
            // 
            // btnRemoveImage
            // 
            this.btnRemoveImage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(229)))));
            this.btnRemoveImage.BorderRadius = 8;
            this.btnRemoveImage.BorderThickness = 1;
            this.btnRemoveImage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRemoveImage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRemoveImage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRemoveImage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRemoveImage.FillColor = System.Drawing.Color.White;
            this.btnRemoveImage.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.btnRemoveImage.Location = new System.Drawing.Point(203, 154);
            this.btnRemoveImage.Name = "btnRemoveImage";
            this.btnRemoveImage.Size = new System.Drawing.Size(177, 45);
            this.btnRemoveImage.TabIndex = 2;
            this.btnRemoveImage.Text = "Remove";
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.BorderRadius = 8;
            this.btnUploadImage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUploadImage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUploadImage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUploadImage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUploadImage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(125)))), ((int)(((byte)(255)))));
            this.btnUploadImage.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadImage.ForeColor = System.Drawing.Color.White;
            this.btnUploadImage.Location = new System.Drawing.Point(15, 154);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(177, 45);
            this.btnUploadImage.TabIndex = 1;
            this.btnUploadImage.Text = "Upload Image";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(173)))), ((int)(((byte)(196)))));
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Image;
            this.iconPictureBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(173)))), ((int)(((byte)(196)))));
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 34;
            this.iconPictureBox1.Location = new System.Drawing.Point(25, 13);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox1.TabIndex = 0;
            this.iconPictureBox1.TabStop = false;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Padding = new System.Windows.Forms.Padding(10);
            this.guna2PictureBox1.Size = new System.Drawing.Size(365, 100);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // ctrlImageUploader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "ctrlImageUploader";
            this.Size = new System.Drawing.Size(399, 217);
            this.Load += new System.EventHandler(this.ctrlImageUploader_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.pnlEmptyState.ResumeLayout(false);
            this.pnlEmptyState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnRemoveImage;
        private Guna.UI2.WinForms.Guna2Button btnUploadImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Panel pnlEmptyState;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
    }
}
