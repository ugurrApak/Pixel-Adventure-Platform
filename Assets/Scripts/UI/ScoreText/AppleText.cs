using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AppleText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI appleText;
    int appleCount;
    private void OnEnable()
    {
        Apple.OnAppleCollected += IncrementAppleCount;
    }
    private void OnDisable()
    {
        Apple.OnAppleCollected -= IncrementAppleCount;
    }
    void IncrementAppleCount()
    {
        appleCount++;
        appleText.text = appleCount.ToString();
    }
}
