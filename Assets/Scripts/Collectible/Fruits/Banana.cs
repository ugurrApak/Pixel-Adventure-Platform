using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Banana : MonoBehaviour,ICollectible
{
    public static event Action OnBananaCollected;
    public void Collect()
    {
        Destroy(gameObject);
        OnBananaCollected?.Invoke();
    }
}
