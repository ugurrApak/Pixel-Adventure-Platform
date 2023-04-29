using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            if(SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
            {
                SceneLoader.Instance.LoadNextLevel();
            }
            else
            {
                SceneLoader.Instance.LoadMainMenu();
            }
        }
    }
}
