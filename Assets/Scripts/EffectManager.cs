using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;

struct Effect{
	public string name;
	public float duration;
}

public class EffectManager : MonoBehaviour {

	List<Effect> listOfEffects;
	FirstPersonController fpsController;

	void Start(){
		listOfEffects = new List<Effect> ();
		fpsController = this.GetComponent<FirstPersonController> ();
	}

	void Update(){

		if (listOfEffects.Count > 0) {
			for(int i = listOfEffects.Count-1; i >= 0; i--){
				Effect e = listOfEffects[i];
				e.duration -= Time.deltaTime;
				listOfEffects [i] = e;
				if (e.duration < 0) {
					Debug.Log ("Removing " + e.name);
					removeEffect (i);
				}
			}
			Debug.Log (listOfEffects.Count);
		}

	}

	public void removeEffect(int i){
		Effect e = listOfEffects[i];
		listOfEffects.RemoveAt (i);

		if (e.name.Equals("speedBoost"))
		{
			fpsController.setRunSpeed (fpsController.getRunSpeed () - 10);
			fpsController.setWalkSpeed (fpsController.getWalkSpeed () - 10);
		}
		if (e.name.Equals ("jumpBoost")) {
			fpsController.setJumpSpeed (10.0f);
		}
	}

	int searchForEffect(string effectName)
	{
		for (int i = 0; i < listOfEffects.Count; i++) {
			if (listOfEffects [i].name.Equals (effectName)) {
				return i;
			}
		}
		return -1;
	}

	public void addEffect(string effect, float time){
		Effect newEffect;
		newEffect.name = effect;
		newEffect.duration = time;

		/**
		 * Steps:
		 * 	1.) Search for the effect, if it exists, add to the duration
		 * 	2.) If it does not exist, make the changes and add the effect.
		 */
		int foundEffect = searchForEffect (effect);
		if (foundEffect != -1) {
			Effect found = listOfEffects [foundEffect];
			found.duration += time;
			listOfEffects [foundEffect] = found;
		} else {
			if (effect.Equals ("speedBoost")) {
				fpsController.setRunSpeed (fpsController.getRunSpeed () + 10);
				fpsController.setWalkSpeed (fpsController.getWalkSpeed () + 10);
			}
			if (effect.Equals ("jumpBoost")) {
				fpsController.setJumpSpeed (15.0f);
			}
			listOfEffects.Add (newEffect);
		}
	}
}
