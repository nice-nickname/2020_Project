using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "New Usable Item")]
class ItemUsable : BaseItem
{
	[SerializeField] private UnityEvent Use = null;
	public override bool Usable => true;
	public UnityEvent getEvent() => Use;
}
