using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XboxCtrlrInput;

public class OptionsManager : MonoBehaviour {

	Dropdown playerSelector;
	Dropdown playerOneDropdown;
	Dropdown playerTwoDropdown;
	int numberOfPlayers;
	int p1Control;
	int p2Control;
	List<Dropdown> listOfDrops;
	Text errorText;

	// Use this for initialization
	void Start () {
		Cursor.visible = true;
		GameObject playerOneOptions = GameObject.Find ("P1_Dropdown");
		GameObject playerTwoOptions = GameObject.Find ("P2_Dropdown");
		errorText = GameObject.Find ("ErrorText").GetComponent<Text> ();


		playerSelector = GameObject.Find ("Players_Dropdown").GetComponent<Dropdown> ();
		playerOneDropdown = playerOneOptions.GetComponent<Dropdown> ();
		playerTwoDropdown = playerTwoOptions.GetComponent<Dropdown> ();

		listOfDrops = new List<Dropdown> ();
		listOfDrops.Add (playerOneDropdown);
		listOfDrops.Add (playerTwoDropdown);

		//Restoring the player's preferences if they exist.
		// These will return 0 if they are non-existent which is fine because that is keyboard.
		numberOfPlayers = PlayerPrefs.GetInt("NumberOfPlayers");
		p1Control = PlayerPrefs.GetInt ("P1_Controller_Scheme");
		p2Control = PlayerPrefs.GetInt ("P2_Controller_Scheme");

		playerSelector.value = numberOfPlayers;
		playerOneDropdown.value = p1Control;
		playerTwoDropdown.value = p2Control;
	}

	public void onClick(){

		p1Control = playerOneDropdown.value;
		p2Control = playerTwoDropdown.value;
		numberOfPlayers = playerSelector.value;

		bool status = true; // True means Ok.
		string err_msg = "";
		errorText.text = err_msg;

		int numberOfControllersNeeded = p1Control + p2Control; // This is total number of controllers.
		int totalNumberPluggedIn = XCI.GetNumPluggedCtrlrs ();
		if (numberOfControllersNeeded > totalNumberPluggedIn) {
			status = false;
			err_msg += "Check Controllers.";
		}

		if (status) {
			PlayerPrefs.SetInt ("P1_Controller_Scheme", p1Control);
			PlayerPrefs.SetInt ("P2_Controller_Scheme", p2Control);
			PlayerPrefs.SetInt ("NumberOfPlayers", numberOfPlayers);

			LevelManager levelManger = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();
			levelManger.LoadLevel ("StartMenu");
		} else {
			errorText.text = err_msg;
		}
	}

	public void changeNumberOfPlayers(){
		int targetNumber = playerSelector.value;
		for (int i = 0; i < targetNumber; i++) {
			listOfDrops [i].Show ();
		}
		for (int i = targetNumber; i < listOfDrops.Count; i++) {
			listOfDrops [i].Hide ();
		}
	}

}
