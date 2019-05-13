using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int levelToLoad;
    public Scene scene;
    public void Start()
    {
    	scene = SceneManager.GetActiveScene();
    }
    public void MainMenu()
    {
    	SceneManager.LoadScene("Main Menu");
    }

    public void RetryLevel()
    {
    	levelToLoad = scene.buildIndex;
    	SceneManager.LoadScene(levelToLoad);
    }

    public void LoadLevel()
    {
    	
    	SceneManager.LoadScene(levelToLoad);
    }

    public void NextLevel()
    {
    	
    	levelToLoad = scene.buildIndex + 1;
    	
    	SceneManager.LoadScene(levelToLoad);
    }

    public void ExitGame()
    {
    	Application.Quit();
    }


}
