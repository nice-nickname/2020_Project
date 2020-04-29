using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class Item : BaseItem
{
	public override bool Usable => false;
}