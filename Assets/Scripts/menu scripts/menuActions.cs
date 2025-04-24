using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActions : MonoBehaviour
{
    //functions for the in game menus to use

    //shared functions
    public void QuitGame()
    {
        Application.Quit();
    }


    //settings menu fuctions
    public void SetVolume(float newVolume)
    {
        PlayerPrefs.SetFloat("Volume", newVolume);
        AudioListener.volume = PlayerPrefs.GetFloat("Volume");
        //Debug.Log("volume set");
    }

    //leaderboard functions 
}
