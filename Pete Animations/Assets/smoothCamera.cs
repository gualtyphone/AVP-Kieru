using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoothCamera : MonoBehaviour {

	public Vector3 startPos;
	public Vector3 startAngle;
	public Vector3 endPos;
	public Vector3 endAngle;
	public Vector3[] tempLerpPos;
	public float[] speeds;
	public Vector3[] tempLerpAngle;
	public float[] angleSpeeds;
	public int tempLerpPosInArray;
	public float stopSpeed = 0.1f;
	public float stopAngle = 0.1f;
	public bool isChild;
	public bool lerpPos;
	public bool lerpAngle;
	public float lerpAfter;
	public float lerpDuration;
	float startTime;

	void Start() {
		startTime = Time.time;
		//transform.position = startPos;
		//transform.rotation = Quaternion.Euler (startAngle);

	}

	// Update is called once per frame
	void Update () {
		if (tempLerpPosInArray < tempLerpPos.Length) {
			int i = 0;
			float f = (Time.time - startTime) / speeds[tempLerpPosInArray];
			if (Mathf.Abs(Vector3.Distance (transform.position,transform.parent.position + tempLerpPos [tempLerpPosInArray])) > stopSpeed) {
				if (isChild) {
					//transform.position = Vector3.Lerp (transform.position, transform.parent.position + tempLerpPos [tempLerpPosInArray], Time.deltaTime * speeds [tempLerpPosInArray]);
					transform.position = new Vector3 (Mathf.SmoothStep (transform.position.x, transform.parent.position.x + tempLerpPos[tempLerpPosInArray].x, f),
						Mathf.SmoothStep (transform.position.y, transform.parent.position.y + tempLerpPos[tempLerpPosInArray].y, f),
						Mathf.SmoothStep (transform.position.z, transform.parent.position.z + tempLerpPos[tempLerpPosInArray].z, f));
				} else {
					//transform.position = Vector3.Lerp (transform.position, tempLerpPos [tempLerpPosInArray], Time.deltaTime * speeds [tempLerpPosInArray]);
					transform.position = new Vector3 (Mathf.SmoothStep (transform.position.x, tempLerpPos[tempLerpPosInArray].x, f),
						Mathf.SmoothStep (transform.position.y, tempLerpPos[tempLerpPosInArray].y, f),
						Mathf.SmoothStep (transform.position.z, tempLerpPos[tempLerpPosInArray].z, f));
				}
			} else {
				i++;
			}

			f = (Time.time - startTime) / angleSpeeds[tempLerpPosInArray];
			if (Mathf.Abs(Vector3.Distance (transform.rotation.eulerAngles, transform.parent.rotation.eulerAngles + tempLerpAngle [tempLerpPosInArray])) > stopAngle) {
				Debug.Log (Mathf.Abs (Vector3.Distance(transform.parent.rotation.eulerAngles - transform.rotation.eulerAngles, tempLerpAngle [tempLerpPosInArray])));
				Vector3 rot = transform.rotation.eulerAngles;
				if (isChild) {
					//rot = Vector3.Lerp (rot, transform.parent.rotation.eulerAngles + tempLerpAngle [tempLerpPosInArray], Time.deltaTime * angleSpeeds [tempLerpPosInArray]);
					rot = new Vector3 (Mathf.SmoothStep (rot.x, transform.parent.rotation.x + tempLerpAngle[tempLerpPosInArray].x, f),
						Mathf.SmoothStep (rot.y, transform.parent.rotation.y + tempLerpAngle[tempLerpPosInArray].y, f),
						Mathf.SmoothStep (rot.z, transform.parent.rotation.z + tempLerpAngle[tempLerpPosInArray].z, f));
				} else {
					//rot = Vector3.Lerp (rot, tempLerpAngle [tempLerpPosInArray], Time.deltaTime * angleSpeeds [tempLerpPosInArray]);
					rot = new Vector3 (Mathf.SmoothStep (rot.x, tempLerpAngle[tempLerpPosInArray].x, f),
						Mathf.SmoothStep (rot.y, tempLerpAngle[tempLerpPosInArray].y, f),
						Mathf.SmoothStep (rot.z, tempLerpAngle[tempLerpPosInArray].z, f));
				}
				transform.rotation = Quaternion.Euler (rot);
			} else {
				i++;
			}
			if (i == 2) {
				tempLerpPosInArray++;
			}
		}
		/*
		if (lerpAfter <= 0) {
			float t = Mathf.Max ((Time.time - startTime) / lerpDuration, 0);
			if (!isChild) {
				if (lerpPos) {
					transform.position = new Vector3 (Mathf.SmoothStep (transform.position.x, endPos.x, t), 
						Mathf.SmoothStep (transform.position.y, endPos.y, t),
						Mathf.SmoothStep (transform.position.z, endPos.z, t));
				}
				if (lerpAngle) {
					transform.rotation = Quaternion.Euler (new Vector3 (Mathf.SmoothStep (transform.rotation.x, endAngle.x, t), 
						Mathf.SmoothStep (transform.rotation.y, endAngle.y, t),
						Mathf.SmoothStep (transform.rotation.z, endAngle.z, t)));
				}
			} else {)
				if (lerpPos) {
					transform.position = transform.parent.position + new Vector3 (Mathf.SmoothStep (transform.parent.position.x - transform.position.x, endPos.x, t), 
						Mathf.SmoothStep (transform.parent.position.y - transform.position.y, endPos.y, t),
						Mathf.SmoothStep (transform.parent.position.z - transform.position.z, endPos.z, t));
				}
				if (lerpAngle) {
					transform.rotation = Quaternion.Euler (new Vector3 (Mathf.SmoothStep (transform.rotation.x, endAngle.x, t), 
						Mathf.SmoothStep (transform.rotation.y, endAngle.y, t),
						Mathf.SmoothStep (transform.rotation.z, endAngle.z, t)));
				}
			}
		} else {
			lerpAfter -= Time.deltaTime;
		}
		*/
	}
}
