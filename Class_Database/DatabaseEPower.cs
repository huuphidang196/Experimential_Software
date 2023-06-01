
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experimential_Software.Class_Database
{
    //DTO
    [Serializable]
    public class DatabaseEPower
    {
        public double ZoomFactor { get; set; }

        public ObjectType ObjectType { get; set; }

        public ObjectOrientation ObjectOri { get; set; }

        public bool IsContainPhead { get; set; }

        public bool IsContainInterm { get; set; }

        public bool IsContainPtail { get; set; }

        public ContainPreEpower ContainPreEpower { get; set; }

        public int NumberImage => (int)this.ObjectType;

        public int Width
        {
            get
            {
                if (ObjectType == ObjectType.Bus)
                {
                    if (this.ObjectOri == ObjectOrientation.Horizontal) return 90;
                    return 15;
                }

                if (ObjectType == ObjectType.MF) return 40;
                if (ObjectType == ObjectType.MBA2P) return 40;
                if (ObjectType == ObjectType.MBA3P) return 40;

                if (ObjectType == ObjectType.LineEPower)
                {
                    if (this.ObjectOri == ObjectOrientation.Horizontal) return 60;
                    return 20;
                }

                if (ObjectType == ObjectType.Load) return 40;

                return 0;
            }
        }
        public int Height
        {
            get
            {
                if (ObjectType == ObjectType.Bus)
                {
                    if (this.ObjectOri == ObjectOrientation.Horizontal) return 15;
                    return 90;
                }
                if (ObjectType == ObjectType.MF) return 40;
                if (ObjectType == ObjectType.MBA2P) return 40;
                if (ObjectType == ObjectType.MBA3P) return 40;

                if (ObjectType == ObjectType.LineEPower)
                {
                    if (this.ObjectOri == ObjectOrientation.Horizontal) return 20;
                    return 60;
                }

                if (ObjectType == ObjectType.Load) return 40;

                return 0;
            }
        }

        public Point OldLocation_Save { get; set; }

        public DataRecordEPowerCtrl DataRecordE { get; set; }
    }
}























/*
 *   public DataRecordEPowerCtrl DataRecordE
        {
            get
            {
                if (this.ObjectType == ObjectType.Bus) return (DTOBusEPower)DataRecordE;

                if (this.ObjectType == ObjectType.MF) return (DTOGeneEPower)DataRecordE;

                if (this.ObjectType == ObjectType.MBA) return (DTOTransTwoEPower)DataRecordE;

                if (this.ObjectType == ObjectType.LineEPower) return (DTOLineEPower)DataRecordE;

                if (this.ObjectType == ObjectType.Load) return (DTOLoadEPower)DataRecordE;

                return null;
            }

            set
            {
                if (this.ObjectType == ObjectType.Bus) DataRecordE = (DTOBusEPower)value;

                if (this.ObjectType == ObjectType.MF) DataRecordE = (DTOGeneEPower)value;

                if (this.ObjectType == ObjectType.MBA) DataRecordE = (DTOTransTwoEPower)value;

                if (this.ObjectType == ObjectType.LineEPower) DataRecordE = (DTOLineEPower)value;

                if (this.ObjectType == ObjectType.Load) DataRecordE = (DTOLoadEPower)value;
            }
        }
 */