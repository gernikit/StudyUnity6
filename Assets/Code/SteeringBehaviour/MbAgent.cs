using UnityEngine;

namespace SteeringBehaviour
{
	public class MbAgent: MonoBehaviour
	{
		public float moveSpeed;
		public Transform target;
		public Camera camera;

		public void Update( )
		{
			var direction = GetTargetPos( ) - transform.position;

			if ( direction.magnitude >= 0.1 )
			{
				Vector3 velocity = ( direction ).normalized * moveSpeed;
				transform.position += velocity;
			}
		}

		public Vector3 GetTargetPos( )
		{
			if ( target != null )
				return target.position;
			
			Vector3 mousePosition = camera.ScreenToWorldPoint(
				new Vector3(Input.mousePosition.x, Input.mousePosition.y, -camera.transform.position.z)
			);
			mousePosition.z = 0;
			Debug.Log( mousePosition );
			return mousePosition;
		}
	}
}