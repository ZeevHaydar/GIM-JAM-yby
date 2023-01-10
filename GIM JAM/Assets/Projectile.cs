using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20;
    public float lifeTime;
    //public float distance;
    //public LayerMask whatIsSolid;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    /*
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                Debug.Log("Hit the Enemy");
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(20);
            }
            //DestroyProjectile();
        }
        transform.Translate(transform.up * speed * Time.deltaTime);
    }
    */

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(20);
        }
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
