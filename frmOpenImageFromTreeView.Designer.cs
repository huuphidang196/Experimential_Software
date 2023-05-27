
namespace Experimential_Software
{
    partial class frmOpenImageFromTreeView
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
            this.ptbImagePrinted = new System.Windows.Forms.PictureBox();
            this.pnlImage = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImagePrinted)).BeginInit();
            this.pnlImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // ptbImagePrinted
            // 
            this.ptbImagePrinted.BackColor = System.Drawing.Color.Transparent;
            this.ptbImagePrinted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbImagePrinted.Location = new System.Drawing.Point(0, 0);
            this.ptbImagePrinted.Name = "ptbImagePrinted";
            this.ptbImagePrinted.Size = new System.Drawing.Size(836, 435);
            this.ptbImagePrinted.TabIndex = 0;
            this.ptbImagePrinted.TabStop = false;
            this.ptbImagePrinted.SizeChanged += new System.EventHandler(this.ptbImagePrinted_SizeChanged);
            // 
            // pnlImage
            // 
            this.pnlImage.BackColor = System.Drawing.Color.Transparent;
            this.pnlImage.Controls.Add(this.ptbImagePrinted);
            this.pnlImage.Location = new System.Drawing.Point(23, 25);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(836, 435);
            this.pnlImage.TabIndex = 1;
            // 
            // frmOpenImageFromTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(891, 499);
            this.Controls.Add(this.pnlImage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmOpenImageFromTreeView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form Image";
            this.Load += new System.EventHandler(this.frmOpenImageFromTreeView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbImagePrinted)).EndInit();
            this.pnlImage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbImagePrinted;
        private System.Windows.Forms.Panel pnlImage;
    }
}