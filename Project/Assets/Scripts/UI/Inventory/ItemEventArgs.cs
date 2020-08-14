using UnityEngine;
using UnityEngine.Events;

public class ItemEventArgs
{
	public UnityAction Click { get; private set; }
	public string Description { get; private set; }
	public Sprite Icon { get; private set; }
	public string Name { get; private set; }
	public ItemEventArgs(string description, string name, Sprite icon, UnityAction _click)
	{
		Description = description;
		Name = name;
		Icon = icon;
		Click = _click;
	}
}
