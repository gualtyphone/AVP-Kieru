using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdentActorController : MonoBehaviour {

	public bool randomRot = false;
	public float speed;
	public float sleep;
	public float distance;
	float startTime;
	public Vector3 target;
	public Vector3 ortarget;
    public Rigidbody rb;
    Vector3 prevPos;
    public bool text;

	void Start () {
        rb = GetComponent<Rigidbody>();
        //GetComponent<Animator>().SetFloat("Speed", Random.Range(0.3f, 1.0f));
		startTime = Time.time;
        //speed = GetComponent<Animator> ().GetFloat ("Speed");
        if (text)
        {
            target = transform.position;
            ortarget = transform.position;
        }
        else
        {
            target = transform.position + new Vector3(Random.Range(-distance, distance), 0.0f, Random.Range(-distance, distance));
        }
        transform.position += new Vector3(Random.Range(-distance, distance), 0.0f, Random.Range(-distance, distance));
        //if (randomRot) {
        //	transform.Rotate (new Vector3 (0.0f, Random.Range (0, 360.0f), 0.0f));
        //}

        transform.LookAt(target);
	}
	
	void Update () {
        Vector3 velocity = transform.position - prevPos;
        prevPos = transform.position;
        if (sleep <= 0) {
            if (text)
            {
                if (Vector3.Distance(transform.position, ortarget) > 0.1f)
                {
                    //rb.AddForce((target - transform.position).normalized * speed * 3);
                    transform.position = new Vector3(Mathf.SmoothStep(transform.position.x, ortarget.x, 0.1f),
                        Mathf.SmoothStep(transform.position.y, ortarget.y, 0.1f),
                        Mathf.SmoothStep(transform.position.z, ortarget.z, 0.1f));
                }
            }
            else
            {
                if (Vector3.Distance(transform.position, target) < 2.0f)
                {
                    target = new Vector3(Random.Range(-distance, distance), 0.0f, Random.Range(-distance, distance));
                }
                rb.AddForce((target - transform.position).normalized * speed * 3);
                
            }
        } else {
			sleep -= Time.deltaTime;
            if (Vector3.Distance(transform.position, target) < 2.0f)
            {
                target = new Vector3(Random.Range(-distance, distance), 0.0f, Random.Range(-distance, distance));
            }
            rb.AddForce((target - transform.position).normalized * speed * 3);
        }

        GetComponent<Animator>().SetFloat("Speed", velocity.magnitude * 7);
        Vector3 lookAt = transform.position + velocity;
        lookAt.y = transform.position.y;
        if (velocity.magnitude > 0.07f)
         transform.LookAt(lookAt);

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<IdentActorController>() != null)
        {
            if (!text || sleep > 0)
            {
                rb.AddForce((transform.position - other.transform.position).normalized * speed / 5);
                rb.AddForce(other.GetComponent<Rigidbody>().velocity.normalized * speed / 7);
            }
        }
        else
        {
            if (!text)
                target = new Vector3(Random.Range(-distance, distance), 0.0f, Random.Range(-distance, distance));
        }
    }
}
