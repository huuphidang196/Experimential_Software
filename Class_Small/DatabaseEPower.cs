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
        public ObjectType objectType { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
