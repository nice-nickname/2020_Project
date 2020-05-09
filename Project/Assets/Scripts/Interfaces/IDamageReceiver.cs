public interface IDamageReceiver
{
	Health Health { get; }
	void ReceiveDamage(int damage);
}