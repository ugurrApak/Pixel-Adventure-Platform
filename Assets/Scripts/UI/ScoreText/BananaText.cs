using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BananaText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bananaText;
    int bananaCount;
    private void OnEnable()
    {
        Banana.OnBananaCollected += IncrementBananaCount;
    }
    private void OnDisable()
    {
        Banana.OnBananaCollected -= IncrementBananaCount;
    }
    void IncrementBananaCount()
    {
        bananaCount++;
        bananaText.text = bananaCount.ToString();
    }
}
