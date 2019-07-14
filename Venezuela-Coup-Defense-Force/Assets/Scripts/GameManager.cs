using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameObject instance;
    public Scene currentScene;
    public static int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this.gameObject;
            DontDestroyOnLoad(this.gameObject);
            currentScene = SceneManager.GetActiveScene();
            score = 0;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public bool IsGameActive()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(currentScene.buildIndex);
    }


    public void GameOver()
    {
        SceneManager.LoadScene(2);
        currentScene = SceneManager.GetSceneByBuildIndex(2);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        currentScene = SceneManager.GetSceneByBuildIndex(0);
    }


    public void ExitGame()
    {
        Application.Quit();
    }


    public void Retry()
    {
        SceneManager.LoadScene(1);
        score = 0;
    }
}
