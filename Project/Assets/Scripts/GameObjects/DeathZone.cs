using UnityEngine;

public class DeathZone : MonoBehaviour, IDamageDealer
{
	public int Damage { get; private set; } = int.MaxValue;

	public void DealDamage(IDamageReceiver receiver)
	{
		if (receiver != null)
		{
			receiver.ReceiveDamage(int.MaxValue);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		DealDamage(collision.gameObject.GetComponent<IDamageReceiver>());
	}
}
