using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        StartCoroutine(WaitForFall());
    }
    IEnumerator WaitForFall()
    {
        yield return new WaitForSeconds(0.4f);
        anim.SetTrigger("OnPlatform");
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
