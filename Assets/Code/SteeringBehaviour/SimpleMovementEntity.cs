using UnityEngine;

namespace SteeringBehaviour
{
	public class SimpleMovementEntity : AMovementEntity
	{
		private GameObject entityObject_;

		public override Vector3 position
		{
			get => entityObject_.transform.position;
			protected set => entityObject_.transform.position = value;
		}

		public override Vector3 currentVelocity { get; protected set; }
		public override float maxVelocity { get; protected set; }
		public override float mass { get; protected set; }

		public void Init( SimpleMovementEntityCreationParams _creationParams )
		{
			entityObject_ = _creationParams.entity;
			maxVelocity = _creationParams.maxVelocity;
			mass = _creationParams.mass;
		}

		public override void AddForce( Vector3 _force )
		{
			var newVelocity = currentVelocity + _force;
			currentVelocity = Vector3.ClampMagnitude( newVelocity, maxVelocity );
		}

		public override void ApplyVelocity( float _deltaTime )
		{
			position += currentVelocity * _deltaTime;
		}
	}
}