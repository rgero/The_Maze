using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBlock : MonoBehaviour {

	public GameObject player;
	public GameObject lightPrefab;

	// Use this for initialization
	void Start () {

		Vector3 currentBlockPos = this.transform.position;
		Vector3 targetPos = currentBlockPos;

		player = GameObject.Find("Player");
		targetPos.y += 5;
		player.transform.localPosition = targetPos;

		GameObject pointLight = Instantiate (lightPrefab) as GameObject;
		pointLight.transform.localPosition = targetPos;
		pointLight.transform.parent = this.transform;
	}
}
