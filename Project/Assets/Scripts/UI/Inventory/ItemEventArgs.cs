using UnityEngine;

public class ItemEventArgs
{
	public delegate void OnClick();

	public OnClick Click { get; private set; }
	public string Description { get; private set; }
	public Sprite Icon { get; private set; }
	public string Name { get; private set; }
	public ItemEventArgs(string description, string name, Sprite icon, OnClick _click)
	{
		Description = description;
		Name = name;
		Icon = icon;
		Click = _click;
	}
}
