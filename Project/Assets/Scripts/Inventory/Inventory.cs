using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public static Inventory instance { get; private set; }

	private List<BaseItem> Items;

	private bool IsOpen = false;
	private bool IsSorted = false;

	private void Awake()
	{
		Items = new List<BaseItem>();

		if (instance == null)
		{
			instance = this;
		}
		else if (instance == this)
		{
			Destroy(gameObject);
		}
	}

	public void AddItem(BaseItem item)
	{
		Items.Add(item);
		IsSorted = false;
		if (IsOpen)
		{
			UpdateInventory();
		}
	}

	public void UpdateInventory()
	{
		//  README: Только по открытию инвентаря мы рендерим инвентарь
		//  TODO: Возможно сделать так, чтобы элемент вставлялтся в самом InventoryUI
		//  А не каждый раз перерендерить список предметов
		if(!IsSorted)
		{
			Items.Sort((BaseItem a, BaseItem b) =>
			{
				if (a == null && b == null) return 0;
				else if (a == null) return -1;
				else if (b == null) return 1;
				else return a.Name.CompareTo(b.Name);
			});

			InventoryUI.instance.Clear();
			foreach (BaseItem i in Items)
			{
				InventoryUI.instance.RenderNewItem(i);
			}
			IsSorted = true;
		}
	}

	public void Show()
	{
		if (IsOpen)
		{
			Close();
		}
		else
		{
			Open();
		}
	}

	private void Open()
	{
		InventoryUI.instance.Open();
		UpdateInventory();

		IsOpen = true;
	}

	private void Close()
	{
		InventoryUI.instance.Close();

		IsOpen = false;
	}
}
