using System.Collections;

class Coroutine
{
	public TaskStatus Status { get; private set; }

	private ICoroutinedTask TaskHandler;

	public Coroutine(ICoroutinedTask _class)
	{
		TaskHandler = _class;
		Status = TaskStatus.Waiting;
	}

	public IEnumerator Method()
	{
		Status = TaskStatus.Executed;

		while (true)
		{
			if (TaskHandler.Ended() == false)
			{
				TaskHandler.Task();
				yield return null;
			}
			else
			{
				break;
			}
		}

		Status = TaskStatus.Finished;
		yield break;
	}


}