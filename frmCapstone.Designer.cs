
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
            this.btnLoad = new Experimential_Software.ConnectableE();
            this.imgListTool = new System.Windows.Forms.ImageList(this.components);
            this.btnMFPower = new Experimential_Software.ConnectableE();
            this.btnTransformer = new Experimential_Software.ConnectableE();
            this.btnLinePower = new Experimential_Software.ConnectableE();
            this.btnBusPower = new Experimential_Software.ConnectableE();
            this.imgListEPower = new System.Windows.Forms.ImageList(this.components);
            this.imgListIconCtrl = new System.Windows.Forms.ImageList(this.components);
            this.pnlMain = new Experimential_Software.PanelMain();
            this.panel2.SuspendLayout();
            this.mnuStripBar.SuspendLayout();
            this.pnlTool.SuspendLayout();
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
            this.pnlTool.Controls.Add(this.btnLoad);
            this.pnlTool.Controls.Add(this.btnMFPower);
            this.pnlTool.Controls.Add(this.btnTransformer);
            this.pnlTool.Controls.Add(this.btnLinePower);
            this.pnlTool.Controls.Add(this.btnBusPower);
            this.pnlTool.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlTool.Location = new System.Drawing.Point(907, 127);
            this.pnlTool.Name = "pnlTool";
            this.pnlTool.Size = new System.Drawing.Size(121, 633);
            this.pnlTool.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.Transparent;
            this.btnLoad.containPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnLoad.Flag = 0;
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ImageIndex = 4;
            this.btnLoad.ImageList = this.imgListTool;
            this.btnLoad.IsContainPhead = false;
            this.btnLoad.IsContainPtail = false;
            this.btnLoad.IsMove = false;
            this.btnLoad.isOnTool = true;
            this.btnLoad.IsSelected = false;
            this.btnLoad.Location = new System.Drawing.Point(30, 449);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.PHead = new System.Drawing.Point(0, 0);
            this.btnLoad.PTail = new System.Drawing.Point(0, 0);
            this.btnLoad.Size = new System.Drawing.Size(50, 50);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLoad_MouseDown);
            // 
            // imgListTool
            // 
            this.imgListTool.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListTool.ImageStream")));
            this.imgListTool.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListTool.Images.SetKeyName(0, "MF_Tool.png");
            this.imgListTool.Images.SetKeyName(1, "BUS_Tool.png");
            this.imgListTool.Images.SetKeyName(2, "MBA2_Tool.png");
            this.imgListTool.Images.SetKeyName(3, "Line_Tool.png");
            this.imgListTool.Images.SetKeyName(4, "Load_Tool.png");
            // 
            // btnMFPower
            // 
            this.btnMFPower.BackColor = System.Drawing.Color.Transparent;
            this.btnMFPower.containPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnMFPower.Flag = 0;
            this.btnMFPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMFPower.ImageIndex = 0;
            this.btnMFPower.ImageList = this.imgListTool;
            this.btnMFPower.IsContainPhead = false;
            this.btnMFPower.IsContainPtail = false;
            this.btnMFPower.IsMove = false;
            this.btnMFPower.isOnTool = true;
            this.btnMFPower.IsSelected = false;
            this.btnMFPower.Location = new System.Drawing.Point(30, 37);
            this.btnMFPower.Name = "btnMFPower";
            this.btnMFPower.PHead = new System.Drawing.Point(0, 0);
            this.btnMFPower.PTail = new System.Drawing.Point(0, 0);
            this.btnMFPower.Size = new System.Drawing.Size(50, 50);
            this.btnMFPower.TabIndex = 0;
            this.btnMFPower.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnMFPower.UseVisualStyleBackColor = false;
            this.btnMFPower.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMFPower_MouseDown);
            // 
            // btnTransformer
            // 
            this.btnTransformer.BackColor = System.Drawing.Color.Transparent;
            this.btnTransformer.containPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnTransformer.Flag = 0;
            this.btnTransformer.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransformer.ImageIndex = 2;
            this.btnTransformer.ImageList = this.imgListTool;
            this.btnTransformer.IsContainPhead = false;
            this.btnTransformer.IsContainPtail = false;
            this.btnTransformer.IsMove = false;
            this.btnTransformer.isOnTool = true;
            this.btnTransformer.IsSelected = false;
            this.btnTransformer.Location = new System.Drawing.Point(30, 227);
            this.btnTransformer.Name = "btnTransformer";
            this.btnTransformer.PHead = new System.Drawing.Point(0, 0);
            this.btnTransformer.PTail = new System.Drawing.Point(0, 0);
            this.btnTransformer.Size = new System.Drawing.Size(50, 50);
            this.btnTransformer.TabIndex = 0;
            this.btnTransformer.Text = "Transfoner";
            this.btnTransformer.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnTransformer.UseVisualStyleBackColor = false;
            this.btnTransformer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTransformer_MouseDown);
            // 
            // btnLinePower
            // 
            this.btnLinePower.BackColor = System.Drawing.Color.Transparent;
            this.btnLinePower.containPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnLinePower.Flag = 0;
            this.btnLinePower.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLinePower.ImageIndex = 3;
            this.btnLinePower.ImageList = this.imgListTool;
            this.btnLinePower.IsContainPhead = false;
            this.btnLinePower.IsContainPtail = false;
            this.btnLinePower.IsMove = false;
            this.btnLinePower.isOnTool = true;
            this.btnLinePower.IsSelected = false;
            this.btnLinePower.Location = new System.Drawing.Point(30, 336);
            this.btnLinePower.Name = "btnLinePower";
            this.btnLinePower.PHead = new System.Drawing.Point(0, 0);
            this.btnLinePower.PTail = new System.Drawing.Point(0, 0);
            this.btnLinePower.Size = new System.Drawing.Size(50, 50);
            this.btnLinePower.TabIndex = 0;
            this.btnLinePower.Text = "Line";
            this.btnLinePower.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnLinePower.UseVisualStyleBackColor = false;
            this.btnLinePower.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLinePower_MouseDown);
            // 
            // btnBusPower
            // 
            this.btnBusPower.BackColor = System.Drawing.Color.Transparent;
            this.btnBusPower.containPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnBusPower.Flag = 0;
            this.btnBusPower.ImageIndex = 1;
            this.btnBusPower.ImageList = this.imgListTool;
            this.btnBusPower.IsContainPhead = false;
            this.btnBusPower.IsContainPtail = false;
            this.btnBusPower.IsMove = false;
            this.btnBusPower.isOnTool = true;
            this.btnBusPower.IsSelected = false;
            this.btnBusPower.Location = new System.Drawing.Point(30, 134);
            this.btnBusPower.Name = "btnBusPower";
            this.btnBusPower.PHead = new System.Drawing.Point(0, 0);
            this.btnBusPower.PTail = new System.Drawing.Point(0, 0);
            this.btnBusPower.Size = new System.Drawing.Size(50, 50);
            this.btnBusPower.TabIndex = 0;
            this.btnBusPower.UseVisualStyleBackColor = false;
            this.btnBusPower.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnBusPower_MouseDown);
            // 
            // imgListEPower
            // 
            this.imgListEPower.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListEPower.ImageStream")));
            this.imgListEPower.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListEPower.Images.SetKeyName(0, "imgNoType.png");
            this.imgListEPower.Images.SetKeyName(1, "MF.png");
            this.imgListEPower.Images.SetKeyName(2, "BUS-export.png");
            this.imgListEPower.Images.SetKeyName(3, "MBA 3 cuộn dây-export.png");
            this.imgListEPower.Images.SetKeyName(4, "Line .png");
            this.imgListEPower.Images.SetKeyName(5, "Load_Run.png");
            // 
            // imgListIconCtrl
            // 
            this.imgListIconCtrl.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListIconCtrl.ImageStream")));
            this.imgListIconCtrl.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListIconCtrl.Images.SetKeyName(0, "icon_NewFile.png");
            this.imgListIconCtrl.Images.SetKeyName(1, "icon_OpenFile.png");
            this.imgListIconCtrl.Images.SetKeyName(2, "icon_SaveFile.png");
            // 
            // pnlMain
            // 
            this.pnlMain.AllowDrop = true;
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(115, 127);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(792, 633);
            this.pnlMain.TabIndex = 3;
            this.pnlMain.TabStop = true;
            this.pnlMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlMain_DragDrop);
            this.pnlMain.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlMain_DragEnter);
            this.pnlMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMain_MouseDown);
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
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        public ConnectableE LinePower;
        public System.Windows.Forms.Panel pnlTool;
        public System.Windows.Forms.Label lblLine;
        private ConnectableE btnBusPower;
        private ConnectableE btnLinePower;
        private ConnectableE btnMFPower;
        private ConnectableE btnTransformer;
        private ConnectableE btnLoad;
        public PanelMain pnlMain;
        public System.Windows.Forms.ImageList imgListEPower;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ImageList imgListTool;
        private System.Windows.Forms.ImageList imgListIconCtrl;
        public System.Windows.Forms.MenuStrip mnuStripBar;
        public System.Windows.Forms.ToolStripMenuItem mnuFileNew;
        public System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        public System.Windows.Forms.ToolStripMenuItem mnuFileSave;
    }
}

