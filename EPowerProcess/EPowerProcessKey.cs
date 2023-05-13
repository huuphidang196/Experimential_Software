using Experimential_Software.CustomControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Experimential_Software.DAO.DAO_ProcessDelete.DAO_DeleteLineConnect;
using System.Drawing;

namespace Experimential_Software.EPowerProcess
{
    public class EPowerProcessKey
    {
        protected ConnectableE _ePowerInstance;

        protected List<ConnectableE> ePowers;

        protected List<LineConnect> lineConnectList;

        public EPowerProcessKey(ConnectableE ePower)
        {
            this._ePowerInstance = ePower;
            this.ePowers = ePower.FormCapstone.EPowers;
            // this.lineConnectList = ePower.FormCapstone.LineConnectList;
            //use List LineConneted with this Epower instead of List of Main => up speed Find
            this.lineConnectList = ePower.ListBranch_Drawn;
        }


        #region Key_Down
        public virtual void EPowerInstance_KeyDown(KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;

            this.ProcessEPowerDeleted(e);
            //remove observer 
            this._ePowerInstance.FormCapstone.RemoveIMouseOnEndsAfterDelete(this._ePowerInstance);
        }
        #endregion Key_Down

        protected virtual void ProcessEPowerDeleted(KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;

            //Remove All Line Connect with EPower
            for (int i = 0; i < this.lineConnectList.Count; i++)
            {
                LineConnect lineConnect = this.lineConnectList[i];

                this._ePowerInstance.EPowerLineTemp.ClearTwoOldLineWhenMove(lineConnect);

                this.ProcessDeletePerLine(lineConnect);
                this._ePowerInstance.FormCapstone.RemoveLine(lineConnect);     
            }

            //remove this out EPowers
            this._ePowerInstance.FormCapstone.RemoveEPower(this._ePowerInstance);

            this._ePowerInstance.LblInfoE.Dispose();
            this._ePowerInstance.Dispose();

            this._ePowerInstance.FormCapstone.DrawAllLineOnPanel();
        }

        protected virtual void ProcessDeletePerLine(LineConnect lineConnect)
        {
            //Determine ConnectionE connect with line => set iscontainPHead or Tail
            this.SetIsContainEPower(lineConnect);
            //Remove Line Connect with ePower is removed outside List LineConenect of EPower Affect 
            this.RemoveLineConnectWithERemoveOutSideEAffect(lineConnect);
        }
        #region Set_Contain_Phead_PTail_PIntern

        protected virtual void SetIsContainEPower(LineConnect lineRemoved)
        {
            //Line alwway 2 Connect 
            ConnectableE ortherEPower = lineRemoved.StartEPower != this._ePowerInstance ? lineRemoved.StartEPower : lineRemoved.EndEPower;
            int numOrther = lineRemoved.StartEPower != this._ePowerInstance ? 0 : 1;
            if (this.IsPointOfHead(lineRemoved, numOrther)) ortherEPower.IsContainPhead = false;
            else
            {
                if (ortherEPower.DatabaseE.ObjectType != ObjectType.MBA3P)
                {
                    ortherEPower.IsContainPtail = false;
                    return;
                }

                if (this.IsPointOfIntern(lineRemoved, numOrther)) ortherEPower.IsContainPIntern = false;
                else ortherEPower.IsContainPtail = false;
            } 
        }

        protected virtual bool IsPointOfHead(LineConnect lineSelected, int numberEnds)
        {
            PointOfEnds internPointEPower = numberEnds == 0 ? lineSelected.StartPointEPower : lineSelected.EndPointEPower;
            bool isContainHead = internPointEPower == PointOfEnds.PointOfHead ? true : false;

            return isContainHead;
        }

        //Only apply for MBA3P 
        protected virtual bool IsPointOfIntern(LineConnect lineSelected, int numberEnds)
        {
            PointOfEnds internPointEPower = numberEnds == 0 ? lineSelected.StartPointEPower : lineSelected.EndPointEPower;
            bool isContainIntern = internPointEPower == PointOfEnds.PointOfIntern ? true : false;

            return isContainIntern;
        }

        #endregion Set_Contain_Phead_PTail_PIntern

        protected virtual void RemoveLineConnectWithERemoveOutSideEAffect(LineConnect lineRemoved)
        {
            ConnectableE ortherEPower = lineRemoved.StartEPower != this._ePowerInstance ? lineRemoved.StartEPower : lineRemoved.EndEPower;

            //Remove LinnConnected is removed from List In StartE and End
            //Update Data EPower When EPower Connected is removed
            //Remove before update
            ortherEPower.RemoveLineConnectedToList(lineRemoved);
            if (lineRemoved.StartEPower != this._ePowerInstance) lineRemoved.StartEPower = null;
            else lineRemoved.EndEPower = null;
            ortherEPower.UpdateDataRecordEPowerWhenConnectOrRemove(true);

        }
       

    }
}








/*
        foreach (LineConnect lineConnect in this.lineConnectList)
        {
            this._ePowerInstance.EPowerLineTemp.ClearTwoOldLineWhenMove(lineConnect);

            DAOProcessDeleteLineConnect.Instance.ProcessDeleteLineConnect(lineConnect);

            this._ePowerInstance.FormCapstone.RemoveLine(lineConnect);

            //Remove LineConneted outside this ListLine EPower and other EPower connected with this
            this._ePowerInstance.RemoveLineConnectedToList(lineConnect);
        }


protected virtual List<LineConnect> GetLineStageEPower(ConnectableE btnEPower)
{
    LineConnect lineConPre = null;
    List<LineConnect> lineListConnected = new List<LineConnect>();// Because Bus have many Line

    foreach (LineConnect lineConnect in this.lineConnectList)
    {
        ConnectableE ePower = this.CheckEndsEPowerOfLine(lineConnect, btnEPower);
        if (ePower == null) continue;

        if (lineConnect == lineConPre) continue;

        lineConPre = lineConnect;
        lineListConnected.Add(lineConnect);
    }

    return lineListConnected;
}

   
        protected virtual ConnectableE CheckEndsEPowerOfLine(LineConnect lineConnect, ConnectableE btnEPower)
        {
            bool isStartEPower = lineConnect.CheckEPowerByName(btnEPower, lineConnect.StartEPower);
            if (isStartEPower) return lineConnect.StartEPower;

            bool isEndEPower = lineConnect.CheckEPowerByName(btnEPower, lineConnect.EndEPower);
            if (isEndEPower) return lineConnect.EndEPower;

            return null;
        }

        */
