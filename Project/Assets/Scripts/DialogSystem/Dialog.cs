using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
	[SerializeField] private DialogAsset DialogAsset = null;
	[SerializeField] private Text Text = null;
	[SerializeField] private float CooldownTime = 0f;
	[SerializeField] private float AppearanceSpeed = 0f;
	[SerializeField] private bool ReReadable = false;

	private Queue<string> Sentenses;
	private Vector3 OffSet = new Vector3(0f, 1.5f, -3f);

	private Cooldown Cooldown;

	public bool IsCreated { get; private set; } = false;

	private void Awake()
	{
		DialogAsset.CreateDialog();
		Text.text = "";

		Sentenses = new Queue<string>(DialogAsset.Sentenses);
		Sentenses.Dequeue();

		Cooldown = new Cooldown(CooldownTime);
	}

	public void StartTalk()
	{
		if(ReReadable)
		{
			Sentenses = new Queue<string>(DialogAsset.Sentenses);
			Sentenses.Dequeue();
		}
		Text.text = "";
		IsCreated = true;
	}

	public void Talk()
	{
		if (Cooldown.ActionReady())
		{
			if (Sentenses.Count == 0)
			{
				IsCreated = false;
				EndTalking();
				return;
			}
			string sentense = Sentenses.Dequeue();

			try
			{
				Text.text = DialogAsset.Names[sentense[0] - 48] + ": ";
			}
			catch (IndexOutOfRangeException)
			{
				Text.text = "INVALID_INDEX: ";
			}

			StopAllCoroutines();
			StartCoroutine(ShowSentense(sentense.Substring(1), AppearanceSpeed));
		}
	}

	public void EndTalking()
	{
		if (Sentenses.Count != 0)
		{
			Sentenses = new Queue<string>(DialogAsset.Sentenses);
			Sentenses.Dequeue();
		}
		Text.text = "";
		StopAllCoroutines();
		IsCreated = false;
	}

	public void HoldPosition()
	{
		Text.transform.position = transform.position + OffSet;
	}

	private IEnumerator ShowSentense(string sentense, float speed)
	{
		foreach (char s in sentense)
		{
			Text.text += s;
			yield return new WaitForSeconds(speed);
		}
	}
}