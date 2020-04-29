using UnityEngine;

public class CharacterMover : MonoBehaviour
{
	private IMovable Character;
	private float Direction;

	private void Awake()
	{
		Character = GetComponent<IMovable>();
	}

	private void Update()
	{
		Direction = Input.GetAxisRaw("Horizontal");

		if (Input.GetButtonDown("Open"))
		{
			Inventory.instance.Show();
		}
	}

	private void FixedUpdate()
	{
		Character.Move(Direction);

		if (Input.GetButtonDown("Jump")) 
		{
			Character.Jump();
		}
	}
}