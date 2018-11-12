using System.Collections.Generic;
using UnityEngine;

namespace ProjectZGL
{
	/// <summary>
	/// 生成六边形组成的矩形网格
	/// </summary>
	[ExecuteInEditMode()]
	class RectangularHexGridGenerator : ICellGridGenerator
	{
		public GameObject HexagonPrefab;
		public int Height;
		public int Width;

		public override List<Cell> GenerateGrid()
		{
			HexGridType hexGridType = Width % 2 == 0 ? HexGridType.even_q : HexGridType.odd_q;
			List<Cell> hexagons = new List<Cell>();

			if (HexagonPrefab.GetComponent<Hexagon>() == null)
			{
				Debug.LogError("Invalid hexagon prefab provided");
				return hexagons;
			}

			for (int i = 0; i < Height; i++)
			{
				for (int j = 0; j < Width; j++)
				{
					GameObject hexagon = Instantiate(HexagonPrefab);
					var hexSize = hexagon.GetComponent<Cell>().GetCellDimensions();

					hexagon.transform.position = new Vector3((j * hexSize.x * 0.75f), 0, (i * hexSize.z) + (j % 2 == 0 ? 0 : hexSize.z * 0.5f));
//					hexagon.GetComponent<Hexagon>().OffsetCoord = new Vector2(Width - j - 1, Height - i - 1);
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


