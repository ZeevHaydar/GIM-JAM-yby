using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D rigid_body;
    private bool isFacingRight = true;
    private float moveDirection;

    // Awake dipanggil ketika semua objek telah diinisiasi
    private void Awake()
    {
        rigid_body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get Inputs
        moveDirection = Input.GetAxis("Horizontal");

        // Animate
        if (moveDirection > 0 && !isFacingRight)
        {
            FlipKiriKanan();
        }
        else if (moveDirection < 0 && isFacingRight)
        {
            FlipKiriKanan();
        }

        // Moves
        rigid_body.velocity = new Vector2(moveDirection * moveSpeed, rigid_body.velocity.y);


    }

    private void FlipKiriKanan()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
