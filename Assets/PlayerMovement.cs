using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Attributes
    public float moveSpeed;
    public float jumpForce;
    private Rigidbody2D rigid_body;
    private bool isFacingRight = true;
    private float moveDirection;
    private bool isOnJump = false;
    public Transform CekTanah;
    public Transform CekAtap;
    public LayerMask groundObject;
    private bool diTanah;
    public float checkRadius;
    private int jumpCount;
    public int maxJumpCount;




    // Awake dipanggil ketika semua objek telah diinisiasi
    private void Awake()
    {
        rigid_body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        jumpCount = maxJumpCount;

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

    }
    
    private void FixedUpdate()
    {
        //cek apakah nyentuh tanah
        diTanah = Physics2D.OverlapCircle(CekTanah.position, checkRadius, groundObject);

        // Moves
        Move();

        if (diTanah)
        {
            jumpCount = maxJumpCount;
        }
    }
    private void processInput()
    {
        moveDirection = Input.GetAxis("Horizontal"); //get the input
        
        //check jump
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            isOnJump = true;
        }
    }
    
    private void Animation()
    {
        if (moveDirection > 0 && !isFacingRight)
        {
            FlipKiriKanan();
        }
        else if (moveDirection < 0 && isFacingRight)
        {
            FlipKiriKanan();
        }
    }

    private void FlipKiriKanan()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void Move()
    {
        rigid_body.velocity = new Vector2(moveDirection * moveSpeed, rigid_body.velocity.y);
        if (isOnJump)
        {
            rigid_body.AddForce(new Vector2(0f, jumpForce));
            jumpCount--;
        }
        isOnJump = false;
    }
}
