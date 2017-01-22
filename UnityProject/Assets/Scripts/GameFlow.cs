using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
			if ( currentLevel >= levels.Length ) {
				SceneManager.LoadScene("TheEnd");
			} else {
				ResetLevel();
			}
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
		currentLevel++;
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
