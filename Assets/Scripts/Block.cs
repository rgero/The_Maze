using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	bool isUp;
	bool canMove;
	public bool shouldMove;
	public float move_speed;

	private float blockHeight;
	private float currentHeight;
	private Vector3 currentPos;

	void Awake () {
		isUp = false; // Start in the down position
		shouldMove = false;
		move_speed = 0.5f;
		blockHeight = this.gameObject.transform.localScale.y;
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
		if (shouldMove) 
		{
			moveBlock ();
			if (!isUp && currentPos.y > blockHeight) {
				shouldMove = false;
				canMove = false;
				isUp = true;
				currentPos.y = blockHeight;
				this.gameObject.transform.position = currentPos;
			} else if (isUp && currentPos.y < 0) {
				shouldMove = false;
				canMove = false;
				isUp = false;
				currentPos.y = 0;
				this.gameObject.transform.position = currentPos;
			}
		}
	}

	public void triggerMovement()
	{
		shouldMove = true;
	}
}
