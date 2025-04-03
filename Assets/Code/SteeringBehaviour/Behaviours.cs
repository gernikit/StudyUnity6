using UnityEngine;

namespace SteeringBehaviour
{
	public class Behaviours
	{
		public Vector3 GetSeekForce( Vector3 _currentVelocity, Vector3 _objectPosition, Vector3 _targetPosition, float _forceValue, float _objectMass )
		{
			var desiredVelocity = _targetPosition - _objectPosition;
			var steeringForce = desiredVelocity - _currentVelocity;
			return Vector3.Normalize( steeringForce ) * _forceValue / _objectMass;
		}
		
		public Vector3 GetFleeForce( Vector3 _currentVelocity, Vector3 _objectPosition, Vector3 _targetPosition, float _forceValue, float _objectMass )
		{
			var desiredVelocity = _objectPosition - _targetPosition;
			var steeringForce = desiredVelocity - _currentVelocity;
			return Vector3.Normalize( steeringForce ) * _forceValue / _objectMass;
		}
		
		public Vector3 GetArriveForce( Vector3 _currentVelocity, Vector3 _objectPosition, Vector3 _targetPosition, float _forceValue, float _objectMass, float _slowingDistance )
		{
			var desiredVelocity = (_targetPosition - _objectPosition);
			float distance = desiredVelocity.magnitude;
			
			Debug.Log( "dictance " + distance );
			
			desiredVelocity.Normalize(  );
			
			if (distance <= _slowingDistance)
			{
				float speedFactor = distance / _slowingDistance;
				desiredVelocity *= _forceValue * speedFactor;
			}
			else
			{
				desiredVelocity *= _forceValue;
			}
			
			var steeringForce = desiredVelocity - _currentVelocity;
			
			return steeringForce / _objectMass;
		}
		
		public Vector3 GetWanderForce(Vector3 _currentVelocity, Vector3 _objectPosition, Vector3 _forwardDirection, 
			float _wanderRadius, float _wanderDistance, float _jitterAmount)
		{
			/*// Apply random jitter in XY space (Z should always be 0)
			Vector3 randomJitter = new Vector3(
				Random.Range(-1f, 1f),
				Random.Range(-1f, 1f), // Only XY changes
				0f                     // Keep Z constant
			) * _jitterAmount;

			// Smoothly adjust wander target instead of jumping
			wanderTarget += randomJitter;
			wanderTarget = wanderTarget.normalized * _wanderRadius;

			// Move the wander circle in front of the AI
			Vector3 targetPosition = _objectPosition + (_forwardDirection.normalized * _wanderDistance) + wanderTarget;

			// Ensure movement is only in XY
			targetPosition.z = _objectPosition.z;

			// Compute desired velocity
			Vector3 desiredVelocity = (targetPosition - _objectPosition).normalized * _currentVelocity.magnitude;

			// Ensure movement is only in XY
			desiredVelocity.z = 0;

			// Calculate steering force
			return desiredVelocity - _currentVelocity;*/

			return Vector3.zero;
		}
	}
}