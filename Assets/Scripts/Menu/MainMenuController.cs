using UnityEngine;

public class MainMenuController : MonoBehaviour {
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject creditsMenu;

    // Start is called before the first frame update
    void Start() { MainMenuButton(); }

    public void PlayNowButton() {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }

    public void CreditsButton() {
        // Show Credits Menu
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void MainMenuButton() {
        // Show Main Menu
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    public void QuitButton() {
        // Quit Game
        Application.Quit();
    }
}