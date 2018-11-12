using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ProjectZGL
{
    /// <summary>
    /// 地点类。
    /// </summary>
    public class Site : Entity
    {
		[SerializeField]
		private SiteData m_SiteData = null;

		private float m_NextAttackTime = 0f;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

	        m_SiteData = userData as SiteData;
            if (m_SiteData == null)
            {
                Log.Error("Site data is invalid.");
                return;
            }

	        Name = m_SiteData.SiteName;

//            GameEntry.Entity.AttachEntity(Entity, m_SiteData.OwnerId, AttachPoint);
        }

	    protected override void OnAttached(EntityLogic childEntity, Transform parentTransform, object userData)
	    {
			base.OnAttached(childEntity,parentTransform,userData);
		    if (childEntity is Building)
		    {
			    
		    }

	    }


		protected override void OnAttachTo(EntityLogic parentEntity, Transform parentTransform, object userData)
        {
            base.OnAttachTo(parentEntity, parentTransform, userData);

            Name = string.Format("Weapon of {0}", parentEntity.Name);
            CachedTransform.localPosition = Vector3.zero;
        }

        public void TryAttack()
        {
            if (Time.time < m_NextAttackTime)
            {
                return;
            }

//            m_NextAttackTime = Time.time + m_WeaponData.AttackInterval;
//            GameEntry.Entity.ShowBullet(new BulletData(GameEntry.Entity.GenerateSerialId(), m_WeaponData.BulletId, m_WeaponData.OwnerId, m_WeaponData.OwnerCamp, m_WeaponData.Attack, m_WeaponData.BulletSpeed)
//            {
//                Position = CachedTransform.position,
//            });
//            GameEntry.Sound.PlaySound(m_WeaponData.BulletSoundId);
        }
    }
}
