using UnityEngine;
using UnityEngine.SceneManagement;

public class MainNavigation : MonoBehaviour
{
    [Header("Canvas Groups")]
    [SerializeField]
    private GameObject menuCanvas;

    [SerializeField]
    private GameObject gameUICanvas;

    [Header("Menus")]
    [SerializeField]
    private GameObject StartMenu;

    [SerializeField]
    private GameObject optionsMenu;

    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private GameObject gameOverMenu;

    public static bool isPaused;

    private bool gameScene;

    private bool state;

    void Awake()
    {
        state = false;
    }

    void Start()
    {
        InitializeObjStates();
    }

    void Update()
    {
        // // Handle keyboard input
        if (Input.GetKeyDown(KeyCode.Escape) && gameScene)
        {
            TogglePauseMenu();
            pauseMenu.SetActive(true);
            optionsMenu.SetActive(false);
            // Set Player and Clock active
        }
    }

    private void InitializeObjStates()
    {
        menuCanvas.SetActive(true);
        // hide kill count and settings button
        gameUICanvas.SetActive(false);
        // Set Start Menu active
        StartMenu.SetActive(true);
        // Set Options Menu inactive
        optionsMenu.SetActive(false);
        // Set Pause Menu inactive
        pauseMenu.SetActive(false);
        // Hide Game over stats
        Debug.Log("pre init: " + gameOverMenu.activeSelf);
        gameOverMenu.SetActive(false);
        Debug.Log("post init: " + gameOverMenu.activeSelf);
        // Prevent pause menu from opening while in main menu
        isPaused = true;
        gameScene = false;
        // Start internal game clock (enable fog animations)
        Time.timeScale = 1f;
    }

    // Load game scene, set start menu inactive
    public void StartGame()
    {
        // Set main menu to inactive
        StartMenu.SetActive(false);
        // hide menus
        menuCanvas.SetActive(false);
        // Activate pause menu in preparation for game pause
        pauseMenu.SetActive(true);
        // Show kill count and settings button
        gameUICanvas.SetActive(true);
        // Load new scene
        SceneManager.LoadScene("Level_One");

        // Enable pause menu to be opened
        isPaused = false;
        // Starting game scene
        gameScene = true;
    }

    // Return to main menu from pause screen
    public void ReturnToMainMenu()
    {
        // Hide Game over stats
        // gameOverMenu.SetActive(false);
        // Load new scene
        SceneManager.LoadScene("MainMenu");

        // InitializeObjStates();
    }

    public void TogglePauseMenu()
    {
        if (!isPaused)
        {
            // Stop in-game clock to stop animations and updates
            Time.timeScale = 0f;
            isPaused = true;

            // clock.SetActive(false);
            menuCanvas.SetActive(true);
            pauseMenu.SetActive(true);
            gameUICanvas.SetActive(false);
        }
        else if (isPaused && gameScene)
        {
            // Resume in game clock
            Time.timeScale = 1f;
            isPaused = false;

            // clock.SetActive(true);
            menuCanvas.SetActive(false);
            gameUICanvas.SetActive(true);
        }
    }

    public void ToggleGameOverMenu()
    {
        menuCanvas.SetActive(true);
        pauseMenu.SetActive(false);

        gameUICanvas.SetActive(false);

        gameOverMenu.SetActive(true);
    }

    public void ToggleOptionsMenu()
    {
        if (gameScene)
        {
            pauseMenu.SetActive(state);
        }
        else
        {
            StartMenu.SetActive(state);
        }

        if (optionsMenu.activeSelf == false)
        {
            optionsMenu.SetActive(true);
        }
        else
        {
            optionsMenu.SetActive(false);
        }

        state = !state;
    }

    // Exit application
    public void QuitGame()
    {
        Application.Quit();
    }
}
