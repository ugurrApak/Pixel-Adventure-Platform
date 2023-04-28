using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaınMenu : MonoBehaviour
{
    [SerializeField] Canvas settingsPanel;
    private void Awake()
    {
        settingsPanel.gameObject.SetActive(false);
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
}
