using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject PausePanel;
    [SerializeField] TMP_Text score;
    [SerializeField] TMP_Text bestScore;
    public static bool Ingame = true;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore",0);
        }
        losePanel.SetActive(false);
        PausePanel.SetActive(false);
    }
    private void Update()
    {
        if (Player.IsDead)
        {
            StartCoroutine(DelayLosePanel());
            Ingame= false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Ingame)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
    IEnumerator DelayLosePanel()
    {
        yield return new WaitForSeconds(1f);
        losePanel.SetActive(true);
        score.text = ((AppleText.appleCount + CherryText.cherryCount + BananaText.bananaCount + MelonText.melonCount) * 10).ToString();
        //AppleText.appleCount = 0; CherryText.cherryCount = 0; BananaText.bananaCount = 0; MelonText.melonCount = 0;
        if (((AppleText.appleCount + CherryText.cherryCount + BananaText.bananaCount + MelonText.melonCount) * 10) < PlayerPrefs.GetInt("BestScore"))
        {
            bestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
        }
        else
        {
            PlayerPrefs.SetInt("BestScore",(AppleText.appleCount + CherryText.cherryCount + BananaText.bananaCount + MelonText.melonCount) * 10);
            bestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
        }
    }
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        AppleText.appleCount = 0; CherryText.cherryCount = 0; BananaText.bananaCount = 0; MelonText.melonCount = 0;
        Player.IsDead = false;
        SceneLoader.Instance.RestartLevel();
        Ingame = true;
    }
    public void Close()
    {
        Resume();
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        AppleText.appleCount = 0; CherryText.cherryCount = 0; BananaText.bananaCount = 0; MelonText.melonCount = 0;
        Ingame = true;
        Player.IsDead = false;
        SceneLoader.Instance.LoadMainMenu();
    }
    void Pause()
    {
        PausePanel.SetActive(true);
        AudioManager.Instance.Pause("Theme");
        Time.timeScale = 0F;
        Ingame = false;
    }
    void Resume()
    {
        PausePanel.SetActive(false);
        if (!AudioManager.Instance.IsPlaying("Theme"))
        {
            AudioManager.Instance.Play("Theme");
        }
        Time.timeScale = 1F;
        Ingame = true;
    }
}
