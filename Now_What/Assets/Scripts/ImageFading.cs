using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageFading : MonoBehaviour 
{
    private Image myImage;


    void Awake()
    {
        myImage = GetComponent<Image>();
        Color myCol = myImage.color;
        myCol.a = 0;
        myImage.color = myCol;
    }

    void Start()
    {
        StartCoroutine(ImageAnimation());
    }


    IEnumerator FadeIn(float duration)
    {
        for (float a =0; a < 1; a += Time.deltaTime / duration)
        {
            Color myCol = myImage.color;
            myCol.a = a;
            myImage.color = myCol;
            yield return null;
        }
    }


    IEnumerator FadeOut(float duration)
    { 
        for (float a =1; a > 0; a-= Time.deltaTime / duration)
        {
            Color myCol = myImage.color;
            myCol.a = a;
            myImage.color = myCol;
            yield return null;
        }
    }


    IEnumerator ImageAnimation()
    {
        yield return StartCoroutine(FadeIn(2.0f));
        yield return new WaitForSeconds(1.0f);
        yield return StartCoroutine(FadeOut(2.0f));
    }
}
