using System.Collections.Generic;

namespace ProjectZGL
{
	public interface IUnitGenerator
	{
		List<Unit> SpawnUnits(List<Cell> cells);
	}
}