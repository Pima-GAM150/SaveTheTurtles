using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OnPlayerScript : MonoBehaviour
{
    public GameObject loseAndWinScreen;
    public Text text;
    public bool winLevel;
    public bool died;
    public bool paused;
    public GameObject GC;
    GameController controller;
    public GameObject retryButton;
    public GameObject nextLevelButton;
    public int playerFacing;
    public  GameObject pauseMenu;
    public GameObject UI;


    Scene scene;
    void Awake()
    {
    	winLevel = false;
    	winLevel = false;
    	controller = GC.GetComponent<GameController>();
    	controller.dir = playerFacing;
    	scene = SceneManager.GetActiveScene();
    	paused = false;
    }
    public void Update()
    {
    	if (Input.GetButtonDown("Cancel") && paused == false)
    	{ 
    		pauseMenu.SetActive(true);
    		UI.SetActive(false);
    		paused = true;
    	}
    	
    	else if (Input.GetButtonDown("Cancel") && paused == true)
    	{
    		pauseMenu.SetActive(false);
    		UI.SetActive(true);
    		paused = false;
    	}


    }
    public void OnTriggerEnter2D(Collider2D col)
    {
    	
    	
    		loseAndWinScreen.SetActive(true);

    		if(col.gameObject.name == "Lava")
    		{
				text.text = "You Lose!";
				died = true;
				retryButton.SetActive(true);
			}
    		if(col.gameObject.name == "Goal")
    		{
    			winLevel = true;
    			nextLevelButton.SetActive(true);
    		 	text.text = "You win!";

    		 	if (scene.buildIndex >= 3) nextLevelButton.SetActive(false);
    		}

    

    }
}
