using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetTextQ : MonoBehaviour, ICoroutinedTask
{
	[SerializeField] private Text ToReset;

	private bool Finished = false;

	public void Task()
	{
		ToReset.text = "";
		Finished = true;
	}

	public bool TaskFinished()
	{
		return Finished;
	}
}
