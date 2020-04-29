using UnityEngine;

[CreateAssetMenu(fileName = "Dialog", menuName = "NewDialog")]
public class DialogAsset : ScriptableObject
{
	[SerializeField] private string FileName = null;

	// <readme>
	// Текстовый файл читается из папки Resources
	// В инспекторе у созданного объекта указывается
	// имя соотв. txt файла
	// К примеру File Name: Sample

	private TextAsset Asset;
	public string[] Sentenses { get; private set; }
	public string[] Names { get; private set; }

	public void CreateDialog()
	{
		Asset = Resources.Load<TextAsset>("Dialogues/txt/" + FileName);
		Sentenses = SplitText();
	}

	public void CreateDialog(string path)
	{
		Asset = Resources.Load<TextAsset>(path);
		if (Asset != null)
		{
			Sentenses = SplitText();
		}
	}

	private string[] SplitText()
	{
		string[] names = Asset.text.Split(';');

		Names = new string[names.Length - 1];
		for (int i = 0; i < Names.Length; i++)
			Names[i] = names[i];

		string[] txt = names[names.Length - 1].Replace('\n', '#').Replace('@', '\n').Split('#');
		return txt;
	}
}