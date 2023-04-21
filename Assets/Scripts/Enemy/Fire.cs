using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    Animator anim;
    [SerializeField] BoxCollider2D fireOnCollider;
    bool canHit = true;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "FireOn")
        {
            fireOnCollider.enabled = true;
        }
        else
        {
            fireOnCollider.enabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetTrigger("FireHit");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (fireOnCollider.enabled && canHit)
        {
            canHit = false;
            StartCoroutine(WaitAfterHit(collision));
        }
    }
    IEnumerator WaitAfterHit(Collider2D collision)
    {
        IHitable hitable = collision.gameObject.GetComponent<IHitable>();
        if (hitable != null)
        {
            hitable.GetHit(1, gameObject);
        }
        yield return new WaitForSeconds(0.7f);
        canHit = true;
    }
}
