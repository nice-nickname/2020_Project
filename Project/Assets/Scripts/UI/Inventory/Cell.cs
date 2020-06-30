using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
	[SerializeField] private Item Item;
	[SerializeField] private Sprite __deafault;
	[SerializeField] private Vector3 Position = Vector3.zero;

	private Image Image;
	private ItemEventArgs _Args;
	private Button Button;

	public bool IsActive { get; private set; } = false;

	private void Awake()
	{

		Button = GetComponent<Button>();
		Image = GetComponent<Image>();

		__deafault = Image.sprite;
	}

	public void showItem(Item _item)
	{
		Item = _item;
		IsActive = true;
		Image.sprite = Item.Icon;
		
		_Args = new ItemEventArgs(_item.Description, _item.Name, _item.Icon, Position, () => {
			ItemDescriptionCanvas.instance.Hide();
			this.showDefault();
		});

		Button.onClick.AddListener(OnClick);
	}

	public void showDefault()
	{
		Item = null;
		Image.sprite = __deafault;
		IsActive = false;
	}

	public void OnClick()
	{
		ItemDescriptionCanvas.instance.Show(_Args);
	}
}