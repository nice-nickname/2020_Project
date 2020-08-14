using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
	private void Start()
	{
		Load();
	}

	private void Load()
	{
		IOnSceneStartLoading[] forLoad = GetComponents<IOnSceneStartLoading>();

		foreach (var item in forLoad)
		{
			item.SceneLoad();
		}
	}
}
