using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 10f;
    [SerializeField] LayerMask layer;
    [SerializeField] bool isGround = false;
    [SerializeField] float jumpForce = 12f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        PlayerMove(horizontal);
        GroundCheck();
        Jump();
    }
    void PlayerMove(float horizontal)
    {
        if (rb != null)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
    }
    private void GroundCheck()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, 1.3f,layer);
        if(ray.collider != null)
        {
            isGround= true;
        }
        else
        {
            isGround= false;
        }
    }
    void Jump()
    {
        if (rb != null && isGround)
        {
            rb.AddForce(new Vector2(rb.velocity.x,Input.GetAxisRaw("Jump") * jumpForce));
        }
    }
}
