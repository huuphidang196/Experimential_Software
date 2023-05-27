using Experimential_Software.DAO.DAOCapstone;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experimential_Software.DAO.DAO_Curve.DAO_GeneratePath
{
    public class DAOGeneratePathFolder
    {
        private static DAOGeneratePathFolder _instance;
        public static DAOGeneratePathFolder Instance
        {
            get { if (_instance == null) _instance = new DAOGeneratePathFolder(); return _instance; }
            private set { }
        }

        private DAOGeneratePathFolder() { }

        //Path Sound
        public virtual string CreatFolderLibrarySound()
        {
            // Initialize SoundPlayer
            string pathLibrary = this.GetPathLibrary();
            // Kết hợp đường dẫn của thư mục cha và tên thư mục con
            string SoundName = "LibrarySound/Sound_Completed.wav";
            string fullPathSound = this.GetPathChildFolder(pathLibrary, SoundName);

            return fullPathSound;
        }

        //Path  Lib Image
        public virtual string CreatFolderLibraryImageDrawnCurve()
        {
            // Initialize SoundPlayer
            string pathLibrary = this.GetPathLibrary();
            string nameFolder_Image = "Image_Curve_Print";
            //Path of Folder Image
            string pathLibImageCur = this.GetPathChildFolder(pathLibrary, nameFolder_Image);

            if (!Directory.Exists(pathLibImageCur)) Directory.CreateDirectory(pathLibImageCur);

            return pathLibImageCur;
        }

     
        //Path treeView
        public virtual string CreatFolderSave(string appDirectory)
        {
            string pathLibrary = this.GetPathLibrary();

            // Kiểm tra xem thư mục con đã tồn tại chưa
            if (!Directory.Exists(pathLibrary)) Directory.CreateDirectory(pathLibrary);

            string treeFolderName = "TreeDataSaved";
            string fullPathTree = this.GetPathChildFolder(pathLibrary, treeFolderName);

            // Kiểm tra xem thư mục con đã tồn tại chưa
            if (Directory.Exists(fullPathTree)) return fullPathTree;
            // Tạo thư mục con
            Directory.CreateDirectory(fullPathTree);
            return fullPathTree;
        }


        //Combine Path
        public virtual string GetPathChildFolder(string appDirectory, string childFolderName)
        {
            //Creat Parent Folder
            string parentDirectory = appDirectory;
            string subDirectory = childFolderName;

            // Kết hợp đường dẫn của thư mục cha và tên thư mục con
            string fullPath = Path.Combine(parentDirectory, subDirectory);

            return fullPath;
        }

        //GetPath Lib
        public virtual string GetPathLibrary()
        {
            // Initialize SoundPlayer
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // Kết hợp đường dẫn của thư mục cha và tên thư mục con
            string LibraryName = "Library";
            string fullPathLibrary = this.GetPathChildFolder(appDirectory, LibraryName);

            return fullPathLibrary;
        }

    }
}
