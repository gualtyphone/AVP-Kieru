using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdentActorController : MonoBehaviour {

	public bool randomRot = false;
	public float speed;
	public float sleep;
	public float distance;
	float startTime;
	public Vector3 target;

	void Start () {
        GetComponent<Animator>().SetFloat("Speed", Random.Range(0.3f, 1.0f));
		startTime = Time.time;
		speed = GetComponent<Animator> ().GetFloat ("Speed");
		target = transform.position;
        transform.position += new Vector3(Random.Range(-40.0f, 40.0f), 0.0f, Random.Range(-40.0f, 40.0f));
        //if (randomRot) {
        //	transform.Rotate (new Vector3 (0.0f, Random.Range (0, 360.0f), 0.0f));
        //}

        transform.LookAt(target);
	}
	
	void Update () {
		if (sleep <= 0) {
				Vector3 prevPos = transform.position;
				float f = (Time.time - startTime) / distance;
				if (Vector3.Distance (transform.position, target) > 0.1f) {
					transform.position = new Vector3 (Mathf.SmoothStep (transform.position.x, target.x, f),
						Mathf.SmoothStep (transform.position.y, target.y, f),
						Mathf.SmoothStep (transform.position.z, target.z, f));
				}
				GetComponent<Animator> ().SetFloat ("Speed", Vector3.Distance (prevPos, transform.position) * speed);
		} else {
			sleep -= Time.deltaTime;
		}
	}
}
