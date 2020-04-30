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
		Fade();
	}

	private void Fade()
	{
		FadingColor.a = 1 - (Object.transform.position - transform.position).magnitude / FadingDistance;
		Sprite.color = FadingColor;
	}
}
