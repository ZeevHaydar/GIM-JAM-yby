using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask whatIsSolid;
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
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
            DestroyProjectile();
        }
        transform.Translate(transform.up * speed * Time.deltaTime);
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
