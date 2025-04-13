using System;
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

		public void ApplyForce( float _deltaTime )
		{
			//Maybe use mass for velocity in FUTURE
			var clampedSteering = Vector3.ClampMagnitude( steeringForce, maxForceValue );
			entity.AddForce( clampedSteering * _deltaTime );
		}

		public void ResetForce( )
		{
			steeringForce = Vector3.zero;
		}

		public void SetMaxForceValue( float _maxValue )
		{
			maxForceValue = _maxValue;
		}

		public void AddSeek( Vector3 _targetPosition, float _forceValue )
		{
			steeringForce += SteeringForces.GetSeekForce( 
				entity.currentVelocity, 
				entity.position, 
				_targetPosition,
				_forceValue);
		}
		
		public void AddFlee( Vector3 _targetPosition, float _forceValue )
		{
			steeringForce += SteeringForces.GetFleeForce( 
				entity.currentVelocity, 
				entity.position, 
				_targetPosition,
				_forceValue );
		}
		
		public void AddArrive( Vector3 _targetPosition, float _forceValue, float _slowingDistance )
		{
			steeringForce += SteeringForces.GetArriveForce( 
				entity.currentVelocity, 
				entity.position, 
				_targetPosition,
				_forceValue,
				_slowingDistance);
		}
		
		public void AddPursuit( AMovementEntity _target, float _forceValue )
		{
			steeringForce += SteeringForces.GetPursuitForce( 
				entity.currentVelocity, 
				entity.position, 
				_target.currentVelocity,
				_target.position,
				_forceValue);
		}
		
		public void AddAvoid( AMovementEntity _target, float _forceValue )
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