using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ItemEventArgs
{
	public delegate void OnClick();

	public OnClick Click { get; private set; }
	public string Description { get; private set; }
	public Sprite Icon { get; private set; }
	public string Name { get; private set; }
	public Vector3 Position { get; private set; }

	public ItemEventArgs(string description, string name, Sprite icon, Vector3 position, OnClick function)
	{
		Description = description;
		Name = name;
		Icon = icon;
		Position = position + new Vector3(1.5f, -1.5f, 0f);
		Click = function;
	}
}
