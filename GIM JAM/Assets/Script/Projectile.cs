using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Projectile : MonoBehaviour
{
    public float speed = 20;
    public float lifetime;
    public int damage;
    public int damageCrit;

    private Rigidbody2D _rigidbody;
    private PlayerMovement _player;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        _rigidbody.velocity = _player.isFacingRight ? Vector2.right * speed : Vector2.left * speed;
        Destroy(gameObject,lifetime);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        /*Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(20);
        }
        Destroy(gameObject);*/

        if (hitInfo.CompareTag("Enemy"))
        {
            Boss en = hitInfo.GetComponent<Boss>();
            en.TakeDamage(Random.Range(0, 100) < 50  ? damage : damageCrit);
            en.Hit();
            
            Destroy(gameObject);
        }
    }
}
