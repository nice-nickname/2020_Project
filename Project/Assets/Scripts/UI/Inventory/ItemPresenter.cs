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
}
