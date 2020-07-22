using UnityEngine;

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
				cell.setItem(_item);
				return;
			}
		}
	}

	public static Vector3 StartPoint = Vector3.zero;
}
