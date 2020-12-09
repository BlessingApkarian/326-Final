using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderAI : MonoBehaviour
{

    private NavMeshAgent agent;

    bool walkPointSet;
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
        }
        else
        {
            SearchWalkPoint();
        }

        Vector3 dist = transform.position - walkPoint;

        if(dist.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    void SearchWalkPoint()
    {
        float xPos;
        float yPos = 0;
        float zPos;

        xPos = Random.Range(-walkPointRange, walkPointRange);
        zPos = Random.Range(-walkPointRange, walkPointRange);

        RaycastHit hit;
        Vector3 raycastPos = new Vector3(xPos, 1000, zPos);

        if (Physics.Raycast(raycastPos, Vector3.down, out hit))
        {
            yPos = hit.point.y;

            walkPointSet = true;
        }

        walkPoint = new Vector3(transform.position.x + xPos, transform.position.y, transform.position.z + zPos);
    }
}
