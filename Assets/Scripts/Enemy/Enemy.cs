using HealthSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] EnemyBulletObjectPool objectPool;
    Animator anim;
    Health health;
    int initialHealthValue = 1;
    bool isShooting;
    private void OnEnable()
    {
        if(health == null)
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
        objectPool = GameObject.FindGameObjectWithTag("EnemyObjectPool").GetComponent<EnemyBulletObjectPool>();
        anim= GetComponent<Animator>();

    }
    private void Update()
    {
        Debug.DrawRay(transform.position, new Vector2(-1 * transform.localScale.x, 0f) * 55f,Color.red);
        //anim.SetBool("IsShooting", isShooting);
        if (!isShooting && CanShoot())
        {
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot()
    {
        anim.SetTrigger("Shooting");
        isShooting = true;
        yield return new WaitForSeconds(anim.runtimeAnimatorController.animationClips[0].length);
        GameObject obj = objectPool.GetPooledObject();
        obj.transform.position = transform.position;
        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * transform.localScale.x, 0f) * EnemyBullet.speed;
        anim.SetTrigger("Run");
        yield return new WaitForSeconds(2f);
        isShooting = false;
    }
    bool CanShoot()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, new Vector2(-1 *transform.localScale.x,0f), 105f);
        if (ray.collider != null)
        {
            if (ray.collider.tag == "Player")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else return false;
    }
    private void Death()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
