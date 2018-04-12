using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdentActorController : MonoBehaviour {

	public bool randomRot = false;
	public float speed;
	public float sleep;
	public float distance;
	float startTime;
	public Vector3 target;
	public Vector3 midTarget;
    public Vector3 ortarget;
    public Rigidbody rb;
    Vector3 prevPos;
    public bool text;

    int spawnIndex;

    bool mid = false;


    void Start () {
        rb = GetComponent<Rigidbody>();
        startTime = Time.time;
        if (text)
        {
            ortarget = transform.position;
        }
        SelectSpawnPoint();

        //transform.position += new Vector3(Random.Range(-distance, distance), 0.0f, Random.Range(-distance, distance));
        transform.LookAt(target);
	}
	
	void Update () {
        Vector3 velocity = transform.position - prevPos;
        prevPos = transform.position;
        if (sleep <= 0)
        {
            if (text)
            {
                if (Vector3.Distance(transform.position, ortarget) > 0.1f)
                {
                    GetComponent<NavMeshAgent>().SetDestination(ortarget);
                }
                else
                {
                    //Animation IDLE
                }
            }
            else
            {
                if (Vector3.Distance(transform.position, midTarget) < 2.0f && mid)
                {
                    SelectTarget();
                }
                if (Vector3.Distance(transform.position, target) < 2.0f)
                {
                    SelectSpawnPoint();
                }
            }
        }
        else
        {
            sleep -= Time.deltaTime;
            if (Vector3.Distance(transform.position, midTarget) < 2.0f && mid)
            {
                SelectTarget();
            }
            if (Vector3.Distance(transform.position, target) < 2.0f)
            {
                SelectSpawnPoint();
            }
        }

        GetComponent<Animator>().SetFloat("Speed", Utils.Map(velocity.magnitude, 0.01f, 0.09f, 0.0f, 1.0f));
        //Vector3 lookAt = transform.position + velocity;
        //lookAt.y = transform.position.y;
        //if (velocity.magnitude > 0.07f)
        //    transform.LookAt(lookAt);

    }

    void SelectSpawnPoint()
    {
        var sp = FindObjectsOfType<SpawnPoint>();
        spawnIndex = Random.Range(0, sp.Length);
        var spawn = sp[spawnIndex];
       

        var bounds = spawn.GetComponent<BoxCollider>().bounds;

        Vector3 newPos = new Vector3(Random.Range(bounds.min.x, bounds.max.x), transform.position.y, Random.Range(bounds.min.z, bounds.max.z));

        transform.position = newPos;
        SelectMidPoint();
    }

    void SelectMidPoint()
    {
        mid = true;
        var sp = FindObjectOfType<MidPoint>();

        var bounds = sp.GetComponent<BoxCollider>().bounds;

        midTarget = new Vector3(Random.Range(bounds.min.x, bounds.max.x), transform.position.y, Random.Range(bounds.min.z, bounds.max.z));
        GetComponent<NavMeshAgent>().SetDestination(midTarget);
    }

    void SelectTarget()
    {
        mid = false;
        var sp = FindObjectsOfType<SpawnPoint>();
        int targIndex = spawnIndex;
        do
        {
            targIndex = Random.Range(0, sp.Length);
        } while (spawnIndex == targIndex);
        var targ = sp[targIndex];

        var bounds = targ.GetComponent<BoxCollider>().bounds;

        target = new Vector3(Random.Range(bounds.min.x, bounds.max.x), transform.position.y, Random.Range(bounds.min.z, bounds.max.z));
        GetComponent<NavMeshAgent>().SetDestination(target);
    }


}
