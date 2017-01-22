using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {

	public float blinkInterval;
	public MonoBehaviour visual;

	float nextBlink;

	void Update() {
		nextBlink -= Time.deltaTime;
		if ( nextBlink <= 0.0f ) {
			nextBlink += blinkInterval;
			visual.enabled = ! visual.enabled;
		}
	}

}
