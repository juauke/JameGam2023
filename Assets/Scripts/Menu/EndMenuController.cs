using UnityEngine;

public class EndMenuController : MonoBehaviour {
    [SerializeField] private GameObject endMenu;

    public void Start() {
        ShowEndMenu();
    }

    public void QuitToDesktopButton() {
        // Quit Game
        Application.Quit();
    }
    
    public void BackToMainMenuButton() {
        // Load back mainMenu Scene (and set active mainMenu)
        UnityEngine.SceneManagement.SceneManager.LoadScene("Juauke (Menu)");
    }

    private void ShowEndMenu() {
        // Stop Time
        Time.timeScale = 0;
        // Show End Menu
        endMenu.SetActive(true);
    }

    public void PlayAgainButton() {
        // Start Main Scene again
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
}