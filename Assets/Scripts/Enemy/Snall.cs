using System.Collections;
using System.Collections.Generic;
using HealthSystem;
using UnityEngine;
using UnityEngine.Pool;

public class Snall : MonoBehaviour
{
    [SerializeField] GameObject parent;
    WaypointFollower waypointFollower;
    Rigidbody2D rb;
    BoxCollider2D enemyCollider;
    Animator anim;
    Health health;
    bool inShell;
    int initialHealthValue = 1;
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
        StartCoroutine(WaitHitAnimation());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            anim.SetTrigger("Death");
            waypointFollower.speed = 15f;
            anim.SetTrigger("InShell");
        }
    }
    IEnumerator WaitHitAnimation()
    {
        anim.SetTrigger("Death");
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        rb.AddForce(new Vector2(rb.velocity.x, 2f), ForceMode2D.Impulse);
        rb.gravityScale = 0f;
        yield return new WaitForSeconds(anim.runtimeAnimatorController.animationClips[0].length/2f);
        rb.gravityScale = 9.13f;
        enemyCollider.enabled = false;
        yield return new WaitForSeconds(2f);
        Destroy(parent);
    }
}