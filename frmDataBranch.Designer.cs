
namespace Experimential_Software
{
    partial class frmDataBranch
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
            this.btnOkBr = new System.Windows.Forms.Button();
            this.btnCancelbr = new System.Windows.Forms.Button();
            this.pnlMainBranchData = new Experimential_Software.PanelMain();
            this.tabPowerFlowBr = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grbBasicDataBr = new System.Windows.Forms.GroupBox();
            this.txtBranchName = new System.Windows.Forms.TextBox();
            this.txtBranchID = new System.Windows.Forms.TextBox();
            this.chkInServiceBr = new System.Windows.Forms.CheckBox();
            this.lblBusToName = new System.Windows.Forms.Label();
            this.lblBusToNumber = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBusFromName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBusFromNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grbBranchData = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtChargingBPu = new System.Windows.Forms.TextBox();
            this.txtLengthBr = new System.Windows.Forms.TextBox();
            this.txtLineBPu = new System.Windows.Forms.TextBox();
            this.txtLineGToPu = new System.Windows.Forms.TextBox();
            this.txtLineBFromPu = new System.Windows.Forms.TextBox();
            this.txtLineGFromPu = new System.Windows.Forms.TextBox();
            this.txtLineXPu = new System.Windows.Forms.TextBox();
            this.txtLineRPu = new System.Windows.Forms.TextBox();
            this.pnlMainBranchData.SuspendLayout();
            this.tabPowerFlowBr.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grbBasicDataBr.SuspendLayout();
            this.grbBranchData.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOkBr
            // 
            this.btnOkBr.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOkBr.Location = new System.Drawing.Point(196, 540);
            this.btnOkBr.Name = "btnOkBr";
            this.btnOkBr.Size = new System.Drawing.Size(87, 28);
            this.btnOkBr.TabIndex = 0;
            this.btnOkBr.Text = "Ok";
            this.btnOkBr.UseVisualStyleBackColor = true;
            this.btnOkBr.Click += new System.EventHandler(this.btnOkBr_Click);
            // 
            // btnCancelbr
            // 
            this.btnCancelbr.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelbr.Location = new System.Drawing.Point(376, 540);
            this.btnCancelbr.Name = "btnCancelbr";
            this.btnCancelbr.Size = new System.Drawing.Size(87, 28);
            this.btnCancelbr.TabIndex = 1;
            this.btnCancelbr.Text = "Cancel";
            this.btnCancelbr.UseVisualStyleBackColor = true;
            this.btnCancelbr.Click += new System.EventHandler(this.btnCancelbr_Click);
            // 
            // pnlMainBranchData
            // 
            this.pnlMainBranchData.AutoScroll = true;
            this.pnlMainBranchData.Controls.Add(this.tabPowerFlowBr);
            this.pnlMainBranchData.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMainBranchData.Location = new System.Drawing.Point(10, 12);
            this.pnlMainBranchData.Name = "pnlMainBranchData";
            this.pnlMainBranchData.Size = new System.Drawing.Size(691, 507);
            this.pnlMainBranchData.TabIndex = 0;
            this.pnlMainBranchData.ZoomFactor = 1D;
            // 
            // tabPowerFlowBr
            // 
            this.tabPowerFlowBr.Controls.Add(this.tabPage1);
            this.tabPowerFlowBr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPowerFlowBr.Location = new System.Drawing.Point(0, 0);
            this.tabPowerFlowBr.Name = "tabPowerFlowBr";
            this.tabPowerFlowBr.SelectedIndex = 0;
            this.tabPowerFlowBr.Size = new System.Drawing.Size(691, 507);
            this.tabPowerFlowBr.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grbBasicDataBr);
            this.tabPage1.Controls.Add(this.grbBranchData);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(683, 476);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Power Flow";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grbBasicDataBr
            // 
            this.grbBasicDataBr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbBasicDataBr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grbBasicDataBr.Controls.Add(this.txtBranchName);
            this.grbBasicDataBr.Controls.Add(this.txtBranchID);
            this.grbBasicDataBr.Controls.Add(this.chkInServiceBr);
            this.grbBasicDataBr.Controls.Add(this.lblBusToName);
            this.grbBasicDataBr.Controls.Add(this.lblBusToNumber);
            this.grbBasicDataBr.Controls.Add(this.label9);
            this.grbBasicDataBr.Controls.Add(this.label6);
            this.grbBasicDataBr.Controls.Add(this.label8);
            this.grbBasicDataBr.Controls.Add(this.label2);
            this.grbBasicDataBr.Controls.Add(this.lblBusFromName);
            this.grbBasicDataBr.Controls.Add(this.label4);
            this.grbBasicDataBr.Controls.Add(this.lblBusFromNumber);
            this.grbBasicDataBr.Controls.Add(this.label1);
            this.grbBasicDataBr.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBasicDataBr.Location = new System.Drawing.Point(16, 17);
            this.grbBasicDataBr.Name = "grbBasicDataBr";
            this.grbBasicDataBr.Size = new System.Drawing.Size(651, 170);
            this.grbBasicDataBr.TabIndex = 0;
            this.grbBasicDataBr.TabStop = false;
            this.grbBasicDataBr.Text = "Basic Data";
            // 
            // txtBranchName
            // 
            this.txtBranchName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranchName.Location = new System.Drawing.Point(365, 121);
            this.txtBranchName.Name = "txtBranchName";
            this.txtBranchName.Size = new System.Drawing.Size(143, 23);
            this.txtBranchName.TabIndex = 1;
            // 
            // txtBranchID
            // 
            this.txtBranchID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranchID.Location = new System.Drawing.Point(136, 121);
            this.txtBranchID.Name = "txtBranchID";
            this.txtBranchID.Size = new System.Drawing.Size(81, 23);
            this.txtBranchID.TabIndex = 0;
            // 
            // chkInServiceBr
            // 
            this.chkInServiceBr.AutoSize = true;
            this.chkInServiceBr.Checked = true;
            this.chkInServiceBr.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInServiceBr.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInServiceBr.Location = new System.Drawing.Point(557, 35);
            this.chkInServiceBr.Name = "chkInServiceBr";
            this.chkInServiceBr.Size = new System.Drawing.Size(84, 20);
            this.chkInServiceBr.TabIndex = 2;
            this.chkInServiceBr.Text = "In Service";
            this.chkInServiceBr.UseVisualStyleBackColor = true;
            // 
            // lblBusToName
            // 
            this.lblBusToName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBusToName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusToName.Location = new System.Drawing.Point(365, 82);
            this.lblBusToName.Name = "lblBusToName";
            this.lblBusToName.Size = new System.Drawing.Size(143, 19);
            this.lblBusToName.TabIndex = 1;
            this.lblBusToName.Text = "Bus Slack";
            // 
            // lblBusToNumber
            // 
            this.lblBusToNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBusToNumber.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusToNumber.Location = new System.Drawing.Point(136, 82);
            this.lblBusToNumber.Name = "lblBusToNumber";
            this.lblBusToNumber.Size = new System.Drawing.Size(81, 19);
            this.lblBusToNumber.TabIndex = 1;
            this.lblBusToNumber.Text = "101";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(253, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Branch Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(253, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "To Bus Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Branch ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "To Bus Number";
            // 
            // lblBusFromName
            // 
            this.lblBusFromName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBusFromName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusFromName.Location = new System.Drawing.Point(365, 35);
            this.lblBusFromName.Name = "lblBusFromName";
            this.lblBusFromName.Size = new System.Drawing.Size(143, 19);
            this.lblBusFromName.TabIndex = 1;
            this.lblBusFromName.Text = "Bus Slack";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(253, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "From Bus Name";
            // 
            // lblBusFromNumber
            // 
            this.lblBusFromNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBusFromNumber.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusFromNumber.Location = new System.Drawing.Point(136, 35);
            this.lblBusFromNumber.Name = "lblBusFromNumber";
            this.lblBusFromNumber.Size = new System.Drawing.Size(81, 19);
            this.lblBusFromNumber.TabIndex = 1;
            this.lblBusFromNumber.Text = "101";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Bus Number";
            // 
            // grbBranchData
            // 
            this.grbBranchData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbBranchData.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grbBranchData.Controls.Add(this.label12);
            this.grbBranchData.Controls.Add(this.label17);
            this.grbBranchData.Controls.Add(this.label16);
            this.grbBranchData.Controls.Add(this.label14);
            this.grbBranchData.Controls.Add(this.label11);
            this.grbBranchData.Controls.Add(this.label15);
            this.grbBranchData.Controls.Add(this.label13);
            this.grbBranchData.Controls.Add(this.label10);
            this.grbBranchData.Controls.Add(this.txtChargingBPu);
            this.grbBranchData.Controls.Add(this.txtLengthBr);
            this.grbBranchData.Controls.Add(this.txtLineBPu);
            this.grbBranchData.Controls.Add(this.txtLineGToPu);
            this.grbBranchData.Controls.Add(this.txtLineBFromPu);
            this.grbBranchData.Controls.Add(this.txtLineGFromPu);
            this.grbBranchData.Controls.Add(this.txtLineXPu);
            this.grbBranchData.Controls.Add(this.txtLineRPu);
            this.grbBranchData.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBranchData.Location = new System.Drawing.Point(16, 197);
            this.grbBranchData.Name = "grbBranchData";
            this.grbBranchData.Size = new System.Drawing.Size(651, 266);
            this.grbBranchData.TabIndex = 0;
            this.grbBranchData.TabStop = false;
            this.grbBranchData.Text = "Branch Data";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(474, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Charging B (pu)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(474, 186);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(78, 16);
            this.label17.TabIndex = 0;
            this.label17.Text = "Length (Km)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(259, 186);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 16);
            this.label16.TabIndex = 0;
            this.label16.Text = "Line B To (pu)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(259, 109);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 16);
            this.label14.TabIndex = 0;
            this.label14.Text = "Line B From (pu)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(259, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Line X (pu)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(46, 186);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(90, 16);
            this.label15.TabIndex = 0;
            this.label15.Text = "Line G To (pu)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(46, 109);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "Line G From (pu)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(46, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Line R (pu)";
            // 
            // txtChargingBPu
            // 
            this.txtChargingBPu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChargingBPu.Location = new System.Drawing.Point(477, 68);
            this.txtChargingBPu.Name = "txtChargingBPu";
            this.txtChargingBPu.Size = new System.Drawing.Size(119, 23);
            this.txtChargingBPu.TabIndex = 3;
            this.txtChargingBPu.Text = "0.000000";
            this.txtChargingBPu.Leave += new System.EventHandler(this.EventDataIputIsNotNumber);
            // 
            // txtLengthBr
            // 
            this.txtLengthBr.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLengthBr.Location = new System.Drawing.Point(477, 215);
            this.txtLengthBr.Name = "txtLengthBr";
            this.txtLengthBr.Size = new System.Drawing.Size(119, 23);
            this.txtLengthBr.TabIndex = 2;
            this.txtLengthBr.Text = "0.000";
            this.txtLengthBr.Leave += new System.EventHandler(this.EventDataIputIsNotNumber);
            // 
            // txtLineBPu
            // 
            this.txtLineBPu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineBPu.Location = new System.Drawing.Point(262, 215);
            this.txtLineBPu.Name = "txtLineBPu";
            this.txtLineBPu.Size = new System.Drawing.Size(119, 23);
            this.txtLineBPu.TabIndex = 3;
            this.txtLineBPu.Text = "0.000000";
            this.txtLineBPu.Leave += new System.EventHandler(this.EventDataIputIsNotNumber);
            // 
            // txtLineGToPu
            // 
            this.txtLineGToPu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineGToPu.Location = new System.Drawing.Point(49, 215);
            this.txtLineGToPu.Name = "txtLineGToPu";
            this.txtLineGToPu.Size = new System.Drawing.Size(119, 23);
            this.txtLineGToPu.TabIndex = 3;
            this.txtLineGToPu.Text = "0.000000";
            this.txtLineGToPu.Leave += new System.EventHandler(this.EventDataIputIsNotNumber);
            // 
            // txtLineBFromPu
            // 
            this.txtLineBFromPu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineBFromPu.Location = new System.Drawing.Point(262, 138);
            this.txtLineBFromPu.Name = "txtLineBFromPu";
            this.txtLineBFromPu.Size = new System.Drawing.Size(119, 23);
            this.txtLineBFromPu.TabIndex = 3;
            this.txtLineBFromPu.Text = "0.000000";
            this.txtLineBFromPu.Leave += new System.EventHandler(this.EventDataIputIsNotNumber);
            // 
            // txtLineGFromPu
            // 
            this.txtLineGFromPu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineGFromPu.Location = new System.Drawing.Point(49, 138);
            this.txtLineGFromPu.Name = "txtLineGFromPu";
            this.txtLineGFromPu.Size = new System.Drawing.Size(119, 23);
            this.txtLineGFromPu.TabIndex = 3;
            this.txtLineGFromPu.Text = "0.000000";
            this.txtLineGFromPu.Leave += new System.EventHandler(this.EventDataIputIsNotNumber);
            // 
            // txtLineXPu
            // 
            this.txtLineXPu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineXPu.Location = new System.Drawing.Point(262, 68);
            this.txtLineXPu.Name = "txtLineXPu";
            this.txtLineXPu.Size = new System.Drawing.Size(119, 23);
            this.txtLineXPu.TabIndex = 1;
            this.txtLineXPu.Text = "0.000000";
            this.txtLineXPu.Leave += new System.EventHandler(this.EventDataIputIsNotNumber);
            // 
            // txtLineRPu
            // 
            this.txtLineRPu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineRPu.Location = new System.Drawing.Point(49, 68);
            this.txtLineRPu.Name = "txtLineRPu";
            this.txtLineRPu.Size = new System.Drawing.Size(119, 23);
            this.txtLineRPu.TabIndex = 0;
            this.txtLineRPu.Text = "0.000000";
            this.txtLineRPu.Leave += new System.EventHandler(this.EventDataIputIsNotNumber);
            // 
            // frmDataBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(713, 580);
            this.Controls.Add(this.pnlMainBranchData);
            this.Controls.Add(this.btnCancelbr);
            this.Controls.Add(this.btnOkBr);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDataBranch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Branch Data Record";
            this.Load += new System.EventHandler(this.frmDataBranch_Load);
            this.pnlMainBranchData.ResumeLayout(false);
            this.tabPowerFlowBr.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.grbBasicDataBr.ResumeLayout(false);
            this.grbBasicDataBr.PerformLayout();
            this.grbBranchData.ResumeLayout(false);
            this.grbBranchData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PanelMain pnlMainBranchData;
        private System.Windows.Forms.TabControl tabPowerFlowBr;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox grbBasicDataBr;
        private System.Windows.Forms.Label lblBusFromNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBusToName;
        private System.Windows.Forms.Label lblBusToNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBusFromName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBranchName;
        private System.Windows.Forms.TextBox txtBranchID;
        private System.Windows.Forms.CheckBox chkInServiceBr;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox grbBranchData;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtChargingBPu;
        private System.Windows.Forms.TextBox txtLengthBr;
        private System.Windows.Forms.TextBox txtLineBPu;
        private System.Windows.Forms.TextBox txtLineGToPu;
        private System.Windows.Forms.TextBox txtLineBFromPu;
        private System.Windows.Forms.TextBox txtLineGFromPu;
        private System.Windows.Forms.TextBox txtLineXPu;
        private System.Windows.Forms.TextBox txtLineRPu;
        private System.Windows.Forms.Button btnOkBr;
        private System.Windows.Forms.Button btnCancelbr;
    }
}