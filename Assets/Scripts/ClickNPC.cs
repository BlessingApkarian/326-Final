using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickNPC : MonoBehaviour
{
    private Inventory inventory;
    public GameObject mushroom1Button;

    public static bool hitEnemy = false;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left mouse button
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform)
                {
                    Debug.Log(hit.transform.name);
                    if (hit.transform.CompareTag("NPC"))
                    {
                        Debug.Log("right click to speak to NPC");
                    }

                    if (hit.transform.CompareTag("enemy"))
                    {
                        Debug.Log("right click to attack");
                    }

                    if (hit.transform.CompareTag("collectable"))
                    {
                        Debug.Log("right click to gather items");
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(1)) // right mouse button (middle is 2)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform)
                {
                    Debug.Log(hit.transform.name);
                    if (hit.transform.CompareTag("NPC"))
                    {
                        OpenDialog();
                    }

                    if (hit.transform.CompareTag("enemy"))
                    {
                        hitEnemy = true;
                        DoDamage();
                    }

                    if (hit.transform.CompareTag("collectable"))
                    {
                        GatherItems(hit.transform.gameObject);
                    }
                }
            }
        }
    }

    void OpenDialog()
    {
        Debug.Log("Hello Izabelle");
    }

    void DoDamage()
    {
        Debug.Log("Damage Done: ");
    }

    void GatherItems(GameObject item)
    {
        Debug.Log("Gathered: ");
        for(int i = 0; i < inventory.slots.Length; i++)
        {
            if(inventory.isFull[i] == false)
            {
                // add item to inventory    
                inventory.isFull[i] = true;
                Instantiate(mushroom1Button, inventory.slots[i].transform, false); // instantiate a clickable icon in th einventory slot we just put that item in
                Destroy(item); // after we finish gathering, it disapears
                break;
            }
        }
    }

}
