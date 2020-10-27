using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Dialog : MonoBehaviour
{
	[SerializeField] private DialogAsset DialogAsset = null;
	[SerializeField] private float CooldownTime = 0f;
	[SerializeField] private bool ReReadable = false;
	[SerializeField] private AppearanceSpeed AppearanceSpeed = global::AppearanceSpeed.Normal;
	[SerializeField] private UnityEvent OnDialogEneded;

	private AudioSource OnLetterAppearence;
	private Text Text;

	public UnityEvent OnSentenseEnded;

	private Queue<string> Sentenses;
	[SerializeField] private Vector3 OffSet = new Vector3(0f, 2.5f, -3f);

	private Cooldown Cooldown;
	
	private float Speed = 0f;

	public bool IsCreated { get; private set; } = false;

	private void Start()
	{
		OnLetterAppearence = GameObjectHandler.instance.OnLetterAppearance;
		Text = GameObjectHandler.instance.DialogTextField;
		DialogAsset.CreateDialog();
		Text.text = "";

		Sentenses = new Queue<string>(DialogAsset.Sentenses);
		Sentenses.Dequeue();

		Cooldown = new Cooldown(CooldownTime);

		switch (AppearanceSpeed)
		{
			case AppearanceSpeed.RatherSlow:
				Speed = 0.083f;
				break;

			case AppearanceSpeed.Slow:
				Speed = 0.05f;
				break;

			case AppearanceSpeed.Normal:
				Speed = 0.026f;
				break;

			case AppearanceSpeed.AboveNormal:
				Speed = 0.02f;
				break;

			case AppearanceSpeed.Fast:
				Speed = 0.01f;
				break;

			case AppearanceSpeed.RatherFast:
				Speed = 0.0f;
				break;

			default:
				Speed = 0.026f;
				break;
		}
	}

	public void StartTalk()
	{
		if (ReReadable)
		{
			Sentenses = new Queue<string>(DialogAsset.Sentenses);
			Sentenses.Dequeue();
		}
		Text = GameObjectHandler.instance.DialogTextField;

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
			StartCoroutine(ShowSentense(sentense.Substring(1), Speed));
		}
	}

	public void EndTalking()
	{
		if (Sentenses.Count != 0)
		{
			Sentenses = new Queue<string>(DialogAsset.Sentenses);
			Sentenses.Dequeue();
		}
		else
		{
			OnDialogEneded.Invoke();
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
		int count = 0;
		foreach (char s in sentense)
		{
			Text.text += s;

			if (s != ' ' && count % 2 != 0) 
			{
				OnLetterAppearence.Play();
			}

			yield return new WaitForSeconds(speed);

			count++;
		}
		OnSentenseEnded.Invoke();
	}

	public void ResetDialog(DialogAsset newDialog)
	{
		DialogAsset = newDialog;
		DialogAsset.CreateDialog();
	}
}

enum AppearanceSpeed
{
	RatherSlow,
	Slow,
	Normal,
	AboveNormal,
	Fast,
	RatherFast
}