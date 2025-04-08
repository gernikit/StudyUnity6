using UnityEngine;

namespace SteeringBehaviour
{
	public class SteeringForce
	{
		public AMovementEntity entity { get; private set; }
		public Vector3 steeringForce { get; private set; }
		public float maxForceValue { get; private set; } = float.MaxValue;

		public void Init( AMovementEntity _movementEntity )
		{
			entity = _movementEntity;
		}

		public void Update( )
		{
			//Maybe use mass for velocity in FUTURE
			var clampedSteering = Vector3.ClampMagnitude( steeringForce, maxForceValue );
			entity.AddForce( clampedSteering );
		}

		public void SetMaxForceValue( float _maxValue )
		{
			maxForceValue = _maxValue;
		}

		public void Seek( Vector3 _targetPosition, float _forceValue )
		{
			steeringForce += SteeringForces.GetSeekForce( 
				entity.currentVelocity, 
				entity.position, 
				_targetPosition,
				_forceValue);
		}
		
		public void Flee( Vector3 _targetPosition, float _forceValue )
		{
			steeringForce += SteeringForces.GetFleeForce( 
				entity.currentVelocity, 
				entity.position, 
				_targetPosition,
				_forceValue );
		}
		
		public void Arrive( Vector3 _targetPosition, float _forceValue, float _slowingDistance )
		{
			steeringForce += SteeringForces.GetArriveForce( 
				entity.currentVelocity, 
				entity.position, 
				_targetPosition,
				_forceValue,
				_slowingDistance);
		}
		
		public void Pursuit( AMovementEntity _target, float _forceValue )
		{
			steeringForce += SteeringForces.GetPursuitForce( 
				entity.currentVelocity, 
				entity.position, 
				_target.currentVelocity,
				_target.position,
				_forceValue);
		}
		
		public void Avoid( AMovementEntity _target, float _forceValue )
		{
			steeringForce += SteeringForces.GetEvadingForce( 
				entity.currentVelocity, 
				entity.position, 
				_target.currentVelocity,
				_target.position,
				_forceValue);
		}
	}
}