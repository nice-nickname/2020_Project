using UnityEngine;

public abstract class BaseItem : ScriptableObject
{
	public abstract bool Usable { get; }
	public ItemTypes Type;
	public string Name;
	public string Description;
	public Sprite Icon;
}