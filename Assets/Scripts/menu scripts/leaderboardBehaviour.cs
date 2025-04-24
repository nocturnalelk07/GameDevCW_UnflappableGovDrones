using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


//this controls the leaderboard and updates it with the players' data
public class leaderboardBehaviour : MonoBehaviour
{

    [SerializeField] private leaderboardEntry[] leaderboardEntries;
    private leaderboardEntry playerEntry;
    private string playername;
    private int playerPoints;

    private void Start()
    {
        setOtherEntries();
        setPlayerEntry();
        sortEntries();
        highlightPlayer();
    }

    private void setPlayerEntry()
    {
        playerEntry = leaderboardEntries[0];
        Text[] playerTexts = playerEntry.GetComponentsInChildren<Text>();
        saveDataClass saveData = saveGameSystem.LoadGame("default");
        if (saveData == null)
        {
            saveData = new saveDataClass();
        }
        playerEntry.username = saveData.username;
        playerEntry.points = saveData.playerPoints;
        playername = playerEntry.username;
        playerPoints = playerEntry.points;
        playerTexts[0].text = " name: " + playerEntry.username;
        playerTexts[1].text = " points: " + playerEntry.points;
    }

    private void setOtherEntries()
    {
        //use a class of example data to use, this would be real data from other players in an actual game
        foreach (leaderboardEntry entry in leaderboardEntries)
        {
            entry.username = leaderboardExampleData.getExampleName();
            entry.points = leaderboardExampleData.getExampleScore();
            Text[] entryTexts = entry.gameObject.GetComponentsInChildren<Text>();
            entryTexts[0].text = " name: " + entry.username;
            entryTexts[1].text = " points: " + entry.points;
            Debug.Log(entry.username);
        }
        
    }

    private void sortEntries()
    {
        //sorting algorithm, probably not efficient (but im getting short on time to finish this cw)
        //loop through with a bubble sort until entries are sorted by points
        while (!isSorted())
        {
            for (int i = 0; i < leaderboardEntries.Length - 1; i++)
            {
                compareEntries(leaderboardEntries[i], leaderboardEntries[i + 1]);
            }
        }
        //this sorts the entries to wherever they should be in the list
        


    }

    private void swapEntries(leaderboardEntry firstEntry, leaderboardEntry secondEntry)
    {
        Text[] firstText = firstEntry.gameObject.GetComponentsInChildren<Text>();
        Text[] secondText = secondEntry.gameObject.GetComponentsInChildren<Text>();
        string tempUserName;
        int tempPoints;

        tempUserName = firstEntry.username;
        tempPoints = firstEntry.points;

        firstEntry.username = secondEntry.username;
        firstEntry.points = secondEntry.points;
        secondEntry.username = tempUserName;
        secondEntry.points = tempPoints;

        firstText[0].text = " name: " + firstEntry.username;
        firstText[1].text = " points: " + firstEntry.points.ToString();
        secondText[0].text = " name: " + secondEntry.username;
        secondText[1].text = " points: " + secondEntry.points.ToString();
    }

    private void compareEntries(leaderboardEntry firstEntry, leaderboardEntry secondEntry)
    {
        //compares the two entries and swaps if second is bigger than first
        if (firstEntry.points < secondEntry.points)
        {
            swapEntries(firstEntry, secondEntry);
        }
    }

    private bool isSorted()
    {
        for (int i = 0; i < leaderboardEntries.Length-1; i++)
        {
            if (leaderboardEntries[i].points < leaderboardEntries[i + 1].points)
            {
                Debug.Log("not sorted");
                return false;
            }
        }
        Debug.Log("sorted");
        return true;
    }

    private void highlightPlayer()
    {
        foreach (leaderboardEntry entry in leaderboardEntries)
        {
            if (entry.username == playername && entry.points == playerPoints)
            {
                Color colour = new Color(0.3333f, 0.7647f, 0.1921f);
                Text[] entryText = entry.GetComponentsInChildren<Text>();
                entryText[0].color = colour;
                entryText[1].color = colour;
            }
        }
    }
}
