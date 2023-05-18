
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experimential_Software.CustomControl
{
    public class PanelMainMouse
    {
        protected PanelMain pnlMainDrawn;
        protected frmCapstone _frmCapstone;

        public frmCapstone FrmCapstone { get => _frmCapstone; set => _frmCapstone = value; }

        public PanelMainMouse(PanelMain pnlMainDrawn)
        {
            this.pnlMainDrawn = pnlMainDrawn;
        }

        #region Line
        public virtual void ProcessMain_MouseCDown(List<LineConnect> lineConnectList, MouseEventArgs e)
        {
            //Click empty or have line correct

            foreach (LineConnect lineConnect in lineConnectList)
            {
                Point startLine = lineConnect.StartPoint;
                Point endLine = lineConnect.EndPoint;
                // kiểm tra vị trí click có nằm trên đường Line không
                if (!IsPointOnLine(e.Location, startLine, endLine))
                {
                    lineConnect.IsSelected = false;
                }
                else lineConnect.IsSelected = !lineConnect.IsSelected;
               
                this.AdjustmentColorSelected(lineConnect);
            }
        }

        protected virtual void AdjustmentColorSelected(LineConnect lineConnect)
        {
            Point startLine = lineConnect.StartPoint;
            Point endLine = lineConnect.EndPoint;

            // thay đổi màu của Pen thành màu đen => Line is selected before => not set null EPower
            if (!lineConnect.IsSelected)
            {
                pnlMainDrawn.CreateGraphics().DrawLine(Pens.Black, startLine, endLine);
                return;
            }

            // thay đổi màu của Pen thành màu đỏ =>  Line isn't selected before =>  set null EPower
            pnlMainDrawn.CreateGraphics().DrawLine(Pens.Red, startLine, endLine);
        }

        private bool IsPointOnLine(Point p, Point start, Point end)
        {
            double dis_AB = Math.Sqrt(Math.Pow((p.X - end.X), 2) + Math.Pow((p.Y - end.Y), 2));
            double dis_AC = Math.Sqrt(Math.Pow((p.X - start.X), 2) + Math.Pow((p.Y - start.Y), 2));
            double dis_BC = Math.Sqrt(Math.Pow((end.X - start.X), 2) + Math.Pow((end.Y - start.Y), 2));

            double distance = (dis_AB + dis_AC) - dis_BC; // if same Line -> distance = 0
            return Math.Abs(distance) < 5; // nếu khoảng cách nhỏ hơn 5 thì coi như nằm trên đường Line
        }


        //when press ConnectionE then False all Line
        public virtual void SetFalseSelectedOtherLine(LineConnect lineSelected, List<LineConnect> lineConnectList)
        {
            foreach (LineConnect lineConnect in lineConnectList)
            {
                if (lineConnect == lineSelected) continue;

                lineConnect.IsSelected = false;
                this.AdjustmentColorSelected(lineConnect);
            }
        }


        public virtual LineConnect FindLineConnectIsSelected(List<LineConnect> lineConnectList)
        {
            LineConnect lineSelected = lineConnectList.Find(x => x.IsSelected);

            return lineSelected;
        }

        public virtual LineConnect FindLineConnectEPower(List<LineConnect> lineConnectList, ConnectableE ePower)
        {
            foreach (LineConnect lineConnect in lineConnectList)
            {
                if (lineConnect.StartEPower != ePower && lineConnect.EndEPower != ePower) continue;

                return lineConnect;
            }
            return null;
        }


        #endregion Line
        /*
         * 
         *  public virtual LineConnect FindLineConnectIsSelected(List<LineConnect> lineConnectList)
                {
                    
                    foreach (LineConnect lineConnect in lineConnectList)
                    {
                        if (!lineConnect.IsSelected) continue;

                        return lineConnect;
                    }
                    return null;
                }
                public virtual void ProcessSetNumberObjetEPower(ConnectableE EPower_Instance)
                {
                    // Lấy danh sách tất cả các ConnectionE control có trong pnlMain
                    List<ConnectableE> EPowers = this.GetListEPowerOnMain();

                    ObjectType type_Instance = EPower_Instance.DatabaseE.ObjectType;
                    int count = (int)type_Instance * 100;

                    // Duyệt qua danh sách các ConnectionE control và thực hiện các xử lý cần thiết
                    foreach (ConnectableE ePower in EPowers)
                    {
                        // Code xử lý cho từng ConnectionE control
                        if (ePower.DatabaseE.ObjectType == type_Instance) count++;

                    }
                    // set Obj number = count current + 1;
                   EPower_Instance.DatabaseE.DataRecordE.ObjectNumber = count + 1;
                }

                public virtual void ProcessSetNumberEPowerAfterDelete(ConnectableE EPower_Deleted)
                {
                    // Lấy danh sách tất cả các ConnectionE control có trong pnlMain
                    List<ConnectableE> EPowers = this.GetListEPowerOnMain();

                    ObjectType type_Instance = EPower_Deleted.DatabaseE.ObjectType;
                    // Duyệt qua danh sách các ConnectionE control và thực hiện các xử lý cần thiết
                    foreach (ConnectableE ePower in EPowers)
                    {
                        // Code xử lý cho từng ConnectionE control
                        if (ePower.DatabaseE.ObjectType != type_Instance) continue;

                        int numberObj = ePower.DatabaseE.DataRecordE.ObjectNumber;
                        if (numberObj < EPower_Deleted.DatabaseE.DataRecordE.ObjectNumber) continue;

                        //Reduce number obj
                        ePower.DatabaseE.DataRecordE.ObjectNumber -= 1;
                        // //Set data show on EPower
                        ePower.SetDataLabelInfo();
                    }
                }

                protected virtual List<ConnectableE> GetListEPowerOnMain()
                {
                    if (this._frmCapstone != null) return this._frmCapstone.EPowers;

                    return this.pnlMainDrawn.Controls.OfType<ConnectableE>().ToList();
                }
        */
    }
}
