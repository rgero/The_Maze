using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

	public List<GameObject> potentialObjects;

	public GameObject spawnItem(){
		Transform parent = this.gameObject.transform.parent;
		Debug.Log (parent.gameObject.name);

		int chosenItem = Random.Range (0, potentialObjects.Count);
		GameObject spawnItem = potentialObjects [chosenItem];

		GameObject gameObject = Instantiate (spawnItem) as GameObject;
		gameObject.transform.parent = this.transform;

		return gameObject;
	}
}
