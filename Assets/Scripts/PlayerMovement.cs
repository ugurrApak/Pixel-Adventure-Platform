using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 5.6f;
    [SerializeField] LayerMask layer;
    [SerializeField] bool isGround = false;
    [SerializeField] float jumpForce = 9.2f;
    bool canDoubleJump = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = UnityEngine.Input.GetAxisRaw("Horizontal");
        PlayerMove(horizontal);
        GroundCheck();
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        Debug.Log(isGround);
        Debug.Log(canDoubleJump);
    }
    void PlayerMove(float horizontal)
    {
        if (rb != null)
        {
            rb.velocity = new Vector2(horizontal * speed * 100 * Time.fixedDeltaTime, rb.velocity.y);
        }
    }
    private void GroundCheck()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, 1.1f,layer);
        if(ray.collider != null)
        {
            isGround= true;
            canDoubleJump = false;
            rb.velocity= new Vector2(rb.velocity.x,0f);
        }
        else
        {
            isGround= false;
        }
    }
    void Jump()
    {
        if (isGround)
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
