
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
            this.btnMFPower = new Experimential_Software.ConnectableE();
            this.btnLinePower = new Experimential_Software.ConnectableE();
            this.btnBusPower = new Experimential_Software.ConnectableE();
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
            this.pnlTool.Controls.Add(this.btnMFPower);
            this.pnlTool.Controls.Add(this.btnLinePower);
            this.pnlTool.Controls.Add(this.btnBusPower);
            this.pnlTool.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlTool.Location = new System.Drawing.Point(907, 127);
            this.pnlTool.Name = "pnlTool";
            this.pnlTool.Size = new System.Drawing.Size(121, 633);
            this.pnlTool.TabIndex = 1;
            // 
            // btnMFPower
            // 
            this.btnMFPower.BackColor = System.Drawing.Color.Transparent;
            this.btnMFPower.containPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnMFPower.IsContainPhead = false;
            this.btnMFPower.IsContainPtail = false;
            this.btnMFPower.IsMove = false;
            this.btnMFPower.isOnTool = true;
            this.btnMFPower.IsSelected = false;
            this.btnMFPower.Location = new System.Drawing.Point(30, 212);
            this.btnMFPower.Name = "btnMFPower";
            this.btnMFPower.PHead = new System.Drawing.Point(0, 0);
            this.btnMFPower.PTail = new System.Drawing.Point(0, 0);
            this.btnMFPower.Size = new System.Drawing.Size(50, 50);
            this.btnMFPower.TabIndex = 0;
            this.btnMFPower.Text = "MF";
            this.btnMFPower.UseVisualStyleBackColor = false;
            this.btnMFPower.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMFPower_MouseDown);
            // 
            // btnLinePower
            // 
            this.btnLinePower.BackColor = System.Drawing.Color.Transparent;
            this.btnLinePower.containPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnLinePower.IsContainPhead = false;
            this.btnLinePower.IsContainPtail = false;
            this.btnLinePower.IsMove = false;
            this.btnLinePower.isOnTool = true;
            this.btnLinePower.IsSelected = false;
            this.btnLinePower.Location = new System.Drawing.Point(30, 132);
            this.btnLinePower.Name = "btnLinePower";
            this.btnLinePower.PHead = new System.Drawing.Point(0, 0);
            this.btnLinePower.PTail = new System.Drawing.Point(0, 0);
            this.btnLinePower.Size = new System.Drawing.Size(50, 50);
            this.btnLinePower.TabIndex = 0;
            this.btnLinePower.Text = "Line";
            this.btnLinePower.UseVisualStyleBackColor = false;
            this.btnLinePower.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLinePower_MouseDown);
            // 
            // btnBusPower
            // 
            this.btnBusPower.BackColor = System.Drawing.Color.Transparent;
            this.btnBusPower.containPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnBusPower.IsContainPhead = false;
            this.btnBusPower.IsContainPtail = false;
            this.btnBusPower.IsMove = false;
            this.btnBusPower.isOnTool = true;
            this.btnBusPower.IsSelected = false;
            this.btnBusPower.Location = new System.Drawing.Point(30, 48);
            this.btnBusPower.Name = "btnBusPower";
            this.btnBusPower.PHead = new System.Drawing.Point(0, 0);
            this.btnBusPower.PTail = new System.Drawing.Point(0, 0);
            this.btnBusPower.Size = new System.Drawing.Size(50, 50);
            this.btnBusPower.TabIndex = 0;
            this.btnBusPower.Text = "Bus";
            this.btnBusPower.UseVisualStyleBackColor = false;
            this.btnBusPower.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnBusPower_MouseDown);
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
        private ConnectableE btnBusPower;
        private ConnectableE btnLinePower;
        private ConnectableE btnMFPower;
    }
}

