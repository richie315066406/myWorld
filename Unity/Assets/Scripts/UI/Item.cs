using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectZGL
{
    class Item : MonoBehaviour
    {
        [SerializeField]
        private Text m_ItemName;
        [SerializeField]
        private Text m_ItemNumber;
        [SerializeField]
        private Image m_ItemPic;
        [SerializeField]
        private ItemData m_ItemParam = null;

        private static List<Sprite> m_ImageList = new List<Sprite>();

        public static void AddImageAsset(Sprite item)
		{
            m_ImageList.Add(item);
        }

        public ItemData ItemParam
        {
            get
            {
                return m_ItemParam;
            }
            set
            {
                m_ItemParam = value;
            }
        }

        private void Start()
        {
            m_ItemName.text = GameEntry.Localization.GetString(ItemParam.Name);
            foreach (var image in m_ImageList)
            {
                if (image.name == ItemParam.PicAssName)
                {
                    m_ItemPic.sprite = image;
                }
            }
        }
    }
}
