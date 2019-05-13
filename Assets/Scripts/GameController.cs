using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text displayText;
    //public InputAction[] inputActions;
    public string[] words;
    public GameObject player;
    public string logAsText;
    public string currentWord;
    public int j = 0;
    
    List<string> actionLog = new List<string>();
    List<string> commandLog = new List<string>();
    string newText;
    public int dir;
    public Vector3 startPos;
    public Quaternion startRot;
    OnPlayerScript OPS;
   




    // Use this for initialization
    void Awake () 
    {
  		OPS = player.GetComponent<OnPlayerScript>();
    }

    void Start()
    {
        startPos = player.transform.position;
        startRot = player.transform.rotation;
        
       
    }

    public void DisplayLoggedText()
    {
        

        logAsText = string.Join (" ", commandLog.ToArray ());

        displayText.text = logAsText;
        actionLog = new List<string>();
        commandLog = new List<string>();
       
    }

    

   

    

    public void LogStringWithReturn(string stringToAdd)
    {
       words = stringToAdd.Split(' ');
       //currentWord = new string[words.Length];
       //Debug.Log("currentWord Array length is " + currentWord.Length);
       foreach (var word in words)
       {
       	
       		actionLog.Add(word);

       }

       for (int i = 0; i < words.Length; i++)
        {
        	if (words[i] == "forward" || words[i] == "fwd" || words[i] == "f")
   			{
	   			currentWord = "Forward";
   				commandLog.Add(currentWord);
   			}
   			else if (words[i] == "left" || words[i] == "lt" || words[i] == "l")
   			{
	   			currentWord = "Left";
   				commandLog.Add(currentWord);
   			}
   			else if (words[i] == "right" || words[i] == "rt" || words[i] == "r")
   			{
	   			currentWord = "Right";
   				commandLog.Add(currentWord);
   			}
   			
   			else
   			{
   				currentWord = "?";
   				commandLog.Add(currentWord);
   			}
        }
    }

    public void CallMovement()
    {
    	
    	for(int i = 0; i < words.Length; i++)
    	{
    		
    		// currentWord[i] = words[i];

    		if (OPS.died == true) break;
    		Invoke("Move", 1f + i);
    		j++;
    	}
    	
    	j = 0;
    	Invoke("GoalCheck", words.Length + 1);
    }


	
	public void Move()
	{
		
   		if (words[j] == "forward" || words[j] == "fwd" || words[j] == "f")
   		{
   			if (OPS.died == false)
   			{	
   				/*k++;
   				currentWord = "Forward";
   				commandLog.Add(currentWord);*/
   				if (dir == 0) player.transform.position += Vector3.up;
				if (dir == 2) player.transform.position += Vector3.down;
				if (dir == 1) player.transform.position += Vector3.right;
				if (dir == 3) player.transform.position += Vector3.left;
				//Debug.Log("I moved Forward");
			}
			
			
		}//move the player one square forward;
   		else if (words[j] == "left" || words[j] == "lt" || words[j] == "l")
   		{
   			if (OPS.died == false)
   			{
   				/*currentWord = "Left";
   				commandLog.Add(currentWord);*/
   				//Debug.Log(commandLog[0]);
   				player.transform.eulerAngles += new Vector3(0f, 0f, 90f);
   				//Debug.Log("I moved left");
				dir -= 1;
				if (dir == -1) dir = 3;
				
			}


   		} //rotate the players z-axis 90 degrees;

   		else if (words[j] == "right" || words[j] == "rt" || words[j] == "r")
   		{
   			if (OPS.died == false)
   			{
   				/*currentWord = "Right";
   				commandLog.Add(currentWord);*/
   				player.transform.eulerAngles += new Vector3(0f, 0f, -90f);
   				//Debug.Log("I moved right");
				dir += 1;
				if (dir == 4) dir = 0;
				
			}


   		} //rotate the players z-axis -90 degrees;
   		else 
   		{

   		}
    	
    	j++;
	}

	public void GoalCheck()
	{
		
		if (OPS.winLevel == false && OPS.died == false)
		{
			player.transform.position = startPos; 
			player.transform.rotation = startRot;
			dir = OPS.playerFacing;
		} 
		
	}
	
}

