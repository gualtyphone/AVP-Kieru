using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Use this for initialization
    void Start () {
        Models = new List<Animator>();
        Models.AddRange(transform.GetComponentsInChildren<Animator>());
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= next)
        {
            timer = 0;
            next = Random.Range(0, disappearSpeed);

            int mID = Random.Range(0, Models.Count);
            Models[mID].gameObject.SetActive( false);
            Models.RemoveAt(mID);
        }

        if (Models.Count == 0)
        {
            finished = true;
            gameObject.SetActive( false);
        }
	}
}
