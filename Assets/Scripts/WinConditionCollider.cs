using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinConditionCollider : MonoBehaviour {

	public GameObject winPrefab;
	bool winTriggered = false;


	void OnTriggerEnter(Collider collider){
		GameObject collidedObject = collider.gameObject;
		if (collidedObject.name == "Player" && !winTriggered) {
			winTriggered = true;
			Instantiate (winPrefab);
		}
	}
}
