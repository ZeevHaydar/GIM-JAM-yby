using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Attributes
    public float moveSpeed;
    public float jumpForce;
    public bool isFacingRight = true;
    public Animator anim;
    public float wrapLimit;
       
    private float moveDirection;
    private bool isGround;
    private Rigidbody2D _rigidbody;

    // Awake dipanggil ketika semua objek telah diinisiasi
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get Inputs
        processInput();

        // Animation
        Animation();

        // Moves
        Move();
        
        //Wrap
        Wrap();
    }
    
    private void processInput()
    {
        moveDirection = Input.GetAxis("Horizontal"); //get the input
        
        //check jump
        if (Input.GetButtonDown("Jump") && isGround)
        {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    
    private void Animation()
    {
        if (moveDirection > 0 && !isFacingRight)
        {
            FlipKiriKanan();
            anim.SetBool("isWalk", true);
        }
        else if (moveDirection < 0 && isFacingRight)
        {
            FlipKiriKanan();
            anim.SetBool("isWalk", true);
        }
        
        if(moveDirection == 0) anim.SetBool("isWalk", false);
    }

    private void FlipKiriKanan()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector2(moveDirection * moveSpeed, _rigidbody.velocity.y);
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

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground")) isGround = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) isGround = false;
    }
}
