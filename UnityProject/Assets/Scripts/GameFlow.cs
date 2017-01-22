using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFlow : MonoBehaviour {

	public LevelData[] levels;
	public Microwave microwave;
	public AudioSource backgroundMusic;
	public GameObject pressSpace;
	public float waitTime;

	int currentLevel;
	bool willReset;

	void Start() {
		currentLevel = 0;
		ResetLevel();
	}

	void Update() {
		if ( willReset && Input.GetKeyDown(KeyCode.Space) ) {
			ResetLevel();
		}
	}

	void ResetLevel() {
		willReset = false;
		pressSpace.SetActive(false);
		microwave.StartLevel(levels[currentLevel]);
		if ( ! backgroundMusic.isPlaying ) {
			backgroundMusic.Play();
		}
	}

	public void WonLevel() {
		if ( currentLevel < levels.Length - 1 ) currentLevel++;
		StartCoroutine(WaitAndAllowReset());
	}

	public void LostLevel() {
		StartCoroutine(WaitAndAllowReset());
	}

	IEnumerator WaitAndAllowReset() {
		yield return new WaitForSeconds(waitTime);
		willReset = true;
		pressSpace.SetActive(true);
	}

}
