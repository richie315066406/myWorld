using GameFramework.Event;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace ProjectZGL
{
	public class ProcedureTurnChanging : ProcedureMain
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

        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
			base.OnLeave(procedureOwner, isShutdown);
        }

	    protected override void OnDestroy(ProcedureOwner procedureOwner)
	    {
		    base.OnDestroy(procedureOwner);
	    }

		protected override void OnCellClicked(object sender, GameEventArgs e)
		{
			throw new System.NotImplementedException();
		}

		protected override void OnCellDeselected(object sender, GameEventArgs e)
		{
			throw new System.NotImplementedException();
		}

		protected override void OnCellSelected(object sender, GameEventArgs e)
		{
			throw new System.NotImplementedException();
		}
	}
}
