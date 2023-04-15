
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experimential_Software.Class_Database
{
    [Serializable]
    public class DatabaseEPower
    {
        public ObjectType ObjectType { get; set; }

        public string ObjectName { get; set; }

        public int ObjectNumber { get; set; }

        public bool IsContainPhead { get; set; }

        public bool IsContainPtail { get; set; }

        public ContainPreEpower ContainPreEpower { get; set; }

        public int NumberImage => (int)ObjectType;

        public int Width
        {
            get
            {
                if (ObjectType == ObjectType.MF) return 40;
                if (ObjectType == ObjectType.Bus) return 100;
                if (ObjectType == ObjectType.MBA) return 40;
                if (ObjectType == ObjectType.LineEPower) return 20;
                if (ObjectType == ObjectType.Load) return 40;

                return 0;
            }
        }
        public int Height
        {
            get
            {
                if (ObjectType == ObjectType.MF) return 40;
                if (ObjectType == ObjectType.Bus) return 25;
                if (ObjectType == ObjectType.MBA) return 40;
                if (ObjectType == ObjectType.LineEPower) return 60;
                if (ObjectType == ObjectType.Load) return 40;

                return 0;
            }
        }

        public Point OldLocation { get; set; }


    }
}
