using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
	[SerializeField] private string Promt = "F, чтобы говорить с персонажем";

	private Dialog Dialog;

	private void Awake()
	{
		Dialog = GetComponent<Dialog>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Dialog.StartTalk();
		Dialog.HoldPosition();
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		HelpOnTriggerEvent.instance.SetText(Promt);
		if (Input.GetButtonDown("Interact") && Dialog.IsCreated)
		{
			Dialog.Talk();
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		HelpOnTriggerEvent.instance.Unset();
		Dialog.EndTalking();
	}
}