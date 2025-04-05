using System;
using UnityEngine;

namespace SteeringBehaviour
{
	public class MbAgent: MonoBehaviour
	{
		public MbAgent target;
		public float mass = 1;

		[Space] 
		public float maxForceValue = 1f;

		public EBehaviourType behaviourType;
		
		public Vector3 currentVelocity { get; private set; }

		private Camera camera_;

		private void Start( )
		{
			camera_ = Camera.main;
		}

		private void Update( )
		{
			var steeringForce = GetBehaviourForce( );
			
			Debug.Log( "steeringForce " + steeringForce.magnitude );
			Debug.Log( "currentVelocity " + currentVelocity.magnitude );
			
			currentVelocity += steeringForce * Time.deltaTime;
			transform.position += currentVelocity * Time.deltaTime;
			RotateToVelocity(  );
			DrawHelpers(  );
		}

		private Vector3 GetBehaviourForce( )
		{
			switch ( behaviourType )
			{
				case EBehaviourType.Seek:
					return Behaviours.GetSeekForce( currentVelocity, transform.position, GetTargetPos(  ), maxForceValue, mass);
				case EBehaviourType.Flee:
					return Behaviours.GetFleeForce( currentVelocity, transform.position, GetTargetPos(  ), maxForceValue, mass );
				case EBehaviourType.Arrive:
					return Behaviours.GetArriveForce( currentVelocity, transform.position, GetTargetPos(  ), maxForceValue, mass, 1f );
				case EBehaviourType.Pursuit:
					return Behaviours.GetPursuitForce( currentVelocity, transform.position, target.currentVelocity, GetTargetPos(  ),  maxForceValue, mass  );
					break;
				case EBehaviourType.Evading:
					return Behaviours.GetEvadingForce( currentVelocity, transform.position, target.currentVelocity, GetTargetPos(  ),  maxForceValue, mass  );
				default:
					return Vector3.zero;
			}
			
			return Vector3.zero;
		}
		
		private void RotateToVelocity( )
		{
			transform.rotation = Quaternion.LookRotation(currentVelocity);
		}

		private Vector3 GetTargetPos( )
		{
			if ( target == null )
			{
				Vector3 mousePosition = camera_.ScreenToWorldPoint(
					new Vector3(Input.mousePosition.x, Input.mousePosition.y, -camera_.transform.position.z)
				);
				mousePosition.z = 0;
				return mousePosition;
			}
			
			return target.gameObject.transform.position;
		}

		private void DrawHelpers( )
		{
			Debug.DrawRay( transform.position, currentVelocity * 5, Color.red );
		}
	}
}