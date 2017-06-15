using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XboxCtrlrInput;

public class OptionsManager : MonoBehaviour {

	Dropdown playerOneDropdown;
	Dropdown playerTwoDropdown;

	// Use this for initialization
	void Start () {
		GameObject playerOneOptions = GameObject.Find ("P1_Dropdown");
		GameObject playerTwoOptions = GameObject.Find ("P2_Dropdown");

		playerOneDropdown = playerOneOptions.GetComponent<Dropdown> ();
		playerTwoDropdown = playerTwoOptions.GetComponent<Dropdown> ();

		//Restoring the player's preferences if they exist.
		// These will return 0 if they are non-existent which is fine because that is keyboard.
		int p1Control = PlayerPrefs.GetInt ("P1_Controller_Scheme");
		int p2Control = PlayerPrefs.GetInt ("P2_Controller_Scheme");

		playerOneDropdown.value = p1Control;
		playerTwoDropdown.value = p2Control;
	}

	public void onClick(){

		int p1Control = playerOneDropdown.value;
		int p2Control = playerTwoDropdown.value;

		bool status = true; // True means Ok.
		string err_msg = "";
		//Check the controllers.
		if (p1Control == 1 && !XCI.IsPluggedIn((int)XboxController.First))
		{
			status = false;
			err_msg += "Controller for Player 1 is unplugged.\n";
		}
		if (p2Control == 1 && !XCI.IsPluggedIn ((int)XboxController.Second)) {
			status = false;
			err_msg += "Controller for Player 2 is unplugged.\n";
		}

		if (status) {
			PlayerPrefs.SetInt ("P1_Controller_Scheme", p1Control);
			PlayerPrefs.SetInt ("P2_Controller_Scheme", p2Control);
		} else {
			Debug.Log (err_msg);
		}
			
	}
}
