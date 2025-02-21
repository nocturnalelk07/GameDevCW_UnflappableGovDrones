using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActions : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;
    //this can be null in the main menu scene
    [SerializeField] GameObject pauseMenu = null;
    [SerializeField] GameObject mainMenu;

    //functions for the in game menus to use

    //shared functions (pause menu)
    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {
        
    }

    //main menu functions
    public void SelectLevel()
    {

    }

    //settings menu fuctions

    public void CloseSettings() 
    {
        
    }

    public void ChangeVolume()
    {

    }
}
