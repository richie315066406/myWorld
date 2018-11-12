using System;
using System.Collections.Generic;

namespace ProjectZGL
{
	public class SiteLogic : DataLogicBase
	{
//		private SiteInfo m_site = null;
//		private Dictionary<int,SiteInfo> m_siteList = new Dictionary<int, SiteInfo>();
//		private List<SiteInfo> SiteInfoList = new List<SiteInfo>();

		public override void OnInit(object userData)
		{
			GameEntry.DataNode.LoadAllSiteByTable();
//			m_siteList = GameEntry.DataNode.GetA

		}

		public override void OnEnter(object userData)
		{
			throw new NotImplementedException();
		}

		public override void OnLeave(object userData, bool isShutdown)
		{
			throw new NotImplementedException();
		}

		public override void OnUpdate(object userData, float elapseSeconds, float realElapseSeconds)
		{
//			m_site = GameEntry.DataNode.GetNowSite();
		}
	}
}
