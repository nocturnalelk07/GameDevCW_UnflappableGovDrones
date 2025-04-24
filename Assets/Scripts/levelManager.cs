using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class levelManager : MonoBehaviour
{
    //this singleton handles all the global level information, how many drones are left, how many targets, is the level finished etc

    public static levelManager instance { get; private set; }
    private int targetsRemaining = 0;
    [SerializeField] private DroneBaseClass[] droneTypesAvailable;
    [SerializeField] private int dronesAvailable;
    [SerializeField] private TextMeshProUGUI dronesRemainingText;
    private const string remainingBaseString = "drones remaining: ";
    private int dronesRemaining;
    private int points;
    private int levelNumber;
    [SerializeField] private GameObject menu; 

    public void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        points = 0;
        dronesRemaining = dronesAvailable;
        dronesRemainingText.text = remainingBaseString + dronesRemaining;
        levelNumber = SceneManager.GetActiveScene().buildIndex;
    }

    //checks that the drone is an allowed type 
    public bool checkType(DroneBaseClass drone)
    {
        foreach (DroneBaseClass droneType in droneTypesAvailable) 
        {
            if (droneType.GetType() == drone.GetType())
            {
                return true;
            }
        }
        return false;
    }
    public void checkGameOver()
    {
        if (dronesRemaining <= 0 || targetsRemaining <= 0)
        {
            //if there are no drones left or the player got all the targets, end the level
            endLevel();
        }
    }
    //all the code that should be run when the level ends, adds up score etc.
    private void endLevel()
    {
        saveDataClass saveData = saveGameSystem.LoadGame("default");
        if (saveData != null)
        {
            Debug.Log("save was not null");
            saveData.playerPoints += points;
            Debug.Log(saveData.playerPoints + " " + saveData.levelUnlocked);
        } else
        {
            Debug.Log("did not find save game");
            saveData = new saveDataClass();
        }


        //unlock next level if they got all targets
        if (targetsRemaining <= 0 && saveData.levelUnlocked < levelNumber)
        {
            saveData.levelUnlocked++;
            saveGameSystem.SaveGame(saveData, "default");
        }

        //give player the option to try again or go back to menu with popup
        //display their score
        //tell them if they won or not
        menu.SetActive(true);

        //for now just send back to main menu
        SceneManager.LoadScene("Menu");
    }

    public void addPoints()
    {
        points += dronesRemaining;
    }
    //incrementers and decrementers for variables
    public void incrementTargetsRemaining() { targetsRemaining++; }
    public void decrementTargetsRemaining() { targetsRemaining--; }
    public void decrementDronesRemaining() { dronesRemaining--; dronesRemainingText.text = remainingBaseString + dronesRemaining; }

    //getters and setters for values
    public int getTargetsRemaining() { return targetsRemaining; }
    public int getDronesRemaining() { return dronesRemaining; }
    public int getDronesAvailableAtStart() { return dronesAvailable; }
}
