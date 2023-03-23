using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    
    public TMP_Text NextLevel;

    public void Awake()
    {
        PlayerData data = SaveManager.LoadData();
        if(data != null)
        {
            if (data.GetUnlockedLevels() > LevelSelector.GetUnlockedLevels())
                LevelSelector.SetUnlockedLevels(data.GetUnlockedLevels());
        }
        NextLevel.text = "Level " + LevelSelector.activeLevel.Substring(3);
    }

    
    public void PlayGame()
    {
        SceneManager.LoadScene(LevelSelector.activeLevel );
    }

    public void QuitGame()
    {
        Application.Quit();
        
    }

    public void OpenLevels()
    {
        SceneManager.LoadScene("Levels");
    }

    public static void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
