using Experimential_Software.BLL.BLL_SaveAndReadPowerSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experimential_Software.DAO.DAO_SaveAndReadPowerSystem
{
    public class DAONewFilePowerSystem
    {
        private static DAONewFilePowerSystem _instance;
        public static DAONewFilePowerSystem Instance
        {
            get { if (_instance == null) _instance = new DAONewFilePowerSystem(); return _instance; }
            private set {; }
        }

        private DAONewFilePowerSystem() {; }

        #region New_File;
        public virtual void ClearAllEPowerAndLineOnMain(frmCapstone frmCapstone)
        {
            //Clear Old EPower 
            frmCapstone.pnlMain.Controls.Clear();
            //Clear Old Line
            frmCapstone.pnlMain.CreateGraphics().Clear(frmCapstone.pnlMain.BackColor);
            //Clear List Old EPower
            frmCapstone.EPowers.Clear();

            //Clear Interface Mouse Move EPower
            frmCapstone.IEPowers.Clear();
            //Clear List Line
            frmCapstone.LineConnectList.Clear();
            //Set ZoomFactor = 1
            frmCapstone.pnlMain.ZoomFactor = 1;
        }

        #endregion New_File

       
    }
}
