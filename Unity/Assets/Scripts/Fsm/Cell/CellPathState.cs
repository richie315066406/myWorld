using GameFramework.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZGL
{
	/// <summary>
	/// 友好状态
	/// </summary>
	public class CellPathState : FsmState<Cell>
	{

		protected override void OnInit(IFsm<Cell> fsm)
		{
			fsm.Owner.SetColor(new Color(0, 1, 0, 1));
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