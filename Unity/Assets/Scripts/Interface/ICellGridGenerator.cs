using System.Collections.Generic;
using UnityEngine;

namespace ProjectZGL
{
	public abstract class ICellGridGenerator : MonoBehaviour
	{
		public Transform CellsParent;
		public abstract List<Cell> GenerateGrid();
	}
}