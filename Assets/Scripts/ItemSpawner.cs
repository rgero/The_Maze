using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

	public GameObject testObjectPrefab;

	public void spawnItem(){
		Transform parent = this.gameObject.transform.parent;
		Debug.Log (parent.gameObject.name);

		GameObject gameObject = Instantiate (testObjectPrefab) as GameObject;
		gameObject.transform.parent = this.transform;
		gameObject.transform.position = this.transform.position;
	}
}
