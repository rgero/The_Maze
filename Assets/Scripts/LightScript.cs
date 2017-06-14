using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Combine this with the LightControl script.

public class LightScript : MonoBehaviour {

	public GameObject characterObject;
	Camera playerCamera;
	Vector3 flashlightHeight;
	float handOffset; // I don't want the light to appear eye level.

	// Use this for initialization
	void Awake () {
		characterObject = GameObject.FindGameObjectWithTag ("MainCamera");
		playerCamera = characterObject.GetComponent<Camera> ();
		handOffset = characterObject.transform.localPosition.y / 2;
	}

	// Update is called once per frame
	void Update () {
		flashlightHeight = playerCamera.transform.position;
		flashlightHeight.y -= handOffset;

		this.transform.rotation = playerCamera.transform.rotation;
		this.transform.position = flashlightHeight;
	}
}
