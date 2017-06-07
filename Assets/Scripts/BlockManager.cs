using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {

	public GameObject gameBlockPrefab;
	public int boardWidth;
	public int boardLength;
	public int numberOfBlocksToggled;

	List<GameObject> listOfBlocks;
	float blockWidth;
	float blockLength;
	Random rand;

	bool shiftBlocks;
	float cool_down_timer = 0.0f;

	// Use this for initialization
	void Start () {
		shiftBlocks = false; // We want the cooldown to be started immediately.

		listOfBlocks = new List<GameObject> ();
		
		blockWidth = gameBlockPrefab.gameObject.transform.localScale.x;
		blockLength = gameBlockPrefab.gameObject.transform.localScale.z;

		GameObject blockHolder = new GameObject ();
		blockHolder.name = "Block Holder";

		for (int i = 0; i < boardWidth; i++) {
			for (int j = 0; j < boardLength; j++) {
				Vector3 blockPosition = new Vector3 (i * blockWidth, 0, j * blockLength);
				GameObject newBlock = Instantiate (gameBlockPrefab) as GameObject;
				newBlock.transform.localPosition = blockPosition;
				newBlock.name = listOfBlocks.Count.ToString ();

				float r = Random.value;
				float g = Random.value;
				float b = Random.value;

				MeshRenderer renderer = newBlock.GetComponent<MeshRenderer> ();
				renderer.material.SetColor ("_Color", new Color(r,g,b) );

				listOfBlocks.Add (newBlock);
				newBlock.transform.parent = blockHolder.transform;
			}
		}

		toggleBlocks ();
	}

	void toggleBlocks()
	{
		for (int k = 0; k < numberOfBlocksToggled; k++) {
			int blockNumber = Random.Range (0, listOfBlocks.Count);
			GameObject targetBlock = listOfBlocks [blockNumber];
			Debug.Log (targetBlock.transform.localPosition);
			targetBlock.GetComponent<Block> ().triggerMovement ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!shiftBlocks) {
			cool_down_timer += Time.deltaTime;
			if (cool_down_timer > GameConstants.COOLDOWN_VALUE) {
				cool_down_timer = 0;
				shiftBlocks = true;
			}
		} else {
			toggleBlocks ();
		}
		
	}
}
