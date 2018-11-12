using GameFramework.Fsm;
using UnityEngine;

namespace ProjectZGL
{
	/// <summary>
	/// 选中状态
	/// </summary>
	public class CellHighlightedState : FsmState<Cell>
	{
		protected override void OnInit(IFsm<Cell> fsm)
		{
			fsm.Owner.SetColor(new Color(0.5f, 0.5f, 0.5f, 0.25f));
		}

		protected override void OnUpdate(IFsm<Cell> fsm, float elapseSeconds, float realElapseSeconds)
		{

		}
		protected override void OnLeave(IFsm<Cell> fsm, bool isShutdown)
		{
		}

		protected override void OnDestroy(IFsm<Cell> fsm)
		{
			base.OnDestroy(fsm);
		}
	}
}