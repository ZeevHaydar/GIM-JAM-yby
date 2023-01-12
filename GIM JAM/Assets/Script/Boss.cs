using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour
{
    [Header("Boss Stat")]
    public int baseHP;
    private int _curHP;
    public HealthBar healthBar;
    public CooldownUI cooldownUI_1;
    public CooldownUI cooldownUI_2;
    
    [Header("Target")]
    public Player target;

    [Header("Hand Drop Ability")]
    public GameObject handPrefab;
    public float handDropTimeCooldown;
    private float _handAttackTime;
    
    [Header("Ice Cream Rain Ability")]
    public GameObject[] iceCreamPrefab;
    public float iceCreamRainTimeCooldown;
    private float _iceCreamAttackTime;
    public int maxSpawn;
    public Vector2 spawnArea;

    private Animator _animator;
    

    private void Start()
    {
        Initialization();
    }

    // set agar ability tidak langsung muncul
    void Initialization()
    {
        _curHP = baseHP;
        _handAttackTime = handDropTimeCooldown;
        _iceCreamAttackTime = iceCreamRainTimeCooldown;
        _animator = GetComponent<Animator>();
        
        cooldownUI_1.Cooldown(_handAttackTime, handDropTimeCooldown);
        cooldownUI_2.Cooldown(_iceCreamAttackTime, iceCreamRainTimeCooldown);
        healthBar.UpdateHealth(_curHP, baseHP);
    }

    private void Update()
    {
        // mengecek targetnya ada atau tidak, jika tidak ada di return;
        if (target == null) return;
        
        // Hand Drop Ability Ability
        HandAttack();
        
        // Ice Cream Rain Ability
        IceCreamRain();
    }

    void HandAttack()
    {
        if (_handAttackTime >= 0)
        {
            _handAttackTime -= Time.deltaTime;
            cooldownUI_1.Cooldown(_handAttackTime, handDropTimeCooldown);
        }
        else
        {
            Instantiate(handPrefab, new Vector3(target.transform.position.x, target.transform.position.y + 12f, 0f), Quaternion.identity);
            
            cooldownUI_1.Cooldown(_handAttackTime, handDropTimeCooldown);
            _handAttackTime = handDropTimeCooldown;
        }
    }

    void IceCreamRain()
    {
        if (_iceCreamAttackTime >= 0)
        {
            _iceCreamAttackTime -= Time.deltaTime;
            cooldownUI_2.Cooldown(_iceCreamAttackTime, iceCreamRainTimeCooldown);
        }
        else
        {
            StartCoroutine(IceCreamRainAttack());
            
            IEnumerator IceCreamRainAttack()
            {
                for (int i = 0; i < maxSpawn; i++)
                {
                    yield return new WaitForSeconds(1f);
            
                    float ran = Random.Range(-(spawnArea.x / 2), spawnArea.x / 2);
                    int ranObj = Random.Range(0, iceCreamPrefab.Length);
                    Instantiate(iceCreamPrefab[ranObj], new Vector3(ran, transform.position.y + spawnArea.y, 0f), iceCreamPrefab[ranObj].transform.rotation);
                }
            }
            
            cooldownUI_2.Cooldown(_iceCreamAttackTime, iceCreamRainTimeCooldown);
            _iceCreamAttackTime = iceCreamRainTimeCooldown;
        }
    }

    public void TakeDamage(int amount)
    {
        _curHP -= amount;
        Debug.Log(_curHP);

        if (_curHP <= 0)
        {
            _curHP = 0;
            Destroy(gameObject);
        }
        
        healthBar.UpdateHealth(_curHP, baseHP);
    }

    public void Hit()
    {
        _animator.SetTrigger("Hit");
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + new Vector3(0, spawnArea.y, 0), new Vector3(spawnArea.x, 0,0));
    }
}
