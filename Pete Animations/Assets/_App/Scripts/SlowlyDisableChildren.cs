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
                        StartCoroutine(Disappear(Models[mID].gameObject));
						Models.RemoveAt (mID);
					}
				}
			}
		} else {
			sleep -= Time.deltaTime;
		}
	}

    IEnumerator Disappear(GameObject obj)
    {
        var fade = obj.AddComponent<FadeObjectInOut>();
        fade.fadeTime = 2;
        fade.fadeOutOnStart = true;
        yield return new WaitForSeconds(2);
        obj.SetActive(false);
        yield return null;
    }
}
