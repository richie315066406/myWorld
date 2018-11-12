using System;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectZGL
{
	class OtherGuiController : MonoBehaviour
	{
//		public CellGridComponent CellGridComponent;
		public Image FullMarkerImage;
		public Image EmptyMarkerImage;
		public Image FullHPBar;
		public Image EmptyHPBar;
		public Button NextTurnButton;

		public Text InfoText;
		public Text HPText;
		public Text AttackText;
		public Text DefenceText;
		public Text RangeText;

		private void Awake()
		{
//			CellGridComponent.GameStarted += OnGameStarted;
//			CellGridComponent.TurnEnded += OnTurnEnded;
//			CellGridComponent.GameEnded += OnGameEnded;
//			CellGridComponent.UnitAdded += OnUnitAdded;      
		}

		private void OnUnitAttacked(object sender, AttackEventArgs e)
		{
//			if (!(CellGridComponent.CurrentPlayer is HumanPlayer)) return;

			OnUnitDehighlighted(sender, e);

//			if ((sender as Unit).HitPoints <= 0) return;

			OnUnitHighlighted(sender, e);
		}
		private void OnGameStarted(object sender, EventArgs e)
		{
//			InfoText.text = "Player " + (CellGridComponent.CurrentPlayerNumber + 1);

			OnTurnEnded(sender,e);
		}
		private void OnGameEnded(object sender, EventArgs e)
		{
//			InfoText.text = "Player " + ((sender as CellGridComponent).CurrentPlayerNumber + 1) + " wins!";
		}
		private void OnTurnEnded(object sender, EventArgs e)
		{
//			NextTurnButton.interactable = ((sender as CellGridComponent).CurrentPlayer is HumanPlayer);
//			InfoText.text = "Player " + ((sender as CellGridComponent).CurrentPlayerNumber + 1);
		}

		private void OnUnitDehighlighted(object sender, EventArgs e)
		{
			foreach (Transform marker in AttackText.transform)
			{
				Destroy(marker.gameObject);
			}

			foreach (Transform marker in DefenceText.transform)
			{
				Destroy(marker.gameObject);
			}

			foreach (Transform marker in RangeText.transform)
			{
				Destroy(marker.gameObject);
			}

			foreach (Transform hpBar in HPText.transform)
			{
				Destroy(hpBar.gameObject);
			}
		}
		private void OnUnitHighlighted(object sender, EventArgs e)
		{
//			var attack = (sender as Unit).AttackFactor;
//			var defence = (sender as Unit).DefenceFactor;
//			var range = (sender as Unit).AttackRange;
//
//			float hpScale = (float)((float)(sender as Unit).HitPoints / (float)(sender as Unit).TotalHitPoints);

			Image fullHpBar = Instantiate(FullHPBar);
			Image emptyHpBar = Instantiate(EmptyHPBar);
//			fullHpBar.rectTransform.localScale = new Vector3(hpScale, 1, 1);
			emptyHpBar.rectTransform.SetParent(HPText.rectTransform,false);
			fullHpBar.rectTransform.SetParent(HPText.rectTransform, false);
        
			for (int i = 0; i < 7; i++)
			{
//				Image AttackMarker;
//				AttackMarker = Instantiate(i<attack ? FullMarkerImage : EmptyMarkerImage);
//
//				AttackMarker.rectTransform.SetParent(AttackText.rectTransform,false);
//				AttackMarker.rectTransform.anchorMin = new Vector2(i * 0.14f,0.1f);
//				AttackMarker.rectTransform.anchorMax = new Vector2((i * 0.14f)+0.13f, 0.6f);
//
//				Image DefenceMarker;
//				DefenceMarker = Instantiate(i < defence ? FullMarkerImage : EmptyMarkerImage);
//
//				DefenceMarker.rectTransform.SetParent(DefenceText.rectTransform, false);
//				DefenceMarker.rectTransform.anchorMin = new Vector2(i * 0.14f, 0.1f);
//				DefenceMarker.rectTransform.anchorMax = new Vector2((i * 0.14f) + 0.13f, 0.6f);
//
//				Image RangeMarker;
//				RangeMarker = Instantiate(i < range ? FullMarkerImage : EmptyMarkerImage);
//
//				RangeMarker.rectTransform.SetParent(RangeText.rectTransform, false);
//				RangeMarker.rectTransform.anchorMin = new Vector2(i * 0.14f, 0.1f);
//				RangeMarker.rectTransform.anchorMax = new Vector2((i * 0.14f) + 0.13f, 0.6f);             
			}
		}
		private void OnUnitAdded(object sender, UnitCreatedEventArgs e)
		{
//			RegisterUnit(e.unit);
		}

		private void RegisterUnit(Transform unit)
		{
//			unit.GetComponent<Unit>().UnitHighlighted += OnUnitHighlighted;
//			unit.GetComponent<Unit>().UnitDehighlighted += OnUnitDehighlighted;
//			unit.GetComponent<Unit>().UnitAttacked += OnUnitAttacked;
		}
		public void RestartLevel()
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}

