using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectZGL
{
	public abstract class DataLogicBase
	{
		public abstract void OnInit(object userData);

		public abstract void OnEnter(object userData);

		public abstract void OnUpdate(object userData, float elapseSeconds, float realElapseSeconds);

		public abstract void OnLeave(object userData, bool isShutdown);

	}
}
