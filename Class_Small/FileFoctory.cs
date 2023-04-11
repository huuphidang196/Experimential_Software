using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Experimential_Software.Class_Small;

namespace Experimential_Software
{
    public class FileFoctory
    {
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
            return null;
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
    }
}
