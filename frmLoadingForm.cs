using Experimential_Software.DAO.DAO_Curve.DAO_GeneratePath;
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
    public partial class frmLoadingForm : Form
    {
        public frmLoadingForm()
        {
            InitializeComponent();
        }

        private void frmLoadingForm_Load(object sender, EventArgs e)
        {
            this.SetImagePictureBoxLoading();
            this.SetDataStartOnBar();

        }

        private void SetImagePictureBoxLoading()
        {
            string pathLogo = DAOGeneratePathFolder.Instance.LoadLogoInsideLibraryLogo();
            this.ptbImageLoading.Image =  Image.FromFile(pathLogo);
        }

        protected virtual void SetDataStartOnBar()
        {
            this.ControlBox = false;

            this.pgrBarLoading.Minimum = 0;
            this.pgrBarLoading.Maximum = 300;
            this.pgrBarLoading.Value = 0;

            this.pgrBarLoading.Visible = true;
            this.timerLoading.Start();
        }

        private void timerLoading_Tick(object sender, EventArgs e)
        {
            int addValue = 1;
            this.ShowLoading(addValue);
        }

        // Phương thức bắt đầu hiển thị thanh Loading
        private void ShowLoading(int addValue)
        {
            this.pgrBarLoading.Value += addValue;

            int currentValue = this.pgrBarLoading.Value; // Giá trị hiện tại
            int maxValue = this.pgrBarLoading.Maximum; // Giá trị tối đa

            int percent = (int)Math.Floor((currentValue / (double)maxValue) * 100);
            this.lblPercentLoading.Text = "Loading... " + percent + " %";

            if (currentValue >= this.pgrBarLoading.Maximum) this.HideLoading();
   
        }

        // Phương thức dừng hiển thị thanh Loading
        private void HideLoading()
        {
            this.timerLoading.Stop();
            this.pgrBarLoading.Visible = false;
            this.Close();
        }


    }
}
