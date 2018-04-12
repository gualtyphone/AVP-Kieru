using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaytimeController : MonoBehaviour {

    public Transform startRotation;
    public Transform endRotation;

    public float time;

    public List<Light> lampPosts;
    public float lampPostsTime;
    bool on = true;
    float startTime;

    // Use this for initialization
    void Start () {
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
		if (Time.time - startTime < time)
        {
            transform.rotation = Quaternion.Lerp(startRotation.rotation, endRotation.rotation, Utils.Map(Time.time - startTime, startTime, time, 0.0f, 1.0f));
        }
        //if (Time.time - startTime > lampPostsTime)
        //{
        //    if (on)
        //    {
        //        for (int i = 0; i < lampPosts.Count; i++)
        //        {
        //            lampPosts[i].enabled = false;
        //        }
        //        on = false;
        //    }
        //}
	}
}
