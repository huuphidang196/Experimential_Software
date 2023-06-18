
using System;

namespace Experimential_Software
{
    partial class frmDataMBA2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDataMBA2));
            this.pnlManagerTabCtrl = new System.Windows.Forms.Panel();
            this.tabMBA2 = new System.Windows.Forms.TabControl();
            this.tabPowerFlow = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pnlPrimUpDown = new System.Windows.Forms.Panel();
            this.btnPrimUp = new System.Windows.Forms.Button();
            this.imgListUpDown = new System.Windows.Forms.ImageList(this.components);
            this.btnPrimDown = new System.Windows.Forms.Button();
            this.pnlSecUpDown = new System.Windows.Forms.Panel();
            this.btnSecUp = new System.Windows.Forms.Button();
            this.btnSecDown = new System.Windows.Forms.Button();
            this.txtFixedSeckV = new System.Windows.Forms.TextBox();
            this.txtFixedPrimkV = new System.Windows.Forms.TextBox();
            this.btnTCSec = new System.Windows.Forms.Button();
            this.lblTransUnit = new System.Windows.Forms.Label();
            this.btnTCPrim = new System.Windows.Forms.Button();
            this.btnTCUnitMain = new System.Windows.Forms.Button();
            this.lblTapTransSecFixed = new System.Windows.Forms.Label();
            this.lblTapTransPrimFixed = new System.Windows.Forms.Label();
            this.grbVoltageRating = new System.Windows.Forms.GroupBox();
            this.txtRatedSeckV = new System.Windows.Forms.TextBox();
            this.txtRatedPrimkV = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblNorBusSeckV = new System.Windows.Forms.Label();
            this.lblNorBusPrimkV = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPowerRated = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.grbImpendanceMBA2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMagBpu = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtMagGpu = new System.Windows.Forms.TextBox();
            this.txtSpecXpu = new System.Windows.Forms.TextBox();
            this.txtSpecRpu = new System.Windows.Forms.TextBox();
            this.grbLineMBA2Data = new System.Windows.Forms.GroupBox();
            this.chkWinding1 = new System.Windows.Forms.CheckBox();
            this.chkMeterd = new System.Windows.Forms.CheckBox();
            this.chkinService = new System.Windows.Forms.CheckBox();
            this.txtTransID = new System.Windows.Forms.TextBox();
            this.txtTransName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblToBusName = new System.Windows.Forms.Label();
            this.lblToBusNum = new System.Windows.Forms.Label();
            this.lblFromBusName = new System.Windows.Forms.Label();
            this.lblFromBusNum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOkMBA2 = new System.Windows.Forms.Button();
            this.btnCancelMBA2 = new System.Windows.Forms.Button();
            this.pnlManagerTabCtrl.SuspendLayout();
            this.tabMBA2.SuspendLayout();
            this.tabPowerFlow.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pnlPrimUpDown.SuspendLayout();
            this.pnlSecUpDown.SuspendLayout();
            this.grbVoltageRating.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grbImpendanceMBA2.SuspendLayout();
            this.grbLineMBA2Data.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlManagerTabCtrl
            // 
            this.pnlManagerTabCtrl.Controls.Add(this.tabMBA2);
            this.pnlManagerTabCtrl.Location = new System.Drawing.Point(12, 12);
            this.pnlManagerTabCtrl.Name = "pnlManagerTabCtrl";
            this.pnlManagerTabCtrl.Size = new System.Drawing.Size(836, 708);
            this.pnlManagerTabCtrl.TabIndex = 0;
            // 
            // tabMBA2
            // 
            this.tabMBA2.Controls.Add(this.tabPowerFlow);
            this.tabMBA2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMBA2.Location = new System.Drawing.Point(0, 0);
            this.tabMBA2.Name = "tabMBA2";
            this.tabMBA2.SelectedIndex = 0;
            this.tabMBA2.Size = new System.Drawing.Size(836, 708);
            this.tabMBA2.TabIndex = 0;
            // 
            // tabPowerFlow
            // 
            this.tabPowerFlow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPowerFlow.Controls.Add(this.panel2);
            this.tabPowerFlow.Controls.Add(this.panel1);
            this.tabPowerFlow.Controls.Add(this.grbLineMBA2Data);
            this.tabPowerFlow.ForeColor = System.Drawing.Color.Black;
            this.tabPowerFlow.Location = new System.Drawing.Point(4, 27);
            this.tabPowerFlow.Name = "tabPowerFlow";
            this.tabPowerFlow.Padding = new System.Windows.Forms.Padding(3);
            this.tabPowerFlow.Size = new System.Drawing.Size(828, 677);
            this.tabPowerFlow.TabIndex = 0;
            this.tabPowerFlow.Text = "Power Flow";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.grbVoltageRating);
            this.panel2.Location = new System.Drawing.Point(16, 423);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(793, 220);
            this.panel2.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pnlPrimUpDown);
            this.groupBox3.Controls.Add(this.pnlSecUpDown);
            this.groupBox3.Controls.Add(this.txtFixedSeckV);
            this.groupBox3.Controls.Add(this.txtFixedPrimkV);
            this.groupBox3.Controls.Add(this.btnTCSec);
            this.groupBox3.Controls.Add(this.lblTransUnit);
            this.groupBox3.Controls.Add(this.btnTCPrim);
            this.groupBox3.Controls.Add(this.btnTCUnitMain);
            this.groupBox3.Controls.Add(this.lblTapTransSecFixed);
            this.groupBox3.Controls.Add(this.lblTapTransPrimFixed);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(402, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(391, 220);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Fixed Tap";
            // 
            // pnlPrimUpDown
            // 
            this.pnlPrimUpDown.BackColor = System.Drawing.Color.Transparent;
            this.pnlPrimUpDown.Controls.Add(this.btnPrimUp);
            this.pnlPrimUpDown.Controls.Add(this.btnPrimDown);
            this.pnlPrimUpDown.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlPrimUpDown.Location = new System.Drawing.Point(237, 65);
            this.pnlPrimUpDown.Name = "pnlPrimUpDown";
            this.pnlPrimUpDown.Size = new System.Drawing.Size(25, 42);
            this.pnlPrimUpDown.TabIndex = 2;
            // 
            // btnPrimUp
            // 
            this.btnPrimUp.BackColor = System.Drawing.Color.Transparent;
            this.btnPrimUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPrimUp.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrimUp.ImageIndex = 0;
            this.btnPrimUp.ImageList = this.imgListUpDown;
            this.btnPrimUp.Location = new System.Drawing.Point(0, 0);
            this.btnPrimUp.Name = "btnPrimUp";
            this.btnPrimUp.Size = new System.Drawing.Size(25, 18);
            this.btnPrimUp.TabIndex = 0;
            this.btnPrimUp.Tag = "PrimUp";
            this.btnPrimUp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrimUp.UseVisualStyleBackColor = false;
            this.btnPrimUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EventButtonUpFixedTapZone);
            // 
            // imgListUpDown
            // 
            this.imgListUpDown.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListUpDown.ImageStream")));
            this.imgListUpDown.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListUpDown.Images.SetKeyName(0, "btnUp.png");
            this.imgListUpDown.Images.SetKeyName(1, "btnDown.png");
            // 
            // btnPrimDown
            // 
            this.btnPrimDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPrimDown.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrimDown.ImageIndex = 1;
            this.btnPrimDown.ImageList = this.imgListUpDown;
            this.btnPrimDown.Location = new System.Drawing.Point(0, 24);
            this.btnPrimDown.Name = "btnPrimDown";
            this.btnPrimDown.Size = new System.Drawing.Size(25, 18);
            this.btnPrimDown.TabIndex = 1;
            this.btnPrimDown.Tag = "PrimDown";
            this.btnPrimDown.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrimDown.UseVisualStyleBackColor = true;
            this.btnPrimDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EventButtonDownFixedTapZone);
            // 
            // pnlSecUpDown
            // 
            this.pnlSecUpDown.BackColor = System.Drawing.Color.Transparent;
            this.pnlSecUpDown.Controls.Add(this.btnSecUp);
            this.pnlSecUpDown.Controls.Add(this.btnSecDown);
            this.pnlSecUpDown.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSecUpDown.Location = new System.Drawing.Point(237, 144);
            this.pnlSecUpDown.Name = "pnlSecUpDown";
            this.pnlSecUpDown.Size = new System.Drawing.Size(25, 42);
            this.pnlSecUpDown.TabIndex = 3;
            // 
            // btnSecUp
            // 
            this.btnSecUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSecUp.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSecUp.ImageIndex = 0;
            this.btnSecUp.ImageList = this.imgListUpDown;
            this.btnSecUp.Location = new System.Drawing.Point(0, 0);
            this.btnSecUp.Name = "btnSecUp";
            this.btnSecUp.Size = new System.Drawing.Size(25, 18);
            this.btnSecUp.TabIndex = 0;
            this.btnSecUp.Tag = "SecUp";
            this.btnSecUp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSecUp.UseVisualStyleBackColor = true;
            this.btnSecUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EventButtonUpFixedTapZone);
            // 
            // btnSecDown
            // 
            this.btnSecDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSecDown.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSecDown.ImageIndex = 1;
            this.btnSecDown.ImageList = this.imgListUpDown;
            this.btnSecDown.Location = new System.Drawing.Point(0, 24);
            this.btnSecDown.Name = "btnSecDown";
            this.btnSecDown.Size = new System.Drawing.Size(25, 18);
            this.btnSecDown.TabIndex = 1;
            this.btnSecDown.Tag = "SecDown";
            this.btnSecDown.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSecDown.UseVisualStyleBackColor = true;
            this.btnSecDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EventButtonDownFixedTapZone);
            // 
            // txtFixedSeckV
            // 
            this.txtFixedSeckV.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFixedSeckV.Location = new System.Drawing.Point(158, 153);
            this.txtFixedSeckV.Name = "txtFixedSeckV";
            this.txtFixedSeckV.Size = new System.Drawing.Size(66, 24);
            this.txtFixedSeckV.TabIndex = 3;
            this.txtFixedSeckV.Text = "110";
            this.txtFixedSeckV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFixedSeckV.Leave += new System.EventHandler(this.CheckTextBoxValidEventTextBoxLeave);
            // 
            // txtFixedPrimkV
            // 
            this.txtFixedPrimkV.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFixedPrimkV.Location = new System.Drawing.Point(158, 74);
            this.txtFixedPrimkV.Name = "txtFixedPrimkV";
            this.txtFixedPrimkV.Size = new System.Drawing.Size(66, 24);
            this.txtFixedPrimkV.TabIndex = 1;
            this.txtFixedPrimkV.Text = "110";
            this.txtFixedPrimkV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFixedPrimkV.Leave += new System.EventHandler(this.CheckTextBoxValidEventTextBoxLeave);
            // 
            // btnTCSec
            // 
            this.btnTCSec.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTCSec.Location = new System.Drawing.Point(42, 150);
            this.btnTCSec.Name = "btnTCSec";
            this.btnTCSec.Size = new System.Drawing.Size(81, 28);
            this.btnTCSec.TabIndex = 4;
            this.btnTCSec.Text = "Sec...";
            this.btnTCSec.UseVisualStyleBackColor = true;
            this.btnTCSec.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTapChangerPrimAndSecZoneFixed_MouseDown);
            // 
            // lblTransUnit
            // 
            this.lblTransUnit.AutoSize = true;
            this.lblTransUnit.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransUnit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTransUnit.Location = new System.Drawing.Point(291, 28);
            this.lblTransUnit.Name = "lblTransUnit";
            this.lblTransUnit.Size = new System.Drawing.Size(50, 17);
            this.lblTransUnit.TabIndex = 0;
            this.lblTransUnit.Text = "kV Tap";
            // 
            // btnTCPrim
            // 
            this.btnTCPrim.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTCPrim.Location = new System.Drawing.Point(42, 74);
            this.btnTCPrim.Name = "btnTCPrim";
            this.btnTCPrim.Size = new System.Drawing.Size(81, 28);
            this.btnTCPrim.TabIndex = 2;
            this.btnTCPrim.Text = "Prim...";
            this.btnTCPrim.UseVisualStyleBackColor = true;
            this.btnTCPrim.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTapChangerPrimAndSecZoneFixed_MouseDown);
            // 
            // btnTCUnitMain
            // 
            this.btnTCUnitMain.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTCUnitMain.Location = new System.Drawing.Point(147, 25);
            this.btnTCUnitMain.Name = "btnTCUnitMain";
            this.btnTCUnitMain.Size = new System.Drawing.Size(89, 25);
            this.btnTCUnitMain.TabIndex = 0;
            this.btnTCUnitMain.Text = "% Tap";
            this.btnTCUnitMain.UseVisualStyleBackColor = true;
            this.btnTCUnitMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTCUnitMain_MouseDown);
            // 
            // lblTapTransSecFixed
            // 
            this.lblTapTransSecFixed.BackColor = System.Drawing.Color.White;
            this.lblTapTransSecFixed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTapTransSecFixed.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTapTransSecFixed.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTapTransSecFixed.Location = new System.Drawing.Point(289, 154);
            this.lblTapTransSecFixed.Name = "lblTapTransSecFixed";
            this.lblTapTransSecFixed.Size = new System.Drawing.Size(54, 20);
            this.lblTapTransSecFixed.TabIndex = 0;
            this.lblTapTransSecFixed.Text = "22.1";
            this.lblTapTransSecFixed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTapTransPrimFixed
            // 
            this.lblTapTransPrimFixed.BackColor = System.Drawing.Color.White;
            this.lblTapTransPrimFixed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTapTransPrimFixed.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTapTransPrimFixed.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTapTransPrimFixed.Location = new System.Drawing.Point(289, 74);
            this.lblTapTransPrimFixed.Name = "lblTapTransPrimFixed";
            this.lblTapTransPrimFixed.Size = new System.Drawing.Size(54, 20);
            this.lblTapTransPrimFixed.TabIndex = 0;
            this.lblTapTransPrimFixed.Text = "115.2365";
            this.lblTapTransPrimFixed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grbVoltageRating
            // 
            this.grbVoltageRating.Controls.Add(this.txtRatedSeckV);
            this.grbVoltageRating.Controls.Add(this.txtRatedPrimkV);
            this.grbVoltageRating.Controls.Add(this.label13);
            this.grbVoltageRating.Controls.Add(this.label15);
            this.grbVoltageRating.Controls.Add(this.label12);
            this.grbVoltageRating.Controls.Add(this.label11);
            this.grbVoltageRating.Controls.Add(this.lblNorBusSeckV);
            this.grbVoltageRating.Controls.Add(this.lblNorBusPrimkV);
            this.grbVoltageRating.Dock = System.Windows.Forms.DockStyle.Left;
            this.grbVoltageRating.Location = new System.Drawing.Point(0, 0);
            this.grbVoltageRating.Name = "grbVoltageRating";
            this.grbVoltageRating.Size = new System.Drawing.Size(391, 220);
            this.grbVoltageRating.TabIndex = 0;
            this.grbVoltageRating.TabStop = false;
            this.grbVoltageRating.Text = "Voltage Rating";
            // 
            // txtRatedSeckV
            // 
            this.txtRatedSeckV.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRatedSeckV.Location = new System.Drawing.Point(114, 154);
            this.txtRatedSeckV.Name = "txtRatedSeckV";
            this.txtRatedSeckV.Size = new System.Drawing.Size(66, 24);
            this.txtRatedSeckV.TabIndex = 1;
            this.txtRatedSeckV.Text = "110";
            this.txtRatedSeckV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRatedSeckV.Leave += new System.EventHandler(this.CheckTextBoxValidEventTextBoxLeave);
            // 
            // txtRatedPrimkV
            // 
            this.txtRatedPrimkV.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRatedPrimkV.Location = new System.Drawing.Point(114, 75);
            this.txtRatedPrimkV.Name = "txtRatedPrimkV";
            this.txtRatedPrimkV.Size = new System.Drawing.Size(66, 24);
            this.txtRatedPrimkV.TabIndex = 0;
            this.txtRatedPrimkV.Text = "110";
            this.txtRatedPrimkV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRatedPrimkV.Leave += new System.EventHandler(this.CheckTextBoxValidEventTextBoxLeave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(54, 157);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 17);
            this.label13.TabIndex = 0;
            this.label13.Text = "Sec.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(209, 33);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 17);
            this.label15.TabIndex = 0;
            this.label15.Text = "Normal Bus kV";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(134, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "kV";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(54, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Prim.";
            // 
            // lblNorBusSeckV
            // 
            this.lblNorBusSeckV.BackColor = System.Drawing.Color.White;
            this.lblNorBusSeckV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNorBusSeckV.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNorBusSeckV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNorBusSeckV.Location = new System.Drawing.Point(222, 154);
            this.lblNorBusSeckV.Name = "lblNorBusSeckV";
            this.lblNorBusSeckV.Size = new System.Drawing.Size(74, 22);
            this.lblNorBusSeckV.TabIndex = 0;
            this.lblNorBusSeckV.Text = "110";
            this.lblNorBusSeckV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNorBusPrimkV
            // 
            this.lblNorBusPrimkV.BackColor = System.Drawing.Color.White;
            this.lblNorBusPrimkV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNorBusPrimkV.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNorBusPrimkV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNorBusPrimkV.Location = new System.Drawing.Point(222, 75);
            this.lblNorBusPrimkV.Name = "lblNorBusPrimkV";
            this.lblNorBusPrimkV.Size = new System.Drawing.Size(74, 22);
            this.lblNorBusPrimkV.TabIndex = 0;
            this.lblNorBusPrimkV.Text = "110";
            this.lblNorBusPrimkV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.grbImpendanceMBA2);
            this.panel1.Location = new System.Drawing.Point(16, 228);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 177);
            this.panel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPowerRated);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(183, 177);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Power Rating";
            // 
            // txtPowerRated
            // 
            this.txtPowerRated.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPowerRated.Location = new System.Drawing.Point(88, 95);
            this.txtPowerRated.Name = "txtPowerRated";
            this.txtPowerRated.Size = new System.Drawing.Size(66, 24);
            this.txtPowerRated.TabIndex = 0;
            this.txtPowerRated.Text = "500";
            this.txtPowerRated.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPowerRated.Leave += new System.EventHandler(this.CheckTextBoxValidEventTextBoxLeave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(77, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 17);
            this.label14.TabIndex = 0;
            this.label14.Text = "MVA";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.Location = new System.Drawing.Point(32, 98);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 17);
            this.label16.TabIndex = 0;
            this.label16.Text = "Rated";
            // 
            // grbImpendanceMBA2
            // 
            this.grbImpendanceMBA2.BackColor = System.Drawing.Color.Transparent;
            this.grbImpendanceMBA2.Controls.Add(this.label10);
            this.grbImpendanceMBA2.Controls.Add(this.label17);
            this.grbImpendanceMBA2.Controls.Add(this.label8);
            this.grbImpendanceMBA2.Controls.Add(this.label9);
            this.grbImpendanceMBA2.Controls.Add(this.label7);
            this.grbImpendanceMBA2.Controls.Add(this.txtMagBpu);
            this.grbImpendanceMBA2.Controls.Add(this.textBox2);
            this.grbImpendanceMBA2.Controls.Add(this.txtMagGpu);
            this.grbImpendanceMBA2.Controls.Add(this.txtSpecXpu);
            this.grbImpendanceMBA2.Controls.Add(this.txtSpecRpu);
            this.grbImpendanceMBA2.Dock = System.Windows.Forms.DockStyle.Right;
            this.grbImpendanceMBA2.Location = new System.Drawing.Point(200, 0);
            this.grbImpendanceMBA2.Name = "grbImpendanceMBA2";
            this.grbImpendanceMBA2.Size = new System.Drawing.Size(593, 177);
            this.grbImpendanceMBA2.TabIndex = 1;
            this.grbImpendanceMBA2.TabStop = false;
            this.grbImpendanceMBA2.Text = "Transformer Inpedance Data";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(228, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Magnetizing B (pu)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label17.Location = new System.Drawing.Point(427, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(120, 17);
            this.label17.TabIndex = 0;
            this.label17.Text = "Impendance Table";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(228, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Specified X (pu)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(24, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Magnetizing G (pu)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(24, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Specified R (pu)";
            // 
            // txtMagBpu
            // 
            this.txtMagBpu.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMagBpu.Location = new System.Drawing.Point(231, 127);
            this.txtMagBpu.Name = "txtMagBpu";
            this.txtMagBpu.Size = new System.Drawing.Size(120, 24);
            this.txtMagBpu.TabIndex = 4;
            this.txtMagBpu.Text = "0.000000";
            this.txtMagBpu.Leave += new System.EventHandler(this.CheckTextBoxValidEventTextBoxLeave);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(430, 55);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(120, 24);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "0.000000";
            this.textBox2.Leave += new System.EventHandler(this.CheckTextBoxValidEventTextBoxLeave);
            // 
            // txtMagGpu
            // 
            this.txtMagGpu.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMagGpu.Location = new System.Drawing.Point(27, 127);
            this.txtMagGpu.Name = "txtMagGpu";
            this.txtMagGpu.Size = new System.Drawing.Size(120, 24);
            this.txtMagGpu.TabIndex = 3;
            this.txtMagGpu.Text = "0.000000";
            this.txtMagGpu.Leave += new System.EventHandler(this.CheckTextBoxValidEventTextBoxLeave);
            // 
            // txtSpecXpu
            // 
            this.txtSpecXpu.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpecXpu.Location = new System.Drawing.Point(231, 55);
            this.txtSpecXpu.Name = "txtSpecXpu";
            this.txtSpecXpu.Size = new System.Drawing.Size(120, 24);
            this.txtSpecXpu.TabIndex = 1;
            this.txtSpecXpu.Text = "0.000000";
            this.txtSpecXpu.Leave += new System.EventHandler(this.CheckTextBoxValidEventTextBoxLeave);
            // 
            // txtSpecRpu
            // 
            this.txtSpecRpu.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpecRpu.Location = new System.Drawing.Point(27, 55);
            this.txtSpecRpu.Name = "txtSpecRpu";
            this.txtSpecRpu.Size = new System.Drawing.Size(120, 24);
            this.txtSpecRpu.TabIndex = 0;
            this.txtSpecRpu.Text = "0.000000";
            this.txtSpecRpu.Leave += new System.EventHandler(this.CheckTextBoxValidEventTextBoxLeave);
            // 
            // grbLineMBA2Data
            // 
            this.grbLineMBA2Data.BackColor = System.Drawing.Color.Transparent;
            this.grbLineMBA2Data.Controls.Add(this.chkWinding1);
            this.grbLineMBA2Data.Controls.Add(this.chkMeterd);
            this.grbLineMBA2Data.Controls.Add(this.chkinService);
            this.grbLineMBA2Data.Controls.Add(this.txtTransID);
            this.grbLineMBA2Data.Controls.Add(this.txtTransName);
            this.grbLineMBA2Data.Controls.Add(this.label6);
            this.grbLineMBA2Data.Controls.Add(this.label3);
            this.grbLineMBA2Data.Controls.Add(this.label5);
            this.grbLineMBA2Data.Controls.Add(this.label2);
            this.grbLineMBA2Data.Controls.Add(this.label4);
            this.grbLineMBA2Data.Controls.Add(this.lblToBusName);
            this.grbLineMBA2Data.Controls.Add(this.lblToBusNum);
            this.grbLineMBA2Data.Controls.Add(this.lblFromBusName);
            this.grbLineMBA2Data.Controls.Add(this.lblFromBusNum);
            this.grbLineMBA2Data.Controls.Add(this.label1);
            this.grbLineMBA2Data.ForeColor = System.Drawing.Color.Black;
            this.grbLineMBA2Data.Location = new System.Drawing.Point(16, 19);
            this.grbLineMBA2Data.Name = "grbLineMBA2Data";
            this.grbLineMBA2Data.Size = new System.Drawing.Size(793, 192);
            this.grbLineMBA2Data.TabIndex = 0;
            this.grbLineMBA2Data.TabStop = false;
            this.grbLineMBA2Data.Text = "Line Data";
            // 
            // chkWinding1
            // 
            this.chkWinding1.AutoSize = true;
            this.chkWinding1.Checked = true;
            this.chkWinding1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWinding1.Location = new System.Drawing.Point(604, 142);
            this.chkWinding1.Name = "chkWinding1";
            this.chkWinding1.Size = new System.Drawing.Size(179, 22);
            this.chkWinding1.TabIndex = 3;
            this.chkWinding1.Text = "Winding 1 on From End";
            this.chkWinding1.UseVisualStyleBackColor = true;
            // 
            // chkMeterd
            // 
            this.chkMeterd.AutoSize = true;
            this.chkMeterd.Checked = true;
            this.chkMeterd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMeterd.Location = new System.Drawing.Point(604, 90);
            this.chkMeterd.Name = "chkMeterd";
            this.chkMeterd.Size = new System.Drawing.Size(170, 22);
            this.chkMeterd.TabIndex = 3;
            this.chkMeterd.Text = "Metered on From End";
            this.chkMeterd.UseVisualStyleBackColor = true;
            // 
            // chkinService
            // 
            this.chkinService.AutoSize = true;
            this.chkinService.BackColor = System.Drawing.Color.Transparent;
            this.chkinService.Checked = true;
            this.chkinService.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkinService.ForeColor = System.Drawing.Color.Black;
            this.chkinService.Location = new System.Drawing.Point(604, 38);
            this.chkinService.Name = "chkinService";
            this.chkinService.Size = new System.Drawing.Size(92, 22);
            this.chkinService.TabIndex = 2;
            this.chkinService.Text = "In Service";
            this.chkinService.UseVisualStyleBackColor = false;
            // 
            // txtTransID
            // 
            this.txtTransID.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransID.Location = new System.Drawing.Point(138, 139);
            this.txtTransID.Name = "txtTransID";
            this.txtTransID.Size = new System.Drawing.Size(134, 24);
            this.txtTransID.TabIndex = 0;
            this.txtTransID.Leave += new System.EventHandler(this.CheckTextBoxValidEventTextBoxLeave);
            // 
            // txtTransName
            // 
            this.txtTransName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransName.Location = new System.Drawing.Point(434, 139);
            this.txtTransName.Name = "txtTransName";
            this.txtTransName.Size = new System.Drawing.Size(134, 24);
            this.txtTransName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(299, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Transformer Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(15, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Transformer ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(299, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "To Bus Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(15, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "To Bus Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(299, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "From Bus Name";
            // 
            // lblToBusName
            // 
            this.lblToBusName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblToBusName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToBusName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblToBusName.Location = new System.Drawing.Point(436, 90);
            this.lblToBusName.Name = "lblToBusName";
            this.lblToBusName.Size = new System.Drawing.Size(132, 20);
            this.lblToBusName.TabIndex = 0;
            this.lblToBusName.Text = "1110";
            // 
            // lblToBusNum
            // 
            this.lblToBusNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblToBusNum.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToBusNum.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblToBusNum.Location = new System.Drawing.Point(138, 90);
            this.lblToBusNum.Name = "lblToBusNum";
            this.lblToBusNum.Size = new System.Drawing.Size(132, 20);
            this.lblToBusNum.TabIndex = 0;
            this.lblToBusNum.Text = "1110";
            // 
            // lblFromBusName
            // 
            this.lblFromBusName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFromBusName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromBusName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFromBusName.Location = new System.Drawing.Point(436, 39);
            this.lblFromBusName.Name = "lblFromBusName";
            this.lblFromBusName.Size = new System.Drawing.Size(132, 20);
            this.lblFromBusName.TabIndex = 0;
            this.lblFromBusName.Text = "1110";
            // 
            // lblFromBusNum
            // 
            this.lblFromBusNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFromBusNum.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromBusNum.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFromBusNum.Location = new System.Drawing.Point(138, 36);
            this.lblFromBusNum.Name = "lblFromBusNum";
            this.lblFromBusNum.Size = new System.Drawing.Size(132, 20);
            this.lblFromBusNum.TabIndex = 0;
            this.lblFromBusNum.Text = "1110";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(15, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Bus Number";
            // 
            // btnOkMBA2
            // 
            this.btnOkMBA2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOkMBA2.Location = new System.Drawing.Point(306, 738);
            this.btnOkMBA2.Name = "btnOkMBA2";
            this.btnOkMBA2.Size = new System.Drawing.Size(75, 25);
            this.btnOkMBA2.TabIndex = 0;
            this.btnOkMBA2.Text = "OK";
            this.btnOkMBA2.UseVisualStyleBackColor = true;
            this.btnOkMBA2.Click += new System.EventHandler(this.btnOkMBA2_Click);
            // 
            // btnCancelMBA2
            // 
            this.btnCancelMBA2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelMBA2.Location = new System.Drawing.Point(482, 738);
            this.btnCancelMBA2.Name = "btnCancelMBA2";
            this.btnCancelMBA2.Size = new System.Drawing.Size(75, 25);
            this.btnCancelMBA2.TabIndex = 1;
            this.btnCancelMBA2.Text = "Cancel";
            this.btnCancelMBA2.UseVisualStyleBackColor = true;
            this.btnCancelMBA2.Click += new System.EventHandler(this.btnCancelMBA2_Click);
            // 
            // frmDataMBA2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(860, 778);
            this.Controls.Add(this.btnCancelMBA2);
            this.Controls.Add(this.btnOkMBA2);
            this.Controls.Add(this.pnlManagerTabCtrl);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDataMBA2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Two Winding Transformer Data Record";
            this.Load += new System.EventHandler(this.frmDataMBA2_Load);
            this.pnlManagerTabCtrl.ResumeLayout(false);
            this.tabMBA2.ResumeLayout(false);
            this.tabPowerFlow.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.pnlPrimUpDown.ResumeLayout(false);
            this.pnlSecUpDown.ResumeLayout(false);
            this.grbVoltageRating.ResumeLayout(false);
            this.grbVoltageRating.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grbImpendanceMBA2.ResumeLayout(false);
            this.grbImpendanceMBA2.PerformLayout();
            this.grbLineMBA2Data.ResumeLayout(false);
            this.grbLineMBA2Data.PerformLayout();
            this.ResumeLayout(false);

        }

   
        #endregion

        private System.Windows.Forms.Panel pnlManagerTabCtrl;
        private System.Windows.Forms.TabControl tabMBA2;
        private System.Windows.Forms.TabPage tabPowerFlow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFromBusNum;
        private System.Windows.Forms.Label lblToBusName;
        private System.Windows.Forms.Label lblToBusNum;
        private System.Windows.Forms.Label lblFromBusName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblTapTransSecFixed;
        private System.Windows.Forms.Panel pnlPrimUpDown;
        private System.Windows.Forms.Panel pnlSecUpDown;
        private System.Windows.Forms.ImageList imgListUpDown;
        private System.Windows.Forms.Button btnOkMBA2;
        private System.Windows.Forms.Button btnCancelMBA2;
        public System.Windows.Forms.CheckBox chkinService;
        public System.Windows.Forms.TextBox txtTransName;
        public System.Windows.Forms.CheckBox chkMeterd;
        public System.Windows.Forms.CheckBox chkWinding1;
        public System.Windows.Forms.TextBox txtMagBpu;
        public System.Windows.Forms.TextBox txtMagGpu;
        public System.Windows.Forms.TextBox txtSpecXpu;
        public System.Windows.Forms.TextBox txtSpecRpu;
        public System.Windows.Forms.TextBox txtRatedSeckV;
        public System.Windows.Forms.TextBox txtRatedPrimkV;
        public System.Windows.Forms.Label lblNorBusSeckV;
        public System.Windows.Forms.Label lblNorBusPrimkV;
        public System.Windows.Forms.TextBox txtPowerRated;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.Button btnTCPrim;
        public System.Windows.Forms.Button btnTCUnitMain;
        public System.Windows.Forms.TextBox txtFixedSeckV;
        public System.Windows.Forms.TextBox txtFixedPrimkV;
        public System.Windows.Forms.Button btnTCSec;
        public System.Windows.Forms.Label lblTapTransPrimFixed;
        public System.Windows.Forms.Label lblTransUnit;
        public System.Windows.Forms.Button btnPrimUp;
        public System.Windows.Forms.Button btnPrimDown;
        public System.Windows.Forms.Button btnSecUp;
        public System.Windows.Forms.Button btnSecDown;
        public System.Windows.Forms.TextBox txtTransID;
        public System.Windows.Forms.GroupBox grbLineMBA2Data;
        public System.Windows.Forms.GroupBox grbImpendanceMBA2;
        public System.Windows.Forms.GroupBox grbVoltageRating;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.GroupBox groupBox3;
    }
}