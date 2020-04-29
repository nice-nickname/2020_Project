using UnityEngine;

public class Bullet : MonoBehaviour, IDamageDealer
{
	[SerializeField] private float Speed = 0f;
	[SerializeField] private int OriginDamage = 0;

	private Rigidbody2D RBody;

	private float StartTime;
	private float LifeDuration = 3f;

	public int Damage { get; private set; }

	public void DealDamage(IDamageReceiver receiver)
	{
		if (receiver != null)
		{
			int damage = Damage + Random.Range(-10, 20);
			Debug.Log(damage + " урона нанесено");
			receiver.ReceiveDamage(damage);
		}
	}

	private void Start()
	{
		StartTime = Time.time;
		Damage = OriginDamage;
		RBody = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		RBody.velocity = transform.right * Speed;
		if (Time.time - StartTime >= LifeDuration) Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.isTrigger == false)
		{
			DealDamage(collision.gameObject.GetComponent<IDamageReceiver>());
			Destroy(gameObject);
		}
	}
}