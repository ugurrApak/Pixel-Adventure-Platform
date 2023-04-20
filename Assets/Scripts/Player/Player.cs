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
    private Health health;
    private Transform liveImagesUIParent;
    List<Image> lives;
    private int initialHealthValue = 3;
    float cooldown = 0.5f;
    private void Awake()
    {
        objectPool = GameObject.FindGameObjectWithTag("FriendlyObjectPool").GetComponent<FriendlyBulletObjectPool>();
        liveImagesUIParent = GameObject.Find("Canvas/HealthBarPanel").transform;
        lives = liveImagesUIParent.GetComponentsInChildren<Image>().ToList();
        lives.RemoveAt(0);
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
    }
    private void OnDisable()
    {
        health.OnDeath.RemoveListener(Death);
        health.OnDeath.RemoveListener(UpdateHealthBar);
        health.OnHit.RemoveListener(UpdateHealthBar);
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Shoot());
        }
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
        for (int i = 0; i < lives.Count; i++)
        {
            if(i >= health.CurrentHealth)
            {
                lives[i].color = Color.black;
            }
            else
            {
                lives[i].color = Color.white;
            }
        }
    }

    public void Death()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled= false;
    }
}
