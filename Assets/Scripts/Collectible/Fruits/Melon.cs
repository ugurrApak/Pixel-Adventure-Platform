using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Melon : MonoBehaviour,ICollectible
{
    public static event Action OnMelonCollected;
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Collect()
    {
        StartCoroutine(WaitMelonAnimation());
    }
    IEnumerator WaitMelonAnimation()
    {
        anim.SetBool("IsCollected", true);
        yield return new WaitForSeconds(anim.runtimeAnimatorController.animationClips[1].length);
        Destroy(gameObject);
        OnMelonCollected?.Invoke();
    }
}
