using UnityEngine;

namespace ProjectZGL
{
	public class SampleSquare : Square
	{
		public override Vector3 GetCellDimensions()
		{
			return GetComponent<Renderer>().bounds.size;
		}

		public override void SetColor(Color color)
		{
			throw new System.NotImplementedException();
		}

		//		public override void MarkAsHighlighted()
		//		{
		//			GetComponent<Renderer>().material.color = new Color(0.75f, 0.75f, 0.75f); ;
		//		}
		//
		//		public override void MarkAsPath()
		//		{
		//			GetComponent<Renderer>().material.color = Color.green;
		//		}
		//
		//		public override void MarkAsReachable()
		//		{
		//			GetComponent<Renderer>().material.color = Color.yellow;
		//		}
		//
		//		public override void UnMark()
		//		{
		//			GetComponent<Renderer>().material.color = Color.white;
		//		}
	}
}

