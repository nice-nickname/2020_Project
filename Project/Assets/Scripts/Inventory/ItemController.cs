using UnityEngine;

public class ItemController : MonoBehaviour
{
	[SerializeField] private BaseItem Item = null;

	private bool PlayerInArea = false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<Inventory>() != null)
		{
			PlayerInArea = true;
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (Input.GetButtonDown("Interact") && PlayerInArea) 
		{
			Inventory.instance.AddItem(Item);
			Destroy(gameObject);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		PlayerInArea = false;
	}
}
