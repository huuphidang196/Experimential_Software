
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlinfoLoad = new System.Windows.Forms.Panel();
            this.lblStateSystem = new System.Windows.Forms.Label();
            this.lblNumberBusLoad = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlButtonControl = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.pnlTChar = new System.Windows.Forms.Panel();
            this.pnlProbability = new System.Windows.Forms.Panel();
            this.lblProbilityOfInstability = new System.Windows.Forms.Label();
            this.pnlTCharImage = new System.Windows.Forms.Panel();
            this.ptbClockWise = new System.Windows.Forms.PictureBox();
            this.ptbClockPercent = new System.Windows.Forms.PictureBox();
            this.pnlChar = new System.Windows.Forms.Panel();
            this.pnlListBoxPoints = new System.Windows.Forms.Panel();
            this.lstBoxExperPoint = new System.Windows.Forms.ListBox();
            this.pnlCharChild = new System.Windows.Forms.Panel();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.lblCmdReset = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.chartCurveLimted = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlinfoLoad.SuspendLayout();
            this.pnlButtonControl.SuspendLayout();
            this.pnlTChar.SuspendLayout();
            this.pnlProbability.SuspendLayout();
            this.pnlTCharImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbClockWise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbClockPercent)).BeginInit();
            this.pnlChar.SuspendLayout();
            this.pnlListBoxPoints.SuspendLayout();
            this.pnlCharChild.SuspendLayout();
            this.pnlProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCurveLimted)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.10856F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.89144F));
            this.tableLayoutPanel1.Controls.Add(this.pnlinfoLoad, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlButtonControl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlTChar, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlChar, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.6868F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.3132F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1133, 486);
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
            this.pnlinfoLoad.Size = new System.Drawing.Size(776, 89);
            this.pnlinfoLoad.TabIndex = 0;
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
            // lblNumberBusLoad
            // 
            this.lblNumberBusLoad.AutoSize = true;
            this.lblNumberBusLoad.Location = new System.Drawing.Point(360, 17);
            this.lblNumberBusLoad.Name = "lblNumberBusLoad";
            this.lblNumberBusLoad.Size = new System.Drawing.Size(24, 18);
            this.lblNumberBusLoad.TabIndex = 1;
            this.lblNumberBusLoad.Text = "25";
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
            // pnlButtonControl
            // 
            this.pnlButtonControl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlButtonControl.Controls.Add(this.btnCancel);
            this.pnlButtonControl.Controls.Add(this.btnPrint);
            this.pnlButtonControl.Controls.Add(this.btnReset);
            this.pnlButtonControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtonControl.Location = new System.Drawing.Point(785, 3);
            this.pnlButtonControl.Name = "pnlButtonControl";
            this.pnlButtonControl.Size = new System.Drawing.Size(345, 89);
            this.pnlButtonControl.TabIndex = 1;
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
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            this.btnReset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnReset_MouseDown);
            // 
            // pnlTChar
            // 
            this.pnlTChar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlTChar.Controls.Add(this.pnlProbability);
            this.pnlTChar.Controls.Add(this.pnlTCharImage);
            this.pnlTChar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTChar.Location = new System.Drawing.Point(785, 98);
            this.pnlTChar.Name = "pnlTChar";
            this.pnlTChar.Size = new System.Drawing.Size(345, 385);
            this.pnlTChar.TabIndex = 2;
            // 
            // pnlProbability
            // 
            this.pnlProbability.Controls.Add(this.lblProbilityOfInstability);
            this.pnlProbability.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlProbability.Location = new System.Drawing.Point(0, 299);
            this.pnlProbability.Name = "pnlProbability";
            this.pnlProbability.Size = new System.Drawing.Size(345, 86);
            this.pnlProbability.TabIndex = 1;
            // 
            // lblProbilityOfInstability
            // 
            this.lblProbilityOfInstability.AutoSize = true;
            this.lblProbilityOfInstability.Location = new System.Drawing.Point(63, 36);
            this.lblProbilityOfInstability.Name = "lblProbilityOfInstability";
            this.lblProbilityOfInstability.Size = new System.Drawing.Size(164, 18);
            this.lblProbilityOfInstability.TabIndex = 0;
            this.lblProbilityOfInstability.Text = "Xác suất mất ổn định : ";
            // 
            // pnlTCharImage
            // 
            this.pnlTCharImage.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlTCharImage.Controls.Add(this.ptbClockWise);
            this.pnlTCharImage.Controls.Add(this.ptbClockPercent);
            this.pnlTCharImage.Location = new System.Drawing.Point(0, 0);
            this.pnlTCharImage.Name = "pnlTCharImage";
            this.pnlTCharImage.Size = new System.Drawing.Size(345, 299);
            this.pnlTCharImage.TabIndex = 0;
            // 
            // ptbClockWise
            // 
            this.ptbClockWise.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbClockWise.BackColor = System.Drawing.Color.Transparent;
            this.ptbClockWise.Location = new System.Drawing.Point(101, 105);
            this.ptbClockWise.Name = "ptbClockWise";
            this.ptbClockWise.Size = new System.Drawing.Size(120, 120);
            this.ptbClockWise.TabIndex = 1;
            this.ptbClockWise.TabStop = false;
            this.ptbClockWise.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // ptbClockPercent
            // 
            this.ptbClockPercent.BackColor = System.Drawing.Color.Transparent;
            this.ptbClockPercent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbClockPercent.Image = global::Experimential_Software.Properties.Resources.Clock100;
            this.ptbClockPercent.Location = new System.Drawing.Point(0, 0);
            this.ptbClockPercent.Name = "ptbClockPercent";
            this.ptbClockPercent.Size = new System.Drawing.Size(345, 299);
            this.ptbClockPercent.TabIndex = 0;
            this.ptbClockPercent.TabStop = false;
            // 
            // pnlChar
            // 
            this.pnlChar.Controls.Add(this.pnlListBoxPoints);
            this.pnlChar.Controls.Add(this.pnlCharChild);
            this.pnlChar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChar.Location = new System.Drawing.Point(3, 98);
            this.pnlChar.Name = "pnlChar";
            this.pnlChar.Size = new System.Drawing.Size(776, 385);
            this.pnlChar.TabIndex = 3;
            // 
            // pnlListBoxPoints
            // 
            this.pnlListBoxPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlListBoxPoints.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlListBoxPoints.Controls.Add(this.lstBoxExperPoint);
            this.pnlListBoxPoints.Location = new System.Drawing.Point(646, 0);
            this.pnlListBoxPoints.Name = "pnlListBoxPoints";
            this.pnlListBoxPoints.Size = new System.Drawing.Size(130, 385);
            this.pnlListBoxPoints.TabIndex = 4;
            // 
            // lstBoxExperPoint
            // 
            this.lstBoxExperPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBoxExperPoint.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxExperPoint.FormattingEnabled = true;
            this.lstBoxExperPoint.Location = new System.Drawing.Point(0, 0);
            this.lstBoxExperPoint.Name = "lstBoxExperPoint";
            this.lstBoxExperPoint.Size = new System.Drawing.Size(128, 383);
            this.lstBoxExperPoint.TabIndex = 0;
            // 
            // pnlCharChild
            // 
            this.pnlCharChild.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlCharChild.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCharChild.Controls.Add(this.pnlProgress);
            this.pnlCharChild.Controls.Add(this.chartCurveLimted);
            this.pnlCharChild.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCharChild.Location = new System.Drawing.Point(0, 0);
            this.pnlCharChild.Name = "pnlCharChild";
            this.pnlCharChild.Size = new System.Drawing.Size(640, 385);
            this.pnlCharChild.TabIndex = 3;
            // 
            // pnlProgress
            // 
            this.pnlProgress.Controls.Add(this.lblCmdReset);
            this.pnlProgress.Controls.Add(this.lblProgress);
            this.pnlProgress.Location = new System.Drawing.Point(179, 141);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(282, 83);
            this.pnlProgress.TabIndex = 2;
            // 
            // lblCmdReset
            // 
            this.lblCmdReset.AutoSize = true;
            this.lblCmdReset.Location = new System.Drawing.Point(20, 32);
            this.lblCmdReset.Name = "lblCmdReset";
            this.lblCmdReset.Size = new System.Drawing.Size(245, 18);
            this.lblCmdReset.TabIndex = 1;
            this.lblCmdReset.Text = "Press Reset Button To Drawn Curve";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(49, 32);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(170, 18);
            this.lblProgress.TabIndex = 0;
            this.lblProgress.Text = "Program is Processing ...";
            // 
            // chartCurveLimted
            // 
            this.chartCurveLimted.BackColor = System.Drawing.Color.Gainsboro;
            this.chartCurveLimted.BorderlineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.Name = "ChartArea1";
            this.chartCurveLimted.ChartAreas.Add(chartArea1);
            this.chartCurveLimted.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartCurveLimted.Legends.Add(legend1);
            this.chartCurveLimted.Location = new System.Drawing.Point(0, 0);
            this.chartCurveLimted.Name = "chartCurveLimted";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartCurveLimted.Series.Add(series1);
            this.chartCurveLimted.Size = new System.Drawing.Size(638, 383);
            this.chartCurveLimted.TabIndex = 1;
            this.chartCurveLimted.Text = "Miền làm ciệc ổn định trong mặt phẳng công suất P-Q";
            // 
            // frmDrawnCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 486);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
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
            this.pnlTCharImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbClockWise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbClockPercent)).EndInit();
            this.pnlChar.ResumeLayout(false);
            this.pnlListBoxPoints.ResumeLayout(false);
            this.pnlCharChild.ResumeLayout(false);
            this.pnlProgress.ResumeLayout(false);
            this.pnlProgress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCurveLimted)).EndInit();
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
        private System.Windows.Forms.Label lblProbilityOfInstability;
        private System.Windows.Forms.Panel pnlChar;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCurveLimted;
        private System.Windows.Forms.ListBox lstBoxExperPoint;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.Panel pnlListBoxPoints;
        private System.Windows.Forms.Panel pnlCharChild;
        private System.Windows.Forms.Label lblCmdReset;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.PictureBox ptbClockPercent;
        private System.Windows.Forms.PictureBox ptbClockWise;
    }
}