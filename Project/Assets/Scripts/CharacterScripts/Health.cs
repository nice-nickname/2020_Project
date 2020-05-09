
public class Health
{ 
	private int Value;

	public Health(int v)
	{
		Value = v;
	}

	public void UpdateValue(int value)
	{
		Value -= value;
	}

	public bool Alive()
	{
		if (Value > 0)
			return true;
		return false;
	}
}
