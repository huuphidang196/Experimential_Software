
namespace Experimential_Software
{
    partial class frmFixedTapChanger
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
            this.grbTapSetting = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCountTap = new System.Windows.Forms.TextBox();
            this.txtMaxEnds = new System.Windows.Forms.TextBox();
            this.txtMinEnds = new System.Windows.Forms.TextBox();
            this.lblTapTransMin = new System.Windows.Forms.Label();
            this.lblTapTransMax = new System.Windows.Forms.Label();
            this.lblTapTransStep = new System.Windows.Forms.Label();
            this.lblStepTC = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTransUnitRanger = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTCUnitRanger = new System.Windows.Forms.Button();
            this.btnOkTapRanger = new System.Windows.Forms.Button();
            this.btnCanceltapRanger = new System.Windows.Forms.Button();
            this.grbTapSetting.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbTapSetting
            // 
            this.grbTapSetting.Controls.Add(this.groupBox1);
            this.grbTapSetting.Location = new System.Drawing.Point(24, 23);
            this.grbTapSetting.Margin = new System.Windows.Forms.Padding(4);
            this.grbTapSetting.Name = "grbTapSetting";
            this.grbTapSetting.Size = new System.Drawing.Size(324, 305);
            this.grbTapSetting.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCountTap);
            this.groupBox1.Controls.Add(this.txtMaxEnds);
            this.groupBox1.Controls.Add(this.txtMinEnds);
            this.groupBox1.Controls.Add(this.lblTapTransMin);
            this.groupBox1.Controls.Add(this.lblTapTransMax);
            this.groupBox1.Controls.Add(this.lblTapTransStep);
            this.groupBox1.Controls.Add(this.lblStepTC);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblTransUnitRanger);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnTCUnitRanger);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(324, 305);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tap Settings";
            // 
            // txtCountTap
            // 
            this.txtCountTap.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCountTap.Location = new System.Drawing.Point(117, 252);
            this.txtCountTap.Name = "txtCountTap";
            this.txtCountTap.Size = new System.Drawing.Size(44, 24);
            this.txtCountTap.TabIndex = 3;
            this.txtCountTap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckKeyPressIsNumber);
            this.txtCountTap.Leave += new System.EventHandler(this.TextLeaveEvent);
            // 
            // txtMaxEnds
            // 
            this.txtMaxEnds.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxEnds.Location = new System.Drawing.Point(105, 135);
            this.txtMaxEnds.Name = "txtMaxEnds";
            this.txtMaxEnds.Size = new System.Drawing.Size(75, 24);
            this.txtMaxEnds.TabIndex = 2;
            this.txtMaxEnds.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckKeyPressIsNumber);
            this.txtMaxEnds.Leave += new System.EventHandler(this.TextLeaveEvent);
            // 
            // txtMinEnds
            // 
            this.txtMinEnds.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinEnds.Location = new System.Drawing.Point(105, 83);
            this.txtMinEnds.Name = "txtMinEnds";
            this.txtMinEnds.Size = new System.Drawing.Size(75, 24);
            this.txtMinEnds.TabIndex = 1;
            this.txtMinEnds.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckKeyPressIsNumber);
            this.txtMinEnds.Leave += new System.EventHandler(this.TextLeaveEvent);
            // 
            // lblTapTransMin
            // 
            this.lblTapTransMin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTapTransMin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTapTransMin.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTapTransMin.Location = new System.Drawing.Point(216, 80);
            this.lblTapTransMin.Name = "lblTapTransMin";
            this.lblTapTransMin.Size = new System.Drawing.Size(75, 29);
            this.lblTapTransMin.TabIndex = 1;
            this.lblTapTransMin.Text = "12.365";
            this.lblTapTransMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTapTransMax
            // 
            this.lblTapTransMax.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTapTransMax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTapTransMax.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTapTransMax.Location = new System.Drawing.Point(216, 132);
            this.lblTapTransMax.Name = "lblTapTransMax";
            this.lblTapTransMax.Size = new System.Drawing.Size(75, 29);
            this.lblTapTransMax.TabIndex = 1;
            this.lblTapTransMax.Text = "12.365";
            this.lblTapTransMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTapTransStep
            // 
            this.lblTapTransStep.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTapTransStep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTapTransStep.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTapTransStep.Location = new System.Drawing.Point(216, 196);
            this.lblTapTransStep.Name = "lblTapTransStep";
            this.lblTapTransStep.Size = new System.Drawing.Size(75, 29);
            this.lblTapTransStep.TabIndex = 1;
            this.lblTapTransStep.Text = "12.365";
            this.lblTapTransStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStepTC
            // 
            this.lblStepTC.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblStepTC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStepTC.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStepTC.Location = new System.Drawing.Point(102, 196);
            this.lblStepTC.Name = "lblStepTC";
            this.lblStepTC.Size = new System.Drawing.Size(75, 29);
            this.lblStepTC.TabIndex = 1;
            this.lblStepTC.Text = "12.365";
            this.lblStepTC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "# of Tabs";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Step";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Max.";
            // 
            // lblTransUnitRanger
            // 
            this.lblTransUnitRanger.AutoSize = true;
            this.lblTransUnitRanger.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransUnitRanger.Location = new System.Drawing.Point(228, 42);
            this.lblTransUnitRanger.Name = "lblTransUnitRanger";
            this.lblTransUnitRanger.Size = new System.Drawing.Size(50, 17);
            this.lblTransUnitRanger.TabIndex = 1;
            this.lblTransUnitRanger.Text = "kv Tap";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Min.";
            // 
            // btnTCUnitRanger
            // 
            this.btnTCUnitRanger.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTCUnitRanger.Location = new System.Drawing.Point(105, 36);
            this.btnTCUnitRanger.Name = "btnTCUnitRanger";
            this.btnTCUnitRanger.Size = new System.Drawing.Size(75, 29);
            this.btnTCUnitRanger.TabIndex = 0;
            this.btnTCUnitRanger.Text = "% Tap";
            this.btnTCUnitRanger.UseVisualStyleBackColor = true;
            this.btnTCUnitRanger.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTCUnitRanger_MouseDown);
            // 
            // btnOkTapRanger
            // 
            this.btnOkTapRanger.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOkTapRanger.Location = new System.Drawing.Point(84, 353);
            this.btnOkTapRanger.Name = "btnOkTapRanger";
            this.btnOkTapRanger.Size = new System.Drawing.Size(75, 29);
            this.btnOkTapRanger.TabIndex = 0;
            this.btnOkTapRanger.Text = "OK";
            this.btnOkTapRanger.UseVisualStyleBackColor = true;
            this.btnOkTapRanger.Click += new System.EventHandler(this.btnOkTapRanger_Click);
            // 
            // btnCanceltapRanger
            // 
            this.btnCanceltapRanger.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCanceltapRanger.Location = new System.Drawing.Point(203, 353);
            this.btnCanceltapRanger.Name = "btnCanceltapRanger";
            this.btnCanceltapRanger.Size = new System.Drawing.Size(75, 29);
            this.btnCanceltapRanger.TabIndex = 1;
            this.btnCanceltapRanger.Text = "Cancel";
            this.btnCanceltapRanger.UseVisualStyleBackColor = true;
            this.btnCanceltapRanger.Click += new System.EventHandler(this.btnCanceltapRanger_Click);
            // 
            // frmFixedTapChanger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 404);
            this.Controls.Add(this.grbTapSetting);
            this.Controls.Add(this.btnCanceltapRanger);
            this.Controls.Add(this.btnOkTapRanger);
            this.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFixedTapChanger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tap Ranger Fixed";
            this.Load += new System.EventHandler(this.frmFixedTapChanger_Load);
            this.grbTapSetting.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel grbTapSetting;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOkTapRanger;
        private System.Windows.Forms.Button btnCanceltapRanger;
        public System.Windows.Forms.Label lblStepTC;
        public System.Windows.Forms.Button btnTCUnitRanger;
        public System.Windows.Forms.TextBox txtMaxEnds;
        public System.Windows.Forms.TextBox txtMinEnds;
        public System.Windows.Forms.Label lblTransUnitRanger;
        public System.Windows.Forms.Label lblTapTransMin;
        public System.Windows.Forms.Label lblTapTransMax;
        public System.Windows.Forms.Label lblTapTransStep;
        public System.Windows.Forms.TextBox txtCountTap;
    }
}