using UnityEngine;

namespace ProjectZGL
{
	public class SampleUnit : Unit
	{
		public Color LeadingColor;

		protected override void OnShow(object userData)
		{
			base.OnShow(userData);
			transform.position += new Vector3(0, 1, 0);
			GetComponent<Renderer>().material.color = LeadingColor;
		}
		public override void MarkAsAttacking(Unit other)
		{      
		}

		public override void MarkAsDefending(Unit other)
		{       
		}

		public override void MarkAsDestroyed()
		{      
		}

		public override void MarkAsFinished()
		{
		}

		public override void MarkAsFriendly()
		{
			GetComponent<Renderer>().material.color = LeadingColor + new Color(0.8f, 1, 0.8f);
		}

		public override void MarkAsReachableEnemy()
		{
			GetComponent<Renderer>().material.color = LeadingColor + Color.red ;
		}

		public override void MarkAsSelected()
		{
			GetComponent<Renderer>().material.color = LeadingColor + Color.green;
		}

		public override void UnMark()
		{
			GetComponent<Renderer>().material.color = LeadingColor;
		}
	}
}
