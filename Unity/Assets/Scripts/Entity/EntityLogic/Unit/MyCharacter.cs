using UnityEngine;
using UnityGameFramework.Runtime;

namespace ProjectZGL
{
    public class MyCharacter : Character
    {
        [SerializeField]
        private MyCharacterData m_MyCharacterData = null;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

	    protected override void OnShow(object userData)
	    {
		    base.OnShow(userData);

		    m_MyCharacterData = userData as MyCharacterData;
		    if (m_MyCharacterData == null)
		    {
			    Log.Error("My aircraft data is invalid.");
			    return;
		    }
	    }

    }
}
