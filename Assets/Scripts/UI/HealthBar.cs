using HealthSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar Instance { get; private set; }
    List<Image> lives;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        lives = gameObject.GetComponentsInChildren<Image>().ToList();
        lives.RemoveAt(0);
    }
    public void UpdateHealthBar(Health health)
    {
        for (int i = 0; i < lives.Count; i++)
        {
            if (i >= health.CurrentHealth)
            {
                lives[i].color = Color.black;
            }
            else
            {
                lives[i].color = Color.white;
            }
        }
    }
}
