using UnityEngine;
using System.Collections;

public class ChangeSceneScript : MonoBehaviour 
{
    public void ChangeScene(int sceneToChangeTo)
    {
        Application.LoadLevel(sceneToChangeTo);
    }
}
