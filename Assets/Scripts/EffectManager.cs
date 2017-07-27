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
					listOfEffects.RemoveAt (i);
				} else {
					Debug.Log (e.name + " : " + e.duration.ToString ());
				}
			}

		}

	}

	public void addEffect(string effect, float time){
		Effect newEffect;
		newEffect.name = effect;
		newEffect.duration = time;
		Debug.Log ("Added: " + newEffect.name);
		listOfEffects.Add (newEffect);

		//Activate Effect
		if (effect.Equals ("speedBoost")) {
			fpsController.setRunSpeed (fpsController.getRunSpeed () + 10);
			fpsController.setWalkSpeed (fpsController.getWalkSpeed () + 10);
		}
	
	}
}
