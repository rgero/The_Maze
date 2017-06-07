using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceCalculator : MonoBehaviour {

	public GameObject beacon;
	Vector3 beaconPosition;
	public Text distanceText;
	string distancePrefix = "Distance To End: ";

	// Use this for initialization
	void Start () {
		beacon = GameObject.Find ("Beacon");
		distanceText = GameObject.Find ("DistanceFromEnd").GetComponent<Text>();

		beaconPosition = beacon.transform.position;
	}

	double calculateDistance(){
		return Mathf.Round (Vector3.Distance (this.transform.position, beaconPosition) * 100) / 100;
	}

	
	// Update is called once per frame
	void Update () {
		double currentDistance = calculateDistance ();
		distanceText.text = String.Format ("{0} {1:0.00}", distancePrefix, currentDistance);
	}
}
