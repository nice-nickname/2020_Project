using UnityEngine;

public class CameraMover : MonoBehaviour
{
	[Range(0f, 2f)] [SerializeField] private float SmoothTime = 0f;

	private Transform Target;

	private Vector3 Useless;

	private void Awake()
	{
		Target = GameObjectHandler.instance.CameraTarget;
	}

	private void LateUpdate()
	{
		if (Target != null)
		{
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