using UnityEngine;

public class DialogController : MonoBehaviour
{
	private Dialog Dialog;

	private void Awake()
	{
		Dialog = GetComponent<Dialog>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Dialog.StartTalk();
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		Dialog.HoldPosition();
		if (Input.GetButtonDown("Interact") && Dialog.IsCreated)
		{
			Dialog.Talk();
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		Dialog.EndTalking();
	}
}