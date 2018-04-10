using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour {

    public float time;
    public SpriteRenderer rend;

	// Use this for initialization
	void Start () {
        rend.color = new Color(1, 1, 1, 0);
        StartCoroutine(fade(time));
	}

    IEnumerator fade(float t)
    {
        float timePassed = 0;
        while (timePassed < t)
        {
            rend.color = new Color(1, 1, 1, timePassed / t);
            timePassed += t / 100;
            yield return new WaitForSeconds(t / 100);
        }
        yield return null;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
