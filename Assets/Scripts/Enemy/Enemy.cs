using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] EnemyBulletObjectPool objectPool;
    bool isShooting;
    private void Awake()
    {
        objectPool = GameObject.FindGameObjectWithTag("EnemyObjectPool").GetComponent<EnemyBulletObjectPool>();

    }
    private void Update()
    {
        Debug.DrawRay(transform.position, new Vector2(-1 * transform.localScale.x, 0f) * 55f,Color.red);
        if (!isShooting && CanShoot())
        {
            isShooting = true;
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1.4f);
        GameObject obj = objectPool.GetPooledObject();
        obj.transform.position = transform.position;
        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * transform.localScale.x, 0f) * EnemyBullet.speed;
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
}
