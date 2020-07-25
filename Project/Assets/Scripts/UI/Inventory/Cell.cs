using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
	[SerializeField] private Item Item;
	[SerializeField] private Sprite _default;

	private Image Image;
	private Button Click;

	private ItemEventArgs Args;

	private Color OldColor, NewColor;

	public bool IsActive { get; private set; } = false;

	private void Awake()
	{
		Click = GetComponent<Button>();
		Image = GetComponent<Image>();

		OldColor = Image.color;
		NewColor = OldColor;
		NewColor.a = 1f;

		_default = Image.sprite;
	}

	public void setItem(Item _item)
	{
		Item = _item;
		IsActive = true;
		Image.sprite = Item.Icon;
		Image.color = NewColor;

		Args = new ItemEventArgs(_item.Description, _item.Name, _item.Icon, setDefault);

		Click.onClick.AddListener(ShowDescription);
	}

	public void setDefault()
	{
		Inventory.instance.RemoveItem(Item.Name);
		Item = null;
		Image.sprite = _default;
		Image.color = OldColor;
		IsActive = false;
	}

	public void ShowDescription()
	{
		if (IsActive)
			ItemDescriptionCanvas.instance.Show(Args);
	}
}