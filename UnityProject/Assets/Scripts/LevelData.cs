using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelData : ScriptableObject {

	public float initialCookPoints;
	public float burnEnergy;
	public float gainPerAction;
	public float decayPerSec;
	public float roundTime;
	public Sprite foodSprite;

}
