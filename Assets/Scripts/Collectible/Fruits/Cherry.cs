using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cherry : MonoBehaviour,ICollectible
{
    public static event Action OnCherryCollected;
    Animator anim;
    private void Awake()
    {
        anim= GetComponent<Animator>();
    }
    public void Collect()
    {
        StartCoroutine(WaitCherryAnimation());
    }
    IEnumerator WaitCherryAnimation()
    {
        anim.SetBool("IsCollected", true);
        yield return new WaitForSeconds(anim.runtimeAnimatorController.animationClips[1].length);
        Destroy(gameObject);
        OnCherryCollected?.Invoke();
    }
}
