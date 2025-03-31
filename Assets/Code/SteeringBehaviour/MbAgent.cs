using System;
using UnityEngine;

namespace SteeringBehaviour
{
	public class MbAgent: MonoBehaviour
	{
		public Transform target;
		public float moveSpeed;
		public float mass = 1;
		[Space] 
		public float steeringForceValue = 1f;
		
		private SeekBehaviour seekBehaviour_ = new SeekBehaviour( );
		private Vector3 currentVelocity_ = Vector3.zero;

		private void Update( )
		{
			Seek( );
			RotateToVelocity(  );
			DrawHelpers(  );
		}

		private void Seek( )
		{
			var desiredVelocity = GetTargetPos( ) - transform.position;
			var steeringForce = seekBehaviour_.GetSteeringForce( currentVelocity_, desiredVelocity, steeringForceValue, mass );
			currentVelocity_ += steeringForce * Time.deltaTime;
			transform.position += currentVelocity_ * Time.deltaTime;
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
			Debug.DrawLine(transform.position, (transform.position + currentVelocity_) * 3, Color.red);
		}
	}
}