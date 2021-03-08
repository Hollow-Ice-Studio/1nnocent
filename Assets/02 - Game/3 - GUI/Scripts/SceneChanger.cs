using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    
    public void ExitGame()
    {
        Debug.Log("exitgame");
        Application.Quit();
    }

    public void ChangeScene(string sceneName)
    {
        Debug.Log($"Scene changed to: {sceneName}");
        SceneManager.LoadScene(sceneName);
    }
}
