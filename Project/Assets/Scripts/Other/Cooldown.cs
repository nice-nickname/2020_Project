using UnityEngine;

public class Cooldown
{
	private float CooldownTime;
	private float CurrentTime;

	public Cooldown(float cooldownTime = 0.5f)
	{
		CooldownTime = cooldownTime;
		CurrentTime = 0f;
	}

	public bool ActionReady()
	{
		if (Time.time >= CurrentTime + CooldownTime)
		{
			CurrentTime = Time.time;
			return true;
		}
		return false;
	}
}