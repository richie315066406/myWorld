using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZGL
{
    [Serializable]
    public class ShopData
    {
        [SerializeField]
        private string m_Name = null;
        [SerializeField]
        private int m_Level = 0;
        [SerializeField]
        private int m_Type = 0;
        [SerializeField]
        private int m_OpenTime = 0;
        [SerializeField]
        private int m_CloseTime = 0;
        [SerializeField]
        private List<int> m_CommodityList = new List<int>();
        [SerializeField]
        private int m_Site = 0;       

        /// <summary>
        /// 商店名称
        /// </summary>
        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }

        public int Level
        {
            get
            {
                return m_Level;
            }

            set
            {
                m_Level = value;
            }
        }

        public int Type
        {
            get
            {
                return m_Type;
            }

            set
            {
                m_Type = value;
            }
        }

        public int OpenTime
        {
            get
            {
                return m_OpenTime;
            }

            set
            {
                m_OpenTime = value;
            }
        }

        public int CloseTime
        {
            get
            {
                return m_CloseTime;
            }

            set
            {
                m_CloseTime = value;
            }
        }

        public List<int> CommodityList
        {
            get
            {
                return m_CommodityList;
            }

            set
            {
                m_CommodityList = value;
            }
        }
        
        public int Site
		{
            get
            {
                return m_Site;
            }

            set
            {
	            m_Site = value;
            }
        }

    }
}