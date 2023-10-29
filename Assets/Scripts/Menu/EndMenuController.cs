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
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    private void ShowEndMenu() {
        // Show End Menu
        endMenu.SetActive(true);
    }

    public void PlayAgainButton() {
        // Start Main Scene again
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}