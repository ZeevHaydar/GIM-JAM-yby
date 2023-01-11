using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public int damage;
    public float speed;
    public float lifetime;

    // set lifetime
    private void Start() => Destroy(gameObject, lifetime);
    
    // drop
    private void Update() => transform.position += Vector3.down * speed * Time.deltaTime;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
