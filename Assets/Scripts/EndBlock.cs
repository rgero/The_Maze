using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBlock : MonoBehaviour {

	public GameObject lightPrefab;

	// Use this for initialization
	void Start () {

		Vector3 currentBlockPos = this.transform.position;

		Vector3 targetPos = currentBlockPos;
		targetPos.y += 5;

		GameObject pointLight = Instantiate (lightPrefab) as GameObject;
		pointLight.transform.localPosition = targetPos;
		pointLight.transform.parent = this.transform;

		GameObject beacon = GameObject.Find ("Beacon");
		GameObject player = GameObject.Find ("Player");
		if (player != null && beacon != null) {
			player.GetComponent<DistanceCalculator> ().setBeacon (beacon);
		}
	}

}
