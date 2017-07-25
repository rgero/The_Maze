using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	GameObject parentBlock;
	public float rotationSpeed;
	float midHeight;
	float heightVariance;
	float bobSpeed;
	bool moveUp;

	// Use this for initialization
	void Start() {

		parentBlock = this.transform.parent.gameObject;
		rotationSpeed = GameConstants.ITEM_ROT_SPEED;
		midHeight = GameConstants.ITEM_POS_OFFSET;
		heightVariance = GameConstants.ITEM_BOB_Y;
		bobSpeed = GameConstants.ITEM_BOB_SPEED;
		moveUp = true;

		this.transform.localPosition = new Vector3 (0, midHeight, 0);
		
	}
	
	// Update is called once per frame
	void Update () {

		// Height Bobbing.
		Vector3 currentPos = this.transform.localPosition;
		if (moveUp) {
			if (currentPos.y < midHeight + heightVariance) {
				currentPos.y += bobSpeed;
			} else {
				moveUp = false;
			}
		} else {
			if (currentPos.y > midHeight - heightVariance) {
				currentPos.y -= bobSpeed;
			} else {
				moveUp = true;
			}
		}
		this.transform.localPosition = currentPos;

		// Rotation
		this.transform.Rotate (new Vector3(0, rotationSpeed, 0));

	}

	void OnTriggerEnter(Collider collider){
		GameObject collidedObject = collider.gameObject;
		if (collidedObject.name == "Player") {
			// Give player effect
			this.parentBlock.GetComponent<Block>().removeItem();
			Destroy(this.gameObject);
		}
	}
}
