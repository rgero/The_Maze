using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XboxCtrlrInput;

public struct PlayerOption {
	public GameObject playerText;
	public Dropdown playerDropdown;

	public PlayerOption(GameObject p, Dropdown d)
	{
		this.playerText = p;
		this.playerDropdown = d;
	}
}

public class OptionsManager : MonoBehaviour {

	Dropdown playerSelector;
	Dropdown playerOneDropdown;
	Dropdown playerTwoDropdown;
	int numberOfPlayers;
	int p1Control;
	int p2Control;
	List<PlayerOption> listOfDrops;
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

		GameObject playerOneText = GameObject.Find ("P1_Text");
		GameObject playerTwoText = GameObject.Find ("P2_Text");



		listOfDrops = new List<PlayerOption> ();
		listOfDrops.Add (new PlayerOption(playerOneText,playerOneDropdown));
		listOfDrops.Add (new PlayerOption(playerTwoText,playerTwoDropdown));

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
		Debug.Log (targetNumber);
		for (int i = 0; i <= targetNumber; i++) {
			listOfDrops [i].playerText.SetActive(true);
			listOfDrops [i].playerDropdown.gameObject.SetActive(true);

		}
		for (int i = targetNumber+1; i < listOfDrops.Count; i++) {
			Debug.Log (i);
			listOfDrops [i].playerText.SetActive(false);
			listOfDrops [i].playerDropdown.gameObject.SetActive(false);
		}
	}

}
