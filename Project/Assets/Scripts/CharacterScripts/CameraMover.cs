using UnityEngine;

public class CameraMover : MonoBehaviour
{
	[Range(0f, 2f)] [SerializeField] private float SmoothTime = 0f;
	//[SerializeField] private float ViewPortFactor = 0f;
	[SerializeField] private Transform Target = null;
	//[SerializeField] private Vector3 ViewPortSize;

	private Vector3 Useless;
	//private Vector2 TargetPosition;
	//private Vector2 Distance;
	//private Camera Camera;

	private void Awake()
	{
		//Camera = GetComponent<Camera>();
		//TargetPosition = Target.position;
	}

	private void LateUpdate()
	{
		if (Target != null)
		{
			//ViewPortSize = (Camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)) - Camera.ScreenToWorldPoint(Vector2.zero)) * ViewPortFactor;

			//Distance = Target.position - transform.position;
			//if (Mathf.Abs(Distance.x) > ViewPortSize.x / 2)
			//{
			//	TargetPosition.x = Target.position.x - (ViewPortSize.x / 2 * Mathf.Sign(Distance.x));
			//}
			//if (Mathf.Abs(Distance.y) > ViewPortSize.y / 2)
			//{
			//	TargetPosition.y = Target.position.y - (ViewPortSize.y / 2 * Mathf.Sign(Distance.y));
			//}
			SmoothMove();
		}
	}

	private void SmoothMove()
	{
		float X = Mathf.SmoothDamp(transform.position.x, Target.position.x, ref Useless.x, SmoothTime);
		float Y = Mathf.SmoothDamp(transform.position.y, Target.position.y + 2f, ref Useless.y, SmoothTime);
		transform.position = new Vector3(X, Y, transform.position.z);
	}
}