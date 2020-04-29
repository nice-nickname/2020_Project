public interface IDamageReceiver
{
	int Health { get; }
	void ReceiveDamage(int damage);
	void KillMe();

}