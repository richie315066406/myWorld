using UnityEngine;
using System.Collections.Generic;

namespace ProjectZGL
{
	/// <summary>
	/// 生成六边形的等边形网格
	/// </summary>
	[ExecuteInEditMode()]
	public class EquilateralHexGridGenerator : ICellGridGenerator
	{
		public GameObject HexagonPrefab;
		public int Side_a;
		public int Side_b;

		public override List<Cell> GenerateGrid()
		{
			var hexGridType = Side_a % 2 == 0 ? HexGridType.even_q : HexGridType.odd_q; ;
			var hexagons = new List<Cell>();

			if (HexagonPrefab.GetComponent<Hexagon>() == null)
			{
				Debug.LogError("Invalid hexagon prefab provided");
				return hexagons;
			}

			for (int i = 0; i < Side_a; i++)
			{
				for (int j = 0; j < Side_b; j++)
				{
					GameObject hexagon = Instantiate(HexagonPrefab);

					var hexSize = hexagon.GetComponent<Cell>().GetCellDimensions();

					hexagon.transform.position = new Vector3((i * hexSize.x * 0.75f), 0, (i * hexSize.z * 0.5f) + (j * hexSize.z));
//					hexagon.GetComponent<Hexagon>().OffsetCoord = new Vector2(Side_a - i - 1, Side_b - j - 1 - (i / 2));
//					hexagon.GetComponent<Hexagon>().HexGridType = hexGridType;
//					hexagon.GetComponent<Hexagon>().MovementCost = 1;
					hexagons.Add(hexagon.GetComponent<Cell>());

					hexagon.transform.parent = CellsParent;
				}
			}
			return hexagons;
		}
	}


}
