using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ProjectZGL
{
	/// <summary>
	/// 简单的AI实现
	/// TODO 之后会封装成静态方法
	/// </summary>
	public class NaiveAiPlayer //: Player
	{
//		private CellGridComponent _cellGridComponent;
//		private System.Random _rnd;
//	
//		public NaiveAiPlayer()
//		{
//			_rnd = new System.Random();
//		}

//		public override void Play(CellGridComponent cellGridComponent)
//		{
//			cellGridComponent.CellGridState = new CellGridStateAiTurn(cellGridComponent);
//			_cellGridComponent = cellGridComponent;
//
//			StartCoroutine(Play());
//
//			//Coroutine is necessary to allow Unity to run updates on other objects (like UI).
//			//Implementing this with threads would require a lot of modifications in other classes, as Unity API is not thread safe.
//		}
//		private IEnumerator Play()
//		{
//			var myUnits = _cellGridComponent.Units.FindAll(u => u.PlayerNumber.Equals(PlayerNumber)).ToList();
//			foreach (var unit in myUnits.OrderByDescending(u => u.Cell.GetNeighbours(_cellGridComponent.Cells).FindAll(u.IsCellTraversable).Count))
//			{
//				var enemyUnits = _cellGridComponent.Units.Except(myUnits).ToList();
//				var unitsInRange = new List<Unit>();
//				foreach (var enemyUnit in enemyUnits)
//				{
//					if (unit.IsUnitAttackable(enemyUnit, unit.Cell))
//					{
//						unitsInRange.Add(enemyUnit);
//					}
//				}//Looking for enemies that are in attack range.
//				if (unitsInRange.Count != 0)
//				{
//					var index = _rnd.Next(0, unitsInRange.Count);
//					unit.DealDamage(unitsInRange[index]);
//					yield return new WaitForSeconds(0.5f);
//					continue;
//				}//If there is an enemy in range, attack it.
//
//				List<Cell> potentialDestinations = new List<Cell>();
//
//				foreach (var enemyUnit in enemyUnits)
//				{
//					potentialDestinations.AddRange(_cellGridComponent.Cells.FindAll(c => unit.IsCellMovableTo(c) && unit.IsUnitAttackable(enemyUnit, c)));
//				}//Making a list of cells that the unit can attack from.
//
//				var notInRange = potentialDestinations.FindAll(c => c.GetDistance(unit.Cell) > unit.MovementPoints);
//				potentialDestinations = potentialDestinations.Except(notInRange).ToList();
//
//				if (potentialDestinations.Count == 0 && notInRange.Count != 0)
//				{
//					potentialDestinations.Add(notInRange.ElementAt(_rnd.Next(0, notInRange.Count - 1)));
//				}
//
//				potentialDestinations = potentialDestinations.OrderBy(h => _rnd.Next()).ToList();
//				List<Cell> shortestPath = null;
//				foreach (var potentialDestination in potentialDestinations)
//				{
//					var path = unit.FindPath(_cellGridComponent.Cells, potentialDestination);
//					if ((shortestPath == null && path.Sum(h => h.MovementCost) > 0) || shortestPath != null && (path.Sum(h => h.MovementCost) < shortestPath.Sum(h => h.MovementCost) && path.Sum(h => h.MovementCost) > 0))
//						shortestPath = path;
//
//					var pathCost = path.Sum(h => h.MovementCost);
//					if (pathCost > 0 && pathCost <= unit.MovementPoints)
//					{
//						unit.Move(potentialDestination, path);
//						while (unit.isMoving)
//							yield return 0;
//						shortestPath = null;
//						break;
//					}
//					yield return 0;
//				}//If there is a path to any cell that the unit can attack from, move there.
//
//				if (shortestPath != null)
//				{
//					foreach (var potentialDestination in shortestPath.Intersect(unit.GetAvailableDestinations(_cellGridComponent.Cells)).OrderByDescending(h => h.GetDistance(unit.Cell)))
//					{
//						var path = unit.FindPath(_cellGridComponent.Cells, potentialDestination);
//						var pathCost = path.Sum(h => h.MovementCost);
//						if (pathCost > 0 && pathCost <= unit.MovementPoints)
//						{
//							unit.Move(potentialDestination, path);
//							while (unit.isMoving)
//								yield return 0;
//							break;
//						}
//						yield return 0;
//					}
//				}//If the path cost is greater than unit movement points, move as far as possible.
//
//				foreach (var enemyUnit in enemyUnits)
//				{
//					var enemyCell = enemyUnit.Cell;
//					if (unit.IsUnitAttackable(enemyUnit, unit.Cell))
//					{
//						unit.DealDamage(enemyUnit);
//						yield return new WaitForSeconds(0.5f);
//						break;
//					}
//				}//Look for enemies in range and attack.
//			}
//			_cellGridComponent.EndTurn();
//		}
	}

}