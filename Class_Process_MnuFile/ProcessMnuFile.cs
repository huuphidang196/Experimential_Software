using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Experimential_Software;
using Experimential_Software.Class_Database;
using Experimential_Software.CustomControl;

namespace Experimential_Software.Class_Process_MnuFile
{
    public class ProcessMnuFile
    {
        protected frmCapstone _frmCap;

        public ProcessMnuFile(frmCapstone frmCapstone)
        {
            this._frmCap = frmCapstone;
        }


        #region New_File;
        public void FunctionMnuFileNew_Click(object sender, EventArgs e)
        {
            //Question Before Open;
            this.ClearAllEPowerAndLineOnMain();       
        }

        protected virtual void ClearAllEPowerAndLineOnMain()
        {
            //Clear Old EPower 
            this._frmCap.pnlMain.Controls.Clear();
            //Clear Old Line
            this._frmCap.pnlMain.CreateGraphics().Clear(this._frmCap.pnlMain.BackColor);
            //Clear List Old EPower
            this._frmCap.EPowers.Clear();

            //Clear Interface Mouse Move EPower
            this._frmCap.IEPowers.Clear();
            //Clear List Line
            this._frmCap.LineConnectList.Clear();
            //Set Count EPower = 0
            this._frmCap.CountElement = 0;
        }

        #endregion New_File

        #region Open_File
        //openFile
        public void FunctionMnuFileOpen_Click(object sender, EventArgs e)
        {
            //Question Before Open;
            bool saveBefore = this.QuestionSaveBeforeOpen();

           if (saveBefore) return;

            OpenFileDialog openFileDialogMain = new OpenFileDialog();
            openFileDialogMain.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialogMain.FilterIndex = 1;
            //FilterIndex cho biết định dạng mặc định khi mở hộp thoại
            openFileDialogMain.RestoreDirectory = true;
            //RestoreDirectory cho phép hộp thoại khôi phục đường dẫn trước đó khi được mở lên.

            if (openFileDialogMain.ShowDialog() != DialogResult.OK) return;

            //Clear All 
            this.ClearAllEPowerAndLineOnMain();

            string path = openFileDialogMain.FileName;

            //Add EPower adn Add LineConnect
            this.ProcessOpenFile(path);
        }

        protected virtual bool QuestionSaveBeforeOpen()
        {
            if (this._frmCap.pnlMain.Controls.Count == 0) return false;

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
            //process get EPower
            this.ProcessOpenGetEPower(path);

            string diffLine = path;
            //Automatic generate file save for Line, not override path
            string pathLine = this.ProcessPathSaveLineWithEPower(diffLine);

            //process get LineConnect must After EPower
            this.ProcessOpenGetLineConnect(pathLine);

        }
      
        // Process_Get_EPower
        protected virtual void ProcessOpenGetEPower(string path)
        {
            List<DatabaseEPower> databaseEPowers = FileFoctory.ReadDatabaseEPower(path);

            foreach (DatabaseEPower databaseE in databaseEPowers)
            {
                ConnectableE ePower = new ConnectableE(this._frmCap, this._frmCap.pnlMain, databaseE, this._frmCap.imgListEPower, GenerateMode.LoadDatabase);
               
                ePower.DoDragDrop(ePower, DragDropEffects.Move);
                ePower.Location = this.GetPointOldInDatabaseEpower(databaseE);
                ePower.BringToFront();

                this._frmCap.pnlMain.Controls.Add(ePower);

                ePower.UpdatePositonLabelInfo(); //=> use show label. I don;t know it not show on panel, need code row
                this._frmCap.CountElement = this._frmCap.EPowers.Count;

                // ==> not add to List because Panel have event in frm.cs pnlMain_DragDrop . When addmain => do event
            }
        }
        protected virtual Point GetPointOldInDatabaseEpower(DatabaseEPower databaseE)
        {
            Point oldLocation = databaseE.OldLocation;
            return oldLocation;
        }

        // Process_Get_EPower

  

        //Process_Get_LineConnect
        protected virtual void ProcessOpenGetLineConnect(string path)
        {
            //Read DataLine From FileFactory
            List<DatabaseLineConnect> databaseLines = FileFoctory.ReadDataAllLineConnect(path);
            //Set List LineConnect On Main
            this.GenerateLineConnectFromDataSave(databaseLines);;    
        }

     
        protected virtual void GenerateLineConnectFromDataSave(List<DatabaseLineConnect> databaseLines)
        {
            foreach (DatabaseLineConnect dataline in databaseLines)
            {
                ConnectableE StartEPower = this.GetEPowerByNameToString( dataline.NameStartEPower);
                ConnectableE EndEPower = this.GetEPowerByNameToString(dataline.NameEndEPower);

                //Point Start and End Line
                Point StartPoint = dataline.StartPoint;
                Point EndPoint = dataline.EndPoint;

                LineConnect lineConnect = new LineConnect(StartEPower, EndEPower, StartPoint, EndPoint, this._frmCap.pnlMain);

                //this.lineConnectList.Add(lineConnect);
                this._frmCap.AddLine(lineConnect);
            }
        }

        protected virtual ConnectableE GetEPowerByNameToString(string ePower_Found)
        {
            foreach (ConnectableE ePower in this._frmCap.EPowers)
            {
                if (ePower.ToString() == ePower_Found) return ePower;
            }

            return null;
        }
        //Process_Get_LineConnect
        #endregion Open_File


        #region Save_File
        //save File
        public void FunctionMnuFileSave_Click(object sender, EventArgs e)
        {
            if (this._frmCap.pnlMain.Controls.Count == 0) MessageBox.Show("Panel has no Controls, you should not save this file!");

            SaveFileDialog saveFileDialogMain = new SaveFileDialog();
            saveFileDialogMain.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialogMain.FilterIndex = 1;
            saveFileDialogMain.RestoreDirectory = true;

            if (saveFileDialogMain.ShowDialog() != DialogResult.OK) return;
            string path = saveFileDialogMain.FileName;
            //Save All EPower
            this.ProcessSaveEPowerOnMain(path);

            string newLine = path;
            //Automatic generate file save for Line, not override path
            string pathLine = this.ProcessPathSaveLineWithEPower(newLine);
            //Save All Line
            this.ProcessSaveLineOnMain(pathLine);
        }
        //Save EPower
        protected virtual void ProcessSaveEPowerOnMain(string path)
        {
            this.ProcessSaveOldPostionEPower(this._frmCap.EPowers);
            bool saveSuccess = FileFoctory.SaveDataBaseEPower(this._frmCap.EPowers, path);

            if (!saveSuccess) return;
           // MessageBox.Show("Save EPower Successed + " + this.ePowers.Count);
        }

        //Save All LineConnect
        protected virtual void ProcessSaveLineOnMain(string path)
        {
            bool saveSuccess = FileFoctory.SaveDataBaseLineConnect(this._frmCap.LineConnectList, path);

            if (!saveSuccess) return;
           // MessageBox.Show("Save Line Successed");
        }

        protected virtual void ProcessSaveOldPostionEPower(List<ConnectableE> EPowersSave)
        {
            foreach (ConnectableE ePower in EPowersSave)
            {
                DatabaseEPower databaseE = ePower.DatabaseE;
                databaseE.OldLocation = ePower.Location;
            }
        }

        protected virtual string ProcessPathSaveLineWithEPower(string pathEPower)
        {
            //Get Folder Contain
            string folderPath = Path.GetDirectoryName(pathEPower);
            string fileNameEPower = Path.GetFileName(pathEPower);

            string newFileName = "SaveLine" + fileNameEPower; // đổi tên file thành "SaveLine" + fileNameEPower dễ phân biệt
            string newPath = Path.Combine(folderPath, newFileName); // tạo đường dẫn mới

            return newPath;
        }
        #endregion Save_File
    }
}
