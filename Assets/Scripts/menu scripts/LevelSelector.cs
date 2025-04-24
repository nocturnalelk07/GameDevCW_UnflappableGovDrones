using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private levelBehaviour[] levels;
    [SerializeField] private menuMovement menuMovement;
    private saveDataClass saveData;

    void Start()
    {
        //figure out which levels are unlocked
        saveData = new saveDataClass();
        saveGameSystem.LoadGame(PlayerPrefs.GetString("name", "default"));
        setUpLevels();
    }

    private void setUpLevels()
    {
        foreach (levelBehaviour level in levels)
        {
            level.unlockThis(saveData.levelUnlocked);
        }
    }
}
