﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.Class_Database;
using Experimential_Software.CustomControl;
using Experimential_Software.EPowerProcess;

namespace Experimential_Software.DAO.DAO_LoadData
{
    public class DAOUpdateLineAfterConnectBus
    {
        private static DAOUpdateLineAfterConnectBus _instance;

        public static DAOUpdateLineAfterConnectBus Instance
        {
            get { if (_instance == null) _instance = new DAOUpdateLineAfterConnectBus(); return _instance; }
           private set {; }
        }

        private DAOUpdateLineAfterConnectBus() { }

        public virtual void UpDateLineRecordAfterConnectBus(ConnectableE loadEPower)
        {
            //get BusConnect. Bus always connect by Phead
            ConnectableE busConnected = this.GetBusConnectWithLoad(loadEPower);

            //Get DTO Bus
            DTOBusEPower dtoBusEPower = busConnected.DatabaseE.DataRecordE.DTOBusEPower;

            //Set data bus inside Load
            DTOLoadEPower dtoLoadEPower = loadEPower.DatabaseE.DataRecordE.DTOLoadEPower;
            dtoLoadEPower.DTOBusConnected = dtoBusEPower;

        }

        protected virtual ConnectableE GetBusConnectWithLoad(ConnectableE loadEPower)
        {
            //Get Class ProcessEPowerMove => Get Function get Line
            ProcessEPowerMove processEPowerMove = loadEPower.EPowerProcessMouse.ProcessEPowerMove;
            //get Line Connect Bus with Load. Load only connect with Bus
            LineConnect lineConnectedBus = processEPowerMove.GetLineStageEPower(loadEPower)[0];

            if (lineConnectedBus == null) return null;

            //Start Coincode Load => End is Bus. Start Diffence Load => End is Bus
            ConnectableE busConnected = lineConnectedBus.StartEPower.DatabaseE.ObjectType == ObjectType.Load ? lineConnectedBus.EndEPower : lineConnectedBus.StartEPower;

            return busConnected;
        }
    }
}
