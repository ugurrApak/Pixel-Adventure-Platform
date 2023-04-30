using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    Animator anim;
    public static SceneLoader Instance { get; set; }
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
        anim= GetComponentInChildren<Animator>();
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void LoadMainMenu()
    {
        StartCoroutine(LoadLevel(0));
    }
    public void RestartLevel()
    {
        AudioManager.Instance.Stop("Theme");
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }
    public void LoadLevelWithIndex(int index)
    {
        StartCoroutine(LoadLevel(index));
    }
    IEnumerator LoadLevel(int index)
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1.5f);
        if(index != 0)
        {
            AudioManager.Instance.Play("Theme");
        }
        else
        {
            AudioManager.Instance.Stop("Theme");
        }
        SceneManager.LoadScene(index);
    }
}
