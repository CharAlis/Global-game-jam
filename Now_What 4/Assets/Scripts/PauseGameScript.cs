using UnityEngine;
using System.Collections;

public class PauseGameScript : MonoBehaviour 
{
    public GameObject Pause;

    private bool pauseGame = false;
    private bool resumePressed = false;

    void Update()
    {
        resumePressed = false;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame = !pauseGame;

            if (pauseGame == true)
            {
                Pause.SetActive(true);
                Time.timeScale = 0;
                pauseGame = true;
            }
            if (pauseGame == false)
            {
                Pause.SetActive(false);
                Time.timeScale = 1;
                pauseGame = false;
            }
        }
    }

    public void ResumeButton()
    {
        resumePressed = true;
        pauseGame = false;
        Pause.SetActive(false);
        Time.timeScale = 1;
    }
}
