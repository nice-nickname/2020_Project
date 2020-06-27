using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPresenter : MonoBehaviour
{
	private Cell[] Cells;

	private void Awake()
	{
		Cells = GetComponentsInChildren<Cell>();
	}

	public void Append(Item _item)
	{
		foreach (var cell in Cells)
		{
			if (!cell.IsActive)
			{
				cell.showItem(_item);
				return;
			}
		}
	}

	public void Render(List<Item> items)
	{
		Item[] _items = items.ToArray();

		int length = _items.Length;

		if (_items.Length > Cells.Length)
		{
			length = Cells.Length;
		}

		for (int i = 0; i < length; i++)
		{
			Cells[i].showItem(_items[i]);
		}
	}
}
