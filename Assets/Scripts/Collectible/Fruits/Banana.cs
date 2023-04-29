using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Banana : MonoBehaviour,ICollectible
{
    public static event Action OnBananaCollected;
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Collect()
    {
        StartCoroutine(WaitBananaAnimation());
    }
    IEnumerator WaitBananaAnimation()
    {
        anim.SetBool("IsCollected", true);
        yield return new WaitForSeconds(anim.runtimeAnimatorController.animationClips[1].length);
        Destroy(gameObject);
        OnBananaCollected?.Invoke();
    }
}
