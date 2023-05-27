using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experimential_Software
{
    public partial class frmOpenImageFromTreeView : Form
    {
        protected Image _imgPrinted;
        public Image ImgPrinted { set => _imgPrinted = value; }

        public frmOpenImageFromTreeView()
        {
            InitializeComponent();
        }

        private void frmOpenImageFromTreeView_Load(object sender, EventArgs e)
        {
            if (this._imgPrinted == null)
            {
                MessageBox.Show("Hình ảnh không hợp lệ hoặc không tồn tại!");
                return;
            }
            //recify Sixe Panel
            this.ClientSize = this._imgPrinted.Size + new Size(30, 30);
            this.Location = new Point(350, 100);

            this.pnlImage.Size = this._imgPrinted.Size;
            this.ptbImagePrinted.SizeMode = PictureBoxSizeMode.AutoSize;
            this.ptbImagePrinted.Image = this._imgPrinted;
            this.ptbImagePrinted.BorderStyle = BorderStyle.FixedSingle;

            this.pnlImage.Location = new Point(15, 15);
        }

        private void ptbImagePrinted_SizeChanged(object sender, EventArgs e)
        {
          //  this.ClientSize = this.ptbImagePrinted.Size;
        }
    }
}
