using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	bool isUp;
	bool shouldMove;
	float move_speed;
	public float blockHeight;
	float currentHeight;
	Vector3 currentPos;
	bool audioPlaying;
	AudioSource audioClip;
	ItemSpawner itemSpawner;
	GameObject heldItem;

	void Awake () {
		isUp = false; // Start in the down position
		shouldMove = false;
		move_speed = GameConstants.BLOCK_MOVE_SPEED;
		blockHeight = this.gameObject.transform.lossyScale.y;
		audioPlaying = false;
		audioClip = this.GetComponent<AudioSource> ();
		itemSpawner = this.GetComponent<ItemSpawner> ();
		heldItem = null;
	}

	/* 	This function moves the block up/down one block length
	 */
	void moveBlock()
	{
		int direction = isUp ? -1 : 1; // The direction is going down if the block "isUp" and vise versa.
		currentPos.y += (direction * move_speed);
		this.gameObject.transform.position = currentPos;
		if (heldItem) {
			heldItem.transform.localPosition = GameConstants.ITEM_POS_OFFSET;
		}
	}

	void Update () {
		currentPos = this.gameObject.transform.localPosition;
		if (shouldMove) {
			if (!audioPlaying) { //Checks to see if the audio is playing and plays it.
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
        // The audio clip is longer than the time it takes the block to move.
        // This allows me to stop it when the block stops moving.
				audioClip.Stop ();
				audioPlaying = false;
			}
		}
	}

	public void triggerMovement()
	{
		shouldMove = true;
	}

	public void spawnItem(){
		heldItem = itemSpawner.spawnItem ();
	
	}

}
