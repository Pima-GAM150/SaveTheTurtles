using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerController : MonoBehaviour
{
    

    public InputField inputField;
	GameController controller;

    void Awake()
    {
    	controller = GetComponent<GameController>();
    	inputField.onEndEdit.AddListener (AcceptStringInput);

    }

    public void Start()
    {
    	inputField.ActivateInputField();
    	inputField.text = null;
    }

    void AcceptStringInput(string userInput)
    {
    	if (Input.GetButtonDown("Submit"))
    	{
    		userInput = userInput.ToLower();
    		controller.LogStringWithReturn(userInput);
    		InputComplete();
    	}
    }

    void InputComplete()
    {
    	controller.DisplayLoggedText();
    	inputField.ActivateInputField();
    	inputField.text = null;
    	controller.CallMovement();
    	

    }
}
