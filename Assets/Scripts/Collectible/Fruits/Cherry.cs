using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cherry : MonoBehaviour,ICollectible
{
    public static event Action OnCherryCollected;
    public void Collect()
    {
        Destroy(gameObject);
        OnCherryCollected?.Invoke();
    }
}
