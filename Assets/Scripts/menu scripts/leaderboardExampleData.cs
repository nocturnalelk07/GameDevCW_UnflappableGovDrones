using UnityEngine;
using UnityEngine.UI;

//example data class to represent another player for the leaderboard
public static class leaderboardExampleData
{
    public static string getExampleName()
    {
        return ("name " + ((int)(Random.value*100)).ToString());
    }

    public static int getExampleScore()
    {
        return (int)(Random.value*10);
    }
}
