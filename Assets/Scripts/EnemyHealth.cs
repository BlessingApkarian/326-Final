using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 10;
    public int currHealth;

    public HealthBar healthBar;

    private void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnEnable()
    {
        currHealth = maxHealth;
    }

    private void Update()
    {
        if (ClickNPC.hitEnemy)
        {
            ModifyHealth(1);
            if(currHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
        ClickNPC.hitEnemy = false;
    }

    void ModifyHealth(int damage)
    {
        currHealth -= damage;
        healthBar.SetHealth(currHealth);
    }

}
