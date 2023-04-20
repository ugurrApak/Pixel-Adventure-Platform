using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Apple : MonoBehaviour,ICollectible
{
    private Animator anim;
    public static event Action OnAppleCollected;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Collect()
    {
        StartCoroutine(WaitAppleAnimation());
    }
    IEnumerator WaitAppleAnimation()
    {
        anim.SetBool("IsCollected", true);
        yield return new WaitForSeconds(anim.runtimeAnimatorController.animationClips[1].length);
        Destroy(gameObject);
        OnAppleCollected?.Invoke();
        StartCoroutine(WaitAppleAnimation());
    }
}
