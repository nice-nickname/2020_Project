using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameObjectHandler : MonoBehaviour
{
	[SerializeField] private Text _dialogTextField = null;
	[SerializeField] private Font _Font = null;
	[SerializeField] private Transform _CameraTarget = null;

	public static GameObjectHandler instance;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(this.gameObject);
		}
	}

	public Text DialogTextField { get { return _dialogTextField; } }
	public Font Font { get { return _Font; } }
	public Transform CameraTarget { get { return _CameraTarget; } }
}
