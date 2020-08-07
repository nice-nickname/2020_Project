using UnityEngine;

public class Door : MonoBehaviour
{
	private SpriteRenderer Renderer;
	private Collider2D Collider;
	private Cooldown Cooldown;

	public bool Closed { get; private set; }

	private void Awake()
	{
		Renderer = GetComponent<SpriteRenderer>();
		Collider = GetComponent<Collider2D>();
		Cooldown = new Cooldown();
		Closed = true;

		Renderer.color = Color.red;
	}

	private void Open()
	{
		Renderer.color = Color.green;
		Collider.enabled = false;
		Closed = false;
	}

	private void Close()
	{
		Renderer.color = Color.red;
		Collider.enabled = true;
		Closed = true;
	}

	public void ChangeCondition()
	{
		if (Cooldown.ActionReady())
		{
			if (Closed)
				Open();
			else
				Close();
		}

	}
}
