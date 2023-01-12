using System;
using UnityEngine;

public class BossFollow : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float wrapLimit;

    private void Update()
    {
        if (target == null) return;

        Vector3 offset = target.transform.position - transform.position;

        transform.position += new Vector3(offset.x * speed * Time.deltaTime, 0, 0);
        
        Wrap();
    }

    void Wrap()
    {
        if (transform.position.x >= wrapLimit)
        {
            transform.position = new Vector3(-wrapLimit + 2f, transform.position.y, 0);
        }

        else if (transform.position.x <= -wrapLimit)
        {
            transform.position = new Vector3(wrapLimit - 2f, transform.position.y, 0);
        }
    }
}