using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //Hurt animation
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("You Died!");
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
