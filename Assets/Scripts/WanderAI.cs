using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderAI : MonoBehaviour
{
    public LayerMask ground;
    public LayerMask water;

    private NavMeshAgent agent;

    public bool walkPointSet;
    public Vector3 walkPoint;
    public float walkPointRange;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);

            // if 5 seconds have passed and the enemy hasn't moved, set walkPointSet to false
        }
        else
        {
            SearchWalkPoint();
        }

        Vector3 dist = transform.position - walkPoint;
        //Debug.Log("VEL: " + agent.velocity);
        //Debug.Log("RD: " + agent.remainingDistance);
        if (dist.magnitude < 5f)
        {
            walkPointSet = false;
        }
    }

    void SearchWalkPoint()
    {
        float xPos = 0;
        float yPos = 0;
        float zPos = 0;

        xPos = Random.Range(-walkPointRange, walkPointRange);
        zPos = Random.Range(-walkPointRange, walkPointRange);

        RaycastHit hit;
        Vector3 raycastPos = new Vector3(transform.position.x + xPos, 1000, transform.position.z + zPos);

        //Debug.Log(transform.position.x + xPos + " + " + transform.position.z + zPos);

        if(Physics.Raycast(raycastPos, Vector3.down, out hit, Mathf.Infinity, water))
        {
            Debug.Log("Water");
            return;
        }
        if (Physics.Raycast(raycastPos, Vector3.down, out hit, Mathf.Infinity, ground))
        {
            //Debug.DrawLine(raycastPos, hit.point, Color.green, 15f);
            
            yPos = hit.point.y;
            //Debug.Log(yPos);
            
            walkPointSet = true; // if true, enemy will walk
        }

        walkPoint = new Vector3(transform.position.x + xPos, transform.position.y + yPos, transform.position.z + zPos);
    }
}
