using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MicrowaveVisual : MonoBehaviour {

	public TextMesh timerText;
	public SpriteRenderer windowSpr;
	public Color energyMin, energyMax;
	public SpriteRenderer foodSpr;
	public Text gameResultLabel;

	public void SetTime(float t) {
		int min = Mathf.FloorToInt(t / 60.0f);
		int sec = Mathf.CeilToInt(t) % 60;
		timerText.text = String.Format("{0:D2}:{1:D2}", min, sec);
	}

	public void SetEnergyLevel(float level) {
		windowSpr.color = Color.Lerp(energyMin, energyMax, level);
	}

	public void SetCookLevel(float level) {
		foodSpr.material.SetFloat("_Cookness", level);
	}

	public void SetFoodBurnt(bool burnt) {
		foodSpr.material.SetFloat("_Burnt", burnt ? 1.0f : 0.0f);
	}

	public void ResetGameResult() {
		gameResultLabel.text = "";
	}

	public void SetWin() {
		gameResultLabel.text = "YOU WIN!";
	}

	public void SetLose() {
		gameResultLabel.text = "YOU LOSE!";
	}

	public void SetFoodSprite(Sprite spr) {
		foodSpr.sprite = spr;
	}

}
