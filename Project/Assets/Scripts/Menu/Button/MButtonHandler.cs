using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MButtonHandler : MonoBehaviour
{
	private ToOpaque ToOpaque;
	private ToTransparent ToTrasparent;
	private MButton MButton;

	private void Start()
	{
		ToTrasparent = GetComponent<ToTransparent>();
		ToOpaque = GetComponent<ToOpaque>();
		MButton = GetComponent<MButton>();
	}

	public void Execute()
	{
		CoroutineQueueExecutor.instance.PushCoroutine(ToOpaque);
		CoroutineQueueExecutor.instance.PushCoroutine(MButton);
		CoroutineQueueExecutor.instance.PushCoroutine(ToTrasparent);
	}
}
