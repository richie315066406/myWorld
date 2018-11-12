using System;
using UnityEngine;

namespace ProjectZGL
{
    [Serializable]
    public class MyCharacterData : CharacterData
    {
        [SerializeField]
        private string m_Name = null;
	    [SerializeField]
	    private int m_Hp = 0;
	    [SerializeField]
	    private int m_Vigor = 0;
	    [SerializeField]
	    private int m_Repletion = 0;
	    [SerializeField]
	    private int m_Wit = 0;
	    [SerializeField]
	    private int m_Force = 0;
	    [SerializeField]
	    private int m_Charm = 0;
	    [SerializeField]
	    private int m_Health = 0;
	    [SerializeField]
	    private int m_Money = 0;
	    [SerializeField]
	    private int m_Asset = 0;
	    [SerializeField]
	    private int m_Credit = 0;
	    [SerializeField]
	    private int m_Weight = 0;

//	    private Array ItemList = null;

		public MyCharacterData(int entityId, int typeId)
            : base(entityId, typeId, CampType.Player)
        {

        }

        /// <summary>
        /// 角色名称。
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

		public int Hp
		{
			get
			{
				return m_Hp;
			}

			set
			{
				m_Hp = value;
			}
		}

		public int Vigor
		{
			get
			{
				return m_Vigor;
			}

			set
			{
				m_Vigor = value;
			}
		}

		public int Repletion
		{
			get
			{
				return m_Repletion;
			}

			set
			{
				m_Repletion = value;
			}
		}

		public int Wit
		{
			get
			{
				return m_Wit;
			}

			set
			{
				m_Wit = value;
			}
		}

		public int Force
		{
			get
			{
				return m_Force;
			}

			set
			{
				m_Force = value;
			}
		}

		public int Charm
		{
			get
			{
				return m_Charm;
			}

			set
			{
				m_Charm = value;
			}
		}

		public int Health
		{
			get
			{
				return m_Health;
			}

			set
			{
				m_Health = value;
			}
		}

		public int Money
		{
			get
			{
				return m_Money;
			}

			set
			{
				m_Money = value;
			}
		}

		public int Asset
		{
			get
			{
				return m_Asset;
			}

			set
			{
				m_Asset = value;
			}
		}

		public int Credit
		{
			get
			{
				return m_Credit;
			}

			set
			{
				m_Credit = value;
			}
		}

		public int Weight
		{
			get
			{
				return m_Weight;
			}

			set
			{
				m_Weight = value;
			}
		}
	}
}
