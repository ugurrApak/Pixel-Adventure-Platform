using HealthSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public static float speed = 14.7f;
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float deathDelay = 5;
    [SerializeField]
    private int initialHealth = 1;
    [SerializeField]
    private Health health;
    void Start()
    {
        health = GetComponent<Health>();
        health.InitializeHealth(initialHealth);
    }
    private void Update()
    {
        StartCoroutine(DeathAfterDelay(deathDelay));
    }

    private IEnumerator DeathAfterDelay(float deathDelay)
    {
        yield return new WaitForSeconds(deathDelay);
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
            gameObject.SetActive(false);
        }
    }
}
