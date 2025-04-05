using UnityEngine;

namespace SteeringBehaviour
{
	public class ObjectReposition : MonoBehaviour
	{
		public Camera mainCamera;

		private Vector3 startPos_;

		void Start()
		{
			if (mainCamera == null)
				mainCamera = Camera.main;
			
			startPos_ = transform.position;
		}

		void Update()
		{
			Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

			if (viewportPosition.x < 0 || viewportPosition.x > 1 || 
			    viewportPosition.y < 0 || viewportPosition.y > 1)
			{
				transform.position = startPos_;
			}
		}
	}
}