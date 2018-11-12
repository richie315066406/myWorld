using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameFramework.DataTable;
using UnityEngine;

namespace ProjectZGL
{
    class ItemData
    {
		[SerializeField]
		private int m_Id = 0;
		[SerializeField]
		private int m_Burden = 0;
		[SerializeField]
		private string m_Name = null;
		[SerializeField]
		private string m_Description = null;
		[SerializeField]
		private string m_PicAssName = null;

        public int Id { get{return m_Id;} private set{m_Id=value;} }
        public string Name { get{return m_Name;} private set{m_Name=value;} }
        public string Description { get{return m_Description;} private set{m_Description=value;} }
        public int Burden { get{return m_Burden;} private set{m_Burden=value;} }
        // public int SellPrice { get; private set; }
        // public string Icon { get; private set; }
        public string PicAssName { get{return m_PicAssName;} private set{m_PicAssName=value;} }

        public ItemData(int id)
        {
            IDataTable<DRItem> dtItem = GameEntry.DataTable.GetDataTable<DRItem>();
            DRItem dritem = dtItem.GetDataRow(id);

            this.Id = dritem.Id;
			this.Burden = dritem.Burden;
            this.Name = dritem.NameKey;
            this.Description = dritem.IntroKey;
            // this.BuyPrice = dritem.BuyPrice;
            this.PicAssName = dritem.PicAssName;
            // this.Icon = icon;
        }
    }
}
