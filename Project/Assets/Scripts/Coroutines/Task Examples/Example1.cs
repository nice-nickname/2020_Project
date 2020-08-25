using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example1 : MonoBehaviour, ICoroutinedTask
{
	private Rigidbody2D RBody;

	private void Awake()
	{ 
		RBody = GetComponent<Rigidbody2D>();
	}

	public bool TaskFinished()
	{
		return transform.position.x > 10f;
	}

	public void Task()
	{
		RBody.AddForce(Vector2.right * 100f, ForceMode2D.Force);
	}
}
