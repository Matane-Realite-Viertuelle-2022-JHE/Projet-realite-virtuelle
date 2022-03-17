using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WristMenu : MonoBehaviour
{
	public GameObject wristUI;
	public bool activeWriteUI = true;

    // Start is called before the first frame update
    void Start()
    {
        DisplayWriteUI();
    }

	public void exitGame() {
		Application.Quit();
		Debug.Log("Application quitté");
	}

	public void play() {
		Debug.Log("Play");
	}

	public void MenuPressed(InputAction.CallbackContext context) {
		if(context.performed) DisplayWriteUI();
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
