using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
	private GameObject OriginPanel;
	private GameObject OriginButton;

	private Transform Self;
	private RectTransform Rect;

	public static InventoryUI instance { get; private set; }

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance == this)
		{
			Destroy(gameObject);
		}
		
		OriginPanel = Resources.Load<GameObject>("ItemPanel");
		OriginButton = Resources.Load<GameObject>("ItemButton");
		Rect = GetComponent<RectTransform>();
		Self = GetComponent<Transform>();

		Close();
	}

	private GameObject CreatePanel(GameObject Origin, BaseItem item)
	{
		GameObject newPanel = Instantiate(Origin, Self);
		Image image = newPanel.GetComponent<Image>();
		Text text = newPanel.GetComponentInChildren<Text>();

		image.sprite = item.Icon;
		text.text = item.Name;

		return newPanel;
	}

	public void RenderNewItem(BaseItem item)
	{
		if (item.Usable)
		{
			CreatePanel(OriginButton, item).GetComponent<Button>().onClick.AddListener((item as ItemUsable).getEvent().Invoke);
		}
		else
		{
			CreatePanel(OriginPanel, item);
		}
	}

	public void Clear()
	{
		foreach (Transform panel in Self)
		{
			Destroy(panel.gameObject);
		}
	}

	public void Open()
	{
		Rect.anchoredPosition = new Vector2(Rect.anchoredPosition.x, -Rect.anchoredPosition.y);
	}

	public void Close()
	{
		Rect.anchoredPosition = new Vector2(Rect.anchoredPosition.x, -Rect.anchoredPosition.y);
	}
}