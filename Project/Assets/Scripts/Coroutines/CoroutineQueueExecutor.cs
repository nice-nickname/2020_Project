using System.Collections.Generic;
using UnityEngine;

public class CoroutineQueueExecutor : MonoBehaviour
{
	[SerializeField] private List<GameObject> CoroutinedTasksObjects;

	private Queue<Coroutine> Tasks;
	private Coroutine Current;

	private void Awake()
	{
		Tasks = new Queue<Coroutine>();

		foreach (var obj in CoroutinedTasksObjects)
		{
			PushCoroutine(obj.GetComponent<ICoroutinedTask>());
		}
	}

	void Update()
	{
		if (Tasks.Count == 0) return;

		if (Current == null)
		{
			Current = Tasks.Dequeue();

			StartCoroutine(Current.Method());
		}
		else
		{
			if (Current.Status == TaskStatus.Finished)
			{
				Current = null;
			}
		}
	}

	public void PushCoroutine(ICoroutinedTask Task)
	{
		Tasks.Enqueue(new Coroutine(Task));
	}
}
