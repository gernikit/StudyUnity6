using UnityEngine;

namespace SteeringBehaviour
{
	public abstract class AMovementEntity
	{
		public abstract Vector3 position { get; protected set; }
		public abstract Vector3 currentVelocity { get; protected set; }
		public abstract float maxVelocity { get; protected set; }
		public abstract float mass { get; protected set; }

		public abstract void AddForce( Vector3 _force );
		public abstract void ApplyVelocity( float _deltaTime );
	}
}