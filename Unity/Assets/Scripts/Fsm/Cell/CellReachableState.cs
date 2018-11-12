using GameFramework.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZGL
{
	/// <summary>
	/// 完结（毁坏）状态
	/// </summary>
	public class CellReachableState : FsmState<Cell>
	{

		protected override void OnInit(IFsm<Cell> fsm)
		{
			fsm.Owner.SetColor(new Color(1, 0.92f, 0.016f, 1));
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