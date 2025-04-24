using UnityEngine;


//this represents the save data for the game
[System.Serializable]
public class saveDataClass
{
    public int points {  get; set; }
    public int levelUnlocked { get; set; }
    public string username { get; set; }
}
