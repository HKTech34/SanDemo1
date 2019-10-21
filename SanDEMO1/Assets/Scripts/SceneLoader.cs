using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //This script is for button control

    public void LoadMMenu() // Load Main menu
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadCarSelectScene() // Load car selection scene
    {
        SceneManager.LoadScene("CarSelectionScene");
    }
    public void LoadInfoMenu() // Load how to play
    {
        SceneManager.LoadScene("InfoMenu");
    }
    public void QuitGame() // Load quit the game 
    {
        Application.Quit();
    }
    public void PlayWheelLoader() // Load Wheelloader level
    {
        SceneManager.LoadScene("Level1WL");
    }
    public void PlayTelehandler() // Load telehandler level
    {
        SceneManager.LoadScene("Level1TH");
    }
    public void PlayMultiplayer() // Load multiplayer level
    {
        SceneManager.LoadScene("SplitLevel");
    }

}
