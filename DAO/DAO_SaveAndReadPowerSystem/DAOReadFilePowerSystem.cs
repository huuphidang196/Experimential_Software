﻿using Experimential_Software.Class_Database;
using Experimential_Software.CustomControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experimential_Software.DAO.DAO_SaveAndReadPowerSystem
{
    public class DAOReadFilePowerSystem
    {
        private static DAOReadFilePowerSystem _instance;
        public static DAOReadFilePowerSystem Instance
        {
            get { if (_instance == null) _instance = new DAOReadFilePowerSystem(); return _instance; }
            private set {; }
        }

        private DAOReadFilePowerSystem() {; }

        //openFile
        public void FunctionMnuFileOpen_Click(frmCapstone frmCapstone)
        {
            //Question Before Open;
            bool saveBefore = this.QuestionSaveBeforeOpen(frmCapstone);

            if (saveBefore) return;

            OpenFileDialog openFileDialogMain = new OpenFileDialog();
            openFileDialogMain.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialogMain.FilterIndex = 1;
            //FilterIndex cho biết định dạng mặc định khi mở hộp thoại
            openFileDialogMain.RestoreDirectory = true;
            //RestoreDirectory cho phép hộp thoại khôi phục đường dẫn trước đó khi được mở lên.

            if (openFileDialogMain.ShowDialog() != DialogResult.OK) return;

            //Clear All 
            DAOProcessMenuFileStrip.Instance.ClearAllEPowerAndLineOnMain(frmCapstone);

            string path = openFileDialogMain.FileName;

            //Add EPower adn Add LineConnect
            this.ProcessOpenFile(frmCapstone, path);
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

           // frmCapstone.mnuFileNew.PerformClick();
            return false;
        }

 

        protected virtual void ProcessOpenFile(frmCapstone frmCapstone, string path)
        {
            DTODataPowerSystem dtoPowerSystem = this.ReadDatabaseEPowerSystem(path);
            //Set DTO Form Main
            frmCapstone.DTOPowerSystem = dtoPowerSystem;
            //process get EPower
            this.ProcessOpenGetEPower(frmCapstone, dtoPowerSystem);

            //process get LineConnect must After EPower
            this.ProcessOpenGetLineConnect(frmCapstone, dtoPowerSystem);
        }

    
        protected virtual DTODataPowerSystem ReadDatabaseEPowerSystem(string path)
        {
            DTODataPowerSystem dtoPowerSystem = new DTODataPowerSystem();
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();

                object data = bf.Deserialize(fs);
                dtoPowerSystem = data as DTODataPowerSystem;
                fs.Close();
                return dtoPowerSystem;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //MessageBox.Show("Count EPower = " + dataBaseEPowers.Count);
            return dtoPowerSystem;
        }

        #region Process_Get_EPower
        // Process_Get_EPower
        protected virtual void ProcessOpenGetEPower(frmCapstone frmCapstone, DTODataPowerSystem dtoPowerSystem)
        {
            List<DatabaseEPower> databaseEPowers = dtoPowerSystem.Database_EPowersSave;
            for (int i = 0; i < databaseEPowers.Count; i++)
            {
                DatabaseEPower databaseE = databaseEPowers[i];

                if (i == 0) frmCapstone.pnlMain.ZoomFactor = databaseE.ZoomFactor;

                ConnectableE ePower = new ConnectableE(frmCapstone, frmCapstone.pnlMain, databaseE, frmCapstone.imgListEPower, GenerateMode.LoadDatabase);

                ePower.DoDragDrop(ePower, DragDropEffects.Move);
                ePower.PreLocation = databaseE.OldLocation_Save;
                frmCapstone.pnlMain.Controls.Add(ePower);
                ePower.Location = databaseE.OldLocation_Save;
                
                ePower.BringToFront();

                ePower.UpdatePositonLabelInfo(); //=> use show label. I don't know it not show on panel, need code row
                frmCapstone.CountElement = frmCapstone.EPowers.Count;
               
                // ==> not add to List because Panel have event in frm.cs pnlMain_DragDrop . When addmain => do event
            }

        }

        #endregion Process_Get_EPower

        #region Process_Get_LineConnect
        //Process_Get_LineConnect
        protected virtual void ProcessOpenGetLineConnect(frmCapstone frmCapstone, DTODataPowerSystem dtoPowerSystem)
        {
            //Open
            //*Note : Read must start EPower then LineConnect . In Order to ensure that EPower Ends exist

            List<DatabaseLineConnect> databaseLines = dtoPowerSystem.Database_LinesConnected;
            //Set List LineConnect On Main
            this.GenerateLineConnectFromDataSave(frmCapstone, databaseLines); ;
        }


        protected virtual void GenerateLineConnectFromDataSave(frmCapstone frmCapstone, List<DatabaseLineConnect> databaseLines)
        {
            foreach (DatabaseLineConnect dataline in databaseLines)
            {
                ConnectableE StartEPower = this.GetEPowerByNameToString(frmCapstone, dataline.NameStartEPower);
                ConnectableE EndEPower = this.GetEPowerByNameToString(frmCapstone, dataline.NameEndEPower);
                
                //Point Start and End Line
                Point StartPoint = dataline.StartPoint;
                Point EndPoint = dataline.EndPoint;

                LineConnect lineConnect = new LineConnect(StartEPower, EndEPower, StartPoint, EndPoint, frmCapstone.pnlMain);
                //this.lineConnectList.Add(lineConnect);
                frmCapstone.AddLine(lineConnect);

                //Process Add List Line Connect with per EPowerAdd this Line into List of EPower Start and End
                StartEPower.AddLineConnectedToList(lineConnect);
                EndEPower.AddLineConnectedToList(lineConnect);
            }
        }

        protected virtual ConnectableE GetEPowerByNameToString(frmCapstone frmCapstone, string ePower_Found)
        {
            foreach (ConnectableE ePower in frmCapstone.EPowers)
            {
                if (ePower.ToString() == ePower_Found) return ePower;
            }

            return null;
        }
        //Process_Get_LineConnect
        #endregion Process_Get_LineConnect

      
    }
}