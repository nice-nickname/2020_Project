using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct DialogAssetPair
{
	public Dialog ToReset;
	public DialogAsset Asset;

	public DialogAssetPair(Dialog toReset, DialogAsset asset)
	{
		ToReset = toReset;
		Asset = asset;
	}

	public void InvokeUpdate()
	{
		ToReset.ResetDialog(Asset);
	}

}

public class DialogObjectReseter : MonoBehaviour
{
	[SerializeField] private List<DialogAssetPair> ToUpdate = null;
	[SerializeField] private Dialog Dialog = null;

	public void UpdateValues()
	{
		foreach (var item in ToUpdate)
		{
			item.InvokeUpdate();
		}
	}

}
