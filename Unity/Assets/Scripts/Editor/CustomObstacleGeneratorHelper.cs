using UnityEditor;
using UnityEngine;

namespace ProjectZGL
{
	[CustomEditor(typeof(CustomObstacleGenerator))]
	public class CustomObstacleGeneratorHelper : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			CustomObstacleGenerator obstacleGenerator = (CustomObstacleGenerator)target;

			if(GUILayout.Button("Snap to Grid"))
			{
//				obstacleGenerator.SnapToGrid();
			}
		}
	}
}
