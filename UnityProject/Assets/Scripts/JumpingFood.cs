using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingFood : MonoBehaviour {

	public float jumpHeight;
	public float waitMin, waitMax;

	Vector3 basePosition;

	void Start() {
		basePosition = transform.position;
		StartCoroutine(Jump());
	}

	IEnumerator Jump() {
		yield return new WaitForSeconds(Random.Range(waitMin, waitMax));
		float t = 0.0f;
		while ( t <= 1.0f ) {
			t += Time.deltaTime;
			float ang = Mathf.Lerp(0.0f, Mathf.PI, t);
			Vector3 pos = basePosition;
			pos.y += Mathf.Sin(ang) * jumpHeight;
			transform.position = pos;
			yield return null;
		}
		transform.position = basePosition;
		StartCoroutine(Jump());
	}

}
