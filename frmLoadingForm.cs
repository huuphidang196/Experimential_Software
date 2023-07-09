using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Experimential_Software.BLL.BLL_Curve.BLL_GeneratePath;


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
          //  this.PlayMusic();
            this.SetDataStartOnBar();

        }

        private void SetImagePictureBoxLoading()
        {
            string pathLogo = BLLGeneratePathFolder.Instance.LoadLogoInsideLibraryLogo();
            this.ptbImageLoading.Image =  Image.FromFile(pathLogo);
        }

        protected virtual void PlayMusic()
        {
            //Creat folder Library Sound
            string pathSound = BLLGeneratePathFolder.Instance.LoadPathSoundInsideLibrarySoundLoadForm();
            SoundPlayer player = new SoundPlayer(pathSound);
            //Play Sound
            player.Play();

        }

        protected virtual void SetDataStartOnBar()
        {
            this.ControlBox = false;

        }
   
        // Phương thức dừng hiển thị thanh Loading
        private void HideLoading()
        {
            this.Close();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            this.HideLoading();
        }
    }
}
