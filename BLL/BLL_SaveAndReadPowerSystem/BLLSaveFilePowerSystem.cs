using Experimential_Software.DAO.DAO_SaveAndReadPowerSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experimential_Software.BLL.BLL_SaveAndReadPowerSystem
{
    public class BLLSaveFilePowerSystem
    {
        private static BLLSaveFilePowerSystem _instance;

        public static BLLSaveFilePowerSystem Instance
        {
            get { if (_instance == null) _instance = new BLLSaveFilePowerSystem(); return BLLSaveFilePowerSystem._instance; }
            private set { _instance = value; }
        }

        private BLLSaveFilePowerSystem() { }
        //save File
        public void FunctionMnuFileSave_Click(frmCapstone frmCapstone)
        {
            if (frmCapstone.pnlMain.Controls.Count == 0) MessageBox.Show("Panel has no Controls, you should not save this file!");

            SaveFileDialog saveFileDialogMain = new SaveFileDialog();
            saveFileDialogMain.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialogMain.FilterIndex = 1;
            saveFileDialogMain.RestoreDirectory = true;

            if (saveFileDialogMain.ShowDialog() != DialogResult.OK) return;
            string path = saveFileDialogMain.FileName;

            //Save All DatabaseEPower of EPower
            DAOSaveFilePowerSystem.Instance.ProcessSaveOldPostionEPower(frmCapstone.EPowers);

            //Process Save
            DAOSaveFilePowerSystem.Instance.ProcessSavePowerSystem(frmCapstone, path);

        }
    }
}
