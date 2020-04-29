using UnityEngine;

public class Character : MonoBehaviour, IDamageReceiver, IMovable
{
	[SerializeField] private float NormalSpeed = 0f;
	[SerializeField] private float SpeedMultiplier = 0f;
	[SerializeField] private float JumpForce = 0f;

	private Rigidbody2D RBody;

	private Quaternion RightFlip;
	private Quaternion LeftFlip;

	public int Health { get; private set; } = 100;

	private bool Grounded
	{
		get
		{
			if (RBody.velocity.y == 0)
				return true;
			return false;
		}
	}

	public float Speed
	{
		get
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				return NormalSpeed * SpeedMultiplier;
			}
			return NormalSpeed;
		}
	}

	private void Awake()
	{
		RBody = GetComponent<Rigidbody2D>();

		RightFlip = new Quaternion(0f, 0f, 0f, 0f);
		LeftFlip = new Quaternion(0f, 180f, 0f, 0f);
	}

	public void Move(float direction)
	{
		RBody.velocity = new Vector2(direction * Speed, RBody.velocity.y);
		TurnCharacter(direction);
	}

	public void Jump()
	{
		if (Grounded)
		{
			RBody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
		}
	}

	public void ReceiveDamage(int damage)
	{
		Health -= damage;
		Debug.Log(Health + "/100 здоровья осталось");
		if (Health <= 0)
			KillMe();
	}

	public void KillMe()
	{
		Health = 0;
		Destroy(this.gameObject);
	}

	private void TurnCharacter(float direction)
	{
		if (direction < 0f)
		{
			transform.rotation = LeftFlip;
		}
		else if (direction > 0f)
		{
			transform.rotation = RightFlip;
		}
	}
}