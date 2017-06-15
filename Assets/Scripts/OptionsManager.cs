using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

		PlayerPrefs.SetInt ("P1_Controller_Scheme", p1Control);
		PlayerPrefs.SetInt ("P2_Controller_Scheme", p2Control);
	}
}
