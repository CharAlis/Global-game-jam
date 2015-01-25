using UnityEngine;
using System.Collections;

public class ExitScript : MonoBehaviour 
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Restart(int loadedLevel)
    {
        Application.LoadLevel(loadedLevel);
    }
}
