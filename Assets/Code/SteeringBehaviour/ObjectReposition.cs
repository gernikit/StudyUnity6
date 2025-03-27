using UnityEngine;

namespace SteeringBehaviour
{
	public class ObjectReposition : MonoBehaviour
	{
		public Camera mainCamera;

		void Start()
		{
			if (mainCamera == null)
				mainCamera = Camera.main;
		}

		void Update()
		{
			Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

			if (viewportPosition.x < 0 || viewportPosition.x > 1 || 
			    viewportPosition.y < 0 || viewportPosition.y > 1)
			{
				Vector3 centerWorldPosition = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, viewportPosition.z));
				centerWorldPosition.z = transform.position.z;
				transform.position = centerWorldPosition;
			}
		}
	}
}