namespace ProjectZGL
{
	/// <summary>
	/// Class representing an "upgrade" to a unit.
	/// </summary>
	public interface Buff
	{
		/// <summary>
		/// 表示Buff的持续时间 (回合数). 如果设置为负数，则是永久的
		/// </summary>
		int Duration { get; set; }

		/// <summary>
		/// Describes how the unit should be upgraded.
		/// </summary>
		void Apply(Unit unit);
		/// <summary>
		/// Returns units stats to normal.
		/// </summary>
		void Undo(Unit unit);

		/// <summary>
		/// Returns deep copy of the Buff object.
		/// </summary>
		Buff Clone();
	}


}