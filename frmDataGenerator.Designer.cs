
namespace Experimential_Software
{
    partial class frmDataGenerator
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabCtrlPowerFlow = new System.Windows.Forms.TabControl();
            this.tabPowerFlow = new System.Windows.Forms.TabPage();
            this.pnlMachineAndPlant = new System.Windows.Forms.Panel();
            this.grbPlantData = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtRemoteBus = new System.Windows.Forms.TextBox();
            this.txtSchedVoltage = new System.Windows.Forms.TextBox();
            this.grbWindData = new System.Windows.Forms.GroupBox();
            this.cboControlMode = new System.Windows.Forms.ComboBox();
            this.lblValuePowerFactor = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.pnlMachineData = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtGentapMF = new System.Windows.Forms.TextBox();
            this.txtXTran_pu = new System.Windows.Forms.TextBox();
            this.txtRTran_pu = new System.Windows.Forms.TextBox();
            this.grbMachineData = new System.Windows.Forms.GroupBox();
            this.txtXSource_pu = new System.Windows.Forms.TextBox();
            this.txtQmin_Mvar = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPmin_MW = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRSource_pu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQmax_Mvar = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPmax_MW = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMbase_MVA = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtQgen_Mvar = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPgen_MW = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkInService = new System.Windows.Forms.CheckBox();
            this.txtMachineName = new System.Windows.Forms.TextBox();
            this.txtMachineID = new System.Windows.Forms.TextBox();
            this.lblBusConnTypeCode = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBusNameConnMF = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBusNumConnMF = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOKGene = new System.Windows.Forms.Button();
            this.btnCancelGene = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabCtrlPowerFlow.SuspendLayout();
            this.tabPowerFlow.SuspendLayout();
            this.pnlMachineAndPlant.SuspendLayout();
            this.grbPlantData.SuspendLayout();
            this.grbWindData.SuspendLayout();
            this.pnlMachineData.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grbMachineData.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabCtrlPowerFlow);
            this.panel1.Location = new System.Drawing.Point(12, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(711, 635);
            this.panel1.TabIndex = 0;
            // 
            // tabCtrlPowerFlow
            // 
            this.tabCtrlPowerFlow.Controls.Add(this.tabPowerFlow);
            this.tabCtrlPowerFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrlPowerFlow.Location = new System.Drawing.Point(0, 0);
            this.tabCtrlPowerFlow.Name = "tabCtrlPowerFlow";
            this.tabCtrlPowerFlow.SelectedIndex = 0;
            this.tabCtrlPowerFlow.Size = new System.Drawing.Size(711, 635);
            this.tabCtrlPowerFlow.TabIndex = 0;
            // 
            // tabPowerFlow
            // 
            this.tabPowerFlow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPowerFlow.Controls.Add(this.pnlMachineAndPlant);
            this.tabPowerFlow.Controls.Add(this.pnlMachineData);
            this.tabPowerFlow.Controls.Add(this.groupBox1);
            this.tabPowerFlow.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPowerFlow.Location = new System.Drawing.Point(4, 27);
            this.tabPowerFlow.Name = "tabPowerFlow";
            this.tabPowerFlow.Padding = new System.Windows.Forms.Padding(3);
            this.tabPowerFlow.Size = new System.Drawing.Size(703, 604);
            this.tabPowerFlow.TabIndex = 0;
            this.tabPowerFlow.Text = "Power Flow";
            // 
            // pnlMachineAndPlant
            // 
            this.pnlMachineAndPlant.Controls.Add(this.grbPlantData);
            this.pnlMachineAndPlant.Controls.Add(this.grbWindData);
            this.pnlMachineAndPlant.Location = new System.Drawing.Point(15, 413);
            this.pnlMachineAndPlant.Name = "pnlMachineAndPlant";
            this.pnlMachineAndPlant.Size = new System.Drawing.Size(669, 167);
            this.pnlMachineAndPlant.TabIndex = 2;
            // 
            // grbPlantData
            // 
            this.grbPlantData.Controls.Add(this.label21);
            this.grbPlantData.Controls.Add(this.label20);
            this.grbPlantData.Controls.Add(this.txtRemoteBus);
            this.grbPlantData.Controls.Add(this.txtSchedVoltage);
            this.grbPlantData.Dock = System.Windows.Forms.DockStyle.Right;
            this.grbPlantData.Location = new System.Drawing.Point(377, 0);
            this.grbPlantData.Name = "grbPlantData";
            this.grbPlantData.Size = new System.Drawing.Size(292, 167);
            this.grbPlantData.TabIndex = 1;
            this.grbPlantData.TabStop = false;
            this.grbPlantData.Text = "Plant Data";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(26, 111);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(82, 17);
            this.label21.TabIndex = 0;
            this.label21.Text = "Remote Bus";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(26, 51);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(95, 17);
            this.label20.TabIndex = 0;
            this.label20.Text = "Sched Voltage";
            // 
            // txtRemoteBus
            // 
            this.txtRemoteBus.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemoteBus.Location = new System.Drawing.Point(144, 108);
            this.txtRemoteBus.Name = "txtRemoteBus";
            this.txtRemoteBus.Size = new System.Drawing.Size(122, 24);
            this.txtRemoteBus.TabIndex = 1;
            this.txtRemoteBus.Text = "0";
            this.txtRemoteBus.Leave += new System.EventHandler(this.CheckNumberValidTextBoxEventLeave);
            // 
            // txtSchedVoltage
            // 
            this.txtSchedVoltage.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSchedVoltage.Location = new System.Drawing.Point(144, 45);
            this.txtSchedVoltage.Name = "txtSchedVoltage";
            this.txtSchedVoltage.Size = new System.Drawing.Size(122, 24);
            this.txtSchedVoltage.TabIndex = 1;
            this.txtSchedVoltage.Text = "1.0000";
            this.txtSchedVoltage.Leave += new System.EventHandler(this.CheckNumberValidTextBoxEventLeave);
            // 
            // grbWindData
            // 
            this.grbWindData.Controls.Add(this.cboControlMode);
            this.grbWindData.Controls.Add(this.lblValuePowerFactor);
            this.grbWindData.Controls.Add(this.label19);
            this.grbWindData.Controls.Add(this.label18);
            this.grbWindData.Dock = System.Windows.Forms.DockStyle.Left;
            this.grbWindData.Location = new System.Drawing.Point(0, 0);
            this.grbWindData.Name = "grbWindData";
            this.grbWindData.Size = new System.Drawing.Size(361, 167);
            this.grbWindData.TabIndex = 0;
            this.grbWindData.TabStop = false;
            this.grbWindData.Text = "Wind Data";
            // 
            // cboControlMode
            // 
            this.cboControlMode.FormattingEnabled = true;
            this.cboControlMode.Location = new System.Drawing.Point(124, 43);
            this.cboControlMode.Name = "cboControlMode";
            this.cboControlMode.Size = new System.Drawing.Size(221, 26);
            this.cboControlMode.TabIndex = 1;
            // 
            // lblValuePowerFactor
            // 
            this.lblValuePowerFactor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblValuePowerFactor.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValuePowerFactor.Location = new System.Drawing.Point(177, 110);
            this.lblValuePowerFactor.Name = "lblValuePowerFactor";
            this.lblValuePowerFactor.Size = new System.Drawing.Size(132, 22);
            this.lblValuePowerFactor.TabIndex = 0;
            this.lblValuePowerFactor.Text = "1.000";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(19, 111);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(132, 17);
            this.label19.TabIndex = 0;
            this.label19.Text = "Power Factor (WPF)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(23, 51);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(90, 17);
            this.label18.TabIndex = 0;
            this.label18.Text = "Control Mode";
            // 
            // pnlMachineData
            // 
            this.pnlMachineData.Controls.Add(this.groupBox2);
            this.pnlMachineData.Controls.Add(this.grbMachineData);
            this.pnlMachineData.Location = new System.Drawing.Point(15, 154);
            this.pnlMachineData.Name = "pnlMachineData";
            this.pnlMachineData.Size = new System.Drawing.Size(669, 237);
            this.pnlMachineData.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtGentapMF);
            this.groupBox2.Controls.Add(this.txtXTran_pu);
            this.groupBox2.Controls.Add(this.txtRTran_pu);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(504, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(165, 237);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transformer Data";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(19, 172);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(82, 17);
            this.label17.TabIndex = 0;
            this.label17.Text = "Gentap (pu)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(19, 101);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 17);
            this.label16.TabIndex = 0;
            this.label16.Text = "X Tran (pu)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(19, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 17);
            this.label15.TabIndex = 0;
            this.label15.Text = "R Tran (pu)";
            // 
            // txtGentapMF
            // 
            this.txtGentapMF.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGentapMF.Location = new System.Drawing.Point(19, 197);
            this.txtGentapMF.Name = "txtGentapMF";
            this.txtGentapMF.Size = new System.Drawing.Size(122, 24);
            this.txtGentapMF.TabIndex = 1;
            this.txtGentapMF.Text = "1.00000";
            this.txtGentapMF.Leave += new System.EventHandler(this.CheckNumberValidTextBoxEventLeave);
            // 
            // txtXTran_pu
            // 
            this.txtXTran_pu.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXTran_pu.Location = new System.Drawing.Point(19, 126);
            this.txtXTran_pu.Name = "txtXTran_pu";
            this.txtXTran_pu.Size = new System.Drawing.Size(122, 24);
            this.txtXTran_pu.TabIndex = 1;
            this.txtXTran_pu.Text = "0.00000";
            this.txtXTran_pu.Leave += new System.EventHandler(this.CheckNumberValidTextBoxEventLeave);
            // 
            // txtRTran_pu
            // 
            this.txtRTran_pu.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRTran_pu.Location = new System.Drawing.Point(19, 57);
            this.txtRTran_pu.Name = "txtRTran_pu";
            this.txtRTran_pu.Size = new System.Drawing.Size(122, 24);
            this.txtRTran_pu.TabIndex = 1;
            this.txtRTran_pu.Text = "0.00000";
            this.txtRTran_pu.Leave += new System.EventHandler(this.CheckNumberValidTextBoxEventLeave);
            // 
            // grbMachineData
            // 
            this.grbMachineData.Controls.Add(this.txtXSource_pu);
            this.grbMachineData.Controls.Add(this.txtQmin_Mvar);
            this.grbMachineData.Controls.Add(this.label14);
            this.grbMachineData.Controls.Add(this.txtPmin_MW);
            this.grbMachineData.Controls.Add(this.label11);
            this.grbMachineData.Controls.Add(this.txtRSource_pu);
            this.grbMachineData.Controls.Add(this.label8);
            this.grbMachineData.Controls.Add(this.txtQmax_Mvar);
            this.grbMachineData.Controls.Add(this.label13);
            this.grbMachineData.Controls.Add(this.txtPmax_MW);
            this.grbMachineData.Controls.Add(this.label10);
            this.grbMachineData.Controls.Add(this.txtMbase_MVA);
            this.grbMachineData.Controls.Add(this.label7);
            this.grbMachineData.Controls.Add(this.label12);
            this.grbMachineData.Controls.Add(this.txtQgen_Mvar);
            this.grbMachineData.Controls.Add(this.label9);
            this.grbMachineData.Controls.Add(this.txtPgen_MW);
            this.grbMachineData.Controls.Add(this.label6);
            this.grbMachineData.Dock = System.Windows.Forms.DockStyle.Left;
            this.grbMachineData.Location = new System.Drawing.Point(0, 0);
            this.grbMachineData.Name = "grbMachineData";
            this.grbMachineData.Size = new System.Drawing.Size(490, 237);
            this.grbMachineData.TabIndex = 0;
            this.grbMachineData.TabStop = false;
            this.grbMachineData.Text = "Machine Data";
            // 
            // txtXSource_pu
            // 
            this.txtXSource_pu.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXSource_pu.Location = new System.Drawing.Point(345, 197);
            this.txtXSource_pu.Name = "txtXSource_pu";
            this.txtXSource_pu.Size = new System.Drawing.Size(122, 24);
            this.txtXSource_pu.TabIndex = 1;
            this.txtXSource_pu.Text = "1.000000";
            this.txtXSource_pu.Leave += new System.EventHandler(this.CheckNumberValidTextBoxEventLeave);
            // 
            // txtQmin_Mvar
            // 
            this.txtQmin_Mvar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQmin_Mvar.Location = new System.Drawing.Point(345, 126);
            this.txtQmin_Mvar.Name = "txtQmin_Mvar";
            this.txtQmin_Mvar.Size = new System.Drawing.Size(122, 24);
            this.txtQmin_Mvar.TabIndex = 1;
            this.txtQmin_Mvar.Text = "-9999.0000";
            this.txtQmin_Mvar.Leave += new System.EventHandler(this.CheckNumberValidTextBoxEventLeave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(345, 172);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 17);
            this.label14.TabIndex = 0;
            this.label14.Text = "X Source (pu)";
            // 
            // txtPmin_MW
            // 
            this.txtPmin_MW.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPmin_MW.Location = new System.Drawing.Point(345, 57);
            this.txtPmin_MW.Name = "txtPmin_MW";
            this.txtPmin_MW.Size = new System.Drawing.Size(122, 24);
            this.txtPmin_MW.TabIndex = 1;
            this.txtPmin_MW.Text = "-9999.0000";
            this.txtPmin_MW.Leave += new System.EventHandler(this.CheckNumberValidTextBoxEventLeave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(345, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Qmin (Mvar)";
            // 
            // txtRSource_pu
            // 
            this.txtRSource_pu.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRSource_pu.Location = new System.Drawing.Point(177, 197);
            this.txtRSource_pu.Name = "txtRSource_pu";
            this.txtRSource_pu.Size = new System.Drawing.Size(122, 24);
            this.txtRSource_pu.TabIndex = 1;
            this.txtRSource_pu.Text = "0.000000";
            this.txtRSource_pu.Leave += new System.EventHandler(this.CheckNumberValidTextBoxEventLeave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(345, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Pmin (MW)";
            // 
            // txtQmax_Mvar
            // 
            this.txtQmax_Mvar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQmax_Mvar.Location = new System.Drawing.Point(177, 126);
            this.txtQmax_Mvar.Name = "txtQmax_Mvar";
            this.txtQmax_Mvar.Size = new System.Drawing.Size(122, 24);
            this.txtQmax_Mvar.TabIndex = 1;
            this.txtQmax_Mvar.Text = "9999.0000";
            this.txtQmax_Mvar.Leave += new System.EventHandler(this.CheckNumberValidTextBoxEventLeave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(177, 172);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 17);
            this.label13.TabIndex = 0;
            this.label13.Text = "R Source (pu)";
            // 
            // txtPmax_MW
            // 
            this.txtPmax_MW.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPmax_MW.Location = new System.Drawing.Point(177, 57);
            this.txtPmax_MW.Name = "txtPmax_MW";
            this.txtPmax_MW.Size = new System.Drawing.Size(122, 24);
            this.txtPmax_MW.TabIndex = 1;
            this.txtPmax_MW.Text = "9999.0000";
            this.txtPmax_MW.Leave += new System.EventHandler(this.CheckNumberValidTextBoxEventLeave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(177, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Qmax (Mvar)";
            // 
            // txtMbase_MVA
            // 
            this.txtMbase_MVA.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMbase_MVA.Location = new System.Drawing.Point(17, 197);
            this.txtMbase_MVA.Name = "txtMbase_MVA";
            this.txtMbase_MVA.Size = new System.Drawing.Size(122, 24);
            this.txtMbase_MVA.TabIndex = 1;
            this.txtMbase_MVA.Text = "100.00";
            this.txtMbase_MVA.Leave += new System.EventHandler(this.CheckNumberValidTextBoxEventLeave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(177, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Pmax (MW)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(17, 172);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "Mbase (MVA)";
            // 
            // txtQgen_Mvar
            // 
            this.txtQgen_Mvar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQgen_Mvar.Location = new System.Drawing.Point(17, 126);
            this.txtQgen_Mvar.Name = "txtQgen_Mvar";
            this.txtQgen_Mvar.Size = new System.Drawing.Size(122, 24);
            this.txtQgen_Mvar.TabIndex = 1;
            this.txtQgen_Mvar.Text = "0.0000";
            this.txtQgen_Mvar.Leave += new System.EventHandler(this.CheckNumberValidTextBoxEventLeave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Qgen (Mvar)";
            // 
            // txtPgen_MW
            // 
            this.txtPgen_MW.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPgen_MW.Location = new System.Drawing.Point(17, 57);
            this.txtPgen_MW.Name = "txtPgen_MW";
            this.txtPgen_MW.Size = new System.Drawing.Size(122, 24);
            this.txtPgen_MW.TabIndex = 1;
            this.txtPgen_MW.Text = "0.0000";
            this.txtPgen_MW.Leave += new System.EventHandler(this.CheckNumberValidTextBoxEventLeave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Pgen (MW)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkInService);
            this.groupBox1.Controls.Add(this.txtMachineName);
            this.groupBox1.Controls.Add(this.txtMachineID);
            this.groupBox1.Controls.Add(this.lblBusConnTypeCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblBusNameConnMF);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblBusNumConnMF);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(669, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic Data";
            // 
            // chkInService
            // 
            this.chkInService.AutoSize = true;
            this.chkInService.Checked = true;
            this.chkInService.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInService.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInService.Location = new System.Drawing.Point(487, 82);
            this.chkInService.Name = "chkInService";
            this.chkInService.Size = new System.Drawing.Size(87, 21);
            this.chkInService.TabIndex = 3;
            this.chkInService.Text = "In Service";
            this.chkInService.UseVisualStyleBackColor = true;
            // 
            // txtMachineName
            // 
            this.txtMachineName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMachineName.Location = new System.Drawing.Point(316, 80);
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.Size = new System.Drawing.Size(151, 24);
            this.txtMachineName.TabIndex = 2;
            // 
            // txtMachineID
            // 
            this.txtMachineID.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMachineID.Location = new System.Drawing.Point(103, 80);
            this.txtMachineID.Name = "txtMachineID";
            this.txtMachineID.Size = new System.Drawing.Size(93, 24);
            this.txtMachineID.TabIndex = 2;
            this.txtMachineID.Leave += new System.EventHandler(this.CheckNumberValidTextBoxEventLeave);
            // 
            // lblBusConnTypeCode
            // 
            this.lblBusConnTypeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBusConnTypeCode.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusConnTypeCode.Location = new System.Drawing.Point(595, 33);
            this.lblBusConnTypeCode.Name = "lblBusConnTypeCode";
            this.lblBusConnTypeCode.Size = new System.Drawing.Size(62, 20);
            this.lblBusConnTypeCode.TabIndex = 1;
            this.lblBusConnTypeCode.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(484, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Bus Type Code";
            // 
            // lblBusNameConnMF
            // 
            this.lblBusNameConnMF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBusNameConnMF.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusNameConnMF.Location = new System.Drawing.Point(304, 33);
            this.lblBusNameConnMF.Name = "lblBusNameConnMF";
            this.lblBusNameConnMF.Size = new System.Drawing.Size(162, 20);
            this.lblBusNameConnMF.TabIndex = 1;
            this.lblBusNameConnMF.Text = "NULL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(210, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Bus Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(214, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Machine Name";
            // 
            // lblBusNumConnMF
            // 
            this.lblBusNumConnMF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBusNumConnMF.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusNumConnMF.Location = new System.Drawing.Point(103, 33);
            this.lblBusNumConnMF.Name = "lblBusNumConnMF";
            this.lblBusNumConnMF.Size = new System.Drawing.Size(93, 20);
            this.lblBusNumConnMF.TabIndex = 1;
            this.lblBusNumConnMF.Text = "101";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Machine ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bus Number";
            // 
            // btnOKGene
            // 
            this.btnOKGene.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOKGene.Location = new System.Drawing.Point(204, 686);
            this.btnOKGene.Name = "btnOKGene";
            this.btnOKGene.Size = new System.Drawing.Size(106, 26);
            this.btnOKGene.TabIndex = 1;
            this.btnOKGene.Text = "OK";
            this.btnOKGene.UseVisualStyleBackColor = true;
            this.btnOKGene.Click += new System.EventHandler(this.btnOKGene_Click);
            // 
            // btnCancelGene
            // 
            this.btnCancelGene.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelGene.Location = new System.Drawing.Point(370, 686);
            this.btnCancelGene.Name = "btnCancelGene";
            this.btnCancelGene.Size = new System.Drawing.Size(106, 26);
            this.btnCancelGene.TabIndex = 1;
            this.btnCancelGene.Text = "Cancel";
            this.btnCancelGene.UseVisualStyleBackColor = true;
            this.btnCancelGene.Click += new System.EventHandler(this.btnCancelGene_Click);
            // 
            // frmDataGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(735, 731);
            this.Controls.Add(this.btnCancelGene);
            this.Controls.Add(this.btnOKGene);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDataGenerator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Machine Data Record";
            this.Load += new System.EventHandler(this.frmDataGenerator_Load);
            this.panel1.ResumeLayout(false);
            this.tabCtrlPowerFlow.ResumeLayout(false);
            this.tabPowerFlow.ResumeLayout(false);
            this.pnlMachineAndPlant.ResumeLayout(false);
            this.grbPlantData.ResumeLayout(false);
            this.grbPlantData.PerformLayout();
            this.grbWindData.ResumeLayout(false);
            this.grbWindData.PerformLayout();
            this.pnlMachineData.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grbMachineData.ResumeLayout(false);
            this.grbMachineData.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabCtrlPowerFlow;
        private System.Windows.Forms.TabPage tabPowerFlow;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblBusConnTypeCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBusNameConnMF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBusNumConnMF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMachineData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grbMachineData;
        private System.Windows.Forms.CheckBox chkInService;
        private System.Windows.Forms.TextBox txtMachineID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPgen_MW;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPmin_MW;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPmax_MW;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtXSource_pu;
        private System.Windows.Forms.TextBox txtQmin_Mvar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRSource_pu;
        private System.Windows.Forms.TextBox txtQmax_Mvar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMbase_MVA;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtQgen_Mvar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtGentapMF;
        private System.Windows.Forms.TextBox txtXTran_pu;
        private System.Windows.Forms.TextBox txtRTran_pu;
        private System.Windows.Forms.Panel pnlMachineAndPlant;
        private System.Windows.Forms.GroupBox grbPlantData;
        private System.Windows.Forms.GroupBox grbWindData;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtRemoteBus;
        private System.Windows.Forms.TextBox txtSchedVoltage;
        private System.Windows.Forms.ComboBox cboControlMode;
        private System.Windows.Forms.Label lblValuePowerFactor;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnOKGene;
        private System.Windows.Forms.Button btnCancelGene;
        private System.Windows.Forms.TextBox txtMachineName;
        private System.Windows.Forms.Label label4;
    }
}