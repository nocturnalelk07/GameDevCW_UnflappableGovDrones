using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    //functions for the in game menus to use

    public void QuitGame()
    {
        Application.Quit();
    }


    public void SetVolume(float newVolume)
    {
        PlayerPrefs.SetFloat("Volume", newVolume);
        AudioListener.volume = PlayerPrefs.GetFloat("Volume");
        //Debug.Log("volume set");
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //leaderboard functions 
}
