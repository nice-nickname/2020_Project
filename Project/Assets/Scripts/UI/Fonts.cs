using UnityEngine.UI;
using UnityEngine;

public class Fonts : MonoBehaviour, IOnSceneStartLoading
{
	[SerializeField][Range(0f,5f)] private float FontSizeMultiplier = 0;

	private Font Font;

	private void Awake()
	{
		Font = GameObjectHandler.instance.Font;
	}

	public void SceneLoad()
	{
		if (Font == null)
			return;

		var textComponents = FindObjectsOfType<Text>();

		foreach (var item in textComponents)
		{
			item.font = Font;
			item.fontSize *= Mathf.RoundToInt(FontSizeMultiplier);
		}
	}

}
