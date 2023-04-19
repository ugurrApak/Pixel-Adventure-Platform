using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] LayerMask layer;
    [SerializeField] float speed = 5.6f;//Player speed on the x-axis
    [SerializeField] float boxCastDistance = 0.7f;//Ground checking.
    [SerializeField] float jumpHeight = 5f;//Limited jump distance.
    [SerializeField] float fallingGravityScale = 22f; //gravity as the player falls.
    [SerializeField] float gravityScale = 9.13f; //World gravity
    float jumpForce = 9.2f;//Jumping power.
    BoxCollider2D playerCollider;
    private bool canDoubleJump = false;
    private bool isRun;
    private bool isJump;
    private bool isFall;
    private bool isDoubleJump;

    public bool IsDoubleJump
    {
        get { return isDoubleJump; }
        private set { isDoubleJump = value; }
    }
    public bool IsFall
    {
        get { return isFall; }
        private set { isFall = value; }
    }
    public bool IsJump
    {
        get { return isJump; }
        private set { isJump = value; }
    }
    public bool IsRun
    {
        get { return isRun; }
        private set { isRun = value; }
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
        ChangeGravityOnFalling();
    }
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        PlayerMove(horizontal);
    }
    //Player movement on the x axis.
    void PlayerMove(float horizontal)
    {
        if (rb != null && horizontal != 0)
        {
            transform.localScale = new Vector3(horizontal, transform.localScale.y, transform.localScale.z);
            gameObject.transform.Translate(speed * horizontal, 0f, 0f);
            isRun = true;
        }
        else
        {
            isRun = false;
            gameObject.transform.Translate(0f, 0f, 0f);
        }
    }
    //Check if the player is on the ground.
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
    // Player Jump.
    void Jump()
    {
        if (GroundCheck())
        {
            isJump= true;
            jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
            rb.AddForce(new Vector2(rb.velocity.x,jumpForce),ForceMode2D.Impulse);
            canDoubleJump = true;
        }
        else if (canDoubleJump)
        {
            isJump= false;
            IsDoubleJump = true;
            jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
            rb.AddForce(new Vector2(rb.velocity.x,jumpForce),ForceMode2D.Impulse);
            canDoubleJump = false;
        }
    }
    //Increases gravity as the player falls.
    void ChangeGravityOnFalling()
    {
        if(rb.velocity.y >= 0f)
        {
            isFall = false;
            rb.gravityScale = gravityScale;
        }
        else if(rb.velocity.y < 0f)
        {
            IsDoubleJump= false;
            isJump = false;
            isFall = true;
            rb.gravityScale = fallingGravityScale;
        }
    }
}