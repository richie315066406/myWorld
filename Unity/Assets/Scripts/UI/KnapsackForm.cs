using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameFramework.DataTable;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ProjectZGL
{
	class KnapsackForm : CommonForm
	{
		[SerializeField]
		private Item m_Item = null;
		[SerializeField]
		private RectTransform m_GridPanel = null;
		public Dictionary<int,ItemData> ItemList { get; private set; }

		public new void OnLButtonClick()
		{
//			Log.Info("123");
			GameEntry.UI.OpenUIForm(UIFormId.MainForm);
//			GameEntry.UI.RefocusUIForm(GameEntry.UI.GetUIForm(UIFormId.MainForm).UIForm);
		}

		protected override void OnOpen(object userData)
		{
			if (m_Item==null)
			{
				Log.Error("Item obj is null");
			}

			//数据加载
			List<int> itemIdList = GameEntry.DataNode.GetPlayerInfo().ItemIDs;
			foreach (var itemId in itemIdList)
			{
				Item obj = Instantiate(m_Item);
				obj.ItemParam = new ItemData(itemId){
					//TODO 添加Item信息
				};
				obj.gameObject.transform.SetParent(m_GridPanel);
			}
			itemIdList.Clear();
			base.OnOpen(userData);
		}

		public void StoreItem(int itemId)
		{
			if (!ItemList.ContainsKey(itemId))
				return;
			ItemData temp = ItemList[itemId];
			//加载资源
//			Resources.Load<GameObject>()
			//实例化Item
		}

		protected override void OnClose(object userData)
		{

			base.OnClose(userData);
		}

	}
}
