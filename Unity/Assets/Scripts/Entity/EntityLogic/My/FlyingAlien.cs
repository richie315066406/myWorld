using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZGL
{
	public class FlyingCaracter : Character
	{
		protected override void OnInit(object userdata)
		{
			base.OnInit(userdata);
//			(cell as MyOtherHexagon).IsSkyTaken = true;
		}

		public void Initialize()
		{
//			base.Initialize();
//			(Cell as MyOtherHexagon).IsSkyTaken = true;
		}

		public override bool IsCellTraversable(Cell cell)
		{
//			return !(cell as MyOtherHexagon).IsSkyTaken;//Allows unit to move through any cell that is not occupied by a flying unit.
			return false;
		}

		public override void Move(Cell destinationCell, List<Cell> path)
		{
//			(Cell as MyOtherHexagon).IsSkyTaken = false;
//			(destinationCell as MyOtherHexagon).IsSkyTaken = true;
			base.Move(destinationCell, path);      
		}

		protected override IEnumerator MovementAnimation(List<Cell> path)
		{
			GetComponent<SpriteRenderer>().sortingOrder = 6;
			yield return StartCoroutine(base.MovementAnimation(path));
			GetComponent<SpriteRenderer>().sortingOrder = 3;
		}

		protected override void OnDestroyed()
		{
//			(Cell as MyOtherHexagon).IsSkyTaken = false;
			base.OnDestroyed();
		}
	}
}