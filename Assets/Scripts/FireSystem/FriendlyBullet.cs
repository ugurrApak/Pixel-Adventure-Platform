using HealthSystem;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class FriendlyBullet : MonoBehaviour
{
    public static float speed = 22.7f;
    Rigidbody2D rb2d;
    [SerializeField]
    private int initialHealth = 1;
    [SerializeField]
    private Health health;
    [SerializeField]
    Transform parentTransform;
    void Awake()
    {
        health = GetComponent<Health>();
        health.InitializeHealth(initialHealth);
        parentTransform = GameObject.FindWithTag("Player").transform;
    }
    private void Update()
    {
        if (transform.position.x > 17 || transform.position.x < -22)
        {
            DeathAfterDelay();
        }
    }
    void DeathAfterDelay()
    {
        health.GetHit(1, gameObject);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHitable hittable = collision.GetComponent<IHitable>();
        if (hittable != null)
        {
            hittable.GetHit(1, gameObject);
            health.GetHit(1, gameObject);
            Destroy(gameObject);
        }
    }
}
