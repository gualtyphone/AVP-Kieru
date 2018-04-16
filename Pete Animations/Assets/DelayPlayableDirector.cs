using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DelayPlayableDirector : MonoBehaviour {

	[SerializeField]
	float delay = 0.0f;

	// Use this for initialization
	void Start () {
		StartCoroutine (delayPlayableDirector ());
	}

	IEnumerator delayPlayableDirector()
	{
		yield return new WaitForSeconds (delay);
		GetComponent<PlayableDirector> ().Play ();
		yield return null;
	}
}
