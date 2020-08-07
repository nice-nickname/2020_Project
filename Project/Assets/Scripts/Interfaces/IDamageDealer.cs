public interface IDamageDealer
{
	int Damage { get; }
	void DealDamage(IDamageReceiver receiver);
}