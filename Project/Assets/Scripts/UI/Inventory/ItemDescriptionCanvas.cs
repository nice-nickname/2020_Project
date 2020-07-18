using UnityEngine;
using UnityEngine.UI;

public class ItemDescriptionCanvas : MonoBehaviour
{
	private Text Content;
	private Button Button;
	private RectTransform RTransform;

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

		Content = GetComponentInChildren<Text>();
		Button = GetComponentInChildren<Button>();
	}

	public void Show(ItemEventArgs args)
	{
		Vector3 newpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		transform.position = new Vector3(newpos.x, newpos.y, 0f);
		Content.text = args.Description;
	}

	public void Hide()
	{
		transform.position = new Vector3(100000f, 100000f, 0f);
		Content.text = "Null";
	}
}
