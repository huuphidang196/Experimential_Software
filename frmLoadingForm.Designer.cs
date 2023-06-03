
namespace Experimential_Software
{
    partial class frmLoadingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoadingForm));
            this.pgrBarLoading = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timerLoading = new System.Windows.Forms.Timer(this.components);
            this.lblPercentLoading = new System.Windows.Forms.Label();
            this.ptbImageLoading = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImageLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // pgrBarLoading
            // 
            this.pgrBarLoading.ForeColor = System.Drawing.Color.DodgerBlue;
            this.pgrBarLoading.Location = new System.Drawing.Point(46, 173);
            this.pgrBarLoading.Name = "pgrBarLoading";
            this.pgrBarLoading.Size = new System.Drawing.Size(318, 14);
            this.pgrBarLoading.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgrBarLoading.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblPercentLoading);
            this.panel1.Controls.Add(this.pgrBarLoading);
            this.panel1.Controls.Add(this.ptbImageLoading);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 206);
            this.panel1.TabIndex = 1;
            // 
            // timerLoading
            // 
            this.timerLoading.Interval = 10;
            this.timerLoading.Tick += new System.EventHandler(this.timerLoading_Tick);
            // 
            // lblPercentLoading
            // 
            this.lblPercentLoading.AutoSize = true;
            this.lblPercentLoading.BackColor = System.Drawing.Color.Transparent;
            this.lblPercentLoading.Location = new System.Drawing.Point(250, 150);
            this.lblPercentLoading.Name = "lblPercentLoading";
            this.lblPercentLoading.Size = new System.Drawing.Size(72, 18);
            this.lblPercentLoading.TabIndex = 1;
            this.lblPercentLoading.Text = "Loading...";
            // 
            // ptbImageLoading
            // 
            this.ptbImageLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbImageLoading.Location = new System.Drawing.Point(0, 0);
            this.ptbImageLoading.Name = "ptbImageLoading";
            this.ptbImageLoading.Size = new System.Drawing.Size(433, 206);
            this.ptbImageLoading.TabIndex = 2;
            this.ptbImageLoading.TabStop = false;
            // 
            // frmLoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 206);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoadingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmLoadingForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImageLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgrBarLoading;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timerLoading;
        private System.Windows.Forms.Label lblPercentLoading;
        private System.Windows.Forms.PictureBox ptbImageLoading;
    }
}