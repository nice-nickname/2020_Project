using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
	[SerializeField] private Item Item;
	[SerializeField] private Sprite __deafault;

	private Image Image;

	public bool IsActive { get; private set; } = false;
	public string Name { get => Item.Name; }

	private void Awake()
	{
		Image = GetComponent<Image>();
		__deafault = Image.sprite;
	}

	public void showItem(Item _item)
	{
		Item = _item;
		IsActive = true;
		Image.sprite = Item.Icon;
	}

	public void showDefault()
	{
		Item = null;
		Image.sprite = __deafault;
	}
}