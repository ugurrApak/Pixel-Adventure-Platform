using System.Collections;
using System.Collections.Generic;
using HealthSystem;
using UnityEngine;
using UnityEngine.Pool;

public class Snall : MonoBehaviour
{
    [SerializeField] GameObject parent;
    WaypointFollower waypointFollower;
    float animJumpForce;
    Rigidbody2D rb;
    BoxCollider2D enemyCollider;
    Animator anim;
    Health health;
    int initialHealthValue = 1;
    bool isDieByBullet;
    private void OnEnable()
    {
        if (health == null)
        {
            health = GetComponent<Health>();
            health.InitializeHealth(initialHealthValue);
        }
        health.OnDeath.AddListener(Death);
    }
    private void OnDisable()
    {
        health.OnDeath.RemoveListener(Death);
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        waypointFollower = GetComponent<WaypointFollower>();
    }
    private void Death()
    {
        isDieByBullet = true;
        StartCoroutine(WaitHitAnimation());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            isDieByBullet = false;
            StartCoroutine(WaitHitAnimation());
        }
    }
    IEnumerator WaitHitAnimation()
    {
        //anim.SetTrigger("Death");
        if (isDieByBullet)
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            rb.AddForce(new Vector2(rb.velocity.x, 4f), ForceMode2D.Impulse);
        }
        else
        {
            //gameObject.GetComponent<CircleCollider2D>().enabled = false;
            rb.AddForce(new Vector2(rb.velocity.x, 20f), ForceMode2D.Impulse);
            waypointFollower.speed = 25f;
        }
        rb.gravityScale = 0f;
        yield return new WaitForSeconds(anim.runtimeAnimatorController.animationClips[0].length);
        rb.gravityScale = 9.13f;
        enemyCollider.enabled = false;
        //yield return new WaitForSeconds(2f);
        //Destroy(parent);
    }
}