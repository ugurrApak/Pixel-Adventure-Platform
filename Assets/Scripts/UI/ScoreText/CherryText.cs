using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CherryText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI cherryText;
    public static int cherryCount;
    private void OnEnable()
    {
        Cherry.OnCherryCollected += IncrementCherryCount;
    }
    private void OnDisable()
    {
        Cherry.OnCherryCollected -= IncrementCherryCount;
    }
    void IncrementCherryCount()
    {
        cherryCount++;
        cherryText.text = cherryCount.ToString();
    }
}
