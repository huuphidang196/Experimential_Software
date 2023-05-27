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
    public partial class frmNameImagePrint : Form
    {
        protected string _nameImage;
        public string NameImage => _nameImage;

        public frmNameImagePrint()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this._nameImage = this.txtNameImage.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
