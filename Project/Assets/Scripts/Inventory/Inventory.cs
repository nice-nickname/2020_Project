using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public static Inventory instance;

	private ItemPresenter ItemUI;
	private List<Item> Items;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}

		ItemUI = GetComponent<ItemPresenter>();

		Items = new List<Item>();
	}

	public void AddItem(Item _item)
	{
		if (_item != null && ItemUI != null)
		{
			Items.Add(_item);
			ItemUI.Append(_item);
		}
	}

	public void RemoveItem(Item _item)
	{
		Items.Remove(_item);
	}
}
