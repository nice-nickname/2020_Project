using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpOnTriggerEvent : MonoBehaviour
{
	[SerializeField] private Text place;
	[SerializeField] private Image placeImage;

	public static HelpOnTriggerEvent instance;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void SetText(string text)
	{
		place.text = text;
		placeImage.color = new Color(0, 0, 0, 0.4f);
	}

	public void Unset()
	{
		place.text = string.Empty;
		placeImage.color = new Color(0, 0, 0, 0);
	}
}
