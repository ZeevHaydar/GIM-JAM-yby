using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    public float offset;
    public GameObject projectile;
    public Transform shotPoint;
    private float timeBetweenShots = 0.75f;
    public float startTimeBetweenShots = 0f;

    void Update()
    {
        /*
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        */
        if (Time.time >= startTimeBetweenShots)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Shoot();
                startTimeBetweenShots = Time.time + timeBetweenShots;
            }
        }

        
    }

    private void Shoot()
    {
        Instantiate(projectile, shotPoint.position, shotPoint.rotation);
    }
}
