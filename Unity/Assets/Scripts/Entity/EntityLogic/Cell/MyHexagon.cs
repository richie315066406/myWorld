using GameFramework.Fsm;
using UnityEngine;

namespace ProjectZGL
{
	public class MyHexagon : Hexagon
	{
		[SerializeField]
		private MyHexagonData m_MyHexagonData = null;
		public MyHexagonData MyHexagonData
		{
			get { return m_MyHexagonData; }
			set { m_MyHexagonData = value; }
		}
		//Cell×´Ì¬»ú
		private IFsm<Cell> m_CellFsm = null;

		protected override void OnInit(object userdata)
		{
			base.OnInit(userdata);

			m_CellFsm = GameEntry.Fsm.CreateFsm(this, new FsmState<Cell>[]
			{
				new CellNormalState(),
				new CellHighlightedState(),
				new CellPathState(),
				new CellReachableState(),
			});
		}

		protected override void OnShow(object userdata)
		{
			base.OnShow(userdata);
			m_CellFsm.Start<CellNormalState>();
		}

		public override Vector3 GetCellDimensions()
		{
			var ret = GetComponent<SpriteRenderer>().bounds.size;
			return ret*0.98f;
		}

		public override void SetColor(Color color)
		{
			var highlighter = transform.Find("Highlighter");
			var spriteRenderer = highlighter.GetComponent<SpriteRenderer>();
			if (spriteRenderer != null)
			{
				spriteRenderer.color = color;
			}
			foreach (Transform child in highlighter.transform)
			{
				var childColor = new Color(color.r, color.g, color.b, 1);
				spriteRenderer = child.GetComponent<SpriteRenderer>();
				if (spriteRenderer == null) continue;

				child.GetComponent<SpriteRenderer>().color = childColor;
			}
		}
	}
}