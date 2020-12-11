using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMushrooms : MonoBehaviour
{
    public GameObject shroom;

    public float xPos;
    public float xRange;
    public float yPos;
    public float zPos;
    public float zRange;
    public int count;

    private void Start()
    {
        StartCoroutine(SpawnMushrooms());
    }

    IEnumerator SpawnMushrooms()
    {
        while (count > 0)
        {
            xPos = Random.Range(-xRange, xRange);
            zPos = Random.Range(-zRange, zRange);

            RaycastHit hit;
            Vector3 raycastPos = new Vector3(xPos, 1000, zPos);

            if (Physics.Raycast(raycastPos, Vector3.down, out hit))
            {
                yPos = hit.point.y;
            }

            Instantiate(shroom, new Vector3(xPos, yPos, zPos), Quaternion.identity);

            yield return new WaitForSeconds(0.01f);
            count -= 1;
        }
    }
}
