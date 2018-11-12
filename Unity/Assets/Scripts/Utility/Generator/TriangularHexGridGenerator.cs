using UnityEngine;
using System.Collections.Generic;

namespace ProjectZGL
{
	/// <summary>
	/// 生成六边形的三角形网格
	/// </summary>
	[ExecuteInEditMode()]
	public class TriangularHexGridGenerator : ICellGridGenerator
	{
		public GameObject HexagonPrefab;
		public int Side;

		public override List<Cell> GenerateGrid()
		{
			List<Cell> hexagons = new List<Cell>();

			if (HexagonPrefab.GetComponent<Hexagon>() == null)
			{
				Debug.LogError("Invalid hexagon prefab provided");
				return hexagons;
			}

			for (int i = 0; i < Side; i++)
			{
				for (int j = 0; j < Side - i; j++)
				{
					GameObject hexagon = Instantiate(HexagonPrefab);
					var hexSize = hexagon.GetComponent<Cell>().GetCellDimensions();

					hexagon.transform.position = new Vector3((i * hexSize.x * 0.75f), 0, (i * hexSize.z * 0.5f) + (j * hexSize.z));
//					hexagon.GetComponent<Hexagon>().OffsetCoord = new Vector2(i, Side - j - 1 - (i / 2));
//					hexagon.GetComponent<Hexagon>().HexGridType = HexGridType.odd_q;
//					hexagon.GetComponent<Hexagon>().MovementCost = 1;
					hexagons.Add(hexagon.GetComponent<Cell>());

					hexagon.transform.parent = CellsParent;
				}
			}
			return hexagons;
		}
	}
}
