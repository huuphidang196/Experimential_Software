using Experimential_Software.DTO;
using Experimential_Software.CustomControl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experimential_Software.DAO.DAO_SaveAndReadPowerSystem
{
    public class DAOSaveFilePowerSystem
    {
        private static DAOSaveFilePowerSystem _instance;
        public static DAOSaveFilePowerSystem Instance
        {
            get { if (_instance == null) _instance = new DAOSaveFilePowerSystem(); return _instance; }
            private set {; }
        }

        private DAOSaveFilePowerSystem() {; }

   
        public virtual void ProcessSaveOldPostionEPower(List<ConnectableE> EPowersSave)
        {
            foreach (ConnectableE ePower in EPowersSave)
            {
                DTODatabaseEPower databaseE = ePower.DatabaseE;
                databaseE.OldLocation_Save = ePower.Location;
                databaseE.ZoomFactor = ePower.PanelMain.ZoomFactor;
            }
        }

        public virtual void ProcessSavePowerSystem(frmCapstone frmCapstone, string path)
        {
            //Save AllDatabase of EPower
            frmCapstone.DTOPowerSystem.Database_EPowersSave = this.GetDatabaseInEPower(frmCapstone.EPowers);
            //Save All Lineconnected
            frmCapstone.DTOPowerSystem.Database_LinesConnected = this.ProcessTransferDataLine(frmCapstone.LineConnectList);
            bool isSuccess = SaveDataBaseEPowerSystem(frmCapstone.DTOPowerSystem, path);
        }

        //Database EPower
        protected virtual List<DTODatabaseEPower> GetDatabaseInEPower(List<ConnectableE> EPowers)
        {
            List<DTODatabaseEPower> dataBaseEPowers = new List<DTODatabaseEPower>();
            foreach (ConnectableE ePower in EPowers)
            {
                DTODatabaseEPower databaseE = ePower.DatabaseE;
                dataBaseEPowers.Add(databaseE);
            }
            return dataBaseEPowers;
        }

        //Database LineConnected
        protected virtual List<DatabaseLineConnect> ProcessTransferDataLine(List<LineConnect> lineConnectList)
        {
            List<DatabaseLineConnect> dataLines = new List<DatabaseLineConnect>();
            foreach (LineConnect lineConnect in lineConnectList)
            {
                DatabaseLineConnect databaseLine = new DatabaseLineConnect();
                //EPower Ends
                databaseLine.NameStartEPower = lineConnect.StartEPower.ToString();
                databaseLine.NameEndEPower = lineConnect.EndEPower.ToString();

                //Point Start and End Line
                databaseLine.StartPoint = lineConnect.StartPoint;
                databaseLine.EndPoint = lineConnect.EndPoint;

                dataLines.Add(databaseLine);
            }
            return dataLines;
        }

        protected bool SaveDataBaseEPowerSystem(DTODataPowerSystem dtoPowerSystem, string path)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(fs, dtoPowerSystem);
                fs.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

    }
}
