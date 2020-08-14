using UnityEngine.UI;
using UnityEngine;

public class Fonts : MonoBehaviour, IOnSceneStartLoading
{
	[SerializeField] private Font Font = null;
	[SerializeField][Range(0f,5f)] private float FontSizeMultiplier = 0;

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
