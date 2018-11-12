using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectZGL
{
	public enum GridGeneratorType
	{
		/// <summary>
		/// 六边形等边网格
		/// </summary>
		EquilateraHexGrid,

		/// <summary>
		/// 常规六边形网格
		/// </summary>
		HexagonalHexGrid,

		/// <summary>
		/// 六边形矩形网格
		/// </summary>
		RectangularHexGrid,

		/// <summary>
		/// 四边形矩形网格
		/// </summary>
		RectangularSquareGrid,

		/// <summary>
		/// 六边形三角形网格
		/// </summary>
		TriangularHexGrid,
	}
}
