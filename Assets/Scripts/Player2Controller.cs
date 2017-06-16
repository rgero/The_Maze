using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;
using UnityEngine.UI;
using XboxCtrlrInput;

public class Player2Controller : MonoBehaviour {

	public Camera player2Camera;
	public Transform gameTransform;
	public Transform cameraTransform;
	public MouseLook mouseLook;
	public Vector2 movementDirection;
	public GameObject movesLeftGO;
	XboxController player2Controller;
	bool usingXbox;
	Text movesLeftText;
	int moves;
	float coolDown;
	float elapsedTime;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("P2_Controller_Scheme") == 0) {
			usingXbox = false;
		} else {
			usingXbox = true;
			if (PlayerPrefs.GetInt ("P1_Controller_Scheme") == 0) {
				player2Controller = XboxController.First;
			} else {
				player2Controller = XboxController.Second;
			}
		}
		player2Camera = gameObject.GetComponentInChildren<Camera> ();
		gameTransform = this.gameObject.transform;
		cameraTransform = player2Camera.transform;
		mouseLook.Init (this.transform, player2Camera.transform);

		moves = GameConstants.MOVES_BEFORE_COOLDOWN;
		coolDown = GameConstants.COOLDOWN_VALUE;
		elapsedTime = 0;
		movesLeftText = movesLeftGO.GetComponent<Text> ();
		updateMovesText ();
	}

	// Update is called once per frame
	void Update () {

		// This section is pretty much taken from the FirstPersonController script provided by standard asset.
		// Just trimmed the fat a bit.
		RotateView();
		Debug.Log (player2Controller);
		float horizontal, vertical;
		if (usingXbox) {
			horizontal = XCI.GetAxis (XboxAxis.LeftStickX, player2Controller);
			vertical = XCI.GetAxis (XboxAxis.LeftStickY, player2Controller);
		} else {
			// Read input
			horizontal = CrossPlatformInputManager.GetAxis ("Horizontal");
			vertical = CrossPlatformInputManager.GetAxis ("Vertical");
		}
		movementDirection = new Vector2 (horizontal, vertical);
		Vector3 desiredMove = transform.forward*movementDirection.y + transform.right*movementDirection.x;
		Vector3 currentPos = this.transform.position;
		currentPos += desiredMove;
		this.transform.position = currentPos;

		//Moving Up and Down (increasing/decreasing altitude)
		if (usingXbox) {
			if (XCI.GetButton(XboxButton.RightBumper, player2Controller))
			{
				currentPos.y += GameConstants.MOVEMENT_SPEED;
			}
			if (XCI.GetButton(XboxButton.LeftBumper, player2Controller))
			{
				currentPos.y -= GameConstants.MOVEMENT_SPEED;
			}

		} else {
  		if (Input.GetKey(KeyCode.Space))
  		{
  			currentPos.y += GameConstants.MOVEMENT_SPEED;
  		}
  		if (Input.GetKey(KeyCode.LeftShift))
  		{
  			currentPos.y -= GameConstants.MOVEMENT_SPEED;
  		}
    }
		this.transform.position = currentPos;

		if (usingXbox && XCI.GetButtonDown(XboxButton.Y, player2Controller) && moves > 0){
			processRaycast();
		} else if (!usingXbox && CrossPlatformInputManager.GetButtonDown ("Fire1") && moves > 0) {
			processRaycast();
		}

		elapsedTime += Time.deltaTime;
		if (elapsedTime > coolDown) {
			elapsedTime = 0;
			if (moves < GameConstants.MOVES_BEFORE_COOLDOWN) {
				moves += 1;
				updateMovesText ();
			}
		}
	}

	void processRaycast(){
		GameObject hit = DetectHit ();
		if (hit) {
			hit.GetComponent<Block> ().triggerMovement();
			moves -= 1;
			updateMovesText ();
		}
	}

	void updateMovesText(){
		movesLeftText.text = string.Format ("Moves Left: {0}", moves);
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
		mouseLook.LookRotation (this.gameObject.transform, player2Camera.transform, usingXbox, player2Controller);
	}
}
