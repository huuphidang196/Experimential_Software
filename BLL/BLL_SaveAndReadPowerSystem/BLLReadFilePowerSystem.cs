using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Experimential_Software.DAO.DAO_SaveAndReadPowerSystem;

namespace Experimential_Software.BLL.BLL_SaveAndReadPowerSystem
{
   public class BLLReadFilePowerSystem
    {
        private static BLLReadFilePowerSystem _instance;

        public static BLLReadFilePowerSystem Instance
        {
            get { if (_instance == null) _instance = new BLLReadFilePowerSystem(); return BLLReadFilePowerSystem._instance; }
            private set { _instance = value; }
        }

        private BLLReadFilePowerSystem() { }
        //openFile
        public void FunctionMnuFileOpen_Click(frmCapstone frmCapstone, string pathTreeView)
        {
            //Question Before Open;
            bool saveBefore = this.QuestionSaveBeforeOpen(frmCapstone);

            if (saveBefore) return;

            //use TreeView
            if (pathTreeView != "")
            {
                DAOReadFilePowerSystem.Instance.ProcessInternOpenFileUseOverallWithTreeView(frmCapstone, pathTreeView);
                //Set Name Form
                this.SetNameFormByPath(pathTreeView, frmCapstone);
                return;
            }

            OpenFileDialog openFileDialogMain = new OpenFileDialog();
            openFileDialogMain.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialogMain.FilterIndex = 1;
            //FilterIndex cho biết định dạng mặc định khi mở hộp thoại
            openFileDialogMain.RestoreDirectory = true;
            //RestoreDirectory cho phép hộp thoại khôi phục đường dẫn trước đó khi được mở lên.

            if (openFileDialogMain.ShowDialog() != DialogResult.OK) return;

            string path = openFileDialogMain.FileName;
            //Set Name Form
            this.SetNameFormByPath(path, frmCapstone);

            DAOReadFilePowerSystem.Instance.ProcessInternOpenFileUseOverallWithTreeView(frmCapstone, path);

        }

        protected virtual void SetNameFormByPath(string path, frmCapstone frmCapstone)
        {
            frmCapstone.Text = "Phần mềm đánh giá khả năng ổn định điện áp của hệ thống điện";
            string nameFileOpening = Path.GetFileNameWithoutExtension(path);
            frmCapstone.Text += (" - " + nameFileOpening);
        }
        protected virtual bool QuestionSaveBeforeOpen(frmCapstone frmCapstone)
        {
            if (frmCapstone.pnlMain.Controls.Count == 0) return false;

            DialogResult result = MessageBox.Show("Do you want to Save this File", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                frmCapstone.mnuFileSave.PerformClick();
                return true;
            }
            return false;
        }

    }
}
