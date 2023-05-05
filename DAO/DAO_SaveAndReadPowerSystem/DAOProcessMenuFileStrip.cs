using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experimential_Software.DAO.DAO_SaveAndReadPowerSystem
{
    public class DAOProcessMenuFileStrip
    {
        private static DAOProcessMenuFileStrip _instance;
        public static DAOProcessMenuFileStrip Instance
        {
            get { if (_instance == null) _instance = new DAOProcessMenuFileStrip(); return _instance; }
            private set {; }
        }

        private DAOProcessMenuFileStrip() {; }

        #region New_File;
        public void FunctionMnuFileNew_Click(frmCapstone frmCapstone)
        {
            //Question Before Open;
            this.ClearAllEPowerAndLineOnMain(frmCapstone);
        }

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
            //Set Count EPower = 0
            frmCapstone.CountElement = 0;
            //Set ZoomFactor = 1
            frmCapstone.pnlMain.ZoomFactor = 1;
        }

        #endregion New_File

        #region Open_File
        //openFile
        public void FunctionMnuFileOpen_Click(frmCapstone frmCapstone)
        {
            DAOReadFilePowerSystem.Instance.FunctionMnuFileOpen_Click(frmCapstone);
        }

        #endregion Open_File

        #region Save_File
        //save File
        public void FunctionMnuFileSave_Click(frmCapstone frmCapstone)
        {
            DAOSaveFilePowerSystem.Instance.FunctionMnuFileSave_Click(frmCapstone);
        }
        
        #endregion Save_File
    }
}
