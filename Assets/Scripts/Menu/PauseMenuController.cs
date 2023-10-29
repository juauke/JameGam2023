using UnityEngine;

public class PauseMenuController : MonoBehaviour {
    public GameObject pauseMenu;

    private void Update() {
        if (Input.GetKeyDown("escape")) {
            PauseMenuButton();
        }
    }

    private void PauseMenuButton() {
        // Pause Time
        PauseGame();
        // Disable any UI present on player screen
        //??
        // Enable Pause Menu
        pauseMenu.SetActive(true);
    }

    static void PauseGame() { Time.timeScale = 0; }
    static void ResumeGame() { Time.timeScale = 1; }

    public void QuitToDesktopButton() {
        // Quit Game
        Application.Quit();
    }

    public void BackToMainMenuButton() {
        // Load back mainMenu Scene (and set active mainMenu)
        UnityEngine.SceneManagement.SceneManager.LoadScene("Juauke (Menu)");
    }

    public void ResumeButton() {
        // Resume current game
        pauseMenu.SetActive(false);
        // Debug.Log("Player clicked on Resume Button");
        ResumeGame();
    }

    public void RetryButton() {
        // Start Main Scene again
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
}