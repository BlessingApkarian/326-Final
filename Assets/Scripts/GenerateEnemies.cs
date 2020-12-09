    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject enemy;

    public float xPos;
    public float xRange;
    public float yPos;
    public float zPos;
    public float zRange;
    public int count;

    private void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while(count > 0)
        {
            xPos = Random.Range(-40, 9);
            zPos = Random.Range(-140, -78);

            RaycastHit hit;
            Vector3 raycastPos = new Vector3(xPos, 1000, zPos);

            if (Physics.Raycast(raycastPos, Vector3.down, out hit))
            {
                yPos = hit.point.y;
            }
            
            Instantiate(enemy, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            
            yield return new WaitForSeconds(0.1f);
            count -= 1;
        }
    }
}
