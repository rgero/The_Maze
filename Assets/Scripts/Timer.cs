﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	private float countDownTimer;
	GameObject playerObject;
	FirstPersonController fpsController;
	bool presentMessage;
	public Text timeText;
	public GameObject EndGameTextPrefab;

	// Use this for initialization
	void Start () {
		presentMessage = false;
		countDownTimer = GameConstants.TIME_LIMIT;
		playerObject = GameObject.Find ("Player");
		fpsController = playerObject.GetComponent<FirstPersonController> ();
		timeText = GameObject.Find ("TimerText").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		timeText.text = string.Format ("Time Remaining: {0:0.00}", countDownTimer);
		countDownTimer -= Time.deltaTime;
		if (countDownTimer < 0) {
			fpsController.enabled = false;
			timeText.text = "GAME OVER!";

			if (!presentMessage) {
				presentMessage = true;
				Instantiate (EndGameTextPrefab);
				Text winnerText = GameObject.Find ("WinnerText").GetComponent<Text> ();

				Scene currentScene = SceneManager.GetActiveScene ();
				if (currentScene.name.Equals ("SplitScreen")) {
					winnerText.text = "Player 2\nwins!";
				} else {
					winnerText.text = "Player 1\nloses!";
				}
			}
		}
		
	}
}
