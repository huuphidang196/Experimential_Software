using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experimential_Software.Class_Small
{
    [Serializable]
    public class DatabaseEPower
    {
        public ObjectType ObjectType { get; set; }

        public string ObjectName { get; set; }

        public int ObjectNumber { get; set; }

        public int NumberImage => (int)ObjectType;

        public int Width
        {
            get 
            {
                if (ObjectType == ObjectType.MF) return 40;
                if (ObjectType == ObjectType.Bus) return 100;
                if (ObjectType == ObjectType.MBA) return 40;
                if (ObjectType == ObjectType.LineEPower) return 16;
                if (ObjectType == ObjectType.Load) return 40;

                return 0;
            }
        }
        public int Height
        {
            get
            {
                if (ObjectType == ObjectType.MF) return 40;
                if (ObjectType == ObjectType.Bus) return 30;
                if (ObjectType == ObjectType.MBA) return 40;
                if (ObjectType == ObjectType.LineEPower) return 64;
                if (ObjectType == ObjectType.Load) return 40;

                return 0;
            }
        }

        public Point OldLocation { get; set; } 
    }
}
