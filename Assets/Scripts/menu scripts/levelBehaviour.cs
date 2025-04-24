using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelBehaviour : MonoBehaviour
{
    [SerializeField] private int levelNumber;
    [SerializeField] private Text levelText;
    [SerializeField] private GameObject padlock;
    [SerializeField] private Button button;

    private void Awake()
    {
        levelText.text = "level " + levelNumber;
    }
    public void unlockThis(int levelCompleted)
    {
        //a level is available if it has been completed already or is the next level

        if (levelNumber <= levelCompleted + 1)
        {
            //do everything required to unlock a level
            padlock.SetActive(false);
            button.interactable = true;
        } else
        {
            button.interactable = false;
            padlock.SetActive(true);
        }
    }

    public void playLevel()
    {
        SceneManager.LoadScene("level " + levelNumber);
    }
}
