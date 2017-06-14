using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
using UnityStandardAssets.CrossPlatformInput;

/*
  This class handles the "Flashlight" the player is holding.
*/
public class LightControl : MonoBehaviour {

	GameObject light;
	AudioSource audioSource;
	public AudioClip flashlightSound;

	void Start () {
		light = GetComponentInChildren<Light> ().gameObject;
		audioSource = GetComponent<AudioSource> ();
	}

	void Update () {
		if (GameConstants.usingXbox && XCI.GetButtonDown(XboxButton.Y, XboxController.First)){
			toggleLight();
		} else if (!GameConstants.usingXbox && CrossPlatformInputManager.GetButtonDown ("Fire1")) {
			toggleLight ();
		}

	}

  // Allows the player to turn off the light.
  // For now this doesn't do anything but inconvenience the first player
  // I might make it so it "hides" the player from the second player.
	void toggleLight(){
		light.SetActive (!light.gameObject.activeSelf);
		audioSource.PlayOneShot (flashlightSound);
	}
}
