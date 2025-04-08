using System.Collections.Generic;
using UnityEngine;

namespace SteeringBehaviour
{
	public class MbAgent: MonoBehaviour
	{
		public SimpleMovementEntity movementEntity { get; private set; }

		private Camera camera_;

		private void Start( )
		{
			camera_ = Camera.main;
		}

		private void Update( )
		{
			var steeringForce = GetBehaviourForce( behaviourType, 0 );
			var steeringForce2 = GetBehaviourForce( behaviourType2, 1 );

			var generalSteeringForce = steeringForce + steeringForce2;
			currentVelocity += generalSteeringForce * Time.deltaTime;

			Debug.Log( "steeringForce " + steeringForce.magnitude );
			Debug.Log( "currentVelocity " + currentVelocity.magnitude );
			
			transform.position += currentVelocity * Time.deltaTime;
			RotateToVelocity(  );
			DrawHelpers(  );
		}

		private Vector3 GetBehaviourForce( EBehaviourType _behaviourType, int _targetIndex )
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
		}
		
		private void RotateToVelocity( )
		{
			transform.rotation = Quaternion.LookRotation(currentVelocity);
		}

		private Vector3 GetTargetPos( int _index )
		{
			if ( targets == null || targets.Count == 0 )
			{
				Vector3 mousePosition = camera_.ScreenToWorldPoint(
					new Vector3(Input.mousePosition.x, Input.mousePosition.y, -camera_.transform.position.z)
				);
				mousePosition.z = 0;
				return mousePosition;
			}
			
			
			return targets[_index].gameObject.transform.position;
		}

		private void DrawHelpers( )
		{
			Debug.DrawRay( transform.position, currentVelocity * 5, Color.red );
		}
	}
}