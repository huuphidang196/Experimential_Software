
namespace Experimential_Software
{
    partial class frmDataBus
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
            this.pnlOverallBus = new System.Windows.Forms.Panel();
            this.htnCancelBus = new System.Windows.Forms.Button();
            this.btnOKBus = new System.Windows.Forms.Button();
            this.BusRecTab = new System.Windows.Forms.TabControl();
            this.PowerFlow = new System.Windows.Forms.TabPage();
            this.grbBasicData = new System.Windows.Forms.GroupBox();
            this.cboTypeBus = new System.Windows.Forms.ComboBox();
            this.txtVoltageBus = new System.Windows.Forms.TextBox();
            this.txtBusNumber = new System.Windows.Forms.TextBox();
            this.txtBasekV = new System.Windows.Forms.TextBox();
            this.txtAngleBus = new System.Windows.Forms.TextBox();
            this.txtBusName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grbLimitData = new System.Windows.Forms.GroupBox();
            this.txtEmerVmin = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNorVmin = new System.Windows.Forms.TextBox();
            this.txtEmerVmax = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNorVmax = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlOverallBus.SuspendLayout();
            this.BusRecTab.SuspendLayout();
            this.PowerFlow.SuspendLayout();
            this.grbBasicData.SuspendLayout();
            this.grbLimitData.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOverallBus
            // 
            this.pnlOverallBus.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlOverallBus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlOverallBus.Controls.Add(this.htnCancelBus);
            this.pnlOverallBus.Controls.Add(this.btnOKBus);
            this.pnlOverallBus.Controls.Add(this.BusRecTab);
            this.pnlOverallBus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOverallBus.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlOverallBus.Location = new System.Drawing.Point(0, 0);
            this.pnlOverallBus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlOverallBus.Name = "pnlOverallBus";
            this.pnlOverallBus.Size = new System.Drawing.Size(622, 547);
            this.pnlOverallBus.TabIndex = 0;
            // 
            // htnCancelBus
            // 
            this.htnCancelBus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.htnCancelBus.Location = new System.Drawing.Point(360, 506);
            this.htnCancelBus.Name = "htnCancelBus";
            this.htnCancelBus.Size = new System.Drawing.Size(106, 26);
            this.htnCancelBus.TabIndex = 1;
            this.htnCancelBus.Text = "Cancel";
            this.htnCancelBus.UseVisualStyleBackColor = true;
            this.htnCancelBus.Click += new System.EventHandler(this.htnCancelBus_Click);
            // 
            // btnOKBus
            // 
            this.btnOKBus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOKBus.Location = new System.Drawing.Point(150, 506);
            this.btnOKBus.Name = "btnOKBus";
            this.btnOKBus.Size = new System.Drawing.Size(106, 26);
            this.btnOKBus.TabIndex = 0;
            this.btnOKBus.Text = "OK";
            this.btnOKBus.UseVisualStyleBackColor = true;
            this.btnOKBus.Click += new System.EventHandler(this.btnOKSet_Click);
            // 
            // BusRecTab
            // 
            this.BusRecTab.Controls.Add(this.PowerFlow);
            this.BusRecTab.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BusRecTab.Location = new System.Drawing.Point(10, 10);
            this.BusRecTab.Name = "BusRecTab";
            this.BusRecTab.SelectedIndex = 0;
            this.BusRecTab.Size = new System.Drawing.Size(598, 477);
            this.BusRecTab.TabIndex = 0;
            // 
            // PowerFlow
            // 
            this.PowerFlow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PowerFlow.Controls.Add(this.grbBasicData);
            this.PowerFlow.Controls.Add(this.grbLimitData);
            this.PowerFlow.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PowerFlow.Location = new System.Drawing.Point(4, 27);
            this.PowerFlow.Name = "PowerFlow";
            this.PowerFlow.Padding = new System.Windows.Forms.Padding(3);
            this.PowerFlow.Size = new System.Drawing.Size(590, 446);
            this.PowerFlow.TabIndex = 0;
            this.PowerFlow.Text = "Power Flow";
            this.PowerFlow.UseVisualStyleBackColor = true;
            // 
            // grbBasicData
            // 
            this.grbBasicData.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grbBasicData.Controls.Add(this.cboTypeBus);
            this.grbBasicData.Controls.Add(this.txtVoltageBus);
            this.grbBasicData.Controls.Add(this.txtBusNumber);
            this.grbBasicData.Controls.Add(this.txtBasekV);
            this.grbBasicData.Controls.Add(this.txtAngleBus);
            this.grbBasicData.Controls.Add(this.txtBusName);
            this.grbBasicData.Controls.Add(this.label6);
            this.grbBasicData.Controls.Add(this.label4);
            this.grbBasicData.Controls.Add(this.label2);
            this.grbBasicData.Controls.Add(this.label5);
            this.grbBasicData.Controls.Add(this.label3);
            this.grbBasicData.Controls.Add(this.label1);
            this.grbBasicData.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBasicData.Location = new System.Drawing.Point(15, 15);
            this.grbBasicData.Name = "grbBasicData";
            this.grbBasicData.Size = new System.Drawing.Size(556, 283);
            this.grbBasicData.TabIndex = 0;
            this.grbBasicData.TabStop = false;
            this.grbBasicData.Text = "Basic Data";
            // 
            // cboTypeBus
            // 
            this.cboTypeBus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTypeBus.FormattingEnabled = true;
            this.cboTypeBus.Location = new System.Drawing.Point(50, 148);
            this.cboTypeBus.Name = "cboTypeBus";
            this.cboTypeBus.Size = new System.Drawing.Size(152, 24);
            this.cboTypeBus.TabIndex = 2;
            // 
            // txtVoltageBus
            // 
            this.txtVoltageBus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVoltageBus.Location = new System.Drawing.Point(50, 235);
            this.txtVoltageBus.Name = "txtVoltageBus";
            this.txtVoltageBus.Size = new System.Drawing.Size(115, 23);
            this.txtVoltageBus.TabIndex = 4;
            this.txtVoltageBus.Leave += new System.EventHandler(this.EventInputTextDataIsNotNumber);
            // 
            // txtBusNumber
            // 
            this.txtBusNumber.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusNumber.Location = new System.Drawing.Point(50, 63);
            this.txtBusNumber.Name = "txtBusNumber";
            this.txtBusNumber.Size = new System.Drawing.Size(115, 23);
            this.txtBusNumber.TabIndex = 0;
            // 
            // txtBasekV
            // 
            this.txtBasekV.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBasekV.Location = new System.Drawing.Point(366, 149);
            this.txtBasekV.Name = "txtBasekV";
            this.txtBasekV.Size = new System.Drawing.Size(115, 23);
            this.txtBasekV.TabIndex = 3;
            this.txtBasekV.Text = "0.0";
            this.txtBasekV.Leave += new System.EventHandler(this.EventInputTextDataIsNotNumber);
            // 
            // txtAngleBus
            // 
            this.txtAngleBus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAngleBus.Location = new System.Drawing.Point(366, 235);
            this.txtAngleBus.Name = "txtAngleBus";
            this.txtAngleBus.Size = new System.Drawing.Size(115, 23);
            this.txtAngleBus.TabIndex = 5;
            this.txtAngleBus.Leave += new System.EventHandler(this.EventInputTextDataIsNotNumber);
            // 
            // txtBusName
            // 
            this.txtBusName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusName.Location = new System.Drawing.Point(366, 63);
            this.txtBusName.Name = "txtBusName";
            this.txtBusName.Size = new System.Drawing.Size(115, 23);
            this.txtBusName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(363, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Angle (rad)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(363, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Base kV";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(363, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Bus Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(47, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Voltage (pu)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Type Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bus Number";
            // 
            // grbLimitData
            // 
            this.grbLimitData.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grbLimitData.Controls.Add(this.txtEmerVmin);
            this.grbLimitData.Controls.Add(this.label10);
            this.grbLimitData.Controls.Add(this.txtNorVmin);
            this.grbLimitData.Controls.Add(this.txtEmerVmax);
            this.grbLimitData.Controls.Add(this.label8);
            this.grbLimitData.Controls.Add(this.label9);
            this.grbLimitData.Controls.Add(this.txtNorVmax);
            this.grbLimitData.Controls.Add(this.label7);
            this.grbLimitData.Location = new System.Drawing.Point(15, 315);
            this.grbLimitData.Name = "grbLimitData";
            this.grbLimitData.Size = new System.Drawing.Size(556, 105);
            this.grbLimitData.TabIndex = 2;
            this.grbLimitData.TabStop = false;
            this.grbLimitData.Text = "Limit Data";
            // 
            // txtEmerVmin
            // 
            this.txtEmerVmin.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmerVmin.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmerVmin.Location = new System.Drawing.Point(429, 55);
            this.txtEmerVmin.Name = "txtEmerVmin";
            this.txtEmerVmin.Size = new System.Drawing.Size(115, 22);
            this.txtEmerVmin.TabIndex = 3;
            this.txtEmerVmin.Leave += new System.EventHandler(this.EventInputTextDataIsNotNumber);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(426, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Emer Vmin (pu)";
            // 
            // txtNorVmin
            // 
            this.txtNorVmin.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNorVmin.Location = new System.Drawing.Point(142, 55);
            this.txtNorVmin.Name = "txtNorVmin";
            this.txtNorVmin.Size = new System.Drawing.Size(115, 22);
            this.txtNorVmin.TabIndex = 1;
            this.txtNorVmin.Leave += new System.EventHandler(this.EventInputTextDataIsNotNumber);
            // 
            // txtEmerVmax
            // 
            this.txtEmerVmax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmerVmax.Location = new System.Drawing.Point(289, 55);
            this.txtEmerVmax.Name = "txtEmerVmax";
            this.txtEmerVmax.Size = new System.Drawing.Size(115, 22);
            this.txtEmerVmax.TabIndex = 2;
            this.txtEmerVmax.Leave += new System.EventHandler(this.EventInputTextDataIsNotNumber);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(139, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Normal Vmin (pu)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(286, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Emer Vmax (pu)";
            // 
            // txtNorVmax
            // 
            this.txtNorVmax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNorVmax.Location = new System.Drawing.Point(8, 55);
            this.txtNorVmax.Name = "txtNorVmax";
            this.txtNorVmax.Size = new System.Drawing.Size(115, 22);
            this.txtNorVmax.TabIndex = 0;
            this.txtNorVmax.Leave += new System.EventHandler(this.EventInputTextDataIsNotNumber);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Normal Vmax (pu)";
            // 
            // frmDataBus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 547);
            this.Controls.Add(this.pnlOverallBus);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDataBus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Bus Data Record";
            this.Load += new System.EventHandler(this.frmDataBus_Load);
            this.pnlOverallBus.ResumeLayout(false);
            this.BusRecTab.ResumeLayout(false);
            this.PowerFlow.ResumeLayout(false);
            this.grbBasicData.ResumeLayout(false);
            this.grbBasicData.PerformLayout();
            this.grbLimitData.ResumeLayout(false);
            this.grbLimitData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOverallBus;
        private System.Windows.Forms.TabControl BusRecTab;
        private System.Windows.Forms.TabPage PowerFlow;
        private System.Windows.Forms.GroupBox grbBasicData;
        private System.Windows.Forms.TextBox txtBusName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOKBus;
        private System.Windows.Forms.ComboBox cboTypeBus;
        private System.Windows.Forms.TextBox txtBusNumber;
        private System.Windows.Forms.TextBox txtBasekV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVoltageBus;
        private System.Windows.Forms.TextBox txtAngleBus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grbLimitData;
        private System.Windows.Forms.Button htnCancelBus;
        private System.Windows.Forms.TextBox txtEmerVmin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNorVmin;
        private System.Windows.Forms.TextBox txtEmerVmax;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNorVmax;
        private System.Windows.Forms.Label label7;
    }
}