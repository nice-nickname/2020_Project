using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPlacerSmart : MonoBehaviour, ICoroutinedTask
{
	[SerializeField] private Text Text;
	[SerializeField] private string PlaceText;

	private bool Finished = false;
	private int Index = 0;

	public void Task()
	{
		if(Index == PlaceText.Length)
		{
			Finished = true;
			return;
		}
		Text.text += PlaceText[Index];
		Index++; 
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
