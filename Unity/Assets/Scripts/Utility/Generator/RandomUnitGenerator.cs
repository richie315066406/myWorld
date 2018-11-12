using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ProjectZGL
{
	//随机角色生成器
	class RandomUnitGenerator : MonoBehaviour, IUnitGenerator
	{
		private System.Random _rnd = new System.Random();

		public Transform UnitsParent;

		public GameObject UnitPrefab;
		public int NumberOfPlayers;
		public int UnitsPerPlayer;

		/// <summary>
		/// Method spawns UnitPerPlayer nunmber of UnitPrefabs in random positions.
		/// 每个玩家得到的单位数量相等
		/// </summary>
		public List<Unit> SpawnUnits(List<Cell> cells)
		{
			List<Unit> ret = new List<Unit>();
//
//			List<Cell> freeCells = cells.FindAll(h => h.GetComponent<Cell>().CellData.IsTaken == false);
//			freeCells = freeCells.OrderBy(h => _rnd.Next()).ToList();
//
//			for (int i = 0; i < NumberOfPlayers; i++)
//			{
//				for (int j = 0; j < UnitsPerPlayer; j++)
//				{
//					var cell = freeCells.ElementAt(0);
//					freeCells.RemoveAt(0);
////					cell.GetComponent<Cell>().IsTaken = true;
//
//					var unit = Instantiate(UnitPrefab);
//					unit.transform.position = cell.transform.position + new Vector3(0, 0, 0);
//					unit.GetComponent<Unit>().UnitData.PlayerNumber = i;
//					unit.GetComponent<Unit>().UnitData.Cell = cell.GetComponent<Cell>();
////					unit.GetComponent<Unit>().UnitData.Initialize();
//					unit.transform.parent = UnitsParent;
//
//
//					ret.Add(unit.GetComponent<Unit>());
//				}
//			}
			return ret;
		}
	}
}
