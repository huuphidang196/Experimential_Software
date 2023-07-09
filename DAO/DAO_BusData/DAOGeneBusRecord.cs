using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experimential_Software.DTO;
using System.Windows.Forms;
using Experimential_Software.CustomControl;

namespace Experimential_Software.DAO.DAO_BusData
{
    public class DAOGeneBusRecord
    {
        private static DAOGeneBusRecord _instance;

        public static DAOGeneBusRecord Instance
        {
            get { if (_instance == null) _instance = new DAOGeneBusRecord(); return DAOGeneBusRecord._instance; }
            private set { DAOGeneBusRecord._instance = value; }
        }

        private DAOGeneBusRecord() { }

        public virtual DTOBusEPower GenerateDTOBusDefault(int ExistOrderBus)
        {
            DTOBusEPower dtoBusE = new DTOBusEPower();

            //Basic Data
            dtoBusE.ObjectName = "";

            int numberObjectType = (int)ObjectType.Bus * 100;
            dtoBusE.ObjectNumber = (ExistOrderBus < 100) ? numberObjectType + 1 : ExistOrderBus + 1;

            dtoBusE.TypeCodeBus = TypeCodeBus.Non_Gen_Bus;
            dtoBusE.BasekV = 0;
            //dtoBusE.KChangerTap = 1;
            dtoBusE.Voltage_pu = 1;
            dtoBusE.Angle_rad = 0;

            //limitData
            dtoBusE.Normal_Vmax_pu = 1.1;
            dtoBusE.Normal_Vmin_pu = 0.9;

            dtoBusE.Emer_Vmax_pu = 1.1;
            dtoBusE.Emer_Vmin_pu = 0.9;

            return dtoBusE;
        }


        public virtual void AddEPowerOnList(ObjectType objectType, List<LineConnect> listLineDrawn)
        {
            List<ConnectableE> listEPowersConn = new List<ConnectableE>();
            foreach (LineConnect lineBranch in listLineDrawn)
            {
                if (lineBranch.StartEPower.DatabaseE.ObjectType == objectType) listEPowersConn.Add(lineBranch.StartEPower);
                else if (lineBranch.EndEPower.DatabaseE.ObjectType == objectType) listEPowersConn.Add(lineBranch.EndEPower);
            }

            if (listEPowersConn.Count == 0) return;

            foreach (ConnectableE item in listEPowersConn)
            {
                item.UpdateDataRecordEPowerWhenConnectOrRemove(false);
            }
        }

        #region SetData_OKCLick
        public virtual void SetObjectRecordInDataBase(frmDataBus frmDataBus, DTOBusEPower _dtoBusRecord)
        {
            //Update database into DTO

            //------------------------------------------------------------------------------------------
            //**BasicData Zone**
            //------------------------------------------------------------------------------------------

            _dtoBusRecord.ObjectNumber = int.Parse(frmDataBus.txtBusNumber.Text);

            //txt BusName => Busname
            _dtoBusRecord.ObjectName = frmDataBus.txtBusName.Text;

            //cbo TypeCodeBus -> typeCodebus DTO
            string enumTypeBus = frmDataBus.cboTypeBus.SelectedItem.ToString().Split('-')[1];

            _dtoBusRecord.TypeCodeBus = (TypeCodeBus)Enum.Parse(typeof(TypeCodeBus), enumTypeBus);

            //txtBaseKV => 
            _dtoBusRecord.BasekV = double.Parse(frmDataBus.txtBasekV.Text);

            //txtVoltage
            _dtoBusRecord.Voltage_pu = double.Parse(frmDataBus.txtVoltageBus.Text);

            //txtAngle
            _dtoBusRecord.Angle_rad = double.Parse(frmDataBus.txtAngleBus.Text);

            ////////////////////////////////////////////////////////////////////////////////////////

            //------------------------------------------------------------------------------------------
            //**LimitDta Zone**
            //------------------------------------------------------------------------------------------

            _dtoBusRecord.Normal_Vmax_pu = double.Parse(frmDataBus.txtNorVmax.Text);
            _dtoBusRecord.Emer_Vmax_pu = double.Parse(frmDataBus.txtEmerVmax.Text);

            _dtoBusRecord.Normal_Vmin_pu = double.Parse(frmDataBus.txtNorVmin.Text);
            _dtoBusRecord.Emer_Vmin_pu = double.Parse(frmDataBus.txtEmerVmin.Text);

            //Set Datarecord Bus 
            //   frmDataBus._busEFixedData.DatabaseE.DataRecordE.DTOBusEPower = this._dtoBusRecord;


        }
        #endregion  SetData_OKCLick
    }
}
