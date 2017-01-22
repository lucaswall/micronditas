using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFlow : MonoBehaviour {

	public LevelData[] levels;
	public Microwave microwave;
	public Text infoLabel;
	public AudioSource backgroundMusic;

	int currentLevel;
	bool stopped;

	void Start() {
		currentLevel = 0;
		stopped = true;
		infoLabel.text = "PRESS SPACE";
	}

	void Update() {
		if ( stopped && Input.GetKeyDown(KeyCode.Space) ) {
			stopped = false;
			microwave.StartLevel(levels[currentLevel]);
			if ( ! backgroundMusic.isPlaying ) {
				backgroundMusic.Play();
			}
		}
	}

	public void WonLevel() {
		if ( currentLevel < levels.Length - 1 ) currentLevel++;
		stopped = true;
	}

	public void LostLevel() {
		stopped = true;
	}

}
