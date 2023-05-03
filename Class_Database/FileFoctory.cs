using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Drawing;
using Experimential_Software.CustomControl;

namespace Experimential_Software.Class_Database
{
    //DAO
    public class FileFoctory
    {
        #region EPower
        public static bool SaveDataBaseEPower(List<ConnectableE> EPowers, string path)
        {
            List<DatabaseEPower> dataBaseEPowers = GetDatabaseInEPower(EPowers);
            try
            {
                FileStream fs = new FileStream(path, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(fs, dataBaseEPowers);
                fs.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public static List<DatabaseEPower> ReadDatabaseEPower(string path)
        {
            List<DatabaseEPower> dataBaseEPowers = new List<DatabaseEPower>();
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();

                object data = bf.Deserialize(fs);
                dataBaseEPowers = data as List<DatabaseEPower>;
                fs.Close();
                return dataBaseEPowers;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //MessageBox.Show("Count EPower = " + dataBaseEPowers.Count);
            return dataBaseEPowers;
        }

        public static List<DatabaseEPower> GetDatabaseInEPower(List<ConnectableE> EPowers)
        {
            List<DatabaseEPower> dataBaseEPowers = new List<DatabaseEPower>();

            foreach (ConnectableE ePower in EPowers)
            {
                DatabaseEPower databaseE = ePower.DatabaseE;
                dataBaseEPowers.Add(databaseE);
            }

            return dataBaseEPowers;
        }

        #endregion EPower

        #region Line_Connect

        public static bool SaveDataBaseLineConnect(List<LineConnect> lineConnectList, string path)
        {
            List<DatabaseLineConnect> dataLines = ProcessTransferDataLine(lineConnectList);
           // MessageBox.Show("Count = " + dataLines.Count);
            try
            {
                FileStream fs = new FileStream(path, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, dataLines);
                fs.Close();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false;
        }

        protected static List<DatabaseLineConnect> ProcessTransferDataLine(List<LineConnect> lineConnectList)
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


        //Open
        //*Note : Read must start EPower then LineConnect . In Order to ensure that EPower Ends exist
        public static List<DatabaseLineConnect> ReadDataAllLineConnect(string path)
        {
            List<DatabaseLineConnect> dataLines = new List<DatabaseLineConnect>();

            try
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();

                object lineList = bf.Deserialize(fs);
                dataLines = lineList as List<DatabaseLineConnect>;
                fs.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataLines;
        }

        #endregion Line_Connect
    }
}
