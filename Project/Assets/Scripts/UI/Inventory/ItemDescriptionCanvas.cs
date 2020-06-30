using UnityEngine;
using UnityEngine.UI;

public class ItemDescriptionCanvas : MonoBehaviour
{
	private Canvas Canvas;
	private Text Content;
	private Button Button;

	public static ItemDescriptionCanvas instance;

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


		Canvas = GetComponent<Canvas>();
		Content = Canvas.GetComponentInChildren<Text>();
		Button = Canvas.GetComponentInChildren<Button>();
		Canvas.enabled = false;
	}

	public void Show(ItemEventArgs args)
	{
		Content.text = args.Description;
		Content.transform.position = args.Position;
		Canvas.enabled = true;
	}

	public void Hide()
	{
		Canvas.enabled = false;
		Content.text = "Null";
	}
}
