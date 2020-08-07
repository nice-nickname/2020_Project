using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
	[SerializeField] private float Speed = 0f;
	[SerializeField] [Range(0f, 2f)] private float epsilon = 0f;

	private BoxCollider2D BoxCollider;
	private Vector3 LeftPivot;
	private Vector3 RightPivot;
	private Vector3 DeafulDirection;

	private void Awake()
	{
		BoxCollider = GetComponent<BoxCollider2D>();
		GetBounds(ref LeftPivot, ref RightPivot);
		DeafulDirection = Vector3.right;
	}

	private void FixedUpdate()
	{
		MoveOnPlatform(RightPivot, LeftPivot);
	}

	private void MoveOnPlatform(Vector3 RightPivot, Vector3 LeftPivot)
	{
		Move(DeafulDirection);

		if (transform.position.x <= LeftPivot.x)
		{
			DeafulDirection = Vector3.right;
		}
		else if (transform.position.x >= RightPivot.x)
		{
			DeafulDirection = Vector3.left;
		}
	}
	private void Move(Vector3 direction)
	{
		transform.position = Vector3.Lerp(transform.position, transform.position + direction, Speed * Time.fixedDeltaTime);
	}

	private void GetBounds(ref Vector3 leftPivot, ref Vector3 rightPivot)
	{
		Vector2 CharactersMinCenter = new Vector2(transform.position.x, transform.position.y - BoxCollider.bounds.size.y / 2);
		RaycastHit2D hit = Physics2D.Raycast(CharactersMinCenter, Vector2.down);
		rightPivot = new Vector3(hit.collider.bounds.max.x - epsilon, hit.collider.bounds.max.y, transform.position.z);
		leftPivot = new Vector3(hit.collider.bounds.min.x + epsilon, hit.collider.bounds.max.y, transform.position.z);
	}
}