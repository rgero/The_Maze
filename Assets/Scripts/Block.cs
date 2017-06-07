using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	bool isUp;
	public bool shouldMove;
	public float move_speed;

	private float blockHeight;
	private float currentHeight;
	private Vector3 currentPos;

	bool audioPlaying;
	public AudioSource audioClip;

	void Awake () {
		isUp = false; // Start in the down position
		shouldMove = false;
		move_speed = 0.1f;
		blockHeight = this.gameObject.transform.localScale.y;

		audioPlaying = false;
		audioClip = this.GetComponent<AudioSource> ();
	}

	/* 	What does this function need to do?
	 * 		1.) It needs to move the block up or down it's entire height.
	 */
	void moveBlock()
	{
		int direction = isUp ? -1 : 1; // The direction is going down if the block "isUp" and vise versa.
		currentPos.y += (direction * move_speed);
		this.gameObject.transform.position = currentPos;
	}

	// Update is called once per frame
	void Update () {
		currentPos = this.gameObject.transform.localPosition;
		if (shouldMove) {
			if (!audioPlaying) {
				audioClip.Play ();
				audioPlaying = true;
			}
			moveBlock ();
			if (!isUp && currentPos.y > blockHeight) {
				shouldMove = false;
				isUp = true;
				currentPos.y = blockHeight;
				this.gameObject.transform.position = currentPos;
			} else if (isUp && currentPos.y < 0) {
				shouldMove = false;
				isUp = false;
				currentPos.y = 0;
				this.gameObject.transform.position = currentPos;
			}
		} else {
			if (audioPlaying) {
				audioClip.Stop ();
				audioPlaying = false;
			}
		}
	}

	public void triggerMovement()
	{
		shouldMove = true;
	}
}
