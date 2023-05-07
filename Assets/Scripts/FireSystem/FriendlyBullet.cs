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
    void Awake()
    {
        health = GetComponent<Health>();
        health.InitializeHealth(initialHealth);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHitable hittable = collision.GetComponent<IHitable>();
        if (hittable != null && !collision.GetComponent<Player>() && !collision.GetComponent<Cherry>() && !collision.GetComponent<Banana>() && !collision.GetComponent<Melon>() && !collision.GetComponent<Apple>())
        {
            hittable.GetHit(1, gameObject);
            health.GetHit(1, gameObject);
            gameObject.SetActive(false);
        }
        else if (!collision.GetComponent<Player>() && !collision.GetComponent<Cherry>() && !collision.GetComponent<Banana>() && !collision.GetComponent<Melon>() && !collision.GetComponent<Apple>())
        {
            gameObject.SetActive(false);
        }
    }
}
