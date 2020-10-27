using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
	[SerializeField] private float endY = 0;
	[SerializeField] private float Speed = 0;

	private bool Move = false;
	private bool IsPlayerInArea = false;
	private Transform transform;
	private Rigidbody2D body;

	private void Awake()
	{
		transform = GetComponent<Transform>();
	}

	private void Update()
	{
		if (IsPlayerInArea && Input.GetKeyDown(KeyCode.F))
		{
			Move = true;
			body.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
		}

		if (transform.position.y <= endY)
		{
			Move = false;
			body.constraints = RigidbodyConstraints2D.FreezeRotation;
		}

		if (Move)
		{
			transform.Translate(Vector3.down * Speed * Time.deltaTime);
			Vector3 pos = body.transform.position;
			pos.y = transform.position.y + 1.5f;
			body.transform.position = pos;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<IMovable>() != null)
		{
			IsPlayerInArea = true;
			body = collision.gameObject.GetComponent<Rigidbody2D>();
			HelpOnTriggerEvent.instance.SetText("F, чтобы использовать лифт");
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<IMovable>() != null)
		{
			IsPlayerInArea = false;
			HelpOnTriggerEvent.instance.Unset();
		}
	}
}
