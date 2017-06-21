using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
using UnityStandardAssets.CrossPlatformInput;

// TODO: Combine this with the LightControl script.

public class LightScript : MonoBehaviour {

	GameObject characterObject;
	Camera playerCamera;
	Vector3 flashlightHeight;
	float handOffset; // I don't want the light to appear eye level.

	//From Light Control.
	Light light;
	AudioSource audioSource;
	bool usingXbox;
	XboxController playerController;
	public AudioClip flashlightSound;

	// Use this for initialization
	void Awake () {
		characterObject = GameObject.FindGameObjectWithTag ("MainCamera");
		playerCamera = characterObject.GetComponent<Camera> ();
		handOffset = characterObject.transform.localPosition.y / 2;

		light = this.GetComponent<Light> ();
		audioSource = this.transform.parent.gameObject.GetComponent<AudioSource> ();
		if (PlayerPrefs.GetInt ("P1_Controller_Scheme") == 0) {
			usingXbox = false;
		} else {
			usingXbox = true;
			playerController = XboxController.First;
		}
	}

	// Update is called once per frame
	void Update () {
		flashlightHeight = playerCamera.transform.position;
		flashlightHeight.y -= handOffset;

		this.transform.rotation = playerCamera.transform.rotation;
		this.transform.position = flashlightHeight;

		if (usingXbox && XCI.GetButtonDown(XboxButton.Y, playerController)){
			toggleLight();
		} else if (!usingXbox && CrossPlatformInputManager.GetButtonDown ("Fire1")) {
			toggleLight ();
		}

	}

	// Allows the player to turn off the light.
	// For now this doesn't do anything but inconvenience the first player
	// I might make it so it "hides" the player from the second player.
	void toggleLight(){
		light.enabled = !light.enabled;
		audioSource.PlayOneShot (flashlightSound);
	}
}
