using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void StartGame()
    {
        int level = GameObject.Find("Level Selection").GetComponent<LevelSelector>().selectedLevel;
        ChangeScene("Level " + level);
    }

    // Called by the UI buttons
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Called by the exit button
    public void ExiteGame()
    {
        Application.Quit();
    }
}
