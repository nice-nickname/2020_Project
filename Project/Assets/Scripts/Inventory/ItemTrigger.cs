using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
	[SerializeField] private Item item = null;
	
	private bool PlayerInArea;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		PlayerInArea = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		PlayerInArea = false;
	}

	private void Update()
	{
		if (PlayerInArea && item != null)
		{
			if (Input.GetButtonDown("Interact"))
			{
				Inventory.instance.AddItem(item);
				Destroy(gameObject);
			}
		}
	}
}
