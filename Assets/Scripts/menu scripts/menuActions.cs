using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuActions : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    //functions for the in game menus to use
    private void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("Volume", 0.5f);
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.5f);
        Debug.Log(PlayerPrefs.GetFloat("Volume", 0.5f));
    }
    public void QuitGame()
    {
        Application.Quit();
    }


    public void SetVolume(float newVolume)
    {
        PlayerPrefs.SetFloat("Volume", newVolume);
        AudioListener.volume = PlayerPrefs.GetFloat("Volume");
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
