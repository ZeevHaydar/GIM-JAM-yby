using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Stat")] 
    public HealthBar healthStat;
    public int maxHealth = 100;
    private int _currentHealth;

    [Header("Ranged Attack Setting")]
    public GameObject projectile;
    public Transform shotPoint;

    private void Start()
    {
        _currentHealth = maxHealth;
        healthStat.UpdateHealth(_currentHealth, maxHealth);
    }

    private void Update()
    {
        if (GameManager.instance.GameOverOrPause()) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(projectile, shotPoint.position, quaternion.identity);
        }
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        Debug.Log(_currentHealth);

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Die();
        }
        
        AudioManager.instance.PlaySFX("Player Hit");
        healthStat.UpdateHealth(_currentHealth, maxHealth);
    }

    void Die()
    {
        GameManager.instance.isGameOver = true;
        Destroy(gameObject);
    }
}
