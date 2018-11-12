using System;
using UnityEngine;

namespace ProjectZGL
{
	public class GUIController : MonoBehaviour
	{
//		public CellGridComponent CellGridComponent;
	
		void Awake()
		{ 
//			CellGridComponent.LevelLoading += onLevelLoading;
//			CellGridComponent.LevelLoadingDone += onLevelLoadingDone;
		}

		private void onLevelLoading(object sender, EventArgs e)
		{
			Debug.Log("Level is loading");
		}

		private void onLevelLoadingDone(object sender, EventArgs e)
		{
			Debug.Log("Level loading done");
			Debug.Log("Press 'n' to end turn");
		}

		void Update ()
		{
			if(Input.GetKeyDown(KeyCode.N))
			{
//				CellGridComponent.EndTurn();//User ends his turn by pressing "n" on keyboard.
			}
		}
	}
}
