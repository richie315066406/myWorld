using System;
using System.Collections.Generic;
using GameFramework.DataTable;
using UnityEngine;

namespace ProjectZGL
{
    //地点信息是只读的
    [Serializable]
    public class SiteInfo
    {
        [SerializeField]
        private int m_SiteId = 0;
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
	    [SerializeField]
	    private List<ShopData> m_Shop = null;

		//根据ID设置Site信息
		public SiteInfo(int siteId)
        {
            IDataTable<DRSite> dtSite = GameEntry.DataTable.GetDataTable<DRSite>();
	        IDataTable<DRFunction> dtFunctions = GameEntry.DataTable.GetDataTable<DRFunction>();
	        IDataTable<DRShop> dtShop = GameEntry.DataTable.GetDataTable<DRShop>();

			DRSite drSite = dtSite.GetDataRow(siteId);
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
	        
//			foreach (var function in m_FunctionList)
//	        {
//				DRFunction drFunction = dtFunctions.GetDataRow(function);
//		        if (drFunction.FunctionType == (int)FunctionType.OpenShop)
//		        {
//			        DRShop drShop = dtShop.GetDataRow(drFunction.ParameterList[1]);
//					//商店集合
//					m_Shop.Add(new ShopData()
//					{
//						Level = drShop.Level,
//						Type = drShop.GoodType,
//						OpenTime = drShop.OpenTime,
//						CloseTime = drShop.CloseTime,
//						CommodityList = drShop.CommodityList
//					});
//		        }
//			}
		}

		public int SiteId
        {
            get
            {
                return m_SiteId;
            }
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