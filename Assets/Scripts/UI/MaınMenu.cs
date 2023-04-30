using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MaınMenu : MonoBehaviour
{
    [SerializeField] Canvas settingsPanel;
    [SerializeField] Canvas levelSelectPanel;
    [SerializeField] GameObject levelSelectTable;
    [SerializeField] List<Button> levels;
    int topLevel;
    private void Awake()
    {
        settingsPanel.gameObject.SetActive(false);
        levelSelectPanel.gameObject.SetActive(false);
        levels = levelSelectTable.GetComponentsInChildren<Button>().ToList();
    }
    private void Start()
    {
        if (!PlayerPrefs.HasKey("topLevel"))
        {
            PlayerPrefs.SetInt("topLevel",1);
        }
        topLevel = PlayerPrefs.GetInt("topLevel");
        for (int i = 0; i < levels.Count; i++)
        {
            if (i < topLevel)
            {
                levels[i].interactable = true;
                levels[i].GetComponentsInChildren<Image>()[1].gameObject.SetActive(true);
                levels[i].GetComponentsInChildren<Image>()[2].gameObject.SetActive(false);
            }
            else
            {
                levels[i].interactable = false;
                levels[i].GetComponentsInChildren<Image>()[2].gameObject.SetActive(true);
                levels[i].GetComponentsInChildren<Image>()[1].gameObject.SetActive(false);
            }
        }
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
        SceneLoader.Instance.LoadLevelWithIndex(PlayerPrefs.GetInt("topLevel"));
    }
    public void CloseLevelSelect()
    {
        levelSelectPanel.gameObject.SetActive(false);
    }
    public void LevelSelect()
    {
        levelSelectPanel.gameObject.SetActive(true);
    }
    public void LoadLevel(int index)
    {
        SceneLoader.Instance.LoadLevelWithIndex(index);
    }
}
