﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string level){
		SceneManager.LoadScene (level);
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.F6)) {
			LoadLevel ("StartMenu");
		}
	}
}
