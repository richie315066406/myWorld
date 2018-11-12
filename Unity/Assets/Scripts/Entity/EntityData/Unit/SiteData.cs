using GameFramework.DataTable;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZGL
{
	[Serializable]
    public class SiteData : EntityData
    {
        [SerializeField]
        private int m_SiteType = 0;

        [SerializeField]
        private string m_SiteName = null;

        [SerializeField]
        private int m_PositionX = 0;

        [SerializeField]
        private int m_PositionY = 0;

        [SerializeField]
        private string m_BGAssName = null;

        [SerializeField]
        private int m_ItemID = 0;

	    [SerializeField]
	    private int m_OpenTime = 0;

	    [SerializeField]
	    private int m_CloseTime = 0;

	    [SerializeField]
	    private List<int> m_FunctionList = null;

		public SiteData(int entityId, int typeId)
            : base(entityId, typeId)
        {
            IDataTable<DRSite> dtSite = GameEntry.DataTable.GetDataTable<DRSite>();
            DRSite drSite = dtSite.GetDataRow(entityId);
            if (drSite == null)
            {
                return;
            }

	        m_SiteType = drSite.SiteType;
	        m_SiteName = drSite.SiteName;
	        m_PositionX = drSite.PositionX;
	        m_PositionY = drSite.PositionY;
	        m_BGAssName = drSite.BGAssName;
	        // m_ItemID = drSite.ItemID;
	        m_OpenTime = drSite.OpenTime;
	        m_CloseTime = drSite.CloseTime;
	        m_FunctionList = drSite.FunctionList;
		}

		public int SiteType
		{
			get
			{
				return m_SiteType;
			}
		}

		public string SiteName
		{
			get
			{
				return m_SiteName;
			}
		}

		public int PositionX
		{
			get
			{
				return m_PositionX;
			}
		}

		public int PositionY
		{
			get
			{
				return m_PositionY;
			}
		}

		public string BGAssName
		{
			get
			{
				return m_BGAssName;
			}
		}

		public int ItemID
		{
			get
			{
				return m_ItemID;
			}
		}

		public int OpenTime
		{
			get
			{
				return m_OpenTime;
			}
		}

		public int CloseTime
		{
			get
			{
				return m_CloseTime;
			}
		}

		public List<int> FunctionList
		{
			get
			{
				return m_FunctionList;
			}
		}
	}
}
