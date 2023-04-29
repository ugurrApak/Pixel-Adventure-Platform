using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MelonText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI melonText;
    public static int melonCount;
    private void OnEnable()
    {
        Melon.OnMelonCollected += IncrementMelonCount;
    }
    private void OnDisable()
    {
        Melon.OnMelonCollected -= IncrementMelonCount;
    }
    void IncrementMelonCount()
    {
        melonCount++;
        melonText.text = melonCount.ToString();
    }
}
