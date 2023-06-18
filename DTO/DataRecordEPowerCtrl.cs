﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experimential_Software.DTO
{
    [Serializable]
    public class DataRecordEPowerCtrl
    {
        public DTOBusEPower DTOBusEPower { get; set; }

        public DTOGeneEPower DTOGeneEPower { get; set; }

        public DTOTransTwoEPower DTOTransTwoEPower { get; set; }

        public DTOTransThreeEPower DTOTransThreeEPower { get; set; }

        public DTOLineEPower DTOLineEPower { get; set; }

        public DTOLoadEPower DTOLoadEPower { get; set; }

    }
}