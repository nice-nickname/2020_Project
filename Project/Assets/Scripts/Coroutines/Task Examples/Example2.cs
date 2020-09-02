using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example2 : MonoBehaviour, ICoroutinedTask
{
	private IMovable Body;
	private bool Flag = false;

	private void Awake()
	{
		Body = GetComponent<IMovable>();
	}

	public bool TaskFinished()
	{
		return Flag;
	}

	public void Task()
	{
		Body.Jump();
		Flag = true;
	}
}
