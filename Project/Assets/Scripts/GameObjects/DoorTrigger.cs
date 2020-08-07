using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
	private Door Door;

	private bool PlayerInArea = false;

	private void Awake()
	{
		Door = GetComponentInParent<Door>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		// TODO: Заменить GetComponent на поиск по тегу
		// TODO: TODO: Создать тэги...
		if (collision.gameObject.GetComponent<IMovable>() != null)
		{
			PlayerInArea = true;
		}
	}
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (Input.GetButtonDown("Interact") && PlayerInArea) 
		{
			Door.ChangeCondition();
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		PlayerInArea = false;
	}
}
