using GameFramework.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZGL
{
	/// <summary>
	/// 友好状态
	/// </summary>
	public class UnitFriendlyState : FsmState<Unit>
	{

		protected override void OnInit(IFsm<Unit> fsm)
		{
//			_unit.MarkAsFriendly();
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