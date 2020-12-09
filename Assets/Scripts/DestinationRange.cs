using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationRange : MonoBehaviour
{
    public float xPos;
    public float yPos;
    public float zPos;

    private void Start()
    {
        transform.position = destinationPosition();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            transform.position = destinationPosition();
        }
    }

    private Vector3 destinationPosition()
    {
        xPos = Random.Range(68, 88);
        zPos = Random.Range(-35, -27);

        RaycastHit hit;
        Vector3 raycastPos = new Vector3(xPos, 1000, zPos);

        if (Physics.Raycast(raycastPos, Vector3.down, out hit))
        {
            yPos = hit.point.y;
        }

        return new Vector3(xPos, yPos, zPos);
    }
}
