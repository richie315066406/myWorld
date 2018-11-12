using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ProjectZGL
{
	/// <summary>
	/// 自定义单位生成器
	/// </summary>
	public class CustomUnitGenerator : MonoBehaviour, IUnitGenerator
	{
		public Transform UnitsParent;
		public Transform CellsParent;

//		/// <summary>
//		/// Returns units that are already children of UnitsParent object.
//		/// </summary>
		public List<Unit> SpawnUnits(List<Cell> cells)
		{
//			List<Unit> ret = new List<Unit>();
//			for (int i = 0; i < UnitsParent.childCount; i++)
//			{
//				var unit = UnitsParent.GetChild(i).GetComponent<Unit>();
//				if (unit != null)
//				{
//					var cell = cells.OrderBy(h => Math.Abs((h.transform.position - unit.transform.position).magnitude)).First();
//					if (!cell.CellData.IsTaken)
//					{
//						cell.CellData.IsTaken = true;
//						unit.Cell = cell;
//						unit.transform.position = cell.transform.position;
//						unit.Initialize();
//						ret.Add(unit);
//					}//Unit gets snapped to the nearest cell
//					else
//					{
//						Destroy(unit.gameObject);
//					}//If the nearest cell is taken, the unit gets destroyed.
//				}
//				else
//				{
//					Debug.LogError("Invalid object in Units Parent game object");
//				}
//
//			}
//			return ret;
			return null;
		}
//
//		/// <summary>
//		/// Snaps unit objects to the nearest cell.
//		/// </summary>
//		public void SnapToGrid()
//		{
//			List<Transform> cells = new List<Transform>();
//
//			foreach (Transform cell in CellsParent)
//			{
//				cells.Add(cell);
//			}
//
//			foreach (Transform unit in UnitsParent)
//			{
//				var closestCell = cells.OrderBy(h => Math.Abs((h.transform.position - unit.transform.position).magnitude)).First();
//				if (!closestCell.GetComponent<Cell>().CellData.IsTaken)
//				{
//					Vector3 offset = new Vector3(0, closestCell.GetComponent<Cell>().GetCellDimensions().y, 0);
//					unit.localPosition = closestCell.transform.localPosition + offset;
//				}//Unit gets snapped to the nearest cell
//			}
//		}
	}



}
