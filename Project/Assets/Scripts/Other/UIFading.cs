using UnityEngine;
using UnityEngine.UI;

public class UIFading : MonoBehaviour
{
	[SerializeField] private GameObject Object = null;
	[SerializeField] private float FadingDistance = 4f;

	private Text FadingObject;
	private Color FadingColor;

	private void Awake()
	{
		FadingObject = GetComponent<Text>();
		FadingColor = FadingObject.color;
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
		FadingColor.a = FadingFunction((Object.transform.position - transform.position).magnitude / FadingDistance);
		FadingObject.color = FadingColor;
	}

	private float FadingFunction(float x)
	{
		return 1 - 0.5f * Mathf.Pow(x, 2);
	}
}
