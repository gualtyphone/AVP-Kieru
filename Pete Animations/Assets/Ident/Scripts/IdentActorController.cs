using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdentActorController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Animator>().SetFloat("Speed", Random.Range(0.3f, 1.0f));
        transform.Rotate(new Vector3(0.0f, Random.Range(0, 360.0f), 0.0f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
