using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageFading : MonoBehaviour 
{
    private Image myImage;
    void Awake()
    {
        myImage = FindObjectOfType<Image>();
        Color myCol = myImage.color;
        myCol.a = 0;
        myImage.color = myCol;
    }

    void Start()
    {
        StartCoroutine(ImageAnimation());
    }

    IEnumerator FadeIn(float duration , Image myImage)
    {
        Color myCol = myImage.color;
        myCol.a = 0;
        myImage.color = myCol;

        for (float a =0; a < 1; a += Time.deltaTime / duration)
        {
            Color myColor = myImage.color;
            myColor.a = a;
            myImage.color = myColor;
            yield return null;
        }

        myCol.a = 1;
    }


    IEnumerator FadeOut(float duration , Image myImage)
    {
        Color myCol = myImage.color;
        myCol.a = 0;
        myImage.color = myCol;

        for (float a =1; a > 0; a-= Time.deltaTime / duration)
        {
            Color myColor = myImage.color;
            myColor.a = a;
            myImage.color = myColor;
            yield return null;
        }

        myCol.a = 1;
    }


    IEnumerator ImageAnimation()
    {
        yield return StartCoroutine(FadeIn(2.0f , myImage));
        yield return new WaitForSeconds(1.0f);
        yield return StartCoroutine(FadeOut(2.0f , myImage));
    }
}