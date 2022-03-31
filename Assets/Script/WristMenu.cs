using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class WristMenu : MonoBehaviour
{
	public GameObject wristUI;
	public bool activeWriteUI = true;
	public bool play = true;
	public XRController leftController;
	public InputHelpers.Button button;

    // Start is called before the first frame update
    void Start()
    {
        // DisplayWriteUI();
    }

    private void Update()
    {
		bool pressed;
		leftController.inputDevice.IsPressed(button,out pressed);

		if (pressed) Debug.Log("Pressed " + button);
    }

    public void exitGame() {
		Application.Quit();
		Debug.Log("Application quitté");
	}

	public void changeEtat() {
		play = !play;
		if (play) {
			Debug.Log("play");
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
 