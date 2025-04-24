using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private levelBehaviour[] levels;
    [SerializeField] private menuMovement menuMovement;
    private saveDataClass saveData;

    void Start()
    {
        //figure out which levels are unlocked
        saveData = saveGameSystem.LoadGame("default");
        if (saveData == null )
        {
            Debug.Log("save data was null");
            saveData = new saveDataClass();
        } else
        {
            Debug.Log(saveData.levelUnlocked);
        }
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
