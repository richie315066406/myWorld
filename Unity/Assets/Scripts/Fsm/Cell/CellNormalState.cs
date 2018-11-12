using GameFramework.Event;
using GameFramework.Fsm;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ProjectZGL
{

	/// <summary>
	/// 常规状态
	/// </summary>
	public class CellNormalState : FsmState<Cell>
	{
		private bool m_IsClicked = false;

		protected override void OnInit(IFsm<Cell> fsm)
		{
			//正常颜色
			fsm.Owner.SetColor(new Color(1, 1, 1, 0));

			GameEntry.Event.Subscribe(CellClickedEventArgs.EventId,OnCellClicked);
		}

		protected override void OnUpdate(IFsm<Cell> fsm, float elapseSeconds, float realElapseSeconds)
		{

		}
		protected override void OnLeave(IFsm<Cell> fsm, bool isShutdown)
		{
			GameEntry.Event.Unsubscribe(CellClickedEventArgs.EventId, OnCellClicked);
		}

		protected override void OnDestroy(IFsm<Cell> fsm)
		{
			base.OnDestroy(fsm);
		}

		private void OnCellClicked(object sender, GameEventArgs e)
		{
//			ChangeState<CellClickedEventArgs>(fsm);
			Log.Info("Cell is Clicked");
		}
	}
}