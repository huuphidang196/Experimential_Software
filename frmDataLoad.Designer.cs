
namespace Experimential_Software
{
    partial class frmDataLoad
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
            this.tabCtrlLoad = new System.Windows.Forms.TabControl();
            this.tabPowerFlow = new System.Windows.Forms.TabPage();
            this.pnlPowerFlowSub1 = new System.Windows.Forms.Panel();
            this.grbLoadData = new System.Windows.Forms.GroupBox();
            this.txtYQLoad = new System.Windows.Forms.TextBox();
            this.txtIQLoad = new System.Windows.Forms.TextBox();
            this.txtQLoad = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtYLoad = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIPLoad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPLoad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grbBasicData = new System.Windows.Forms.GroupBox();
            this.chkInterruptible = new System.Windows.Forms.CheckBox();
            this.chkScalable = new System.Windows.Forms.CheckBox();
            this.chkInService = new System.Windows.Forms.CheckBox();
            this.txtLoadID = new System.Windows.Forms.TextBox();
            this.lblBusNameConn = new System.Windows.Forms.Label();
            this.lblBusNumberConn = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOKLoad = new System.Windows.Forms.Button();
            this.btnCancelLoad = new System.Windows.Forms.Button();
            this.tabCtrlLoad.SuspendLayout();
            this.tabPowerFlow.SuspendLayout();
            this.pnlPowerFlowSub1.SuspendLayout();
            this.grbLoadData.SuspendLayout();
            this.grbBasicData.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCtrlLoad
            // 
            this.tabCtrlLoad.Controls.Add(this.tabPowerFlow);
            this.tabCtrlLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrlLoad.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCtrlLoad.Location = new System.Drawing.Point(0, 0);
            this.tabCtrlLoad.Name = "tabCtrlLoad";
            this.tabCtrlLoad.SelectedIndex = 0;
            this.tabCtrlLoad.Size = new System.Drawing.Size(439, 482);
            this.tabCtrlLoad.TabIndex = 0;
            // 
            // tabPowerFlow
            // 
            this.tabPowerFlow.BackColor = System.Drawing.Color.Transparent;
            this.tabPowerFlow.Controls.Add(this.pnlPowerFlowSub1);
            this.tabPowerFlow.Location = new System.Drawing.Point(4, 27);
            this.tabPowerFlow.Name = "tabPowerFlow";
            this.tabPowerFlow.Padding = new System.Windows.Forms.Padding(3);
            this.tabPowerFlow.Size = new System.Drawing.Size(431, 451);
            this.tabPowerFlow.TabIndex = 0;
            this.tabPowerFlow.Text = "Power Flow";
            // 
            // pnlPowerFlowSub1
            // 
            this.pnlPowerFlowSub1.Controls.Add(this.grbLoadData);
            this.pnlPowerFlowSub1.Controls.Add(this.grbBasicData);
            this.pnlPowerFlowSub1.Location = new System.Drawing.Point(6, 6);
            this.pnlPowerFlowSub1.Name = "pnlPowerFlowSub1";
            this.pnlPowerFlowSub1.Size = new System.Drawing.Size(410, 439);
            this.pnlPowerFlowSub1.TabIndex = 1;
            // 
            // grbLoadData
            // 
            this.grbLoadData.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grbLoadData.Controls.Add(this.txtYQLoad);
            this.grbLoadData.Controls.Add(this.txtIQLoad);
            this.grbLoadData.Controls.Add(this.txtQLoad);
            this.grbLoadData.Controls.Add(this.label10);
            this.grbLoadData.Controls.Add(this.label8);
            this.grbLoadData.Controls.Add(this.label6);
            this.grbLoadData.Controls.Add(this.txtYLoad);
            this.grbLoadData.Controls.Add(this.label9);
            this.grbLoadData.Controls.Add(this.txtIPLoad);
            this.grbLoadData.Controls.Add(this.label7);
            this.grbLoadData.Controls.Add(this.txtPLoad);
            this.grbLoadData.Controls.Add(this.label5);
            this.grbLoadData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grbLoadData.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbLoadData.Location = new System.Drawing.Point(0, 169);
            this.grbLoadData.Name = "grbLoadData";
            this.grbLoadData.Size = new System.Drawing.Size(410, 270);
            this.grbLoadData.TabIndex = 1;
            this.grbLoadData.TabStop = false;
            this.grbLoadData.Text = "Load Data";
            // 
            // txtYQLoad
            // 
            this.txtYQLoad.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYQLoad.Location = new System.Drawing.Point(230, 228);
            this.txtYQLoad.Name = "txtYQLoad";
            this.txtYQLoad.Size = new System.Drawing.Size(158, 23);
            this.txtYQLoad.TabIndex = 5;
            this.txtYQLoad.Text = "0.0000";
            this.txtYQLoad.Leave += new System.EventHandler(this.EventTextDataInputIsNotNumber);
            // 
            // txtIQLoad
            // 
            this.txtIQLoad.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIQLoad.Location = new System.Drawing.Point(231, 151);
            this.txtIQLoad.Name = "txtIQLoad";
            this.txtIQLoad.Size = new System.Drawing.Size(158, 23);
            this.txtIQLoad.TabIndex = 3;
            this.txtIQLoad.Text = "0.0000";
            this.txtIQLoad.Leave += new System.EventHandler(this.EventTextDataInputIsNotNumber);
            // 
            // txtQLoad
            // 
            this.txtQLoad.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQLoad.Location = new System.Drawing.Point(230, 68);
            this.txtQLoad.Name = "txtQLoad";
            this.txtQLoad.Size = new System.Drawing.Size(158, 23);
            this.txtQLoad.TabIndex = 1;
            this.txtQLoad.Text = "0.0000";
            this.txtQLoad.Leave += new System.EventHandler(this.EventTextDataInputIsNotNumber);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(228, 196);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "YQload (Mvar)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(229, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "IQload (Mvar)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(228, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Qload (Mvar)";
            // 
            // txtYLoad
            // 
            this.txtYLoad.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYLoad.Location = new System.Drawing.Point(15, 228);
            this.txtYLoad.Name = "txtYLoad";
            this.txtYLoad.Size = new System.Drawing.Size(158, 23);
            this.txtYLoad.TabIndex = 4;
            this.txtYLoad.Text = "0.0000";
            this.txtYLoad.Leave += new System.EventHandler(this.EventTextDataInputIsNotNumber);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 196);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "YPload (Mw)";
            // 
            // txtIPLoad
            // 
            this.txtIPLoad.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIPLoad.Location = new System.Drawing.Point(16, 151);
            this.txtIPLoad.Name = "txtIPLoad";
            this.txtIPLoad.Size = new System.Drawing.Size(158, 23);
            this.txtIPLoad.TabIndex = 2;
            this.txtIPLoad.Text = "0.0000";
            this.txtIPLoad.Leave += new System.EventHandler(this.EventTextDataInputIsNotNumber);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "IPload (Mw)";
            // 
            // txtPLoad
            // 
            this.txtPLoad.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPLoad.Location = new System.Drawing.Point(15, 68);
            this.txtPLoad.Name = "txtPLoad";
            this.txtPLoad.Size = new System.Drawing.Size(158, 23);
            this.txtPLoad.TabIndex = 0;
            this.txtPLoad.Text = "0.0000";
            this.txtPLoad.Leave += new System.EventHandler(this.EventTextDataInputIsNotNumber);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Pload (Mw)";
            // 
            // grbBasicData
            // 
            this.grbBasicData.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grbBasicData.Controls.Add(this.chkInterruptible);
            this.grbBasicData.Controls.Add(this.chkScalable);
            this.grbBasicData.Controls.Add(this.chkInService);
            this.grbBasicData.Controls.Add(this.txtLoadID);
            this.grbBasicData.Controls.Add(this.lblBusNameConn);
            this.grbBasicData.Controls.Add(this.lblBusNumberConn);
            this.grbBasicData.Controls.Add(this.label2);
            this.grbBasicData.Controls.Add(this.label4);
            this.grbBasicData.Controls.Add(this.label1);
            this.grbBasicData.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbBasicData.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBasicData.Location = new System.Drawing.Point(0, 0);
            this.grbBasicData.Name = "grbBasicData";
            this.grbBasicData.Size = new System.Drawing.Size(410, 163);
            this.grbBasicData.TabIndex = 0;
            this.grbBasicData.TabStop = false;
            this.grbBasicData.Text = "Basic Data";
            // 
            // chkInterruptible
            // 
            this.chkInterruptible.AutoSize = true;
            this.chkInterruptible.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInterruptible.Location = new System.Drawing.Point(291, 123);
            this.chkInterruptible.Name = "chkInterruptible";
            this.chkInterruptible.Size = new System.Drawing.Size(97, 20);
            this.chkInterruptible.TabIndex = 5;
            this.chkInterruptible.Text = "Interruptible";
            this.chkInterruptible.UseVisualStyleBackColor = true;
            // 
            // chkScalable
            // 
            this.chkScalable.AutoSize = true;
            this.chkScalable.Checked = true;
            this.chkScalable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkScalable.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkScalable.Location = new System.Drawing.Point(206, 123);
            this.chkScalable.Name = "chkScalable";
            this.chkScalable.Size = new System.Drawing.Size(75, 20);
            this.chkScalable.TabIndex = 4;
            this.chkScalable.Text = "Scalable";
            this.chkScalable.UseVisualStyleBackColor = true;
            // 
            // chkInService
            // 
            this.chkInService.AutoSize = true;
            this.chkInService.Checked = true;
            this.chkInService.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInService.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInService.Location = new System.Drawing.Point(110, 124);
            this.chkInService.Name = "chkInService";
            this.chkInService.Size = new System.Drawing.Size(84, 20);
            this.chkInService.TabIndex = 3;
            this.chkInService.Text = "In Service";
            this.chkInService.UseVisualStyleBackColor = true;
            // 
            // txtLoadID
            // 
            this.txtLoadID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoadID.Location = new System.Drawing.Point(16, 121);
            this.txtLoadID.Name = "txtLoadID";
            this.txtLoadID.Size = new System.Drawing.Size(80, 23);
            this.txtLoadID.TabIndex = 2;
            this.txtLoadID.Text = "L1";
            // 
            // lblBusNameConn
            // 
            this.lblBusNameConn.BackColor = System.Drawing.Color.Snow;
            this.lblBusNameConn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBusNameConn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusNameConn.Location = new System.Drawing.Point(230, 57);
            this.lblBusNameConn.Name = "lblBusNameConn";
            this.lblBusNameConn.Size = new System.Drawing.Size(158, 24);
            this.lblBusNameConn.TabIndex = 1;
            this.lblBusNameConn.Text = "101";
            // 
            // lblBusNumberConn
            // 
            this.lblBusNumberConn.BackColor = System.Drawing.Color.Snow;
            this.lblBusNumberConn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBusNumberConn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusNumberConn.Location = new System.Drawing.Point(15, 57);
            this.lblBusNumberConn.Name = "lblBusNumberConn";
            this.lblBusNumberConn.Size = new System.Drawing.Size(158, 24);
            this.lblBusNumberConn.TabIndex = 0;
            this.lblBusNumberConn.Text = "101";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(227, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Bus Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Load ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bus Number";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabCtrlLoad);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(439, 482);
            this.panel1.TabIndex = 1;
            // 
            // btnOKLoad
            // 
            this.btnOKLoad.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOKLoad.Location = new System.Drawing.Point(76, 514);
            this.btnOKLoad.Name = "btnOKLoad";
            this.btnOKLoad.Size = new System.Drawing.Size(106, 26);
            this.btnOKLoad.TabIndex = 0;
            this.btnOKLoad.Text = "OK";
            this.btnOKLoad.UseVisualStyleBackColor = true;
            this.btnOKLoad.Click += new System.EventHandler(this.btnOKLoad_Click);
            // 
            // btnCancelLoad
            // 
            this.btnCancelLoad.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelLoad.Location = new System.Drawing.Point(244, 514);
            this.btnCancelLoad.Name = "btnCancelLoad";
            this.btnCancelLoad.Size = new System.Drawing.Size(106, 26);
            this.btnCancelLoad.TabIndex = 1;
            this.btnCancelLoad.Text = "Cancel";
            this.btnCancelLoad.UseVisualStyleBackColor = true;
            this.btnCancelLoad.Click += new System.EventHandler(this.btnCancelLoad_Click);
            // 
            // frmDataLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(463, 561);
            this.Controls.Add(this.btnCancelLoad);
            this.Controls.Add(this.btnOKLoad);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDataLoad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Load Data Record";
            this.Load += new System.EventHandler(this.frmDataLoad_Load);
            this.tabCtrlLoad.ResumeLayout(false);
            this.tabPowerFlow.ResumeLayout(false);
            this.pnlPowerFlowSub1.ResumeLayout(false);
            this.grbLoadData.ResumeLayout(false);
            this.grbLoadData.PerformLayout();
            this.grbBasicData.ResumeLayout(false);
            this.grbBasicData.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtrlLoad;
        private System.Windows.Forms.TabPage tabPowerFlow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlPowerFlowSub1;
        private System.Windows.Forms.GroupBox grbLoadData;
        private System.Windows.Forms.GroupBox grbBasicData;
        private System.Windows.Forms.Button btnOKLoad;
        private System.Windows.Forms.Button btnCancelLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblBusNameConn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblBusNumberConn;
        public System.Windows.Forms.TextBox txtYQLoad;
        public System.Windows.Forms.TextBox txtIQLoad;
        public System.Windows.Forms.TextBox txtQLoad;
        public System.Windows.Forms.TextBox txtYLoad;
        public System.Windows.Forms.TextBox txtIPLoad;
        public System.Windows.Forms.TextBox txtPLoad;
        public System.Windows.Forms.CheckBox chkInterruptible;
        public System.Windows.Forms.CheckBox chkScalable;
        public System.Windows.Forms.CheckBox chkInService;
        public System.Windows.Forms.TextBox txtLoadID;
    }
}