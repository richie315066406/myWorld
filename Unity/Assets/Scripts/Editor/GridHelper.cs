using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ProjectZGL;
using UnityEditor;
using UnityEngine;

namespace ProjectZGL
{
	class GridHelper : EditorWindow
	{
		private static string MAP_TYPE_3D = "3D";
		private static string MAP_TYPE_2D = "2D";

		public int nHumanPlayer;
		public int nComputerPlayer;

		public int generatorIndex;
		public int mapTypeIndex;

		public static List<Type> generators;
		public static string[] generatorNames;
		public static string[] mapTypes;

		GameObject cellGrid;
		GameObject units;
		GameObject players;
		GameObject guiController;
		GameObject directionalLight;

		Dictionary<string, object> parameterValues;

		[MenuItem("Window/Grid Helper")]
		public static void ShowWindow()
		{
			var window = GetWindow(typeof(GridHelper));
			window.titleContent.text = "Grid Helper";
		}
		void Initialize()
		{
			if (parameterValues == null)
			{
				parameterValues = new Dictionary<string, object>();
			}

			if (generators == null)
			{
				Type generatorInterface = typeof(ICellGridGenerator);
				var assembly = generatorInterface.Assembly;

				generators = new List<Type>();
				foreach (var t in assembly.GetTypes())
				{
					if (generatorInterface.IsAssignableFrom(t) && t != generatorInterface)
						generators.Add(t);
				}
			}

			if (generatorNames == null)
			{
				generatorNames = generators.Select(t => t.Name).ToArray();
			}

			if (mapTypes == null)
			{
				mapTypes = new string[2];
				mapTypes[0] = MAP_TYPE_3D;
				mapTypes[1] = MAP_TYPE_2D;
			}
		}
		void OnGUI()
		{
			Initialize();

			GUILayout.Label("Players", EditorStyles.boldLabel);
			nHumanPlayer = EditorGUILayout.IntField(new GUIContent("Human players No"), nHumanPlayer);
			nComputerPlayer = EditorGUILayout.IntField(new GUIContent("AI players No"), nComputerPlayer);

			GUILayout.Label("Map", EditorStyles.boldLabel);

			mapTypeIndex = EditorGUILayout.Popup("Map Type", mapTypeIndex, mapTypes, new GUILayoutOption[0]);
			GUI.changed = false;
			generatorIndex = EditorGUILayout.Popup("Generator", generatorIndex, generatorNames, new GUILayoutOption[0]);
			if(GUI.changed)
			{
				parameterValues = new Dictionary<string, object>();
			}

			foreach (var field in generators[generatorIndex].GetFields().Where(f => f.IsPublic))
			{
				if (field.FieldType == typeof(int))
				{
					int x = 0;
					if (parameterValues.ContainsKey(field.Name))
					{
						x = (int)(parameterValues[field.Name]);
					}
					x = EditorGUILayout.IntField(new GUIContent(field.Name), x);
					parameterValues[field.Name] = x;
				}
				else if (field.FieldType == typeof(GameObject))
				{
					GameObject g = null;
					if (parameterValues.ContainsKey(field.Name))
					{
						g = (GameObject)(parameterValues[field.Name]);
					}
					g = (GameObject)EditorGUILayout.ObjectField(field.Name, g, typeof(GameObject), false, new GUILayoutOption[0]);
					parameterValues[field.Name] = g;
				}
			}

			if (GUILayout.Button("Generate scene"))
			{
				generateBaseStructure();
			}
			if (GUILayout.Button("Clear scene"))
			{
				string dialogTitle = "Confirm delete";
				string dialogMessage = "This will delete all objects on the scene. Do you wish to continue?";
				string dialogOK = "Ok";
				string dialogCancel = "Cancel";

				bool shouldDelete = EditorUtility.DisplayDialog(dialogTitle, dialogMessage, dialogOK, dialogCancel); 
				if(shouldDelete)
					clearScene();
			}
		}

		void generateBaseStructure()
		{
			if(checkMissingParameters())
			{
				return;
			}

			clearScene();

			var mapType = mapTypes[mapTypeIndex];
			var camera = Camera.main;
			if (camera == null)
			{
				var cameraObject = new GameObject("Main Camera");
				cameraObject.tag = "MainCamera";
				cameraObject.AddComponent<Camera>();
				camera = cameraObject.GetComponent<Camera>();
			}

			camera.transform.rotation = Quaternion.Euler(mapType.Equals(MAP_TYPE_2D) ? 0 : 90, 0, 0);
        

			cellGrid = new GameObject("CellGrid");
			players = new GameObject("Players");
			units = new GameObject("Units");
			guiController = new GameObject("GUIController");

			directionalLight = new GameObject("DirectionalLight");
			var light = directionalLight.AddComponent<Light>();
			light.type = LightType.Directional;
			light.transform.Rotate(45f, 0, 0);

			for (int i = 0; i < nHumanPlayer; i++)
			{
				var player = new GameObject(string.Format("Player_{0}", players.transform.childCount));
				player.AddComponent<HumanPlayer>();
				player.GetComponent<Player>().PlayerNumber = players.transform.childCount;
				player.transform.parent = players.transform;
			}

			for (int i = 0; i < nComputerPlayer; i++)
			{
				var aiPlayer = new GameObject(string.Format("AI_Player_{0}", players.transform.childCount));
//				aiPlayer.AddComponent<NaiveAiPlayer>();
				aiPlayer.GetComponent<Player>().PlayerNumber = players.transform.childCount;
				aiPlayer.transform.parent = players.transform;
			}

			Type selectedGenerator = generators[generatorIndex];

//			var cellGridScript = cellGrid.AddComponent<CellGridComponent>();
			var generator = (ICellGridGenerator)cellGrid.AddComponent(selectedGenerator);
			generator.CellsParent = cellGrid.transform;

//			cellGrid.GetComponent<CellGridComponent>().PlayersParent = players.transform;

			var unitGenerator = cellGrid.AddComponent<CustomUnitGenerator>();
			unitGenerator.UnitsParent = units.transform;
			unitGenerator.CellsParent = cellGrid.transform;

			var guiControllerScript = guiController.AddComponent<GUIController>();
//			guiControllerScript.CellGridComponent = cellGridScript;
        
			foreach (var fieldName in parameterValues.Keys)
			{
				FieldInfo prop = generator.GetType().GetField(fieldName);
				if (null != prop)
				{
					prop.SetValue(generator, parameterValues[fieldName]);
				}
			}
			generator.GenerateGrid();

			if (mapType.Equals(MAP_TYPE_2D))
			{
				cellGrid.transform.Rotate(new Vector3(-90f, 0f, 0f));
				players.transform.Rotate(new Vector3(-90f, 0f, 0f));
				units.transform.Rotate(new Vector3(-90f, 0f, 0f));
			}
		}

		void clearScene()
		{
			var objects = FindObjectsOfType<GameObject>();
			var toDestroy = new List<GameObject>();

			foreach (var obj in objects)
			{
				bool isCamera = obj.GetComponent<Camera>() != null;
				bool isChild = obj.transform.parent != null;

				if (isCamera || isChild)
					continue;

				toDestroy.Add(obj);
			}
			toDestroy.ForEach(o => DestroyImmediate(o));
		}

		private bool checkMissingParameters()
		{
			List<String> missingParams = new List<string>();
			foreach (var entry in parameterValues)
			{
				if (entry.Value == null)
				{
					missingParams.Add(entry.Key);
				}
			}

			if(missingParams.Count != 0)
			{
				string dialogTitle = String.Format("Parameter{0} missing", missingParams.Count > 1 ? "s" : "");

				StringBuilder dialogMessage = new StringBuilder();
				dialogMessage.AppendFormat("Please fill in the missing parameter{0} first:\n", missingParams.Count > 1 ? "s" : "");
				foreach (var missingParam in missingParams)
				{
					dialogMessage.AppendLine(String.Format("   -{0}", missingParam));
				}

				string dialogOK = "Ok";
				EditorUtility.DisplayDialog(dialogTitle, dialogMessage.ToString(), dialogOK);

				return true;
			}
			return false;
		}
	}
}