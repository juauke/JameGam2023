using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsMenu;
    public GameObject PauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
    }

    private void Update() {
        if (Input.GetKeyDown("Pause")) {
            PauseMenu();
        }
    }

    public void PlayNowButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }

    public void CreditsButton()
    {
        // Show Credits Menu
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void MainMenuButton()
    {
        // Show Main Menu
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }

    public void BackToMainMenuButton() {
        // Load back MainMenu Scene and set active MainMenu
        UnityEngine.SceneManagement.SceneManager.LoadScene("Juauke (Menu)");
        MainMenuButton();
    }
    
    public void ResumeButton() {
        // Resume current game
        // Debug.Log("Player clicked on Resume Button");
        
    }

    public void RetryButton() 
    {
        // Start Main Scene again
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
}