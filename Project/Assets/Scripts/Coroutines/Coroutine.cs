using System.Collections;

public class Coroutine
{
	public TaskStatus Status { get; private set; }

	private ICoroutinedTask TaskHandler;

	public Coroutine(ICoroutinedTask _taskHandler)
	{
		TaskHandler = _taskHandler;
		Status = TaskStatus.Waiting;
	}

	public IEnumerator Method()
	{
		Status = TaskStatus.Executed;

		while (TaskHandler.TaskFinished() == false)
		{
			TaskHandler.Task();
			yield return null;
		}

		Status = TaskStatus.Finished;
		yield break;
	}
}