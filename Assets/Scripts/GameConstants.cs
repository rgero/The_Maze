using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConstants : MonoBehaviour {

	public static float COOLDOWN_VALUE = 5.0f;
	public static int MOVES_BEFORE_COOLDOWN = 5;
	public static Vector3 BLOCK_SCALE = new Vector3 (10, 10, 10);
	public static float ITEM_WEIGHT = 0.05f;
	public static int MAX_ITEMS = 1;
	public static int MINIMUM_MOVEMENTS = 10;
	public static int MAXIMUM_MOVEMENTS = 100;

	public static float TIME_LIMIT = 10.0f;

	public static float MOVEMENT_SPEED = 1.0f;

	public static float BLOCK_MOVE_SPEED = 0.1f;

  // These might not actually be Constants, in which case I should find a better place to store them.
	public static bool usingXbox = true;
	public static bool p2UsingXbox = true;

	public static float ITEM_POS_OFFSET = 0.7f;
	public static float ITEM_ROT_SPEED = 1.0f;
	public static float ITEM_BOB_Y = 0.05f;
	public static float ITEM_BOB_SPEED = 0.001f;

}
