using System;
using System.Security.Cryptography;
using UnityEngine;

public class BossHand : MonoBehaviour
{
    public float speed;
    public int damage;
    public float limit = 2f;
    public Vector3 startPos;
    private bool isLimit = true;

    // mengeambil posisi awal 
    private void Start() => startPos = transform.position;
    
    private void Update()
    {
        // apakah posisi y nya itu kurang dari limit?
        if (transform.position.y < limit) isLimit = false;

        // posisinya diubah jika islimit true maka jalan turun ke bawah jika islimit false maka ke jalan ke atas
        transform.position +=
            isLimit ? Vector3.down * speed * 2f * Time.deltaTime : Vector3.up * speed * Time.deltaTime;

        // jika posisi y nya melebih start pos ke y maka destory gameobject
        if (transform.position.y >= startPos.y)
        {
            isLimit = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<Player>().TakeDamage(damage);
        }
    }
}