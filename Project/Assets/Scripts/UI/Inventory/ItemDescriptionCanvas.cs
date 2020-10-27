using UnityEngine;
using UnityEngine.UI;

public class ItemDescriptionCanvas : MonoBehaviour
{
	private Text Content;

	private Button ToHide;
	private Button ToErase;

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
		Button[] buttons = GetComponentsInChildren<Button>();

		ToHide = buttons[0];
		ToErase = buttons[1];

		ToHide.onClick.AddListener(Hide);
	}

	public void Show(ItemEventArgs args)
	{
		gameObject.SetActive(true);

		Content.text = args.Description;

		ToErase.onClick.AddListener(args.Click);
		ToErase.onClick.AddListener(Hide);
		ToErase.onClick.AddListener(() => { Inventory.instance.RemoveItem(args.Name); });
	}

	public void Hide()
	{
		gameObject.SetActive(false);
		Content.text = "Null";
		ToErase.onClick.RemoveAllListeners();
	}

}
