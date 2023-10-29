using System;
using UnityEngine;

public class PauseMenuController : MonoBehaviour {
    public GameObject pauseMenu;

    private void OnEnable()
    {
        PauseGame();
    }

    static void PauseGame() { Time.timeScale = 0; }
    static void ResumeGame() { Time.timeScale = 1; }

    public void QuitToDesktopButton() {
        // Quit Game
        Application.Quit();
    }

    public void BackToMainMenuButton() {
        // Load back mainMenu Scene (and set active mainMenu)
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void ResumeButton() {
        // Debug.Log("Player clicked on Resume Button");
        ResumeGame();
        // Resume current game
        pauseMenu.SetActive(false);
    }

    public void RetryButton() {
        // Start Main Scene again
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}