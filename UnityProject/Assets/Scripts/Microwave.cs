using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Microwave : MonoBehaviour {

	public float timeTick;

	public float initialCookPoints;
	public float burnEnergy;
	public float gainPerAction;
	public float decayPerSec;
	public float roundTime;

	public Image cookBar;
	public Image energyBar;
	public Text remTimeText;
	public MicrowaveVisual visual;
	public GameFlow gameFlow;

	float cookPoints;
	float energyLevel;
	float time;
	bool burnt;

	float nextTick;
	bool stopped = true;

	public void StartLevel(LevelData data) {
		visual.gameObject.SetActive(true);
		initialCookPoints = data.initialCookPoints;
		burnEnergy = data.burnEnergy;
		gainPerAction = data.gainPerAction;
		decayPerSec = data.decayPerSec;
		roundTime = data.roundTime;
		InitSimulation();
		UpdateVisuals();
		visual.SetFoodSprite(data.foodSprite);
	}

	void Update() {
		if ( ! stopped ) UpdateEnergy();
		if ( ! stopped ) RunCookTick();
		if ( ! stopped ) UpdateTimer();
		UpdateVisuals();
	}

	void RunCookTick() {
		nextTick -= Time.deltaTime;
		if ( nextTick <= 0.0f ) {
			nextTick += timeTick;
			RunTick();
		}
	}

	void UpdateEnergy() {
		energyLevel -= decayPerSec * Time.deltaTime;
		if ( energyLevel < 0.0f ) energyLevel = 0.0f;
		if ( Input.GetKeyDown(KeyCode.Space) ) {
			AddEnergy();
		}
	}

	void UpdateTimer() {
		time -= Time.deltaTime;
		if ( time <= 0.0f ) {
			visual.NoMoreTime();
			LostLevel();
		}
	}

	void InitSimulation() {
		nextTick = timeTick;
		cookPoints = initialCookPoints;
		energyLevel = 0.0f;
		time = roundTime;
		burnt = false;
		visual.ResetGameResult();
		stopped = false;
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
			visual.Burnt();
			LostLevel();
		} else {
			visual.EnergyAction();
		}
	}

	void WonLevel() {
		Debug.Log("WON LEVEL!!!");
		stopped = true;
		visual.Cooked();
		gameFlow.WonLevel();
	}

	void LostLevel() {
		Debug.Log("LOST LEVEL!!!!");
		stopped = true;
		gameFlow.LostLevel();
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

