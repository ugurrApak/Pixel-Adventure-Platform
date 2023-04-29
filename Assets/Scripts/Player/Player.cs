using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using HealthSystem;
using System.Linq;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] FriendlyBulletObjectPool objectPool = null;
    Rigidbody2D rb;
    Animator anim;
    private Health health;
    private int initialHealthValue = 3;
    float cooldown = 0.5f;
    public static bool IsDead { get; set; }
    private void Awake()
    {
        objectPool = GameObject.FindGameObjectWithTag("FriendlyObjectPool").GetComponent<FriendlyBulletObjectPool>();
        rb = GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
    }
    private void OnEnable()
    {
        if(health == null)
        {
            health = GetComponent<Health>();
            health.InitializeHealth(initialHealthValue);
        }
        health.OnDeath.AddListener(Death);
        health.OnDeath.AddListener(UpdateHealthBar);
        health.OnHit.AddListener(UpdateHealthBar);
        health.OnHit.AddListener(Hit);
    }
    private void OnDisable()
    {
        health.OnDeath.RemoveListener(Death);
        health.OnDeath.RemoveListener(UpdateHealthBar);
        health.OnHit.RemoveListener(UpdateHealthBar);
        health.OnHit.RemoveListener(Hit);
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Shoot());
        }
        DeadZone();
    }
    IEnumerator Shoot()
    {
        GameObject obj = objectPool.GetPooledObject();
        obj.transform.position = transform.position;
        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 0f) * FriendlyBullet.speed;
        yield return new WaitForSeconds(cooldown);
    }
    private void UpdateHealthBar()
    {
        HealthBar.Instance.UpdateHealthBar(health);
    }

    public void Death()
    {
        StartCoroutine(WaitDeadAnimaton());
    }
    private void Hit()
    {
        anim.Play("Hit");
        rb.AddForce(new Vector2(-transform.localScale.x * 10f,20f),ForceMode2D.Impulse);
    }
    private void DeadZone()
    {
        if(transform.position.y < -3f)
        {
            IsDead = true;
            Destroy(gameObject,2f);
        }
    }
    IEnumerator WaitDeadAnimaton()
    {
        Hit();
        GetComponent<Collider2D>().enabled = false;
        rb.gravityScale = 0f;
        yield return new WaitForSeconds(anim.runtimeAnimatorController.animationClips[0].length);
        rb.gravityScale = 9.13f;
        IsDead = true;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
