using System.Linq;
using TMPro;
using UnityEngine;
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
            //if there are no drones left end the level
            endLevel();
        }
    }
    //all the code that should be run when the level ends, adds up score etc.
    private void endLevel()
    {

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
