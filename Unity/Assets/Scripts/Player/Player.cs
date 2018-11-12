using UnityEngine;

namespace ProjectZGL
{
	/// <summary>
	/// 代表一个游戏参与者（玩家），可以是真人玩家或者AI玩家
	/// （是玩家不是角色）
	/// </summary>
	public abstract class Player : MonoBehaviour
	{
		public int PlayerNumber;
		/// <summary>
		/// 方法每次调用一次。允许玩家与他的单位互动
		/// </summary>         
		public abstract void Play();
//		public abstract void Play(CellGridComponent cellGridComponent);

	}
}