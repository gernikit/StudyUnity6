using UnityEngine;

namespace SteeringBehaviour
{
	public class MbMouseTarget : MonoBehaviour
	{
		[SerializeField] private Camera camera;

		private void Update( )
		{
			Vector3 mousePosition = camera.ScreenToWorldPoint(
				new Vector3(Input.mousePosition.x, Input.mousePosition.y, -camera.transform.position.z)
			);
			mousePosition.z = 0;
			Debug.Log( mousePosition );
			
			transform.position = mousePosition;
		}
	}
}