using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;

public class Player2Controller : MonoBehaviour {

	public Camera player2Camera;
	public Transform gameTransform;
	public Transform cameraTransform;
	public MouseLook mouseLook;
	public Vector2 movementDirection;

	// Use this for initialization
	void Start () {
		player2Camera = gameObject.GetComponentInChildren<Camera> ();
		gameTransform = this.gameObject.transform;
		cameraTransform = player2Camera.transform;
		mouseLook.Init (this.transform, player2Camera.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
		// This section is pretty much taken from the FirstPersonController script provided by standard asset.
		// Just trimmed the fat a bit.
		RotateView();
		float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
		float vertical = CrossPlatformInputManager.GetAxis("Vertical");
		movementDirection = new Vector2 (horizontal, vertical);
		Vector3 desiredMove = transform.forward*movementDirection.y + transform.right*movementDirection.x;
		Vector3 currentPos = this.transform.position;
		currentPos += desiredMove;
		this.transform.position = currentPos;

		//Moving Up and Down (increasing/decreasing altitude)
		if (Input.GetKey(KeyCode.E))
		{
			currentPos.y += GameConstants.MOVEMENT_SPEED;
		}
		if (Input.GetKey(KeyCode.Q))
		{
			currentPos.y -= GameConstants.MOVEMENT_SPEED;
		}
		this.transform.position = currentPos;

		if (CrossPlatformInputManager.GetButtonDown ("Fire1")) {
			GameObject hit = DetectHit ();
			if (hit) {
				hit.GetComponent<Block> ().shouldMove = true;
			}
		}
	}

	GameObject DetectHit(){
		RaycastHit hit;
		if (Physics.Raycast (player2Camera.transform.position, player2Camera.transform.forward, out hit)) {
			return hit.transform.gameObject;
		} else {
			return null;
		}
	}

	private void RotateView()
	{
		mouseLook.LookRotation (this.gameObject.transform, player2Camera.transform);
	}
}
