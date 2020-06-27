using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
	private Canvas Parent;

	private void Awake()
	{
		Parent = GetComponent<Canvas>();
	}

	private void Update()
	{
		if (Input.GetButtonDown("Open"))
		{
			Parent.enabled = !Parent.enabled;
		}
	}

	public void ToMainMenu()
	{

	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void ToSettings()
	{

	}
}
