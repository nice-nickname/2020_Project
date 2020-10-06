using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QStartGame : MonoBehaviour, ICoroutinedTask
{
	private bool Finished = false;

	public void Task()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		Finished = true;
	}

	public bool TaskFinished()
	{
		return Finished;
	}
}
