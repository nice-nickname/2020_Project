using UnityEngine.UI;
using UnityEngine;

public class Fonts : MonoBehaviour, IOnSceneStartLoading
{
	[SerializeField] private Font Font;

	public void SceneLoad()
	{
		var textComponents = FindObjectsOfType<Text>();

		foreach (var item in textComponents)
		{
			item.font = Font;
			item.fontSize = 30;
		}
	}

}
