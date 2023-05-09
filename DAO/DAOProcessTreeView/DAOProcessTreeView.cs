using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experimential_Software.DAO.DAOProcessTreeView
{
    public class DAOProcessTreeView
    {
        private static DAOProcessTreeView _instance;
        public static DAOProcessTreeView Instance
        {
            get { if (_instance == null) _instance = new DAOProcessTreeView(); return _instance; }
            private set {; }
        }

        private DAOProcessTreeView() {; }

        public virtual string GetPathOpenFileOnTreeView(string pathOri, TreeNode selectedNode)
        {
            int posSeperate = pathOri.LastIndexOf('/');
            string nameNodeOri = pathOri.Substring(0, posSeperate + 1);

            string pathFile = Path.Combine(nameNodeOri, this.ProcessGetPathFileDatabase(selectedNode));

            return pathFile;
        }
        protected virtual string ProcessGetPathFileDatabase(TreeNode selectedNode)
        {
            if (selectedNode.Parent == null) return selectedNode.Text;

            return this.ProcessGetPathFileDatabase(selectedNode.Parent) + "/" + selectedNode.Text;
        }
    }
}
