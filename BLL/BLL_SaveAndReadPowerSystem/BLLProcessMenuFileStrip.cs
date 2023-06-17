using Experimential_Software.DAO.DAO_SaveAndReadPowerSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experimential_Software.BLL.BLL_SaveAndReadPowerSystem
{
    public class BLLProcessMenuFileStrip
    {

        private static BLLProcessMenuFileStrip _instance;

        public static BLLProcessMenuFileStrip Instance
        {
            get { if (_instance == null) _instance = new BLLProcessMenuFileStrip(); return BLLProcessMenuFileStrip._instance; }
            private set { _instance = value; }
        }

        private BLLProcessMenuFileStrip() { }
        #region New_File;
        public void FunctionMnuFileNew_Click(frmCapstone frmCapstone)
        {
            //Question Before Open;
            DAONewFilePowerSystem.Instance.ClearAllEPowerAndLineOnMain(frmCapstone);
        }

        #endregion New_File

        #region Open_File
        //openFile
        public void FunctionMnuFileOpen_Click(frmCapstone frmCapstone, string pathTreeView)
        {
            //not use tree view => null path
            BLLReadFilePowerSystem.Instance.FunctionMnuFileOpen_Click(frmCapstone, pathTreeView);
        }

        #endregion Open_File

        #region Save_File
        //save File
        public void FunctionMnuFileSave_Click(frmCapstone frmCapstone)
        {
            BLLSaveFilePowerSystem.Instance.FunctionMnuFileSave_Click(frmCapstone);
        }

        #endregion Save_File
    }
}
