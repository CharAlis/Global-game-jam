using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Texts : MonoBehaviour 
{
    public Text myText;


	// Update is called once per frame
	void Start() 
    {
        StartCoroutine(UpdateText());
	}

    IEnumerator UpdateText()
    {
        myText.text = "Help";
        yield return new WaitForSeconds(0.15f);
        myText.text += " me";
        yield return new WaitForSeconds(0.15f);
        myText.text += " brother";
        yield return new WaitForSeconds(0.15f);
        myText.text += "!";
        yield return new WaitForSeconds(0.15f);
        myText.text += " Help";
        yield return new WaitForSeconds(0.15f);
        myText.text += " me";
        yield return new WaitForSeconds(0.15f);
    }
}
