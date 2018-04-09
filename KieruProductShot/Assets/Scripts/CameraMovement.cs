using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public Transform startPoint;
    public Transform endPoint;
    public GameObject target;
    public Vector3 offset;
    public float travelTime;
    private Vector3 velocity = Vector3.zero;
    private Vector3 initialTargLocation;
	// Use this for initialization
	void Start () {
        if (target)
        {
            initialTargLocation = target.GetComponent<Transform>().position;
        }
        transform.position = startPoint.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.SmoothDamp(transform.position, endPoint.position, ref velocity, travelTime);
        if (target)
        {
            Transform viewTarget = target.GetComponent<Transform>();

            if (offset != Vector3.zero)
            {
                Vector3 targ = target.GetComponent<Transform>().position;
                //viewTarget.position = new Vector3(viewTarget.position.x + offset.x, viewTarget.position.y + offset.y, viewTarget.position.z + offset.z);
                target.GetComponent<Transform>().position = new Vector3(targ.x + offset.x, targ.y + offset.y, targ.z + offset.z);
                //Debug.Log("viewTarget = " + viewTarget.position);

                transform.LookAt(viewTarget);
            }
            else
            {
                transform.LookAt(initialTargLocation);
            }

            
           
        }
	}
}
