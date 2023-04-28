using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaınMenu : MonoBehaviour
{
    [SerializeField] Canvas settingsPanel;
    [SerializeField] Canvas levelSelectPanel;
    private void Awake()
    {
        settingsPanel.gameObject.SetActive(false);
        levelSelectPanel.gameObject.SetActive(false);
    }
    public void CloseSettingPanel()
    {
        settingsPanel.gameObject.SetActive(false);
    }
    public void SettingsPanel()
    {
        settingsPanel.gameObject.SetActive(true);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void CloseLevelSelect()
    {
        levelSelectPanel.gameObject.SetActive(false);
    }
    public void LevelSelect()
    {
        levelSelectPanel.gameObject.SetActive(true);
    }
}
