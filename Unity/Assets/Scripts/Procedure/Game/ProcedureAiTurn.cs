using GameFramework.Event;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace ProjectZGL
{
	public class ProcedureAiTurn : ProcedureMain
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
            base.OnEnter(procedureOwner);

			//TODO　获取数据并将所有Cell置于正常状态
	        Cell[] cells = (Cell[])GameEntry.Entity.GetEntityGroup("Cell").GetAllEntities();
	        foreach (var cell in cells)
	        {
//		        cell.UnMark();
	        }
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
			base.OnLeave(procedureOwner, isShutdown);
        }

	    protected override void OnDestroy(ProcedureOwner procedureOwner)
	    {
		    base.OnDestroy(procedureOwner);
	    }

	}
}
