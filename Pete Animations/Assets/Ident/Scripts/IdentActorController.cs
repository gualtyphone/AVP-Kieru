using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdentActorController : MonoBehaviour {

	public bool randomRot = false;
	public float speed;
	public float sleep;
	public float distance;
	public bool debug = false;
	float startTime;
	public Vector3 target;

	// Use this for initialization
	void Start () {
        GetComponent<Animator>().SetFloat("Speed", Random.Range(0.3f, 1.0f));
		startTime = Time.time;
		speed = GetComponent<Animator> ().GetFloat ("Speed");
		target = transform.position + (transform.forward * distance);
		if (randomRot) {
			transform.Rotate (new Vector3 (0.0f, Random.Range (0, 360.0f), 0.0f));
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (sleep <= 0) {
			if (!randomRot) {
				Vector3 prevPos = transform.position;
				float f = (Time.time - startTime) / distance;
				if (Vector3.Distance (transform.position, target) > 0.1f) {
					transform.position = new Vector3 (Mathf.SmoothStep (transform.position.x, target.x, f),
						Mathf.SmoothStep (transform.position.y, target.y, f),
						Mathf.SmoothStep (transform.position.z, target.z, f));
					//transform.position = Vector3.Lerp (transform.position, target, Time.deltaTime);
					if (debug) {
						Debug.Log (transform.position);
					}
				}
				GetComponent<Animator> ().SetFloat ("Speed", Vector3.Distance (prevPos, transform.position) * speed);
			}
		} else {
			sleep -= Time.deltaTime;
		}
	}
}
