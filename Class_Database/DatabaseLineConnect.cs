using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software;

namespace Experimential_Software.Class_Database
{
    //DTO
    [Serializable]
    public class DatabaseLineConnect
    {
        public string NameStartEPower { get; set; }
        public string NameEndEPower { get; set; }

        // Beacuse line is child of pnlMain so Point coordinate pnlmain system 
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
    }
}
