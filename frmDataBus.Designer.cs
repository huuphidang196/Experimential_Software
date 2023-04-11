
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BusRecTab = new System.Windows.Forms.TabControl();
            this.PowerFlow = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grbBasicData = new System.Windows.Forms.GroupBox();
            this.lblObjNum = new System.Windows.Forms.Label();
            this.txtObjName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOKSet = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.BusRecTab.SuspendLayout();
            this.PowerFlow.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grbBasicData.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.BusRecTab);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(704, 462);
            this.panel1.TabIndex = 0;
            // 
            // BusRecTab
            // 
            this.BusRecTab.Controls.Add(this.PowerFlow);
            this.BusRecTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BusRecTab.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BusRecTab.Location = new System.Drawing.Point(0, 0);
            this.BusRecTab.Name = "BusRecTab";
            this.BusRecTab.SelectedIndex = 0;
            this.BusRecTab.Size = new System.Drawing.Size(700, 458);
            this.BusRecTab.TabIndex = 0;
            // 
            // PowerFlow
            // 
            this.PowerFlow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PowerFlow.Controls.Add(this.btnOKSet);
            this.PowerFlow.Controls.Add(this.panel2);
            this.PowerFlow.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PowerFlow.Location = new System.Drawing.Point(4, 27);
            this.PowerFlow.Name = "PowerFlow";
            this.PowerFlow.Padding = new System.Windows.Forms.Padding(3);
            this.PowerFlow.Size = new System.Drawing.Size(692, 427);
            this.PowerFlow.TabIndex = 0;
            this.PowerFlow.Text = "Power Flow";
            this.PowerFlow.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grbBasicData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(682, 286);
            this.panel2.TabIndex = 1;
            // 
            // grbBasicData
            // 
            this.grbBasicData.BackColor = System.Drawing.SystemColors.Control;
            this.grbBasicData.Controls.Add(this.lblObjNum);
            this.grbBasicData.Controls.Add(this.txtObjName);
            this.grbBasicData.Controls.Add(this.label2);
            this.grbBasicData.Controls.Add(this.label1);
            this.grbBasicData.Dock = System.Windows.Forms.DockStyle.Left;
            this.grbBasicData.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBasicData.Location = new System.Drawing.Point(0, 0);
            this.grbBasicData.Name = "grbBasicData";
            this.grbBasicData.Size = new System.Drawing.Size(346, 286);
            this.grbBasicData.TabIndex = 0;
            this.grbBasicData.TabStop = false;
            this.grbBasicData.Text = "Basic Data";
            // 
            // lblObjNum
            // 
            this.lblObjNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblObjNum.Location = new System.Drawing.Point(27, 62);
            this.lblObjNum.Name = "lblObjNum";
            this.lblObjNum.Size = new System.Drawing.Size(95, 24);
            this.lblObjNum.TabIndex = 2;
            this.lblObjNum.Text = "Number Obj";
            this.lblObjNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtObjName
            // 
            this.txtObjName.Location = new System.Drawing.Point(206, 63);
            this.txtObjName.Name = "txtObjName";
            this.txtObjName.Size = new System.Drawing.Size(115, 24);
            this.txtObjName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(203, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Object Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Object Number";
            // 
            // btnOKSet
            // 
            this.btnOKSet.Location = new System.Drawing.Point(235, 382);
            this.btnOKSet.Name = "btnOKSet";
            this.btnOKSet.Size = new System.Drawing.Size(75, 30);
            this.btnOKSet.TabIndex = 2;
            this.btnOKSet.Text = "OK";
            this.btnOKSet.UseVisualStyleBackColor = true;
            this.btnOKSet.Click += new System.EventHandler(this.btnOKSet_Click);
            // 
            // frmDataBus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 462);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmDataBus";
            this.Text = "Bus Data Record";
            this.Load += new System.EventHandler(this.frmDataBus_Load);
            this.panel1.ResumeLayout(false);
            this.BusRecTab.ResumeLayout(false);
            this.PowerFlow.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.grbBasicData.ResumeLayout(false);
            this.grbBasicData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl BusRecTab;
        private System.Windows.Forms.TabPage PowerFlow;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grbBasicData;
        private System.Windows.Forms.Label lblObjNum;
        private System.Windows.Forms.TextBox txtObjName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOKSet;
    }
}