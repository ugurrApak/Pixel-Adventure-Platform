using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] AudioSource inGameSound;
    private void Update()
    {
        if (!UIManager.Ingame)
        {
            inGameSound.Pause();
        }
        else if(!inGameSound.isPlaying)
        {
            inGameSound.Play();
        }
    }
}
