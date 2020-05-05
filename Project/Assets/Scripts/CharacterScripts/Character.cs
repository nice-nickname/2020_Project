﻿using UnityEngine;

public class Character : MonoBehaviour, IDamageReceiver, IMovable
{
	[SerializeField] private float NormalSpeed = 0f;
	[SerializeField] private float SpeedMultiplier = 0f;
	[SerializeField] private float JumpForce = 0f;
	[SerializeField] private float FallingDownScale = 0f;

	private Rigidbody2D RBody;

	private Quaternion RightFlip;
	private Quaternion LeftFlip;

	public Health Health { get; private set; }

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

		Health = new Health(100);
	}

	private void FixedUpdate()
	{
		if(RBody.velocity.y < 0)
		{
			RBody.velocity *= FallingDownScale;
		}
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
		Health.UpdateValue(damage);
		if (!Health.Alive())
			Destroy(gameObject);
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