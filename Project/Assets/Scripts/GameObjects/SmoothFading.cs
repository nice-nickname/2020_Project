using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFading : MonoBehaviour
{
	[SerializeField] private GameObject Object = null;
	[SerializeField] private float FadingDistance = 0;

	private SpriteRenderer Sprite;
	private Color FadingColor;

	private void Awake()
	{
		Sprite = GetComponent<SpriteRenderer>();
		FadingColor = new Color(Sprite.color.r, Sprite.color.g, Sprite.color.b, Sprite.color.a);
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
		FadingColor.a = 1 - FadingFunction(Object.transform.position - transform.position);
		Debug.Log(FadingColor.a);
		Sprite.color = FadingColor;
	}

	private float FadingFunction(Vector3 x)
	{
		return 0.5f * Mathf.Pow(x.magnitude / FadingDistance, 2);
	}
}