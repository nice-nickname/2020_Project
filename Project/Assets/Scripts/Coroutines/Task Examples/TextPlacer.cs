using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPlacer : MonoBehaviour, ICoroutinedTask
{
	[SerializeField] private Text Text;
	[SerializeField] private string PlaceText;

	private bool Finished = false;

	public void Task()
	{
		Text.text = PlaceText;
		Finished = true;
	}

	public bool TaskFinished()
	{
		if (Finished)
		{
			Finished = false;
			return true;
		}
		return false;
	}
}
