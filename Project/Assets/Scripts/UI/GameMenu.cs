using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
	private Canvas Canvas;

	private void Awake()
	{
		Canvas = GetComponent<Canvas>();
		Canvas.enabled = false;
	}

	private void Update()
	{
		if (Input.GetButtonDown("Open"))
		{
			Canvas.enabled = !Canvas.enabled;
			ItemDescriptionCanvas.instance.Hide();
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
