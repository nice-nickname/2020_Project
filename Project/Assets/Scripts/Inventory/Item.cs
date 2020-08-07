using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class Item : ScriptableObject
{
	public ItemTypes Type;
	public string Name;
	public string Description;
	public Sprite Icon;
}