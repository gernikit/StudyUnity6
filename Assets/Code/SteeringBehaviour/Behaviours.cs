using UnityEditor;
using UnityEngine;

namespace SteeringBehaviour
{
	public static class Behaviours
	{
		public static Vector3 GetSeekForce( Vector3 _currentVelocity, Vector3 _objectPosition, Vector3 _targetPosition, float _forceValue, float _objectMass )
		{
			Vector3 desiredVelocity = (_targetPosition - _objectPosition).normalized * _forceValue;
			Vector3 steeringForce = desiredVelocity - _currentVelocity;
			return steeringForce / _objectMass;
		}
		
		public static Vector3 GetFleeForce( Vector3 _currentVelocity, Vector3 _objectPosition, Vector3 _targetPosition, float _maxForce, float _objectMass )
		{
			Vector3 desiredVelocity = (_objectPosition - _targetPosition).normalized * _maxForce;
			Vector3 steeringForce = desiredVelocity - _currentVelocity;
			return steeringForce / _objectMass;
		}
		
		public static Vector3 GetArriveForce( Vector3 _currentVelocity, Vector3 _objectPosition, Vector3 _targetPosition, float _forceValue, float _objectMass, float _slowingDistance )
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
			
			return steeringForce / _objectMass;
		}

		public static Vector3 GetPursuitForce( Vector3 _currentVelocity, Vector3 _objectPosition, Vector3 _targetVelocity, Vector3 _targetPosition, float _forceValue, float _objectMass )
		{
			var anticipationRatio = ( _targetPosition - _objectPosition ).magnitude / _targetVelocity.magnitude;
			var targetFuturePosition = _targetPosition + _targetVelocity * anticipationRatio;
			return GetSeekForce( _currentVelocity, _objectPosition, targetFuturePosition, _forceValue, _objectMass );
		}
		
		public static Vector3 GetEvadingForce( Vector3 _currentVelocity, Vector3 _objectPosition, Vector3 _targetVelocity, Vector3 _targetPosition, float _forceValue, float _objectMass )
		{
			var anticipationRatio = (_targetPosition - _objectPosition).magnitude / _targetVelocity.magnitude;
			var targetFuturePosition = _targetPosition + _targetVelocity * anticipationRatio;
			Debug.DrawLine( _objectPosition, targetFuturePosition );
			return GetFleeForce( _currentVelocity, _objectPosition, targetFuturePosition, _forceValue, _objectMass );
		}
	}
}