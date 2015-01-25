using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Texts : MonoBehaviour 
{
    public Text myText;
	public static Texts Instance;

	void Awake()
	{
		Instance = this;
	}

	public void ChangeText(string str)
	{
		myText.gameObject.SetActive(true);
		myText.text = str;
	}

	public void ResetText()
	{
		myText.text = "";
	}

}
