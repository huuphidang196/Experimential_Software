
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
            this.btnZoomOutCenter = new System.Windows.Forms.Button();
            this.imgListIconMnuStrip = new System.Windows.Forms.ImageList(this.components);
            this.lblZoomFactor = new System.Windows.Forms.Label();
            this.btnZoomInCenter = new System.Windows.Forms.Button();
            this.btnPrintSystem = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnNewFile = new System.Windows.Forms.Button();
            this.mnuStripBar = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.vIewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.powerFlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolPrintData = new System.Windows.Forms.ToolStripMenuItem();
            this.onOffSetPositonSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStripHelpUseSW = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSetPosSystem = new System.Windows.Forms.Button();
            this.pnlTreeView = new System.Windows.Forms.Panel();
            this.tvDataSaved = new System.Windows.Forms.TreeView();
            this.pnlTool = new System.Windows.Forms.Panel();
            this.pnlFlowTool = new System.Windows.Forms.FlowLayoutPanel();
            this.imgListTool = new System.Windows.Forms.ImageList(this.components);
            this.imgListEPower = new System.Windows.Forms.ImageList(this.components);
            this.cxtMenuStripEPower = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cxtMnuDCDominationDia = new System.Windows.Forms.ToolStripMenuItem();
            this.cxtMnuDCDrawnCurve = new System.Windows.Forms.ToolStripMenuItem();
            this.cxtMnuDCOperatingMode = new System.Windows.Forms.ToolStripMenuItem();
            this.cxtRemoveLineDrawn = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctMnuRemoveThisLineDrawn = new System.Windows.Forms.ToolStripMenuItem();
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
            this.pnlTreeView.SuspendLayout();
            this.pnlTool.SuspendLayout();
            this.pnlFlowTool.SuspendLayout();
            this.cxtMenuStripEPower.SuspendLayout();
            this.cxtRemoveLineDrawn.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.btnZoomOutCenter);
            this.panel2.Controls.Add(this.lblZoomFactor);
            this.panel2.Controls.Add(this.btnZoomInCenter);
            this.panel2.Controls.Add(this.btnPrintSystem);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnOpen);
            this.panel2.Controls.Add(this.btnNewFile);
            this.panel2.Controls.Add(this.mnuStripBar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1085, 71);
            this.panel2.TabIndex = 1;
            // 
            // btnZoomOutCenter
            // 
            this.btnZoomOutCenter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnZoomOutCenter.ImageIndex = 9;
            this.btnZoomOutCenter.ImageList = this.imgListIconMnuStrip;
            this.btnZoomOutCenter.Location = new System.Drawing.Point(224, 32);
            this.btnZoomOutCenter.Name = "btnZoomOutCenter";
            this.btnZoomOutCenter.Size = new System.Drawing.Size(30, 30);
            this.btnZoomOutCenter.TabIndex = 0;
            this.btnZoomOutCenter.UseVisualStyleBackColor = false;
            this.btnZoomOutCenter.Click += new System.EventHandler(this.btnZoomOutCenter_Click);
            // 
            // imgListIconMnuStrip
            // 
            this.imgListIconMnuStrip.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListIconMnuStrip.ImageStream")));
            this.imgListIconMnuStrip.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListIconMnuStrip.Images.SetKeyName(0, "newFile_Icon.png");
            this.imgListIconMnuStrip.Images.SetKeyName(1, "OpenFolderIcon.png");
            this.imgListIconMnuStrip.Images.SetKeyName(2, "icon_SaveFile.png");
            this.imgListIconMnuStrip.Images.SetKeyName(3, "FolderIcon.png");
            this.imgListIconMnuStrip.Images.SetKeyName(4, "Text_Icon.png");
            this.imgListIconMnuStrip.Images.SetKeyName(5, "Image_Icon.png");
            this.imgListIconMnuStrip.Images.SetKeyName(6, "Logo_Print.png");
            this.imgListIconMnuStrip.Images.SetKeyName(7, "SetPos_Icon.png");
            this.imgListIconMnuStrip.Images.SetKeyName(8, "zoom_in_Icon.png");
            this.imgListIconMnuStrip.Images.SetKeyName(9, "zoom_out_Icon.png");
            // 
            // lblZoomFactor
            // 
            this.lblZoomFactor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblZoomFactor.AutoSize = true;
            this.lblZoomFactor.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZoomFactor.Location = new System.Drawing.Point(912, 39);
            this.lblZoomFactor.Name = "lblZoomFactor";
            this.lblZoomFactor.Size = new System.Drawing.Size(48, 17);
            this.lblZoomFactor.TabIndex = 4;
            this.lblZoomFactor.Text = "Zoom";
            // 
            // btnZoomInCenter
            // 
            this.btnZoomInCenter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnZoomInCenter.ImageIndex = 8;
            this.btnZoomInCenter.ImageList = this.imgListIconMnuStrip;
            this.btnZoomInCenter.Location = new System.Drawing.Point(181, 32);
            this.btnZoomInCenter.Name = "btnZoomInCenter";
            this.btnZoomInCenter.Size = new System.Drawing.Size(30, 30);
            this.btnZoomInCenter.TabIndex = 0;
            this.btnZoomInCenter.UseVisualStyleBackColor = false;
            this.btnZoomInCenter.Click += new System.EventHandler(this.btnZoomInCenter_Click);
            // 
            // btnPrintSystem
            // 
            this.btnPrintSystem.ImageIndex = 6;
            this.btnPrintSystem.ImageList = this.imgListIconMnuStrip;
            this.btnPrintSystem.Location = new System.Drawing.Point(138, 32);
            this.btnPrintSystem.Name = "btnPrintSystem";
            this.btnPrintSystem.Size = new System.Drawing.Size(30, 30);
            this.btnPrintSystem.TabIndex = 0;
            this.btnPrintSystem.UseVisualStyleBackColor = true;
            this.btnPrintSystem.Click += new System.EventHandler(this.btnPrintSystem_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSave.ImageIndex = 2;
            this.btnSave.ImageList = this.imgListIconMnuStrip;
            this.btnSave.Location = new System.Drawing.Point(95, 32);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(30, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.PowderBlue;
            this.btnOpen.ImageIndex = 1;
            this.btnOpen.ImageList = this.imgListIconMnuStrip;
            this.btnOpen.Location = new System.Drawing.Point(52, 32);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(30, 30);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // btnNewFile
            // 
            this.btnNewFile.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnNewFile.ImageIndex = 0;
            this.btnNewFile.ImageList = this.imgListIconMnuStrip;
            this.btnNewFile.Location = new System.Drawing.Point(9, 32);
            this.btnNewFile.Name = "btnNewFile";
            this.btnNewFile.Size = new System.Drawing.Size(30, 30);
            this.btnNewFile.TabIndex = 0;
            this.btnNewFile.UseVisualStyleBackColor = false;
            this.btnNewFile.Click += new System.EventHandler(this.mnuFileNew_Click);
            // 
            // mnuStripBar
            // 
            this.mnuStripBar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.mnuStripBar.Font = new System.Drawing.Font("Tahoma", 10F);
            this.mnuStripBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.vIewToolStripMenuItem,
            this.viewToolStripMenuItem1,
            this.powerFlowToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mnuStripBar.Location = new System.Drawing.Point(0, 0);
            this.mnuStripBar.Name = "mnuStripBar";
            this.mnuStripBar.Size = new System.Drawing.Size(1085, 25);
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
            this.mnuFile.Size = new System.Drawing.Size(38, 21);
            this.mnuFile.Text = "File";
            // 
            // mnuFileNew
            // 
            this.mnuFileNew.Name = "mnuFileNew";
            this.mnuFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuFileNew.Size = new System.Drawing.Size(180, 22);
            this.mnuFileNew.Text = "New File";
            this.mnuFileNew.Click += new System.EventHandler(this.mnuFileNew_Click);
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(180, 22);
            this.mnuFileOpen.Text = "Open File";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSave.Size = new System.Drawing.Size(180, 22);
            this.mnuFileSave.Text = "Save";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // vIewToolStripMenuItem
            // 
            this.vIewToolStripMenuItem.Name = "vIewToolStripMenuItem";
            this.vIewToolStripMenuItem.Size = new System.Drawing.Size(43, 21);
            this.vIewToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem1
            // 
            this.viewToolStripMenuItem1.Name = "viewToolStripMenuItem1";
            this.viewToolStripMenuItem1.Size = new System.Drawing.Size(47, 21);
            this.viewToolStripMenuItem1.Text = "View";
            // 
            // powerFlowToolStripMenuItem
            // 
            this.powerFlowToolStripMenuItem.Name = "powerFlowToolStripMenuItem";
            this.powerFlowToolStripMenuItem.Size = new System.Drawing.Size(89, 21);
            this.powerFlowToolStripMenuItem.Text = "Power Flow";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuToolPrintData,
            this.onOffSetPositonSystemToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // mnuToolPrintData
            // 
            this.mnuToolPrintData.Name = "mnuToolPrintData";
            this.mnuToolPrintData.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
            this.mnuToolPrintData.Size = new System.Drawing.Size(289, 22);
            this.mnuToolPrintData.Text = "Print Data System";
            this.mnuToolPrintData.Click += new System.EventHandler(this.btnPrintSystem_Click);
            // 
            // onOffSetPositonSystemToolStripMenuItem
            // 
            this.onOffSetPositonSystemToolStripMenuItem.Name = "onOffSetPositonSystemToolStripMenuItem";
            this.onOffSetPositonSystemToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.onOffSetPositonSystemToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.onOffSetPositonSystemToolStripMenuItem.Text = "On / Off Set Positon System";
            this.onOffSetPositonSystemToolStripMenuItem.Click += new System.EventHandler(this.btnSetPosSystem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStripHelpUseSW});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(46, 21);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // mnuStripHelpUseSW
            // 
            this.mnuStripHelpUseSW.Name = "mnuStripHelpUseSW";
            this.mnuStripHelpUseSW.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.mnuStripHelpUseSW.Size = new System.Drawing.Size(247, 22);
            this.mnuStripHelpUseSW.Text = "Software User Guide";
            this.mnuStripHelpUseSW.Click += new System.EventHandler(this.mnuStripHelpUseSW_Click);
            // 
            // btnSetPosSystem
            // 
            this.btnSetPosSystem.BackColor = System.Drawing.Color.HotPink;
            this.btnSetPosSystem.ImageIndex = 7;
            this.btnSetPosSystem.ImageList = this.imgListIconMnuStrip;
            this.btnSetPosSystem.Location = new System.Drawing.Point(267, 32);
            this.btnSetPosSystem.Name = "btnSetPosSystem";
            this.btnSetPosSystem.Size = new System.Drawing.Size(30, 30);
            this.btnSetPosSystem.TabIndex = 0;
            this.btnSetPosSystem.UseVisualStyleBackColor = false;
            this.btnSetPosSystem.Click += new System.EventHandler(this.btnSetPosSystem_Click);
            // 
            // pnlTreeView
            // 
            this.pnlTreeView.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTreeView.Controls.Add(this.tvDataSaved);
            this.pnlTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTreeView.Location = new System.Drawing.Point(0, 71);
            this.pnlTreeView.Name = "pnlTreeView";
            this.pnlTreeView.Size = new System.Drawing.Size(176, 689);
            this.pnlTreeView.TabIndex = 2;
            // 
            // tvDataSaved
            // 
            this.tvDataSaved.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tvDataSaved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvDataSaved.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDataSaved.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvDataSaved.ImageIndex = 3;
            this.tvDataSaved.ImageList = this.imgListIconMnuStrip;
            this.tvDataSaved.Location = new System.Drawing.Point(0, 0);
            this.tvDataSaved.Name = "tvDataSaved";
            this.tvDataSaved.SelectedImageIndex = 0;
            this.tvDataSaved.Size = new System.Drawing.Size(174, 687);
            this.tvDataSaved.TabIndex = 0;
            this.tvDataSaved.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvDataSaved_NodeMouseDoubleClick);
            // 
            // pnlTool
            // 
            this.pnlTool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pnlTool.Controls.Add(this.pnlFlowTool);
            this.pnlTool.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlTool.Location = new System.Drawing.Point(962, 71);
            this.pnlTool.Name = "pnlTool";
            this.pnlTool.Size = new System.Drawing.Size(123, 689);
            this.pnlTool.TabIndex = 1;
            // 
            // pnlFlowTool
            // 
            this.pnlFlowTool.BackColor = System.Drawing.Color.Bisque;
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
            this.pnlFlowTool.Size = new System.Drawing.Size(123, 689);
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
            this.imgListTool.Images.SetKeyName(6, "BUS.png");
            this.imgListTool.Images.SetKeyName(7, "MF.png");
            this.imgListTool.Images.SetKeyName(8, "mba 2 cuộn dây.png");
            this.imgListTool.Images.SetKeyName(9, "MBA3P_Tool.png");
            this.imgListTool.Images.SetKeyName(10, "Tranmisson line1.png");
            this.imgListTool.Images.SetKeyName(11, "Load_Tool.png");
            // 
            // imgListEPower
            // 
            this.imgListEPower.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListEPower.ImageStream")));
            this.imgListEPower.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListEPower.Images.SetKeyName(0, "imgNoType.png");
            this.imgListEPower.Images.SetKeyName(1, "Bus_Spawn.png");
            this.imgListEPower.Images.SetKeyName(2, "MF.png");
            this.imgListEPower.Images.SetKeyName(3, "MBA2P_Spawn.png");
            this.imgListEPower.Images.SetKeyName(4, "MBA 3 cuộn dây-export.png");
            this.imgListEPower.Images.SetKeyName(5, "Line .png");
            this.imgListEPower.Images.SetKeyName(6, "Load_EPower.png");
            // 
            // cxtMenuStripEPower
            // 
            this.cxtMenuStripEPower.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.cxtMenuStripEPower.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cxtMnuDCDominationDia,
            this.cxtMnuDCDrawnCurve});
            this.cxtMenuStripEPower.Name = "cxttMenuStripEPower";
            this.cxtMenuStripEPower.Size = new System.Drawing.Size(266, 48);
            // 
            // cxtMnuDCDominationDia
            // 
            this.cxtMnuDCDominationDia.Name = "cxtMnuDCDominationDia";
            this.cxtMnuDCDominationDia.Size = new System.Drawing.Size(265, 22);
            this.cxtMnuDCDominationDia.Text = "Tính đẳng trị sơ đồ về thanh cái này ";
            this.cxtMnuDCDominationDia.Click += new System.EventHandler(this.cxtMnuDCDominationDia_Click);
            // 
            // cxtMnuDCDrawnCurve
            // 
            this.cxtMnuDCDrawnCurve.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cxtMnuDCOperatingMode});
            this.cxtMnuDCDrawnCurve.Name = "cxtMnuDCDrawnCurve";
            this.cxtMnuDCDrawnCurve.Size = new System.Drawing.Size(265, 22);
            this.cxtMnuDCDrawnCurve.Text = "Vẽ miền làm việc ổn định";
            // 
            // cxtMnuDCOperatingMode
            // 
            this.cxtMnuDCOperatingMode.Name = "cxtMnuDCOperatingMode";
            this.cxtMnuDCOperatingMode.Size = new System.Drawing.Size(164, 22);
            this.cxtMnuDCOperatingMode.Text = "Chế độ vận hành";
            this.cxtMnuDCOperatingMode.Click += new System.EventHandler(this.cxtMnuDCOperatingMode_Click);
            // 
            // cxtRemoveLineDrawn
            // 
            this.cxtRemoveLineDrawn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctMnuRemoveThisLineDrawn});
            this.cxtRemoveLineDrawn.Name = "cxtRemoveLineDrawn";
            this.cxtRemoveLineDrawn.Size = new System.Drawing.Size(145, 26);
            // 
            // ctMnuRemoveThisLineDrawn
            // 
            this.ctMnuRemoveThisLineDrawn.Name = "ctMnuRemoveThisLineDrawn";
            this.ctMnuRemoveThisLineDrawn.Size = new System.Drawing.Size(144, 22);
            this.ctMnuRemoveThisLineDrawn.Text = "Xóa Line này ";
            this.ctMnuRemoveThisLineDrawn.Click += new System.EventHandler(this.RemoveThisLineDrawnOnPanel);
            // 
            // pnlMain
            // 
            this.pnlMain.AllowDrop = true;
            this.pnlMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(176, 71);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(786, 689);
            this.pnlMain.TabIndex = 3;
            this.pnlMain.TabStop = true;
            this.pnlMain.ZoomFactor = 1D;
            this.pnlMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlMain_DragDrop);
            this.pnlMain.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlMain_DragEnter);
            this.pnlMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMain_MouseDown);
            this.pnlMain.MouseLeave += new System.EventHandler(this.pnlMain_MouseLeave);
            // 
            // btnBusPower_Hor
            // 
            this.btnBusPower_Hor.BackColor = System.Drawing.Color.Transparent;
            this.btnBusPower_Hor.ContainPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnBusPower_Hor.ImageIndex = 0;
            this.btnBusPower_Hor.ImageList = this.imgListTool;
            this.btnBusPower_Hor.IsContainPhead = false;
            this.btnBusPower_Hor.IsContainPIntern = false;
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
            this.btnBusPower_Hor.PIntern = new System.Drawing.Point(0, 0);
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
            this.btnBusPower_Ver.ContainPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnBusPower_Ver.ImageIndex = 6;
            this.btnBusPower_Ver.ImageList = this.imgListTool;
            this.btnBusPower_Ver.IsContainPhead = false;
            this.btnBusPower_Ver.IsContainPIntern = false;
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
            this.btnBusPower_Ver.PIntern = new System.Drawing.Point(0, 0);
            this.btnBusPower_Ver.PreLocation = new System.Drawing.Point(0, 0);
            this.btnBusPower_Ver.PTail = new System.Drawing.Point(0, 0);
            this.btnBusPower_Ver.Size = new System.Drawing.Size(50, 50);
            this.btnBusPower_Ver.TabIndex = 0;
            this.btnBusPower_Ver.UseVisualStyleBackColor = false;
            this.btnBusPower_Ver.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnBusPower_MouseDown);
            // 
            // btnMFPower_Hor
            // 
            this.btnMFPower_Hor.BackColor = System.Drawing.Color.Transparent;
            this.btnMFPower_Hor.ContainPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnMFPower_Hor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMFPower_Hor.ImageIndex = 7;
            this.btnMFPower_Hor.ImageList = this.imgListTool;
            this.btnMFPower_Hor.IsContainPhead = false;
            this.btnMFPower_Hor.IsContainPIntern = false;
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
            this.btnMFPower_Hor.PIntern = new System.Drawing.Point(0, 0);
            this.btnMFPower_Hor.PreLocation = new System.Drawing.Point(0, 0);
            this.btnMFPower_Hor.PTail = new System.Drawing.Point(0, 0);
            this.btnMFPower_Hor.Size = new System.Drawing.Size(50, 50);
            this.btnMFPower_Hor.TabIndex = 0;
            this.btnMFPower_Hor.UseVisualStyleBackColor = false;
            this.btnMFPower_Hor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMFPower_MouseDown);
            // 
            // btnMFPower_Ver
            // 
            this.btnMFPower_Ver.BackColor = System.Drawing.Color.Transparent;
            this.btnMFPower_Ver.ContainPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnMFPower_Ver.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMFPower_Ver.ImageIndex = 1;
            this.btnMFPower_Ver.ImageList = this.imgListTool;
            this.btnMFPower_Ver.IsContainPhead = false;
            this.btnMFPower_Ver.IsContainPIntern = false;
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
            this.btnMFPower_Ver.PIntern = new System.Drawing.Point(0, 0);
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
            this.btnTransformer2P_Hor.ContainPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnTransformer2P_Hor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransformer2P_Hor.ImageIndex = 8;
            this.btnTransformer2P_Hor.ImageList = this.imgListTool;
            this.btnTransformer2P_Hor.IsContainPhead = false;
            this.btnTransformer2P_Hor.IsContainPIntern = false;
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
            this.btnTransformer2P_Hor.PIntern = new System.Drawing.Point(0, 0);
            this.btnTransformer2P_Hor.PreLocation = new System.Drawing.Point(0, 0);
            this.btnTransformer2P_Hor.PTail = new System.Drawing.Point(0, 0);
            this.btnTransformer2P_Hor.Size = new System.Drawing.Size(50, 50);
            this.btnTransformer2P_Hor.TabIndex = 0;
            this.btnTransformer2P_Hor.UseVisualStyleBackColor = false;
            this.btnTransformer2P_Hor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTransformer2P_MouseDown);
            // 
            // btnTransformer2P_Ver
            // 
            this.btnTransformer2P_Ver.BackColor = System.Drawing.Color.Transparent;
            this.btnTransformer2P_Ver.ContainPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnTransformer2P_Ver.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransformer2P_Ver.ImageIndex = 2;
            this.btnTransformer2P_Ver.ImageList = this.imgListTool;
            this.btnTransformer2P_Ver.IsContainPhead = false;
            this.btnTransformer2P_Ver.IsContainPIntern = false;
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
            this.btnTransformer2P_Ver.PIntern = new System.Drawing.Point(0, 0);
            this.btnTransformer2P_Ver.PreLocation = new System.Drawing.Point(0, 0);
            this.btnTransformer2P_Ver.PTail = new System.Drawing.Point(0, 0);
            this.btnTransformer2P_Ver.Size = new System.Drawing.Size(50, 50);
            this.btnTransformer2P_Ver.TabIndex = 0;
            this.btnTransformer2P_Ver.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnTransformer2P_Ver.UseVisualStyleBackColor = false;
            this.btnTransformer2P_Ver.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTransformer2P_MouseDown);
            // 
            // btnTransformer3P_Hor
            // 
            this.btnTransformer3P_Hor.BackColor = System.Drawing.Color.Transparent;
            this.btnTransformer3P_Hor.ContainPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnTransformer3P_Hor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransformer3P_Hor.ImageIndex = 9;
            this.btnTransformer3P_Hor.ImageList = this.imgListTool;
            this.btnTransformer3P_Hor.IsContainPhead = false;
            this.btnTransformer3P_Hor.IsContainPIntern = false;
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
            this.btnTransformer3P_Hor.PIntern = new System.Drawing.Point(0, 0);
            this.btnTransformer3P_Hor.PreLocation = new System.Drawing.Point(0, 0);
            this.btnTransformer3P_Hor.PTail = new System.Drawing.Point(0, 0);
            this.btnTransformer3P_Hor.Size = new System.Drawing.Size(50, 50);
            this.btnTransformer3P_Hor.TabIndex = 0;
            this.btnTransformer3P_Hor.UseVisualStyleBackColor = false;
            this.btnTransformer3P_Hor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTransformer3P_MouseDown);
            // 
            // btnTransformer3P_Ver
            // 
            this.btnTransformer3P_Ver.BackColor = System.Drawing.Color.Transparent;
            this.btnTransformer3P_Ver.ContainPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnTransformer3P_Ver.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransformer3P_Ver.ImageIndex = 3;
            this.btnTransformer3P_Ver.ImageList = this.imgListTool;
            this.btnTransformer3P_Ver.IsContainPhead = false;
            this.btnTransformer3P_Ver.IsContainPIntern = false;
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
            this.btnTransformer3P_Ver.PIntern = new System.Drawing.Point(0, 0);
            this.btnTransformer3P_Ver.PreLocation = new System.Drawing.Point(0, 0);
            this.btnTransformer3P_Ver.PTail = new System.Drawing.Point(0, 0);
            this.btnTransformer3P_Ver.Size = new System.Drawing.Size(50, 50);
            this.btnTransformer3P_Ver.TabIndex = 0;
            this.btnTransformer3P_Ver.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnTransformer3P_Ver.UseVisualStyleBackColor = false;
            this.btnTransformer3P_Ver.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTransformer3P_MouseDown);
            // 
            // btnLinePower_Hor
            // 
            this.btnLinePower_Hor.BackColor = System.Drawing.Color.Transparent;
            this.btnLinePower_Hor.ContainPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnLinePower_Hor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLinePower_Hor.ImageIndex = 10;
            this.btnLinePower_Hor.ImageList = this.imgListTool;
            this.btnLinePower_Hor.IsContainPhead = false;
            this.btnLinePower_Hor.IsContainPIntern = false;
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
            this.btnLinePower_Hor.PIntern = new System.Drawing.Point(0, 0);
            this.btnLinePower_Hor.PreLocation = new System.Drawing.Point(0, 0);
            this.btnLinePower_Hor.PTail = new System.Drawing.Point(0, 0);
            this.btnLinePower_Hor.Size = new System.Drawing.Size(50, 50);
            this.btnLinePower_Hor.TabIndex = 0;
            this.btnLinePower_Hor.UseVisualStyleBackColor = false;
            this.btnLinePower_Hor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLinePower_MouseDown);
            // 
            // btnLinePower_Ver
            // 
            this.btnLinePower_Ver.BackColor = System.Drawing.Color.Transparent;
            this.btnLinePower_Ver.ContainPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnLinePower_Ver.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLinePower_Ver.ImageIndex = 4;
            this.btnLinePower_Ver.ImageList = this.imgListTool;
            this.btnLinePower_Ver.IsContainPhead = false;
            this.btnLinePower_Ver.IsContainPIntern = false;
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
            this.btnLinePower_Ver.PIntern = new System.Drawing.Point(0, 0);
            this.btnLinePower_Ver.PreLocation = new System.Drawing.Point(0, 0);
            this.btnLinePower_Ver.PTail = new System.Drawing.Point(0, 0);
            this.btnLinePower_Ver.Size = new System.Drawing.Size(50, 50);
            this.btnLinePower_Ver.TabIndex = 0;
            this.btnLinePower_Ver.Text = "Line";
            this.btnLinePower_Ver.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnLinePower_Ver.UseVisualStyleBackColor = false;
            this.btnLinePower_Ver.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLinePower_MouseDown);
            // 
            // btnLoad_Hor
            // 
            this.btnLoad_Hor.BackColor = System.Drawing.Color.Transparent;
            this.btnLoad_Hor.ContainPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnLoad_Hor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad_Hor.ImageIndex = 11;
            this.btnLoad_Hor.ImageList = this.imgListTool;
            this.btnLoad_Hor.IsContainPhead = false;
            this.btnLoad_Hor.IsContainPIntern = false;
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
            this.btnLoad_Hor.PIntern = new System.Drawing.Point(0, 0);
            this.btnLoad_Hor.PreLocation = new System.Drawing.Point(0, 0);
            this.btnLoad_Hor.PTail = new System.Drawing.Point(0, 0);
            this.btnLoad_Hor.Size = new System.Drawing.Size(50, 50);
            this.btnLoad_Hor.TabIndex = 0;
            this.btnLoad_Hor.UseVisualStyleBackColor = false;
            this.btnLoad_Hor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLoad_MouseDown);
            // 
            // btnLoad_Ver
            // 
            this.btnLoad_Ver.BackColor = System.Drawing.Color.Transparent;
            this.btnLoad_Ver.ContainPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnLoad_Ver.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad_Ver.ImageIndex = 5;
            this.btnLoad_Ver.ImageList = this.imgListTool;
            this.btnLoad_Ver.IsContainPhead = false;
            this.btnLoad_Ver.IsContainPIntern = false;
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
            this.btnLoad_Ver.PIntern = new System.Drawing.Point(0, 0);
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
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1085, 760);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.btnSetPosSystem);
            this.Controls.Add(this.pnlTool);
            this.Controls.Add(this.pnlTreeView);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuStripBar;
            this.Name = "frmCapstone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Phần mềm đánh giá khả năng ổn định điện áp của hệ thống điện";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.frmCapstone_Resize);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.mnuStripBar.ResumeLayout(false);
            this.mnuStripBar.PerformLayout();
            this.pnlTreeView.ResumeLayout(false);
            this.pnlTool.ResumeLayout(false);
            this.pnlFlowTool.ResumeLayout(false);
            this.cxtMenuStripEPower.ResumeLayout(false);
            this.cxtRemoveLineDrawn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlTreeView;
        public ConnectableE LinePower;
        public System.Windows.Forms.Panel pnlTool;
        private ConnectableE btnBusPower_Hor;
        private ConnectableE btnLinePower_Ver;
        private ConnectableE btnMFPower_Ver;
        private ConnectableE btnTransformer2P_Ver;
        private ConnectableE btnLoad_Ver;
        public PanelMain pnlMain;
        public System.Windows.Forms.ImageList imgListEPower;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ImageList imgListIconMnuStrip;
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
        private System.Windows.Forms.ToolStripMenuItem cxtMnuDCDominationDia;
        private System.Windows.Forms.ToolStripMenuItem cxtMnuDCDrawnCurve;
        private System.Windows.Forms.ToolStripMenuItem cxtMnuDCOperatingMode;
        public System.Windows.Forms.ContextMenuStrip cxtMenuStripEPower;
        private System.Windows.Forms.TreeView tvDataSaved;
        private System.Windows.Forms.ContextMenuStrip cxtRemoveLineDrawn;
        private System.Windows.Forms.ToolStripMenuItem ctMnuRemoveThisLineDrawn;
        public System.Windows.Forms.ImageList imgListTool;
        private System.Windows.Forms.ToolStripMenuItem vIewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem powerFlowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button btnNewFile;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuStripHelpUseSW;
        public System.Windows.Forms.Label lblZoomFactor;
        private System.Windows.Forms.Button btnPrintSystem;
        private System.Windows.Forms.ToolStripMenuItem mnuToolPrintData;
        private System.Windows.Forms.Button btnSetPosSystem;
        private System.Windows.Forms.ToolStripMenuItem onOffSetPositonSystemToolStripMenuItem;
        private System.Windows.Forms.Button btnZoomInCenter;
        private System.Windows.Forms.Button btnZoomOutCenter;
    }
}

