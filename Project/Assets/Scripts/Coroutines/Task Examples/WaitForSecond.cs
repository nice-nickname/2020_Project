using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForSecond : MonoBehaviour, ICoroutinedTask
{
	[SerializeField] private float Cooldown = 0.5f;

	private float StartTime;

	private bool Finished = false;

	private void Awake()
	{
		StartTime = Time.time;
	}

	public void Task()
	{
		if (StartTime == 0)
		{
			StartTime = Time.time;
		}
		else
		{
			if (Time.time >= StartTime + Cooldown)
			{
				Finished = true;
			}
		}
	}

	public bool TaskFinished()
	{
		if (Finished)
		{
			Finished = false;
			StartTime = 0;
			return true;
		}
		return false;
	}
}
