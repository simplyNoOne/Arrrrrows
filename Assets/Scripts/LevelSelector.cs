
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public static string activeLevel = "Lvl1";
    private static int levelsUnlocked = 1;

    private void Start()
    {
        string m_Path = Application.persistentDataPath;

        //Output the Game data path to the console
        Debug.Log("dataPath : " + m_Path);
    }

    public void Select(string levelName)
    {
        if (int.Parse(levelName.Substring(3)) <= levelsUnlocked)
        {
            activeLevel = levelName;
            Menu.ToMenu();
        }
    }

    public static void Advance()
    {
        if(levelsUnlocked < 10)
        {
            if(int.Parse(activeLevel.Substring(3)) == levelsUnlocked)
                levelsUnlocked++;
        }
        if(activeLevel != "Lvl10")
            activeLevel = "Lvl" + (int.Parse(activeLevel.Substring(3)) + 1).ToString();

        SaveManager.SaveData();
    }

    public static int GetUnlockedLevels() { return levelsUnlocked; }
    public static void SetUnlockedLevels(int levels) {  levelsUnlocked = levels; }
}
