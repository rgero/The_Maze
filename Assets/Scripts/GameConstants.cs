using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConstants : MonoBehaviour {

	public static float COOLDOWN_VALUE = 5.0f;
	public static int MOVES_BEFORE_COOLDOWN = 5;
	public static Vector3 BLOCK_SCALE = new Vector3 (10, 10, 10);
	public static int MINIMUM_MOVEMENTS = 10;
	public static int MAXIMUM_MOVEMENTS = 100;

	public static float MOVEMENT_SPEED = 1.0f;

  // These might not actually be Constants, in which case I should find a better place to store them.
	public static bool usingXbox = true;
	public static bool p2UsingXbox = true;

}
