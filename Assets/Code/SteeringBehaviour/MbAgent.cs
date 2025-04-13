using UnityEngine;

namespace SteeringBehaviour
{
	public class MbAgent: MonoBehaviour
	{
		[SerializeField] private float forceValue = 5f;
		
		public SimpleMovementEntity movementEntity { get; private set; }
		public SteeringForce entitySteeringForce { get; private set; }
		
		public MbAgent target;

		private Camera camera_;

		private void Start( )
		{
			camera_ = Camera.main;
			
			Init(  );
		}

		private void Update( )
		{
			// var steeringForce = GetBehaviourForce( behaviourType, 0 );
			// var steeringForce2 = GetBehaviourForce( behaviourType2, 1 );
			//
			// var generalSteeringForce = steeringForce + steeringForce2;
			// currentVelocity += generalSteeringForce * Time.deltaTime;
			//
			// Debug.Log( "steeringForce " + steeringForce.magnitude );
			// Debug.Log( "currentVelocity " + currentVelocity.magnitude );
			//
			// transform.position += currentVelocity * Time.deltaTime;
			
			entitySteeringForce.Seek( GetTargetPos( 0 ), forceValue );
			entitySteeringForce.ApplyForce( Time.deltaTime );
			entitySteeringForce.ResetForce(  );
			
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

		/*private void SetBehaviourForce( EBehaviourType _behaviourType, int _targetIndex )
		{
			switch ( _behaviourType )
			{
				case EBehaviourType.Seek:
					return SteeringForces.GetSeekForce( currentVelocity, transform.position, GetTargetPos( _targetIndex ), maxForceValue, mass);
				case EBehaviourType.Flee:
					return SteeringForces.GetFleeForce( currentVelocity, transform.position, GetTargetPos( _targetIndex ), maxForceValue, mass );
				case EBehaviourType.Arrive:
					return SteeringForces.GetArriveForce( currentVelocity, transform.position, GetTargetPos( _targetIndex ), maxForceValue, mass, 1f );
				case EBehaviourType.Pursuit:
					return SteeringForces.GetPursuitForce( currentVelocity, transform.position, targets[_targetIndex].currentVelocity, GetTargetPos( _targetIndex ),  maxForceValue, mass  );
					break;
				case EBehaviourType.Evading:
					return SteeringForces.GetEvadingForce( currentVelocity, transform.position, targets[_targetIndex].currentVelocity, GetTargetPos( _targetIndex ),  maxForceValue, mass  );
				default:
					return Vector3.zero;
			}
			
			return Vector3.zero;
		}*/
		
		private void RotateToVelocity( )
		{
			transform.rotation = Quaternion.LookRotation( movementEntity.currentVelocity );
		}

		private Vector3 GetTargetPos( int _index )
		{
			if ( target == null )
			{
				Vector3 mousePosition = camera_.ScreenToWorldPoint(
					new Vector3(Input.mousePosition.x, Input.mousePosition.y, -camera_.transform.position.z)
				);
				mousePosition.z = 0;
				return mousePosition;
			}
			
			
			return target.movementEntity.position;
		}

		private void DrawHelpers( )
		{
			Debug.DrawRay( transform.position, movementEntity.currentVelocity * 5, Color.red );
		}
	}
}