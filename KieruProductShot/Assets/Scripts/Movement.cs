using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public GameObject microchip;
    public float rotationSpeed;
    public GameObject caseUpper;
    public Light spotLight1;
    public Light spotLight2;
    public Light spotLight3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        microchip.GetComponent<Transform>().Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
        
	}
}
