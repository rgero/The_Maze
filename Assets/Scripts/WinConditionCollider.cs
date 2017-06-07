using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditionCollider : MonoBehaviour {
	void OnTriggerEnter(Collider collider){
		GameObject collidedObject = collider.gameObject;
		if (collidedObject.name == "Player") {
			Debug.Log ("Player wins");
		}
	}
}
