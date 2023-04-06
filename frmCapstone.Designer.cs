
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
            this.btnEPower = new Experimential_Software.ConnectableE();
            this.connectableE1 = new Experimential_Software.ConnectableE();
            this.connectableE2 = new Experimential_Software.ConnectableE();
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
            this.pnlTool.Controls.Add(this.connectableE2);
            this.pnlTool.Controls.Add(this.connectableE1);
            this.pnlTool.Controls.Add(this.btnEPower);
            this.pnlTool.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlTool.Location = new System.Drawing.Point(907, 127);
            this.pnlTool.Name = "pnlTool";
            this.pnlTool.Size = new System.Drawing.Size(121, 633);
            this.pnlTool.TabIndex = 1;
            // 
            // btnEPower
            // 
            this.btnEPower.BackColor = System.Drawing.Color.Transparent;
            this.btnEPower.containPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.btnEPower.IsContainPhead = false;
            this.btnEPower.IsContainPtail = false;
            this.btnEPower.IsMove = false;
            this.btnEPower.Location = new System.Drawing.Point(24, 74);
            this.btnEPower.Name = "btnEPower";
            this.btnEPower.PHead = new System.Drawing.Point(15, 0);
            this.btnEPower.PTail = new System.Drawing.Point(15, 80);
            this.btnEPower.Size = new System.Drawing.Size(30, 80);
            this.btnEPower.TabIndex = 0;
            this.btnEPower.UseVisualStyleBackColor = false;
            this.btnEPower.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnEPower_MouseDown);
            // 
            // connectableE1
            // 
            this.connectableE1.BackColor = System.Drawing.Color.Transparent;
            this.connectableE1.containPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.connectableE1.IsContainPhead = false;
            this.connectableE1.IsContainPtail = false;
            this.connectableE1.IsMove = false;
            this.connectableE1.Location = new System.Drawing.Point(23, 213);
            this.connectableE1.Name = "connectableE1";
            this.connectableE1.PHead = new System.Drawing.Point(25, 0);
            this.connectableE1.PTail = new System.Drawing.Point(25, 50);
            this.connectableE1.Size = new System.Drawing.Size(50, 50);
            this.connectableE1.TabIndex = 1;
            this.connectableE1.UseVisualStyleBackColor = false;
            // 
            // connectableE2
            // 
            this.connectableE2.BackColor = System.Drawing.Color.Transparent;
            this.connectableE2.containPreEpower = Experimential_Software.ContainPreEpower.NoContain;
            this.connectableE2.IsContainPhead = false;
            this.connectableE2.IsContainPtail = false;
            this.connectableE2.IsMove = false;
            this.connectableE2.Location = new System.Drawing.Point(23, 316);
            this.connectableE2.Name = "connectableE2";
            this.connectableE2.PHead = new System.Drawing.Point(0, 15);
            this.connectableE2.PTail = new System.Drawing.Point(80, 15);
            this.connectableE2.Size = new System.Drawing.Size(80, 30);
            this.connectableE2.TabIndex = 2;
            this.connectableE2.Text = "connectableE2";
            this.connectableE2.UseVisualStyleBackColor = false;
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
        private ConnectableE btnEPower;
        private ConnectableE connectableE1;
        private ConnectableE connectableE2;
    }
}

