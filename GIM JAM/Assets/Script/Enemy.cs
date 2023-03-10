using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //Hurt animation
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died!");
        // Die animation

        // Disable enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        for (int i = 0; i <= 30000; i++)
        {

        }
        Destroy(gameObject);

    }
}
