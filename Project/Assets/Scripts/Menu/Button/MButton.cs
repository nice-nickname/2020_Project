using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MButton : MonoBehaviour, ICoroutinedTask
{
	[SerializeField] private UnityEvent OnClick;

	private bool Finished = false;

	public void Task()
	{
		OnClick.Invoke();
		Finished = true;
	}

	public bool TaskFinished()
	{
		if(Finished)
		{
			Finished = false;
			return true;
		}
		return false;
	}
}
