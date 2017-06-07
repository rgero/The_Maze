using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBlock : MonoBehaviour {

	public GameObject playerPrefab;
	public GameObject lightPrefab;

	// Use this for initialization
	void Start () {

		Vector3 currentBlockPos = this.transform.position;

		GameObject player = Instantiate (playerPrefab) as GameObject;
		Vector3 targetPos = currentBlockPos;
		targetPos.y += 5;
		player.transform.localPosition = targetPos;
		player.name = "Player";

		GameObject pointLight = Instantiate (lightPrefab) as GameObject;
		pointLight.transform.localPosition = targetPos;
		pointLight.transform.parent = this.transform;
	}
}
