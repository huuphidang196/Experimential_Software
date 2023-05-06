
namespace Experimential_Software
{
    partial class frmDrawnCurve
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlinfoLoad = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumberBusLoad = new System.Windows.Forms.Label();
            this.lblStateSystem = new System.Windows.Forms.Label();
            this.pnlButtonControl = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlTChar = new System.Windows.Forms.Panel();
            this.pnlTCharImage = new System.Windows.Forms.Panel();
            this.pnlProbability = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblProbability = new System.Windows.Forms.Label();
            this.lstBoxExperPoint = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlinfoLoad.SuspendLayout();
            this.pnlButtonControl.SuspendLayout();
            this.pnlTChar.SuspendLayout();
            this.pnlProbability.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.03462F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.96538F));
            this.tableLayoutPanel1.Controls.Add(this.pnlinfoLoad, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlButtonControl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlTChar, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstBoxExperPoint, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.6868F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.3132F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(982, 486);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlinfoLoad
            // 
            this.pnlinfoLoad.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlinfoLoad.Controls.Add(this.lblStateSystem);
            this.pnlinfoLoad.Controls.Add(this.lblNumberBusLoad);
            this.pnlinfoLoad.Controls.Add(this.label1);
            this.pnlinfoLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlinfoLoad.Location = new System.Drawing.Point(3, 3);
            this.pnlinfoLoad.Name = "pnlinfoLoad";
            this.pnlinfoLoad.Size = new System.Drawing.Size(612, 89);
            this.pnlinfoLoad.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(165, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Xét ổn định tại nút phụ tải :";
            // 
            // lblNumberBusLoad
            // 
            this.lblNumberBusLoad.AutoSize = true;
            this.lblNumberBusLoad.Location = new System.Drawing.Point(360, 17);
            this.lblNumberBusLoad.Name = "lblNumberBusLoad";
            this.lblNumberBusLoad.Size = new System.Drawing.Size(24, 18);
            this.lblNumberBusLoad.TabIndex = 1;
            this.lblNumberBusLoad.Text = "25";
            // 
            // lblStateSystem
            // 
            this.lblStateSystem.AutoSize = true;
            this.lblStateSystem.ForeColor = System.Drawing.Color.Navy;
            this.lblStateSystem.Location = new System.Drawing.Point(162, 46);
            this.lblStateSystem.Name = "lblStateSystem";
            this.lblStateSystem.Size = new System.Drawing.Size(217, 18);
            this.lblStateSystem.TabIndex = 2;
            this.lblStateSystem.Text = "Hệ thống đang làm việc ổn định";
            // 
            // pnlButtonControl
            // 
            this.pnlButtonControl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlButtonControl.Controls.Add(this.btnCancel);
            this.pnlButtonControl.Controls.Add(this.btnPrint);
            this.pnlButtonControl.Controls.Add(this.btnReset);
            this.pnlButtonControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtonControl.Location = new System.Drawing.Point(621, 3);
            this.pnlButtonControl.Name = "pnlButtonControl";
            this.pnlButtonControl.Size = new System.Drawing.Size(358, 89);
            this.pnlButtonControl.TabIndex = 1;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(27, 30);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(90, 30);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(140, 30);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(90, 30);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(249, 30);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // pnlTChar
            // 
            this.pnlTChar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlTChar.Controls.Add(this.pnlProbability);
            this.pnlTChar.Controls.Add(this.pnlTCharImage);
            this.pnlTChar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTChar.Location = new System.Drawing.Point(621, 98);
            this.pnlTChar.Name = "pnlTChar";
            this.pnlTChar.Size = new System.Drawing.Size(358, 385);
            this.pnlTChar.TabIndex = 2;
            // 
            // pnlTCharImage
            // 
            this.pnlTCharImage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTCharImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTCharImage.Location = new System.Drawing.Point(0, 0);
            this.pnlTCharImage.Name = "pnlTCharImage";
            this.pnlTCharImage.Size = new System.Drawing.Size(358, 299);
            this.pnlTCharImage.TabIndex = 0;
            // 
            // pnlProbability
            // 
            this.pnlProbability.Controls.Add(this.label2);
            this.pnlProbability.Controls.Add(this.lblProbability);
            this.pnlProbability.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProbability.Location = new System.Drawing.Point(0, 299);
            this.pnlProbability.Name = "pnlProbability";
            this.pnlProbability.Size = new System.Drawing.Size(358, 86);
            this.pnlProbability.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Xác suất mất ổn định : ";
            // 
            // lblProbability
            // 
            this.lblProbability.AutoSize = true;
            this.lblProbability.Location = new System.Drawing.Point(233, 36);
            this.lblProbability.Name = "lblProbability";
            this.lblProbability.Size = new System.Drawing.Size(39, 18);
            this.lblProbability.TabIndex = 1;
            this.lblProbability.Text = "25%";
            // 
            // lstBoxExperPoint
            // 
            this.lstBoxExperPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBoxExperPoint.FormattingEnabled = true;
            this.lstBoxExperPoint.ItemHeight = 18;
            this.lstBoxExperPoint.Location = new System.Drawing.Point(3, 98);
            this.lstBoxExperPoint.Name = "lstBoxExperPoint";
            this.lstBoxExperPoint.Size = new System.Drawing.Size(612, 385);
            this.lstBoxExperPoint.TabIndex = 3;
            // 
            // frmDrawnCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 486);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmDrawnCurve";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Working domain allows conditional static stability limit ";
            this.Load += new System.EventHandler(this.frmDrawnCurve_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlinfoLoad.ResumeLayout(false);
            this.pnlinfoLoad.PerformLayout();
            this.pnlButtonControl.ResumeLayout(false);
            this.pnlTChar.ResumeLayout(false);
            this.pnlProbability.ResumeLayout(false);
            this.pnlProbability.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlinfoLoad;
        private System.Windows.Forms.Label lblNumberBusLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStateSystem;
        private System.Windows.Forms.Panel pnlButtonControl;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlTChar;
        private System.Windows.Forms.Panel pnlTCharImage;
        private System.Windows.Forms.Panel pnlProbability;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblProbability;
        private System.Windows.Forms.ListBox lstBoxExperPoint;
    }
}