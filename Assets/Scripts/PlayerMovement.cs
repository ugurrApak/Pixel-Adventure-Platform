using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 10f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        PlayerMove(horizontal);
    }
    void PlayerMove(float horizontal)
    {
        if (rb != null)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
    }
}
