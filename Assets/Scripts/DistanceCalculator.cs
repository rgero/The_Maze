using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceCalculator : MonoBehaviour {

	GameObject beacon;
	Vector3 beaconPosition;
	Text distanceText;
	string distancePrefix = "Distance To End: ";

	// Use this for initialization
	void Start () {
		distanceText = GameObject.Find ("DistanceFromEnd").GetComponent<Text>();
		distanceText.text = "";
	}

  // The Beacon is a component of the End Block.
  // To prevent a race condition, I am exposing this function.
  // When the end block is instantiated, it looks for this class and sets the beacon.
	public void setBeacon(GameObject g){
		this.beacon = g;
		beaconPosition = g.transform.position;
	}

	double calculateDistance(){
		return Mathf.Round (Vector3.Distance (this.transform.position, beaconPosition) * 100) / 100;
	}


	// Update is called once per frame
	void Update () {
		if (beacon != null) {
			double currentDistance = calculateDistance ();
			distanceText.text = String.Format ("{0} {1:0.00}", distancePrefix, currentDistance);
		}
	}
}
