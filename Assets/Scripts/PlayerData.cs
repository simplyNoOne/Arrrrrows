
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    private int unlockedLevels;

    public PlayerData()
    {
        unlockedLevels = LevelSelector.GetUnlockedLevels();
    }

    public int GetUnlockedLevels() { return unlockedLevels; }
}
