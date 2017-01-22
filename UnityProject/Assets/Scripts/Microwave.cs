using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Microwave : MonoBehaviour {

	public float initialCookPoints;
	public float timeTick;
	public float burnEnergy;
	public float gainPerAction;
	public float decayPerSec;
	public float roundTime;

	public Image cookBar;
	public Image energyBar;
	public Text remTimeText;
	public MicrowaveVisual visual;

	float cookPoints;
	float energyLevel;
	float time;
	bool burnt;

	float nextTick;
	bool stopped = false;

	void Start() {
		InitSimulation();
		nextTick = timeTick;
	}

	void Update() {
		if ( stopped ) {
			if ( Input.GetKeyDown(KeyCode.R) ) {
				InitSimulation();
				nextTick = timeTick;
				stopped = false;
			}
			return;
		}
		nextTick -= Time.deltaTime;
		if ( nextTick <= 0.0f ) {
			nextTick += timeTick;
			RunTick();
		}
		energyLevel -= decayPerSec * Time.deltaTime;
		time -= Time.deltaTime;
		if ( time <= 0.0f ) {
			LostLevel();
		}
		if ( Input.GetKeyDown(KeyCode.Space) ) {
			AddEnergy();
		}
		UpdateVisuals();
	}

	void InitSimulation() {
		cookPoints = initialCookPoints;
		energyLevel = 0.0f;
		time = roundTime;
		burnt = false;
		visual.ResetGameResult();
	}

	void RunTick() {
		cookPoints -= energyLevel;
		if ( cookPoints <= 0.0f ) {
			WonLevel();
		}
	}

	void AddEnergy() {
		energyLevel += gainPerAction;
		if ( energyLevel > burnEnergy ) {
			burnt = true;
			LostLevel();
		}
	}

	void WonLevel() {
		Debug.Log("WON LEVEL!!!");
		stopped = true;
		visual.SetWin();
	}

	void LostLevel() {
		Debug.Log("LOST LEVEL!!!!");
		stopped = true;
		visual.SetLose();
	}

	void UpdateVisuals() {
		cookBar.fillAmount = cookPoints / initialCookPoints;
		energyBar.fillAmount = energyLevel / burnEnergy;
		remTimeText.text = time.ToString();
		visual.SetTime(time);
		visual.SetEnergyLevel(energyLevel / burnEnergy);
		visual.SetCookLevel(1.0f - (cookPoints / initialCookPoints));
		visual.SetFoodBurnt(burnt);
	}

}

