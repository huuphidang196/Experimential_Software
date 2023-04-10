using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experimential_Software.Class_Small
{
    [Serializable]
    public class DatabaseEPower
    {
        public ObjectType ObjectType { get; set; }

        public int ObjectNumber { get; set; }

        public int NumberImage => (int)ObjectType;

        public int Width { get; set; }
        public int Height { get; set; }
      
    }
}
