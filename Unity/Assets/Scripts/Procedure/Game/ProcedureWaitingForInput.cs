using GameFramework.Event;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace ProjectZGL
{
	public class ProcedureWaitingForInput : ProcedureMain
    {
        public override bool UseNativeDialog
        {
            get
            {
                return false;
            }
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
			Log.Info("???");
            base.OnEnter(procedureOwner);

        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
			base.OnLeave(procedureOwner, isShutdown);
        }

	    protected override void OnDestroy(ProcedureOwner procedureOwner)
	    {
		    base.OnDestroy(procedureOwner);
	    }

		//	    public override void OnUnitClicked(Unit unit)
		//	    {
		//		    if (unit.PlayerNumber.Equals(CellGridComponent.CurrentPlayerNumber))
		//			    CellGridComponent.CellGridState = new CellGridStateUnitSelected(CellGridComponent, unit);
		//	    }
	}
}
