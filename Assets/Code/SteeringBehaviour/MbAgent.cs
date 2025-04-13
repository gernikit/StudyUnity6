using UnityEngine;

namespace SteeringBehaviour
{
	public class MbAgent: MonoBehaviour
	{
		[SerializeField] private ForceParams[] forceParams;
		[SerializeField] private float forceValue = 5f;
		[SerializeField] private float slowingDistanceForTarget = 3f;
		
		public SimpleMovementEntity movementEntity { get; private set; }
		public SteeringForce entitySteeringForce { get; private set; }

		private Camera camera_;

		private void Start( )
		{
			camera_ = Camera.main;
			
			Init(  );
		}

		private void Update( )
		{
			ApplyForces(  );

			movementEntity.ApplyVelocity( Time.deltaTime );

			RotateToVelocity(  );
			DrawHelpers(  );
		}

		private void Init( )
		{
			var entityParams = new SimpleMovementEntityCreationParams( )
			{
				entity = gameObject,
				mass = 1,
				maxVelocity = 100
			};
			
			movementEntity = MovementEntityCreator.CreateSimpleMovementEntity( entityParams );
			
			entitySteeringForce = new SteeringForce( );
			entitySteeringForce.Init( movementEntity );
		}

		public void ApplyForces( )
		{
			if ( forceParams == null )
				return;
			
			foreach ( var forceParam in forceParams )
			{
				if ( forceParam.target == null || forceParam.target.movementEntity == null )
					continue;
				
				AddForce( forceParam.forceType, forceParam.target.movementEntity );
			}
			
			entitySteeringForce.ApplyForce( Time.deltaTime );
			entitySteeringForce.ResetForce(  );
		}

		public void AddForce( EForceType _forceType, AMovementEntity _movementEntity )
		{
			if ( _movementEntity == null)
				return;
			
			switch ( _forceType )
			{
				case EForceType.Seek:
					entitySteeringForce.AddSeek( _movementEntity.position, forceValue );
					break;
				case EForceType.Flee:
					entitySteeringForce.AddFlee( _movementEntity.position, forceValue );
					break;
				case EForceType.Arrive:
					entitySteeringForce.AddArrive( _movementEntity.position, forceValue, slowingDistanceForTarget);
					break;
				case EForceType.Pursuit:
					entitySteeringForce.AddPursuit( _movementEntity, forceValue);
					break;
				case EForceType.Avoid:
					entitySteeringForce.AddAvoid( _movementEntity, forceValue );
					break;
			}
		}

		private void RotateToVelocity( )
		{
			transform.rotation = Quaternion.LookRotation( movementEntity.currentVelocity );
		}

		private void DrawHelpers( )
		{
			Debug.DrawRay( transform.position, movementEntity.currentVelocity * 5, Color.red );
		}
	}
}