using UnityEngine;

public class FadingObject : MonoBehaviour
{
	[SerializeField] private GameObject Object = null;
	[SerializeField] private float FadingDistance = 4f;

	private SpriteRenderer Sprite;
	private Color FadingColor;

	private void Awake()
	{
		Sprite = GetComponent<SpriteRenderer>();
		FadingColor = Sprite.color;
	}

	private void Update()
	{
		if (Object != null)
		{
			Fade();
		}
	}

	private void Fade()
	{
		if ((Object.transform.position.y <= transform.position.y + 2f) && (Object.transform.position.y >= transform.position.y - 2f))
		{
			FadingColor.a = FadingFunction((Object.transform.position - transform.position).magnitude / FadingDistance);
			Sprite.color = FadingColor;
		}
	}

	private float FadingFunction(float x)
	{
		return 1 - 0.5f * Mathf.Pow(x, 2);
	}
}