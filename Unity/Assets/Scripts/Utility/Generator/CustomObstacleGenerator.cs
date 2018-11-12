using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ProjectZGL
{

	/// <summary>
	/// 自定义障碍生成器
	/// </summary>
	public class CustomObstacleGenerator : MonoBehaviour
	{
		public Transform ObstaclesParent;
//		public CellGridComponent CellGridComponent;

		public void Start()
		{
//			StartCoroutine(SpawnObstacles());
		}

		/// <summary>
		/// Method sets position on obstacle objects and 
		/// sets isTaken field on cells that the obstacles are occupying
		/// </summary>
//		public IEnumerator SpawnObstacles()
//		{
//			while (CellGridComponent.Cells == null)
//			{
//				yield return 0;
//			}
//
//			var cells = CellGridComponent.Cells;
//
//			for (int i = 0; i < ObstaclesParent.childCount; i++)
//			{
//				var obstacle = ObstaclesParent.GetChild(i);
//
//				var cell = cells.OrderBy(h => Math.Abs((h.transform.position - obstacle.transform.position).magnitude)).First();
//				if (!cell.CellData.IsTaken)
//				{
//					cell.CellData.IsTaken = true;
//					var bounds = getBounds(obstacle);
//					Vector3 offset = new Vector3(0, bounds.y, 0);
//					obstacle.localPosition = cell.transform.localPosition + offset;
//				}
//				else
//				{
//					Destroy(obstacle.gameObject);
//				}
//			}
//		}

		/// <summary>
		/// Method snaps obstacle objects to the nearest cell.
		/// </summary>
//		public void SnapToGrid()
//		{
//			List<Transform> cells = new List<Transform>();
//
//			foreach (Transform cell in CellGridComponent.transform)
//			{
//				cells.Add(cell);
//			}
//
//			foreach (Transform obstacle in ObstaclesParent)
//			{
//				var bounds = getBounds(obstacle);
//				var closestCell = cells.OrderBy(h => Math.Abs((h.transform.position - obstacle.transform.position).magnitude)).First();
////				if (!closestCell.GetComponent<Cell>().IsTaken)
////				{
////					Vector3 offset = new Vector3(0, bounds.y, 0);
////					obstacle.localPosition = closestCell.transform.localPosition + offset;
////				}
//			}
//		}

		private Vector3 getBounds(Transform transform)
		{
			var renderer = transform.GetComponent<Renderer>();
			var combinedBounds = renderer.bounds;
			var renderers = transform.GetComponentsInChildren<Renderer>();
			foreach (var childRenderer in renderers)
			{
				if (childRenderer != renderer) combinedBounds.Encapsulate(childRenderer.bounds);
			}

			return combinedBounds.size;
		}
	}
}