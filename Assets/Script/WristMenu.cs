using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WristMenu : MonoBehaviour
{
	public GameObject wristUI;
	public bool activeWriteUI = true;
	public bool play = true;

    // Start is called before the first frame update
    void Start()
    {
        // DisplayWriteUI();
    }

	public void exitGame() {
		Application.Quit();
		Debug.Log("Application quitté");
	}

	public void changeEtat() {
		play = !play;
		if (play) {
			Console.Log("play");
		} 
		
	}

	public void MenuPressed(InputAction.CallbackContext context) {
		//if(context.performed) DisplayWriteUI();
		Debug.Log("test");
	}

    public void DisplayWriteUI()
    {
        if(activeWriteUI) {
			wristUI.SetActive(false);
			activeWriteUI = false;
		} else {
			wristUI.SetActive(true);
			activeWriteUI = true;
		}
    }
}
