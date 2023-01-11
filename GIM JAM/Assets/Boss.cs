using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour
{
    public int baseHP;
    private int _curHP;

    [Header("Hand Drop Ability")]
    public GameObject handPrefab;
    public float handDropTimeCooldown;
    private float _handAttackTime;
    
    [Header("Ice Cream Rain Ability")]
    public GameObject iceCreamPrefab;
    public int maxSpawn;
    public Vector2 spawnArea;
    public float iceCreamRainTimeCooldown;
    private float _iceCreamAttackTime;

    public Player target;

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
    }

    private void Update()
    {
        // mengecek targetnya ada atau tidak, jika tidak ada di return;
        if (target == null) return;
        
        // Hand Drop Ability Ability
        if (Time.time >= _handAttackTime)
        {
            HandAttack();
            _handAttackTime = Time.time + handDropTimeCooldown;
        }
        
        // Ice Cream Rain Ability
        if (Time.time >= _iceCreamAttackTime)
        {
            StartCoroutine(IceCreamRainAttack());
            _iceCreamAttackTime = Time.time + iceCreamRainTimeCooldown;
        }
    }

    void HandAttack()
    {
        Instantiate(handPrefab, new Vector3(target.transform.position.x, target.transform.position.y + 5f, 0f), Quaternion.identity);
    }

    IEnumerator IceCreamRainAttack()
    {
        for (int i = 0; i < maxSpawn; i++)
        {
            yield return new WaitForSeconds(1f);
            
            float ran = Random.Range(-(spawnArea.x / 2), spawnArea.x / 2);
            Instantiate(iceCreamPrefab, new Vector3(ran, transform.position.y + spawnArea.y, 0f), quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + new Vector3(0, spawnArea.y, 0), new Vector3(spawnArea.x, 0,0));
    }
}
