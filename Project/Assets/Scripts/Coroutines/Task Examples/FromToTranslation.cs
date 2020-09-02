using UnityEngine;

public class FromToTranslation : MonoBehaviour, ICoroutinedTask
{
	[SerializeField] private Vector3 From = Vector3.zero;
	[SerializeField] private Vector3 To = Vector3.zero;
	[SerializeField] private Vector3 Direction = Vector3.zero;


	private void Start()
	{
		transform.position = From;
	}

	void ICoroutinedTask.Task()
	{
		transform.position += Direction * Time.deltaTime;
	}

	bool ICoroutinedTask.TaskFinished()
	{
		if (transform.position.x > To.x ||
			transform.position.y > To.y ||
			transform.position.z > To.z)
		{
			return true;
		}
		return false;
	}
}
