using UnityEngine;

namespace SteeringBehaviour
{
	public class SeekBehaviour
	{
		public Vector3 GetSteeringForce( Vector3 _currentVelocity, Vector3 _desiredVelocity, float _forceValue, float _objectMass )
		{
			var steeringForce = _desiredVelocity - _currentVelocity;
			return Vector3.Normalize( steeringForce ) * _forceValue / _objectMass;
		}
	}
}