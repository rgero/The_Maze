using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {

	public GameObject gameBlockPrefab;
	public GameObject startBlockPrefab;
	public GameObject endBlockPrefab;
	public int boardWidth;
	public int boardLength;
	public int numberOfBlocksToggled;

	List<GameObject> listOfBlocks;
	float blockWidth;
	float blockLength;
	float blockHeight;
	Random rand;
	int MinBlocks = GameConstants.MINIMUM_MOVEMENTS;
	int MaxBlocks = GameConstants.MAXIMUM_MOVEMENTS;
	int startMoveBlocks = 50;

	bool shiftBlocks;
	float cool_down_timer = 0.0f;

	// Use this for initialization
	void Start () {
		shiftBlocks = false; // We want the cooldown to be started immediately.

		listOfBlocks = new List<GameObject> ();
		
		blockWidth = GameConstants.BLOCK_SCALE.x;
		blockLength = GameConstants.BLOCK_SCALE.z;
		blockHeight = GameConstants.BLOCK_SCALE.y;

		GameObject blockHolder = new GameObject ();
		blockHolder.name = "Block Holder";

		for (int i = 0; i < boardWidth; i++) {
			for (int j = 0; j < boardLength; j++) {
				Vector3 blockPosition = new Vector3 (i * blockWidth, 0, j * blockLength);
				GameObject newBlock = Instantiate (gameBlockPrefab) as GameObject;
				newBlock.transform.localPosition = blockPosition;
				newBlock.name = listOfBlocks.Count.ToString ();
				newBlock.transform.localScale = GameConstants.BLOCK_SCALE;

				float r = Random.value;
				float g = Random.value;
				float b = Random.value;

				MeshRenderer renderer = newBlock.GetComponent<MeshRenderer> ();
				renderer.material.SetColor ("_Color", new Color(r,g,b) );

				listOfBlocks.Add (newBlock);
				newBlock.transform.parent = blockHolder.transform;
			}
		}

		//Time to create walls...
		GameObject wallHolder = new GameObject();
		wallHolder.name = "Wall Container";


		GameObject leftWall = Instantiate(gameBlockPrefab) as GameObject;
		leftWall.transform.position = new Vector3 (-blockWidth, blockHeight, blockLength * (boardLength / 2) - blockLength/2);
		Vector3 leftLocalScale = GameConstants.BLOCK_SCALE;
		leftLocalScale.z = boardLength * blockLength;
		leftWall.transform.localScale = leftLocalScale;
		leftWall.name = "Left Wall";
		leftWall.transform.parent = wallHolder.transform;

		GameObject rightWall = Instantiate(gameBlockPrefab) as GameObject;
		rightWall.transform.position = new Vector3 (boardWidth*blockWidth, blockHeight, blockLength * (boardLength / 2) - blockLength/2);
		Vector3 rightWallScale = GameConstants.BLOCK_SCALE;
		rightWallScale.z = boardLength * blockLength;
		rightWall.transform.localScale = rightWallScale;
		rightWall.name = "Right Wall";
		rightWall.transform.parent = wallHolder.transform;

		GameObject topWall = Instantiate(gameBlockPrefab) as GameObject;
		topWall.transform.position = new Vector3 (blockWidth * (boardWidth / 2) - blockWidth/2, blockHeight, -blockLength);
		Vector3 topLS = GameConstants.BLOCK_SCALE;
		topLS.x = boardWidth * blockWidth;
		topWall.transform.localScale = topLS;
		topWall.name = "Top Wall";
		topWall.transform.parent = wallHolder.transform;

		GameObject bottomWall = Instantiate(gameBlockPrefab) as GameObject;
		bottomWall.transform.position = new Vector3 (blockWidth * (boardWidth / 2) - blockWidth/2, blockHeight, boardLength*blockLength);
		Vector3 bottomLS = GameConstants.BLOCK_SCALE;
		bottomLS.x = boardWidth * blockWidth;
		bottomWall.transform.localScale = bottomLS;
		bottomWall.name = "Bottom Wall";
		bottomWall.transform.parent = wallHolder.transform;

		//Creating the start block
		int startBlockNum = Random.Range(0, listOfBlocks.Count);
		GameObject startBlock = Instantiate(startBlockPrefab) as GameObject;
		GameObject oldBlock = listOfBlocks [startBlockNum];
		startBlock.transform.position = oldBlock.transform.position;
		startBlock.name = "StartingBlock";
		startBlock.transform.parent = blockHolder.transform;
		listOfBlocks.RemoveAt (startBlockNum);
		Destroy (oldBlock);

		//Creating the Ending Block
		int endBlockNum = Random.Range(0, listOfBlocks.Count);
		GameObject endBlock = Instantiate(endBlockPrefab) as GameObject;
		oldBlock = listOfBlocks [endBlockNum];
		endBlock.transform.position = oldBlock.transform.position;
		endBlock.name = "EndingBlock";
		endBlock.transform.parent = blockHolder.transform;
		listOfBlocks.RemoveAt (endBlockNum);
		Destroy (oldBlock);


		toggleBlocks (startMoveBlocks);
	}

	void toggleBlocks(int numberOfBlocks)
	{
		for (int k = 0; k < numberOfBlocksToggled; k++) {
			int blockNumber = Random.Range (0, listOfBlocks.Count);
			GameObject targetBlock = listOfBlocks [blockNumber];
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
			int targetBlocks = Random.Range (MinBlocks, MaxBlocks);
			toggleBlocks (targetBlocks);
			shiftBlocks = false;
		}
		
	}
}
