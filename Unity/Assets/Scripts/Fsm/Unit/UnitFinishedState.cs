using GameFramework.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZGL
{
	/// <summary>
	/// 完结（毁坏）状态
	/// </summary>
	public class UnitFinishedState : FsmState<Unit>
	{

		protected override void OnInit(IFsm<Unit> fsm)
		{

		}

		protected override void OnUpdate(IFsm<Unit> fsm, float elapseSeconds, float realElapseSeconds)
		{

		}
		protected override void OnLeave(IFsm<Unit> fsm, bool isShutdown)
		{
		}

		protected override void OnDestroy(IFsm<Unit> fsm)
		{
			base.OnDestroy(fsm);
		}
	}
}