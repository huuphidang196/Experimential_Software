
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblLine = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlTool = new System.Windows.Forms.Panel();
            this.btnBus = new Experimential_Software.ConnectableE();
            this.btnMF = new Experimential_Software.ConnectableE();
            this.btnLineEPower = new Experimential_Software.ConnectableE();
            this.panel2.SuspendLayout();
            this.pnlTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.AllowDrop = true;
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(115, 127);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(913, 633);
            this.pnlMain.TabIndex = 0;
            this.pnlMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlMain_DragDrop);
            this.pnlMain.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlMain_DragEnter);
            this.pnlMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMain_MouseDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.lblLine);
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
            this.lblLine.Location = new System.Drawing.Point(173, 57);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(51, 20);
            this.lblLine.TabIndex = 2;
            this.lblLine.Text = "label1";
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
            this.pnlTool.Controls.Add(this.btnBus);
            this.pnlTool.Controls.Add(this.btnMF);
            this.pnlTool.Controls.Add(this.btnLineEPower);
            this.pnlTool.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlTool.Location = new System.Drawing.Point(907, 127);
            this.pnlTool.Name = "pnlTool";
            this.pnlTool.Size = new System.Drawing.Size(121, 633);
            this.pnlTool.TabIndex = 1;
            // 
            // btnBus
            // 
            this.btnBus.BackColor = System.Drawing.Color.Transparent;
            this.btnBus.containPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnBus.IsContainPhead = false;
            this.btnBus.IsContainPtail = false;
            this.btnBus.IsMove = false;
            this.btnBus.isOnTool = true;
            this.btnBus.IsSelected = false;
            this.btnBus.Location = new System.Drawing.Point(29, 214);
            this.btnBus.Name = "btnBus";
            this.btnBus.PHead = new System.Drawing.Point(25, 0);
            this.btnBus.PTail = new System.Drawing.Point(25, 50);
            this.btnBus.Size = new System.Drawing.Size(50, 50);
            this.btnBus.TabIndex = 2;
            this.btnBus.Text = "Bus";
            this.btnBus.UseVisualStyleBackColor = false;
            this.btnBus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnBus_MouseDown);
            // 
            // btnMF
            // 
            this.btnMF.BackColor = System.Drawing.Color.Transparent;
            this.btnMF.containPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnMF.IsContainPhead = false;
            this.btnMF.IsContainPtail = false;
            this.btnMF.IsMove = false;
            this.btnMF.isOnTool = true;
            this.btnMF.IsSelected = false;
            this.btnMF.Location = new System.Drawing.Point(29, 118);
            this.btnMF.Name = "btnMF";
            this.btnMF.PHead = new System.Drawing.Point(25, 0);
            this.btnMF.PTail = new System.Drawing.Point(25, 50);
            this.btnMF.Size = new System.Drawing.Size(50, 50);
            this.btnMF.TabIndex = 1;
            this.btnMF.Text = "MF";
            this.btnMF.UseVisualStyleBackColor = false;
            this.btnMF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMF_MouseDown);
            // 
            // btnLineEPower
            // 
            this.btnLineEPower.BackColor = System.Drawing.Color.Transparent;
            this.btnLineEPower.containPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnLineEPower.IsContainPhead = false;
            this.btnLineEPower.IsContainPtail = false;
            this.btnLineEPower.IsMove = false;
            this.btnLineEPower.isOnTool = true;
            this.btnLineEPower.IsSelected = false;
            this.btnLineEPower.Location = new System.Drawing.Point(29, 31);
            this.btnLineEPower.Name = "btnLineEPower";
            this.btnLineEPower.PHead = new System.Drawing.Point(25, 0);
            this.btnLineEPower.PTail = new System.Drawing.Point(25, 50);
            this.btnLineEPower.Size = new System.Drawing.Size(50, 50);
            this.btnLineEPower.TabIndex = 0;
            this.btnLineEPower.Text = "Line";
            this.btnLineEPower.UseVisualStyleBackColor = false;
            this.btnLineEPower.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLineEPower_MouseDown);
            // 
            // frmCapstone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 760);
            this.Controls.Add(this.pnlTool);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "frmCapstone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCapstone_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlTool.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        public ConnectableE LinePower;
        public System.Windows.Forms.Panel pnlMain;
        public System.Windows.Forms.Panel pnlTool;
        public System.Windows.Forms.Label lblLine;
        private ConnectableE btnLineEPower;
        private ConnectableE btnMF;
        private ConnectableE btnBus;
    }
}

