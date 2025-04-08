using UnityEngine;

namespace SteeringBehaviour
{
	public static class SteeringForces
	{
		public static Vector3 GetSeekForce( Vector3 _currentVelocity, Vector3 _objectPosition, Vector3 _targetPosition, float _forceValue )
		{
			Vector3 desiredVelocity = (_targetPosition - _objectPosition).normalized * _forceValue;
			Vector3 steeringForce = desiredVelocity - _currentVelocity;
			return steeringForce;
		}
		
		public static Vector3 GetFleeForce( Vector3 _currentVelocity, Vector3 _objectPosition, Vector3 _targetPosition, float _forceValue )
		{
			Vector3 desiredVelocity = (_objectPosition - _targetPosition).normalized * _forceValue;
			Vector3 steeringForce = desiredVelocity - _currentVelocity;
			return steeringForce;
		}
		
		public static Vector3 GetArriveForce( Vector3 _currentVelocity, Vector3 _objectPosition, Vector3 _targetPosition, float _forceValue, float _slowingDistance )
		{
			var desiredVelocity = (_targetPosition - _objectPosition);
			float distance = desiredVelocity.magnitude;

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
			
			return steeringForce;
		}

		public static Vector3 GetPursuitForce( Vector3 _currentVelocity, Vector3 _objectPosition, Vector3 _targetVelocity, Vector3 _targetPosition, float _forceValue )
		{
			var anticipationRatio = ( _targetPosition - _objectPosition ).magnitude / _targetVelocity.magnitude;
			var targetFuturePosition = _targetPosition + _targetVelocity * anticipationRatio;
			return GetSeekForce( _currentVelocity, _objectPosition, targetFuturePosition, _forceValue );
		}
		
		public static Vector3 GetEvadingForce( Vector3 _currentVelocity, Vector3 _objectPosition, Vector3 _targetVelocity, Vector3 _targetPosition, float _forceValue )
		{
			var anticipationRatio = (_targetPosition - _objectPosition).magnitude / _targetVelocity.magnitude;
			var targetFuturePosition = _targetPosition + _targetVelocity * anticipationRatio;
			Debug.DrawLine( _objectPosition, targetFuturePosition );
			return GetFleeForce( _currentVelocity, _objectPosition, targetFuturePosition, _forceValue );
		}
	}
}