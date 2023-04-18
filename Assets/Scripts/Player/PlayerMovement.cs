using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 5.6f;
    [SerializeField] LayerMask layer;
    [SerializeField] float jumpForce = 9.2f;
    [SerializeField] float boxCastDistance = 0.7f;
    BoxCollider2D playerCollider;
    private bool canDoubleJump = false;
    private bool isRun;
    private bool isJump;

    public bool IsJump
    {
        get { return isJump; }
        set { isJump = value; }
    }

    public bool IsRun
    {
        get { return isRun; }
        set { isRun = value; }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        if(GroundCheck()) IsJump= false; else IsJump= true;
    }
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        PlayerMove(horizontal);
    }
    void PlayerMove(float horizontal)
    {
        if (rb != null && horizontal != 0)
        {
            rb.velocity = new Vector2(horizontal * speed * 100 * Time.fixedDeltaTime, rb.velocity.y);
            isRun = true;
        }
        else
        {
            isRun = false;
            rb.velocity = new Vector2(0f,rb.velocity.y);
        }
    }
    private bool GroundCheck()
    {
        if (Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, boxCastDistance, layer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void Jump()
    {
        if (GroundCheck())
        {
            rb.AddForce(new Vector2(rb.velocity.x, 1000 * jumpForce * Time.fixedDeltaTime));
            canDoubleJump = true;
        }
        else if (canDoubleJump)
        {
            rb.AddForce(new Vector2(rb.velocity.x, 1000 * jumpForce * Time.fixedDeltaTime));
            canDoubleJump = false;
        }
    }
}
