using Experimential_Software.Class_Small;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experimential_Software.Class_Process_MnuFile
{
    public class ProcessMnuFile
    {
        protected frmCapstone _frmCap;

        protected PanelMain pnlMain;

        protected List<ConnectableE> ePowers;

        private List<LineConnect> lineConnectList;

        private List<IMouseOnEndsControl> iEPowers;

        protected int countElement = 0;

        public ProcessMnuFile(frmCapstone frmCapstone, PanelMain pnlMainDrawn, List<ConnectableE> ePowers, List<LineConnect> lineConnectList, List<IMouseOnEndsControl> iEPowers, ref int countElement)
        {
            this._frmCap = frmCapstone;
            this.pnlMain = pnlMainDrawn;
            this.ePowers = ePowers;
            this.lineConnectList = lineConnectList;
            this.iEPowers = iEPowers;
            this.countElement = countElement;
        }


        #region New_File;
        public void FunctionMnuFileNew_Click(object sender, EventArgs e)
        {
            this.ClearAllEPowerAndLineOnMain();
        }

        protected virtual void ClearAllEPowerAndLineOnMain()
        {
            this.pnlMain.Controls.Clear();
            this.ePowers.Clear();
            this.iEPowers.Clear();
            this.lineConnectList.Clear();
            this.countElement = 0;
        }

        #endregion New_File

        #region Open_File
        //openFile
        public void FunctionMnuFileOpen_Click(object sender, EventArgs e)
        {
            //Question Before Open;
            bool saveBefore = this.QuestionSaveBeforeOpen();

            if (saveBefore) return;

            OpenFileDialog openFileDialogMaain = new OpenFileDialog();
            openFileDialogMaain.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialogMaain.FilterIndex = 1;
            //FilterIndex cho biết định dạng mặc định khi mở hộp thoại
            openFileDialogMaain.RestoreDirectory = true;
            //RestoreDirectory cho phép hộp thoại khôi phục đường dẫn trước đó khi được mở lên.

            if (openFileDialogMaain.ShowDialog() != DialogResult.OK) return;

            string path = openFileDialogMaain.FileName;

            //Clear All 
            this.ClearAllEPowerAndLineOnMain();
            //Add EPower
            this.ProcessOpenFile(path);

            if (this.ePowers == null) return;

            //  MessageBox.Show("Open Successed , count = " + this.ePowers.Count);
        }

        protected virtual bool QuestionSaveBeforeOpen()
        {
            if (pnlMain.Controls.Count == 0) return false;

            DialogResult result = MessageBox.Show("Do you want to Save this File", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this._frmCap.mnuFileSave.PerformClick();
                return true;
            }

            this._frmCap.mnuFileNew.PerformClick();
            return false;
        }

        protected virtual void ProcessOpenFile(string path)
        {
            List<DatabaseEPower> databaseEPowers = FileFoctory.ReadDatabaseEPower(path);

            foreach (DatabaseEPower databaseE in databaseEPowers)
            {
                ConnectableE ePower = new ConnectableE(this._frmCap, this.pnlMain, databaseE, this._frmCap.imgListEPower);
                this.ePowers.Add(ePower);
                this.iEPowers.Add(ePower);
                ePower.isOnTool = false;

                pnlMain.Controls.Add(ePower);
                ePower.BringToFront();

                ePower.Location = this.GetPointOldInDatabaseEpower(databaseE);

            }
        }

        protected virtual Point GetPointOldInDatabaseEpower(DatabaseEPower databaseE)
        {
            Point oldLocation = databaseE.OldLocation;
            return oldLocation;
        }

        #endregion Open_File


        #region Save_File
        //save File
        public void FunctionMnuFileSave_Click(object sender, EventArgs e)
        {
            if (pnlMain.Controls.Count == 0) MessageBox.Show("Panel has no Controls, you should not save this file!");

            SaveFileDialog saveFileDialogMaain = new SaveFileDialog();
            saveFileDialogMaain.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialogMaain.FilterIndex = 1;
            saveFileDialogMaain.RestoreDirectory = true;

            if (saveFileDialogMaain.ShowDialog() != DialogResult.OK) return;

            string path = saveFileDialogMaain.FileName;
            this.ProcessSaveOldPostionEPower(this.ePowers);
            bool saveSuccess = FileFoctory.SaveDataBaseEPower(this.ePowers, path);

            if (!saveSuccess) return;
            MessageBox.Show("Save Successed");
        }

        protected virtual void ProcessSaveOldPostionEPower(List<ConnectableE> EPowersSave)
        {
            foreach (ConnectableE ePower in EPowersSave)
            {
                DatabaseEPower databaseE = ePower.DatabaseE;
                databaseE.OldLocation = ePower.Location;
            }
        }

        #endregion Save_File
    }
}
