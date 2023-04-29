using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    int topLevel;
    int currentLevel;
    AudioSource winSound;
    private void Awake()
    {
        winSound= GetComponent<AudioSource>();
    }
    private void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        topLevel = PlayerPrefs.GetInt("topLevel");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            Save();
            NextLevel();
            winSound.Play();
        }
    }
    void Save()
    {
        if (topLevel < currentLevel + 1 && currentLevel + 1 < SceneManager.sceneCountInBuildSettings)
        {
            PlayerPrefs.SetInt("topLevel", currentLevel + 1);
        }
    }
    void NextLevel()
    {
        if (currentLevel + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneLoader.Instance.LoadNextLevel();
        }
        else
        {
            SceneLoader.Instance.LoadMainMenu();
        }
    }
}
