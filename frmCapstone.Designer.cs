
namespace Experimential_Software
{
    partial class frmCapstone
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapstone));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblLine = new System.Windows.Forms.Label();
            this.mnuStripBar = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlTool = new System.Windows.Forms.Panel();
            this.pnlFlowTool = new System.Windows.Forms.FlowLayoutPanel();
            this.imgListTool = new System.Windows.Forms.ImageList(this.components);
            this.imgListEPower = new System.Windows.Forms.ImageList(this.components);
            this.imgListIconCtrl = new System.Windows.Forms.ImageList(this.components);
            this.cxttMenuStripEPower = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cxtMnuDCDrawnCurve = new System.Windows.Forms.ToolStripMenuItem();
            this.cxtMnuDCDominationDia = new System.Windows.Forms.ToolStripMenuItem();
            this.cxtMnuDCOperatingMode = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new Experimential_Software.PanelMain();
            this.btnBusPower_Hor = new Experimential_Software.ConnectableE();
            this.btnBusPower_Ver = new Experimential_Software.ConnectableE();
            this.btnMFPower_Hor = new Experimential_Software.ConnectableE();
            this.btnMFPower_Ver = new Experimential_Software.ConnectableE();
            this.btnTransformer2P_Hor = new Experimential_Software.ConnectableE();
            this.btnTransformer2P_Ver = new Experimential_Software.ConnectableE();
            this.btnTransformer3P_Hor = new Experimential_Software.ConnectableE();
            this.btnTransformer3P_Ver = new Experimential_Software.ConnectableE();
            this.btnLinePower_Hor = new Experimential_Software.ConnectableE();
            this.btnLinePower_Ver = new Experimential_Software.ConnectableE();
            this.btnLoad_Hor = new Experimential_Software.ConnectableE();
            this.btnLoad_Ver = new Experimential_Software.ConnectableE();
            this.panel2.SuspendLayout();
            this.mnuStripBar.SuspendLayout();
            this.pnlTool.SuspendLayout();
            this.pnlFlowTool.SuspendLayout();
            this.cxttMenuStripEPower.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.lblLine);
            this.panel2.Controls.Add(this.mnuStripBar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1028, 127);
            this.panel2.TabIndex = 1;
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLine.Location = new System.Drawing.Point(12, 63);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(133, 20);
            this.lblLine.TabIndex = 2;
            this.lblLine.Text = "Command is here";
            this.lblLine.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblLine_MouseDown);
            // 
            // mnuStripBar
            // 
            this.mnuStripBar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.mnuStripBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.mnuStripBar.Location = new System.Drawing.Point(0, 0);
            this.mnuStripBar.Name = "mnuStripBar";
            this.mnuStripBar.Size = new System.Drawing.Size(1028, 24);
            this.mnuStripBar.TabIndex = 3;
            this.mnuStripBar.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileNew,
            this.mnuFileOpen,
            this.mnuFileSave});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuFileNew
            // 
            this.mnuFileNew.Name = "mnuFileNew";
            this.mnuFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuFileNew.Size = new System.Drawing.Size(167, 22);
            this.mnuFileNew.Text = "New File";
            this.mnuFileNew.Click += new System.EventHandler(this.mnuFileNew_Click);
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(167, 22);
            this.mnuFileOpen.Text = "Open File";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSave.Size = new System.Drawing.Size(167, 22);
            this.mnuFileSave.Text = "Save";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 127);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(115, 633);
            this.panel3.TabIndex = 2;
            // 
            // pnlTool
            // 
            this.pnlTool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pnlTool.Controls.Add(this.pnlFlowTool);
            this.pnlTool.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlTool.Location = new System.Drawing.Point(905, 127);
            this.pnlTool.Name = "pnlTool";
            this.pnlTool.Size = new System.Drawing.Size(123, 633);
            this.pnlTool.TabIndex = 1;
            // 
            // pnlFlowTool
            // 
            this.pnlFlowTool.Controls.Add(this.btnBusPower_Hor);
            this.pnlFlowTool.Controls.Add(this.btnBusPower_Ver);
            this.pnlFlowTool.Controls.Add(this.btnMFPower_Hor);
            this.pnlFlowTool.Controls.Add(this.btnMFPower_Ver);
            this.pnlFlowTool.Controls.Add(this.btnTransformer2P_Hor);
            this.pnlFlowTool.Controls.Add(this.btnTransformer2P_Ver);
            this.pnlFlowTool.Controls.Add(this.btnTransformer3P_Hor);
            this.pnlFlowTool.Controls.Add(this.btnTransformer3P_Ver);
            this.pnlFlowTool.Controls.Add(this.btnLinePower_Hor);
            this.pnlFlowTool.Controls.Add(this.btnLinePower_Ver);
            this.pnlFlowTool.Controls.Add(this.btnLoad_Hor);
            this.pnlFlowTool.Controls.Add(this.btnLoad_Ver);
            this.pnlFlowTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFlowTool.Location = new System.Drawing.Point(0, 0);
            this.pnlFlowTool.Name = "pnlFlowTool";
            this.pnlFlowTool.Padding = new System.Windows.Forms.Padding(5, 15, 0, 0);
            this.pnlFlowTool.Size = new System.Drawing.Size(123, 633);
            this.pnlFlowTool.TabIndex = 1;
            // 
            // imgListTool
            // 
            this.imgListTool.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListTool.ImageStream")));
            this.imgListTool.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListTool.Images.SetKeyName(0, "BUS_Tool.png");
            this.imgListTool.Images.SetKeyName(1, "MF_Tool.png");
            this.imgListTool.Images.SetKeyName(2, "MBA2_Tool.png");
            this.imgListTool.Images.SetKeyName(3, "MBA3P_Tool.png");
            this.imgListTool.Images.SetKeyName(4, "Line_Tool.png");
            this.imgListTool.Images.SetKeyName(5, "Load_Tool.png");
            // 
            // imgListEPower
            // 
            this.imgListEPower.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListEPower.ImageStream")));
            this.imgListEPower.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListEPower.Images.SetKeyName(0, "imgNoType.png");
            this.imgListEPower.Images.SetKeyName(1, "BUS-export.png");
            this.imgListEPower.Images.SetKeyName(2, "MF.png");
            this.imgListEPower.Images.SetKeyName(3, "MBA2P_Spawn.png");
            this.imgListEPower.Images.SetKeyName(4, "MBA 3 cuộn dây-export.png");
            this.imgListEPower.Images.SetKeyName(5, "Line .png");
            this.imgListEPower.Images.SetKeyName(6, "Load_Run.png");
            // 
            // imgListIconCtrl
            // 
            this.imgListIconCtrl.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListIconCtrl.ImageStream")));
            this.imgListIconCtrl.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListIconCtrl.Images.SetKeyName(0, "icon_NewFile.png");
            this.imgListIconCtrl.Images.SetKeyName(1, "icon_OpenFile.png");
            this.imgListIconCtrl.Images.SetKeyName(2, "icon_SaveFile.png");
            // 
            // cxttMenuStripEPower
            // 
            this.cxttMenuStripEPower.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cxtMnuDCDominationDia,
            this.cxtMnuDCDrawnCurve});
            this.cxttMenuStripEPower.Name = "cxttMenuStripEPower";
            this.cxttMenuStripEPower.Size = new System.Drawing.Size(266, 70);
            // 
            // cxtMnuDCDrawnCurve
            // 
            this.cxtMnuDCDrawnCurve.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cxtMnuDCOperatingMode});
            this.cxtMnuDCDrawnCurve.Name = "cxtMnuDCDrawnCurve";
            this.cxtMnuDCDrawnCurve.Size = new System.Drawing.Size(265, 22);
            this.cxtMnuDCDrawnCurve.Text = "Vẽ miền làm việc ổn định";
            // 
            // cxtMnuDCDominationDia
            // 
            this.cxtMnuDCDominationDia.Name = "cxtMnuDCDominationDia";
            this.cxtMnuDCDominationDia.Size = new System.Drawing.Size(265, 22);
            this.cxtMnuDCDominationDia.Text = "Tính đẳng trị sơ đồ về thanh cái này ";
            // 
            // cxtMnuDCOperatingMode
            // 
            this.cxtMnuDCOperatingMode.Name = "cxtMnuDCOperatingMode";
            this.cxtMnuDCOperatingMode.Size = new System.Drawing.Size(180, 22);
            this.cxtMnuDCOperatingMode.Text = "Chế độ vận hành";
            this.cxtMnuDCOperatingMode.Click += new System.EventHandler(this.cxtMnuDCOperatingMode_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.AllowDrop = true;
            this.pnlMain.AutoScroll = true;
            this.pnlMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(115, 127);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(790, 633);
            this.pnlMain.TabIndex = 3;
            this.pnlMain.TabStop = true;
            this.pnlMain.ZoomFactor = 1D;
            this.pnlMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlMain_DragDrop);
            this.pnlMain.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlMain_DragEnter);
            this.pnlMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMain_MouseDown);
            // 
            // btnBusPower_Hor
            // 
            this.btnBusPower_Hor.BackColor = System.Drawing.Color.Transparent;
            this.btnBusPower_Hor.containPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnBusPower_Hor.ImageIndex = 0;
            this.btnBusPower_Hor.ImageList = this.imgListTool;
            this.btnBusPower_Hor.IsContainPhead = false;
            this.btnBusPower_Hor.IsContainPtail = false;
            this.btnBusPower_Hor.IsMove = false;
            this.btnBusPower_Hor.IsOnTool = true;
            this.btnBusPower_Hor.IsSelected = false;
            this.btnBusPower_Hor.LblInfoE = null;
            this.btnBusPower_Hor.ListBranch_Drawn = null;
            this.btnBusPower_Hor.Location = new System.Drawing.Point(8, 35);
            this.btnBusPower_Hor.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.btnBusPower_Hor.Name = "btnBusPower_Hor";
            this.btnBusPower_Hor.PHead = new System.Drawing.Point(0, 0);
            this.btnBusPower_Hor.PreLocation = new System.Drawing.Point(0, 0);
            this.btnBusPower_Hor.PTail = new System.Drawing.Point(0, 0);
            this.btnBusPower_Hor.Size = new System.Drawing.Size(50, 50);
            this.btnBusPower_Hor.TabIndex = 0;
            this.btnBusPower_Hor.UseVisualStyleBackColor = false;
            this.btnBusPower_Hor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnBusPower_MouseDown);
            // 
            // btnBusPower_Ver
            // 
            this.btnBusPower_Ver.BackColor = System.Drawing.Color.Transparent;
            this.btnBusPower_Ver.containPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnBusPower_Ver.ImageIndex = 0;
            this.btnBusPower_Ver.IsContainPhead = false;
            this.btnBusPower_Ver.IsContainPtail = false;
            this.btnBusPower_Ver.IsMove = false;
            this.btnBusPower_Ver.IsOnTool = true;
            this.btnBusPower_Ver.IsSelected = false;
            this.btnBusPower_Ver.LblInfoE = null;
            this.btnBusPower_Ver.ListBranch_Drawn = null;
            this.btnBusPower_Ver.Location = new System.Drawing.Point(64, 35);
            this.btnBusPower_Ver.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.btnBusPower_Ver.Name = "btnBusPower_Ver";
            this.btnBusPower_Ver.PHead = new System.Drawing.Point(0, 0);
            this.btnBusPower_Ver.PreLocation = new System.Drawing.Point(0, 0);
            this.btnBusPower_Ver.PTail = new System.Drawing.Point(0, 0);
            this.btnBusPower_Ver.Size = new System.Drawing.Size(50, 50);
            this.btnBusPower_Ver.TabIndex = 0;
            this.btnBusPower_Ver.Text = "Bus Vertical";
            this.btnBusPower_Ver.UseVisualStyleBackColor = false;
            this.btnBusPower_Ver.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnBusPower_MouseDown);
            // 
            // btnMFPower_Hor
            // 
            this.btnMFPower_Hor.BackColor = System.Drawing.Color.Transparent;
            this.btnMFPower_Hor.containPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnMFPower_Hor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMFPower_Hor.ImageIndex = 1;
            this.btnMFPower_Hor.IsContainPhead = false;
            this.btnMFPower_Hor.IsContainPtail = false;
            this.btnMFPower_Hor.IsMove = false;
            this.btnMFPower_Hor.IsOnTool = true;
            this.btnMFPower_Hor.IsSelected = false;
            this.btnMFPower_Hor.LblInfoE = null;
            this.btnMFPower_Hor.ListBranch_Drawn = null;
            this.btnMFPower_Hor.Location = new System.Drawing.Point(8, 108);
            this.btnMFPower_Hor.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.btnMFPower_Hor.Name = "btnMFPower_Hor";
            this.btnMFPower_Hor.PHead = new System.Drawing.Point(0, 0);
            this.btnMFPower_Hor.PreLocation = new System.Drawing.Point(0, 0);
            this.btnMFPower_Hor.PTail = new System.Drawing.Point(0, 0);
            this.btnMFPower_Hor.Size = new System.Drawing.Size(50, 50);
            this.btnMFPower_Hor.TabIndex = 0;
            this.btnMFPower_Hor.Text = "MF Hor";
            this.btnMFPower_Hor.UseVisualStyleBackColor = false;
            this.btnMFPower_Hor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMFPower_MouseDown);
            // 
            // btnMFPower_Ver
            // 
            this.btnMFPower_Ver.BackColor = System.Drawing.Color.Transparent;
            this.btnMFPower_Ver.containPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnMFPower_Ver.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMFPower_Ver.ImageIndex = 1;
            this.btnMFPower_Ver.ImageList = this.imgListTool;
            this.btnMFPower_Ver.IsContainPhead = false;
            this.btnMFPower_Ver.IsContainPtail = false;
            this.btnMFPower_Ver.IsMove = false;
            this.btnMFPower_Ver.IsOnTool = true;
            this.btnMFPower_Ver.IsSelected = false;
            this.btnMFPower_Ver.LblInfoE = null;
            this.btnMFPower_Ver.ListBranch_Drawn = null;
            this.btnMFPower_Ver.Location = new System.Drawing.Point(64, 108);
            this.btnMFPower_Ver.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.btnMFPower_Ver.Name = "btnMFPower_Ver";
            this.btnMFPower_Ver.PHead = new System.Drawing.Point(0, 0);
            this.btnMFPower_Ver.PreLocation = new System.Drawing.Point(0, 0);
            this.btnMFPower_Ver.PTail = new System.Drawing.Point(0, 0);
            this.btnMFPower_Ver.Size = new System.Drawing.Size(50, 50);
            this.btnMFPower_Ver.TabIndex = 0;
            this.btnMFPower_Ver.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnMFPower_Ver.UseVisualStyleBackColor = false;
            this.btnMFPower_Ver.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMFPower_MouseDown);
            // 
            // btnTransformer2P_Hor
            // 
            this.btnTransformer2P_Hor.BackColor = System.Drawing.Color.Transparent;
            this.btnTransformer2P_Hor.containPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnTransformer2P_Hor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransformer2P_Hor.ImageIndex = 2;
            this.btnTransformer2P_Hor.IsContainPhead = false;
            this.btnTransformer2P_Hor.IsContainPtail = false;
            this.btnTransformer2P_Hor.IsMove = false;
            this.btnTransformer2P_Hor.IsOnTool = true;
            this.btnTransformer2P_Hor.IsSelected = false;
            this.btnTransformer2P_Hor.LblInfoE = null;
            this.btnTransformer2P_Hor.ListBranch_Drawn = null;
            this.btnTransformer2P_Hor.Location = new System.Drawing.Point(8, 181);
            this.btnTransformer2P_Hor.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.btnTransformer2P_Hor.Name = "btnTransformer2P_Hor";
            this.btnTransformer2P_Hor.PHead = new System.Drawing.Point(0, 0);
            this.btnTransformer2P_Hor.PreLocation = new System.Drawing.Point(0, 0);
            this.btnTransformer2P_Hor.PTail = new System.Drawing.Point(0, 0);
            this.btnTransformer2P_Hor.Size = new System.Drawing.Size(50, 50);
            this.btnTransformer2P_Hor.TabIndex = 0;
            this.btnTransformer2P_Hor.Text = "Trans_Hor";
            this.btnTransformer2P_Hor.UseVisualStyleBackColor = false;
            this.btnTransformer2P_Hor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTransformer2P_MouseDown);
            // 
            // btnTransformer2P_Ver
            // 
            this.btnTransformer2P_Ver.BackColor = System.Drawing.Color.Transparent;
            this.btnTransformer2P_Ver.containPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnTransformer2P_Ver.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransformer2P_Ver.ImageIndex = 2;
            this.btnTransformer2P_Ver.ImageList = this.imgListTool;
            this.btnTransformer2P_Ver.IsContainPhead = false;
            this.btnTransformer2P_Ver.IsContainPtail = false;
            this.btnTransformer2P_Ver.IsMove = false;
            this.btnTransformer2P_Ver.IsOnTool = true;
            this.btnTransformer2P_Ver.IsSelected = false;
            this.btnTransformer2P_Ver.LblInfoE = null;
            this.btnTransformer2P_Ver.ListBranch_Drawn = null;
            this.btnTransformer2P_Ver.Location = new System.Drawing.Point(64, 181);
            this.btnTransformer2P_Ver.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.btnTransformer2P_Ver.Name = "btnTransformer2P_Ver";
            this.btnTransformer2P_Ver.PHead = new System.Drawing.Point(0, 0);
            this.btnTransformer2P_Ver.PreLocation = new System.Drawing.Point(0, 0);
            this.btnTransformer2P_Ver.PTail = new System.Drawing.Point(0, 0);
            this.btnTransformer2P_Ver.Size = new System.Drawing.Size(50, 50);
            this.btnTransformer2P_Ver.TabIndex = 0;
            this.btnTransformer2P_Ver.Text = "Transfoner";
            this.btnTransformer2P_Ver.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnTransformer2P_Ver.UseVisualStyleBackColor = false;
            this.btnTransformer2P_Ver.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTransformer2P_MouseDown);
            // 
            // btnTransformer3P_Hor
            // 
            this.btnTransformer3P_Hor.BackColor = System.Drawing.Color.Transparent;
            this.btnTransformer3P_Hor.containPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnTransformer3P_Hor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransformer3P_Hor.ImageIndex = 3;
            this.btnTransformer3P_Hor.IsContainPhead = false;
            this.btnTransformer3P_Hor.IsContainPtail = false;
            this.btnTransformer3P_Hor.IsMove = false;
            this.btnTransformer3P_Hor.IsOnTool = true;
            this.btnTransformer3P_Hor.IsSelected = false;
            this.btnTransformer3P_Hor.LblInfoE = null;
            this.btnTransformer3P_Hor.ListBranch_Drawn = null;
            this.btnTransformer3P_Hor.Location = new System.Drawing.Point(8, 254);
            this.btnTransformer3P_Hor.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.btnTransformer3P_Hor.Name = "btnTransformer3P_Hor";
            this.btnTransformer3P_Hor.PHead = new System.Drawing.Point(0, 0);
            this.btnTransformer3P_Hor.PreLocation = new System.Drawing.Point(0, 0);
            this.btnTransformer3P_Hor.PTail = new System.Drawing.Point(0, 0);
            this.btnTransformer3P_Hor.Size = new System.Drawing.Size(50, 50);
            this.btnTransformer3P_Hor.TabIndex = 0;
            this.btnTransformer3P_Hor.Text = "Tran3 Hor";
            this.btnTransformer3P_Hor.UseVisualStyleBackColor = false;
            this.btnTransformer3P_Hor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTransformer3P_MouseDown);
            // 
            // btnTransformer3P_Ver
            // 
            this.btnTransformer3P_Ver.BackColor = System.Drawing.Color.Transparent;
            this.btnTransformer3P_Ver.containPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnTransformer3P_Ver.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransformer3P_Ver.ImageIndex = 3;
            this.btnTransformer3P_Ver.ImageList = this.imgListTool;
            this.btnTransformer3P_Ver.IsContainPhead = false;
            this.btnTransformer3P_Ver.IsContainPtail = false;
            this.btnTransformer3P_Ver.IsMove = false;
            this.btnTransformer3P_Ver.IsOnTool = true;
            this.btnTransformer3P_Ver.IsSelected = false;
            this.btnTransformer3P_Ver.LblInfoE = null;
            this.btnTransformer3P_Ver.ListBranch_Drawn = null;
            this.btnTransformer3P_Ver.Location = new System.Drawing.Point(64, 254);
            this.btnTransformer3P_Ver.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.btnTransformer3P_Ver.Name = "btnTransformer3P_Ver";
            this.btnTransformer3P_Ver.PHead = new System.Drawing.Point(0, 0);
            this.btnTransformer3P_Ver.PreLocation = new System.Drawing.Point(0, 0);
            this.btnTransformer3P_Ver.PTail = new System.Drawing.Point(0, 0);
            this.btnTransformer3P_Ver.Size = new System.Drawing.Size(50, 50);
            this.btnTransformer3P_Ver.TabIndex = 0;
            this.btnTransformer3P_Ver.Text = "Transfoner 3P";
            this.btnTransformer3P_Ver.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnTransformer3P_Ver.UseVisualStyleBackColor = false;
            this.btnTransformer3P_Ver.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTransformer3P_MouseDown);
            // 
            // btnLinePower_Hor
            // 
            this.btnLinePower_Hor.BackColor = System.Drawing.Color.Transparent;
            this.btnLinePower_Hor.containPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnLinePower_Hor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLinePower_Hor.ImageIndex = 4;
            this.btnLinePower_Hor.IsContainPhead = false;
            this.btnLinePower_Hor.IsContainPtail = false;
            this.btnLinePower_Hor.IsMove = false;
            this.btnLinePower_Hor.IsOnTool = true;
            this.btnLinePower_Hor.IsSelected = false;
            this.btnLinePower_Hor.LblInfoE = null;
            this.btnLinePower_Hor.ListBranch_Drawn = null;
            this.btnLinePower_Hor.Location = new System.Drawing.Point(8, 327);
            this.btnLinePower_Hor.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.btnLinePower_Hor.Name = "btnLinePower_Hor";
            this.btnLinePower_Hor.PHead = new System.Drawing.Point(0, 0);
            this.btnLinePower_Hor.PreLocation = new System.Drawing.Point(0, 0);
            this.btnLinePower_Hor.PTail = new System.Drawing.Point(0, 0);
            this.btnLinePower_Hor.Size = new System.Drawing.Size(50, 50);
            this.btnLinePower_Hor.TabIndex = 0;
            this.btnLinePower_Hor.Text = "Line Hor";
            this.btnLinePower_Hor.UseVisualStyleBackColor = false;
            this.btnLinePower_Hor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnLinePower_KeyDown);
            this.btnLinePower_Hor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLinePower_MouseDown);
            // 
            // btnLinePower_Ver
            // 
            this.btnLinePower_Ver.BackColor = System.Drawing.Color.Transparent;
            this.btnLinePower_Ver.containPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnLinePower_Ver.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLinePower_Ver.ImageIndex = 4;
            this.btnLinePower_Ver.ImageList = this.imgListTool;
            this.btnLinePower_Ver.IsContainPhead = false;
            this.btnLinePower_Ver.IsContainPtail = false;
            this.btnLinePower_Ver.IsMove = false;
            this.btnLinePower_Ver.IsOnTool = true;
            this.btnLinePower_Ver.IsSelected = false;
            this.btnLinePower_Ver.LblInfoE = null;
            this.btnLinePower_Ver.ListBranch_Drawn = null;
            this.btnLinePower_Ver.Location = new System.Drawing.Point(64, 327);
            this.btnLinePower_Ver.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.btnLinePower_Ver.Name = "btnLinePower_Ver";
            this.btnLinePower_Ver.PHead = new System.Drawing.Point(0, 0);
            this.btnLinePower_Ver.PreLocation = new System.Drawing.Point(0, 0);
            this.btnLinePower_Ver.PTail = new System.Drawing.Point(0, 0);
            this.btnLinePower_Ver.Size = new System.Drawing.Size(50, 50);
            this.btnLinePower_Ver.TabIndex = 0;
            this.btnLinePower_Ver.Text = "Line";
            this.btnLinePower_Ver.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnLinePower_Ver.UseVisualStyleBackColor = false;
            this.btnLinePower_Ver.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnLinePower_KeyDown);
            this.btnLinePower_Ver.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLinePower_MouseDown);
            // 
            // btnLoad_Hor
            // 
            this.btnLoad_Hor.BackColor = System.Drawing.Color.Transparent;
            this.btnLoad_Hor.containPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnLoad_Hor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad_Hor.ImageIndex = 5;
            this.btnLoad_Hor.IsContainPhead = false;
            this.btnLoad_Hor.IsContainPtail = false;
            this.btnLoad_Hor.IsMove = false;
            this.btnLoad_Hor.IsOnTool = true;
            this.btnLoad_Hor.IsSelected = false;
            this.btnLoad_Hor.LblInfoE = null;
            this.btnLoad_Hor.ListBranch_Drawn = null;
            this.btnLoad_Hor.Location = new System.Drawing.Point(8, 400);
            this.btnLoad_Hor.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.btnLoad_Hor.Name = "btnLoad_Hor";
            this.btnLoad_Hor.PHead = new System.Drawing.Point(0, 0);
            this.btnLoad_Hor.PreLocation = new System.Drawing.Point(0, 0);
            this.btnLoad_Hor.PTail = new System.Drawing.Point(0, 0);
            this.btnLoad_Hor.Size = new System.Drawing.Size(50, 50);
            this.btnLoad_Hor.TabIndex = 0;
            this.btnLoad_Hor.Text = "Load Hor";
            this.btnLoad_Hor.UseVisualStyleBackColor = false;
            this.btnLoad_Hor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLoad_MouseDown);
            // 
            // btnLoad_Ver
            // 
            this.btnLoad_Ver.BackColor = System.Drawing.Color.Transparent;
            this.btnLoad_Ver.containPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnLoad_Ver.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad_Ver.ImageIndex = 5;
            this.btnLoad_Ver.ImageList = this.imgListTool;
            this.btnLoad_Ver.IsContainPhead = false;
            this.btnLoad_Ver.IsContainPtail = false;
            this.btnLoad_Ver.IsMove = false;
            this.btnLoad_Ver.IsOnTool = true;
            this.btnLoad_Ver.IsSelected = false;
            this.btnLoad_Ver.LblInfoE = null;
            this.btnLoad_Ver.ListBranch_Drawn = null;
            this.btnLoad_Ver.Location = new System.Drawing.Point(64, 400);
            this.btnLoad_Ver.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.btnLoad_Ver.Name = "btnLoad_Ver";
            this.btnLoad_Ver.PHead = new System.Drawing.Point(0, 0);
            this.btnLoad_Ver.PreLocation = new System.Drawing.Point(0, 0);
            this.btnLoad_Ver.PTail = new System.Drawing.Point(0, 0);
            this.btnLoad_Ver.Size = new System.Drawing.Size(50, 50);
            this.btnLoad_Ver.TabIndex = 0;
            this.btnLoad_Ver.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnLoad_Ver.UseVisualStyleBackColor = false;
            this.btnLoad_Ver.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLoad_MouseDown);
            // 
            // frmCapstone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1028, 760);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTool);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.MainMenuStrip = this.mnuStripBar;
            this.Name = "frmCapstone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Phần mềm tính trào lưu công suất";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.frmCapstone_Resize);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.mnuStripBar.ResumeLayout(false);
            this.mnuStripBar.PerformLayout();
            this.pnlTool.ResumeLayout(false);
            this.pnlFlowTool.ResumeLayout(false);
            this.cxttMenuStripEPower.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        public ConnectableE LinePower;
        public System.Windows.Forms.Panel pnlTool;
        public System.Windows.Forms.Label lblLine;
        private ConnectableE btnBusPower_Hor;
        private ConnectableE btnLinePower_Ver;
        private ConnectableE btnMFPower_Ver;
        private ConnectableE btnTransformer2P_Ver;
        private ConnectableE btnLoad_Ver;
        public PanelMain pnlMain;
        public System.Windows.Forms.ImageList imgListEPower;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ImageList imgListTool;
        private System.Windows.Forms.ImageList imgListIconCtrl;
        public System.Windows.Forms.MenuStrip mnuStripBar;
        public System.Windows.Forms.ToolStripMenuItem mnuFileNew;
        public System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        public System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private ConnectableE btnTransformer3P_Ver;
        private System.Windows.Forms.FlowLayoutPanel pnlFlowTool;
        private ConnectableE btnMFPower_Hor;
        private ConnectableE btnBusPower_Ver;
        private ConnectableE btnTransformer2P_Hor;
        private ConnectableE btnTransformer3P_Hor;
        private ConnectableE btnLinePower_Hor;
        private ConnectableE btnLoad_Hor;
        private System.Windows.Forms.ContextMenuStrip cxttMenuStripEPower;
        private System.Windows.Forms.ToolStripMenuItem cxtMnuDCDominationDia;
        private System.Windows.Forms.ToolStripMenuItem cxtMnuDCDrawnCurve;
        private System.Windows.Forms.ToolStripMenuItem cxtMnuDCOperatingMode;
    }
}

