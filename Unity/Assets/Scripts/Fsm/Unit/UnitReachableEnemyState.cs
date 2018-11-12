using GameFramework.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZGL
{
	/// <summary>
	/// 可及敌人状态
	/// </summary>
	public class UnitReachableEnemyState : FsmState<Unit>
	{

		protected override void OnInit(IFsm<Unit> fsm)
		{
//			_unit.MarkAsReachableEnemy();
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