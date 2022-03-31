using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using CommonUsages = UnityEngine.XR.CommonUsages;
using InputDevice = UnityEngine.XR.InputDevice;

public class WristMenu : MonoBehaviour
{
	public GameObject wristUI;
	public bool activeWriteUI = true;
	public bool play = true;
	private InputDevice leftController;
	private InputHelpers.Button button;

    // Start is called before the first frame update
    void Start()
    {
		List<InputDevice> inputDevices = new List<InputDevice>();

		InputDeviceCharacteristics inputDeviceCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;

		InputDevices.GetDevicesWithCharacteristics(inputDeviceCharacteristics, inputDevices);
		foreach(var item in inputDevices)
        {
			Debug.Log(item.characteristics);
        }
		if (inputDevices.Count > 0) leftController = inputDevices[0];
        // DisplayWriteUI();
    }

    private void Update()
    {
		bool pressed;
		leftController.TryGetFeatureValue(CommonUsages.primaryButton,out pressed);

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
 