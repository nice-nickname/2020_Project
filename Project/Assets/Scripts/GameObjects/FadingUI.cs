using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadingUI : MonoBehaviour
{
	[SerializeField] private float FadingSpeed = 0.015f;

	private Image Image;
	private Color FadingColor;

	private void Awake()
	{
		Image = GetComponent<Image>();
		FadingColor = new Color(Image.color.r, Image.color.g, Image.color.b, 0f);
		Image.color = FadingColor;
	}

	public void OnActionDisabled()
	{
		if (Image != null)
		{
			StartCoroutine(Fade());
		}
	}

	private IEnumerator Fade()
	{
		for (float f = 1f; f > -0.1; f -= FadingSpeed)
		{
			FadingColor.a = FadingFunction(f);
			Image.color = FadingColor;
			yield return null;
		}
	}

	private float FadingFunction(float x)
	{
		return 1 - Mathf.Pow(1 - x, 3);
	}
}
