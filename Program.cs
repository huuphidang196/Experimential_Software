using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experimential_Software
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmCapstone());
            //Application.Run(new frmDataBus());
            //Application.Run(new frmDataLoad());
            //Application.Run(new frmDataBranch());
            //Application.Run(new frmDataGenerator());
            //Application.Run(new frmDataMBA2());
            //Application.Run(new frmSystemIsoval());
            // Application.Run(new frmDataMBA3());
            // Application.Run(new frmDrawnCurve());
            //Application.Run(new frmPrintDataBase());
        }
    }
}
