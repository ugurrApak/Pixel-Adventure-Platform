using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Melon : MonoBehaviour,ICollectible
{
    public static event Action OnMelonCollected;
    public void Collect()
    {
        Destroy(gameObject);
        OnMelonCollected?.Invoke();
    }
}
