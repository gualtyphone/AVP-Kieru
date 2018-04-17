using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCurrentCamera : MonoBehaviour {

    public Transform cam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (cam != null)
        {
            transform.LookAt(cam);
            transform.Rotate(new Vector3(0, 180, 0));
        }
	}
}
