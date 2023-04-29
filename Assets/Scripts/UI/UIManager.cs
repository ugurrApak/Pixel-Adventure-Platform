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
    public static bool Ingame = true;
    private void Awake()
    {
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
            PausePanel.SetActive(true);
            Ingame = false;
        }
    }
    IEnumerator DelayLosePanel()
    {
        yield return new WaitForSeconds(1f);
        losePanel.SetActive(true);
        score.text = ((AppleText.appleCount + CherryText.cherryCount + BananaText.bananaCount + MelonText.melonCount) * 10).ToString();
    }
    public void RestartLevel()
    {
        Player.IsDead = false;
        SceneLoader.Instance.RestartLevel();
        Ingame = true;
    }
    public void Close()
    {
        PausePanel.SetActive(false);
        Ingame = true;
    }
    public void LoadMainMenu()
    {
        SceneLoader.Instance.LoadMainMenu();
    }
}
