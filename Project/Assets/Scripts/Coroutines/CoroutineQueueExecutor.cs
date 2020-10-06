using System.Collections.Generic;
using UnityEngine;

public class CoroutineQueueExecutor : MonoBehaviour
{
	[SerializeField] List<GameObject> InitializerList;

	private Queue<Coroutine> Tasks;
	private Coroutine Current;

	public static CoroutineQueueExecutor instance;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}

		ICoroutinedTask[] coroutinedTask = GetComponents<ICoroutinedTask>();

		Tasks = new Queue<Coroutine>();

		foreach (var item in coroutinedTask)
		{
			PushCoroutine(item);
		}

		foreach (var item in InitializerList)
		{
			var task = item.GetComponent<ICoroutinedTask>();
			PushCoroutine(task);
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
