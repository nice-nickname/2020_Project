using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
	[SerializeField] private Item Item;
	[SerializeField] private Sprite __deafault;

	private Image Image;
	private Button Click;
	private RectTransform Rect;

	private ItemEventArgs _Args;

	public bool IsActive { get; private set; } = false;

	private void Awake()
	{
		Click = GetComponent<Button>();
		Image = GetComponent<Image>();
		Rect = GetComponent<RectTransform>();

		__deafault = Image.sprite;
	}

	public void setItem(Item _item)
	{
		Item = _item;
		IsActive = true;
		Image.sprite = Item.Icon;

		_Args = new ItemEventArgs(_item.Description, _item.Name, _item.Icon, null);

		Click.onClick.AddListener(ShowDescription);
	}

	public void setDefault()
	{
		Item = null;
		Image.sprite = __deafault;
		IsActive = false;
	}

	public void ShowDescription() => ItemDescriptionCanvas.instance.Show(this._Args);
}