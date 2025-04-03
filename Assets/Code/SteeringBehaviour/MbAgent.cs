using System;
using UnityEngine;

namespace SteeringBehaviour
{
	public class MbAgent: MonoBehaviour
	{
		public Transform target;
		public float mass = 1;
		[Space] 
		public float steeringForceValue = 1f;
		
		private Behaviours behaviours_ = new Behaviours( );
		private Vector3 currentVelocity_ = Vector3.zero;

		private void Update( )
		{
			//var steeringForce = behaviours_.GetFleeForce( currentVelocity_, transform.position, GetTargetPos(  ), steeringForceValue, mass );
			//var steeringForce = behaviours_.GetArriveForce( currentVelocity_, transform.position, GetTargetPos(  ), steeringForceValue, mass, 1f );
			var steeringForce = behaviours_.GetWanderForce( currentVelocity_, transform.position, transform.up, 5, 3, 1);
			
			Debug.Log( "steeringForce " + steeringForce.magnitude );
			Debug.Log( "currentVelocity " + currentVelocity_.magnitude );
			
			currentVelocity_ += steeringForce * Time.deltaTime;
			transform.position += currentVelocity_ * Time.deltaTime;
			RotateToVelocity(  );
			DrawHelpers(  );
		}
		
		private void RotateToVelocity( )
		{
			transform.rotation = Quaternion.LookRotation(currentVelocity_);
		}

		private Vector3 GetTargetPos( )
		{
			return target.position;
		}

		private void DrawHelpers( )
		{
			Debug.DrawRay( transform.position, currentVelocity_ * 5, Color.red );
		}
	}
}