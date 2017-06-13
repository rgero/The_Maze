using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
using UnityStandardAssets.CrossPlatformInput;

public class LightControl : MonoBehaviour {

	GameObject light;
	AudioSource audioSource;
	public AudioClip flashlightSound;

	// Use this for initialization
	void Start () {
		light = GetComponentInChildren<Light> ().gameObject;
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameConstants.usingXbox && XCI.GetButtonDown(XboxButton.Y, XboxController.First)){
			toggleLight();
		} else if (!GameConstants.usingXbox && CrossPlatformInputManager.GetButtonDown ("Fire1")) {
			toggleLight ();
		}
		
	}

	void toggleLight(){
		light.SetActive (!light.gameObject.activeSelf);
		audioSource.PlayOneShot (flashlightSound);
	}
}
