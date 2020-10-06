using UnityEngine;
using UnityEngine.UI;

public class ToOpaque : MonoBehaviour, ICoroutinedTask
{
	[SerializeField] [Range(0, 1)] float Speed = 0f;
	[SerializeField] GameObject FadingCanvas;

	private Image Sprite;
	private Color DefaultColor;

	private void Awake()
	{
		Sprite = FadingCanvas.GetComponent<Image>();
		DefaultColor = Sprite.color;
		DefaultColor.a = 0f;
	}

	public bool TaskFinished()
	{
		if (DefaultColor.a >= 1f)
		{
			DefaultColor.a = 0f;
			return true;
		}
		return false;
	}

	public void Task()
	{
		DefaultColor.a += Speed;
		Sprite.color = DefaultColor;
	}
}
