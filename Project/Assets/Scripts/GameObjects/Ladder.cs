using UnityEngine;

public class Ladder : MonoBehaviour
{
	[SerializeField] private float CooldownTime = 0.5f;

	private bool IsClimbing = false;

	private RigidbodyConstraints2D DeafulContrains;
	private IMovable MovableObject;
	private Rigidbody2D RBody;
	private Cooldown Cooldown;

	private void Awake()
	{
		Cooldown = new Cooldown(CooldownTime);
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (Input.GetButtonDown("Interact"))
		{
			ChangeCondition(collision);
		}
		else if (IsClimbing)
		{
			MoveOnLadder(Input.GetAxisRaw("Vertical") * MovableObject.Speed);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		UnFix();
	}
	
	private void FreezeOx()
	{
		DeafulContrains = RBody.constraints;
		RBody.constraints = RigidbodyConstraints2D.FreezePositionX;
	}

	private void UnFreezeOx()
	{
		RBody.constraints = DeafulContrains;
	}

	private void MoveOnLadder(float direction)
	{
		RBody.velocity = Vector2.up * direction;
	}

	private void FixOnLadder(Collider2D collision)
	{
		MovableObject = collision.gameObject.GetComponent<IMovable>();
		if (MovableObject != null)
		{
			RBody = collision.gameObject.GetComponent<Rigidbody2D>();
			RBody.gravityScale = 0;

			FreezeOx();

			IsClimbing = true;
		}
	}

	private void UnFix()
	{
		if (IsClimbing)
		{
			IsClimbing = false;

			UnFreezeOx();

			RBody.gravityScale = 1;
			RBody = null;
		}
	}

	private void ChangeCondition(Collider2D collision)
	{
		if (Cooldown.ActionReady()) 
		{
			if (IsClimbing)
			{
				UnFix();
			}
			else
			{
				FixOnLadder(collision);
			}
		}
	}
}