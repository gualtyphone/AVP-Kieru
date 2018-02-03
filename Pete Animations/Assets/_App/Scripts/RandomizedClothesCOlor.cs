using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizedClothesCOlor : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material.color = Random.ColorHSV(0, 1, 0.5f, 1, 0.5f, 1, 1, 1);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
