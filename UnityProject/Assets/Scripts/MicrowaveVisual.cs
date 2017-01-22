using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MicrowaveVisual : MonoBehaviour {

	public TextMesh timerText;
	public SpriteRenderer windowSpr;
	public Color energyMin, energyMax;

	public void SetTime(float t) {
		int min = Mathf.FloorToInt(t / 60.0f);
		int sec = Mathf.CeilToInt(t) % 60;
		timerText.text = String.Format("{0:D2}:{1:D2}", min, sec);
	}

	public void SetEnergyLevel(float level) {
		windowSpr.color = Color.Lerp(energyMin, energyMax, level);
	}

}
