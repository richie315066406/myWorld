using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectZGL
{
	public enum GameState
	{
		/// <summary>
		/// 等待输入
		/// </summary>
		WaitingForInput,

		/// <summary>
		/// 单位被选中
		/// </summary>
		UnitSelected,

		/// <summary>
		/// 回合改变
		/// </summary>
		TurnChanging,

		/// <summary>
		/// AI回合
		/// </summary>
		AiTurn,
		
		/// <summary>
		/// 游戏结束
		/// </summary>
		GameOver,
	} 
}
