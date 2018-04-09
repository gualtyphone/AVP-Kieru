using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensFlareScript : MonoBehaviour {
    public float speed;
    public float intensity;
	// Use this for initialization
	void Start () {
        intensity = GetComponent<LensFlare>().brightness;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<LensFlare>().brightness -= speed * Time.deltaTime;
	}
}
