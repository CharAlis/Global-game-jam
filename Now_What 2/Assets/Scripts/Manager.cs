using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    private GameObject gameOver;

    void Awake()
    {
        Instance = this;
        gameOver = GameObject.FindWithTag("GameOverCanvas");
        gameOver.transform.GetChild(0).gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Death();
        }
        //Screen.lockCursor = true;
    }


    public void Death()
    {
        gameOver.transform.GetChild(0).gameObject.SetActive(true);
    }
};