﻿using System;
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


        //Get Path
        public virtual string GetPathChildFolder(string appDirectory, string childFolderName)
        {
            //Creat Parent Folder
            string parentDirectory = appDirectory;
            string subDirectory = childFolderName;

            // Kết hợp đường dẫn của thư mục cha và tên thư mục con
            string fullPath = Path.Combine(parentDirectory, subDirectory);

            return fullPath;
        }
    }
}
