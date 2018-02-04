using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowlyDisableChildren : MonoBehaviour {

    [SerializeField]
    float disappearSpeed;

    [SerializeField]
    float timer = 0;
    [SerializeField]
    float next = 0;

    [SerializeField]
    List<Animator> Models;

    [SerializeField]
    bool finished = false;

	[SerializeField]
	float sleep = 0;
	[SerializeField]
	float deleteAtTime = 0;

    // Use this for initialization
    void Start () {
        Models = new List<Animator>();
        Models.AddRange(transform.GetComponentsInChildren<Animator>());
	}
	
	// Update is called once per frame
	void Update () {
		if (sleep <= 0) {
			timer += Time.deltaTime;
			if (timer >= next) {
				timer = 0;

				//josh's loop
				for (int a = 0; a < deleteAtTime; a++) {
					if (a < Models.Count) {
						next = Random.Range (0, disappearSpeed);

						int mID = Random.Range (0, Models.Count);
						Models [mID].gameObject.SetActive (false);
						Models.RemoveAt (mID);
					}
				}
			}

			//if (Models.Count == 0) {
			//	finished = true;
			//	//gameObject.SetActive (false);
			//	GameObject.FindObjectOfType<Text> ().enabled = true;
			//	Color col = GameObject.FindObjectOfType<Text> ().color;
			//	col.a += 0.01f;
			//	GameObject.FindObjectOfType<Text> ().color = col;
			//}
		} else {
			sleep -= Time.deltaTime;
		}
	}
}
