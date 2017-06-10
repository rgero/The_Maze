using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;

public class Player2CameraControl : MonoBehaviour {

	//This is going to be a somewhat sloppy implementation based on the standard asset implementation.

	public GameObject cameraGO;
	Camera p2Camera;
	Vector3 currentPos;
	MouseLook mouseLook;

	/* TODO:
	 * 	Draw this out or find a way to reuse the player 
	 * 
	 * 	W should make the player move forward in that direction
	 */


	// Use this for initialization
	void Start () {
		cameraGO = GameObject.Find ("P2_Camera");
		p2Camera = cameraGO.GetComponent<Camera> ();
		currentPos = this.transform.forward;
		mouseLook.Init (this.transform, p2Camera.transform);

	}

	private void RotateView()
	{
		mouseLook.LookRotation (transform, p2Camera.transform);
	}
	
	// Update is called once per frame
	void Update () {

		float horizontal = CrossPlatformInputManager.GetAxis ("Horizontal");
		float vertical = CrossPlatformInputManager.GetAxis ("Vertical");

		Debug.Log (string.Format ("Player2 - {0}", CrossPlatformInputManager.mousePosition));

	}
}
