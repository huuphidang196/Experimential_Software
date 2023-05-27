using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experimential_Software.DAO.DAOCapstone
{
    public class DAOProcessCapstone
    {
        private static DAOProcessCapstone _instance;
        public static DAOProcessCapstone Instance
        {
            get { if (_instance == null) _instance = new DAOProcessCapstone(); return _instance; }
            private set {; }
        }

        private DAOProcessCapstone() {; }

        public virtual Point CalculatePreLocationWhenInstance(double zoomFactor, Point dropLocation, List<ConnectableE> ListEPowers, PanelMain pnlMain)
        {
            if (zoomFactor == 1) return dropLocation;

            //Get One EPower standard, zoom = 1
            ConnectableE EPowerA = ListEPowers[0];

            Point pointCurrentA = EPowerA.Location;
            Point pointPreA = EPowerA.PreLocation;

            Point pointMouse_M = this.CalculatePosMouseWhenZoom(zoomFactor, pointCurrentA, pointPreA);
            Point pointPreB = this.CalculatePointPreB(zoomFactor, dropLocation, pointMouse_M);

            return pointPreB;
        }

        protected virtual Point CalculatePosMouseWhenZoom(double zoomFactor, Point pointCurrentA, Point pointPreA)
        {
            int xM = (int)(((double)pointCurrentA.X - pointPreA.X * zoomFactor) / (1 - zoomFactor));
            int yM = (int)(((double)pointCurrentA.Y - pointPreA.Y * zoomFactor) / (1 - zoomFactor));

            Point pointM = new Point(xM, yM);
            return pointM;
        }

        protected virtual Point CalculatePointPreB(double zoomFactor, Point dropLocation, Point pointMouse_M)
        {
            int xB = (int)(pointMouse_M.X + (dropLocation.X - pointMouse_M.X) / zoomFactor);
            int yB = (int)(pointMouse_M.Y + (dropLocation.Y - pointMouse_M.Y) / zoomFactor);

            Point pointPreB = new Point(xB, yB);
            return pointPreB;
        }


        #region Tree_View
        public virtual void GetNodeFolderChildInFolderOrigin(string folderPath, TreeNode parentNode)
        {
            string[] directories = Directory.GetDirectories(folderPath); // lấy danh sách các thư mục con
            if (directories.Length == 0)
            {
                this.AddNodeDatabaseOnTreeView(folderPath, parentNode);
                return;
            }

            foreach (string directory in directories)
            {
                TreeNode node = new TreeNode(Path.GetFileName(directory)); // tạo một nút mới với tên là tên thư mục
                parentNode.Nodes.Add(node); // thêm nút con vào nút cha
                node.ImageIndex = 3;
                node.SelectedImageIndex = 3;

                this.GetNodeFolderChildInFolderOrigin(directory, node); // load thư mục con của thư mục hiện tại
            }
        }

        protected void AddNodeDatabaseOnTreeView(string folderPath, TreeNode parentNode)
        {
            // Tạo đối tượng DirectoryInfo để truy cập vào thư mục
            DirectoryInfo folder = new DirectoryInfo(folderPath);

            // Lấy danh sách các tệp tin txt
            FileInfo[] files = folder.GetFiles("*.txt");

            // Duyệt danh sách tệp tin và thêm chúng vào TreeView
            foreach (FileInfo file in files)
            {
                // Tạo một TreeNode mới với tên là tên tệp tin
                TreeNode node = new TreeNode(file.Name);

                parentNode.Nodes.Add(node); // thêm file Database con vào nút cha
                node.ImageIndex = 4;
                node.SelectedImageIndex = 4;
            }
        }
        #endregion Tree_View
    }
}
