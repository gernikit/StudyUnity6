using System;

namespace SteeringBehaviour
{
	[Serializable]
	public class ForceParams
	{
		public EForceType forceType;
		public MbAgent target;
	}
}