using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TerrainTools;

public class MainNavigation : MonoBehaviour
{
    [Header("Canvas Groups")]
    [SerializeField]
    private GameObject MenuCanvas;

    [SerializeField]
    private GameObject gameUICanvas;

    [Header("Menus")]
    [SerializeField]
    private GameObject StartMenu;

    [SerializeField]
    private GameObject optionsMenu;

    [SerializeField]
    private GameObject pauseMenu;

    private bool state;

    public static bool isPaused;

    private bool gameScene;

    void Awake()
    {
        // Set initial state value
        state = false;
        // Prevent pause menu from opening while in main menu
        isPaused = true;
        gameScene = false;
        InitializeObjStates();
    }

    void Update()
    {
        // Handle keyboard input
        if (Input.GetKeyDown(KeyCode.Escape) && gameScene)
        {
            TogglePauseMenu();
            pauseMenu.SetActive(true);
            // Set Player and Clock active
        }
    }

    private void InitializeObjStates()
    {
        MenuCanvas.SetActive(true);
        // hide kill count and settings button
        gameUICanvas.SetActive(false);
        // Set Start Menu active
        StartMenu.SetActive(true);
        // Set Options Menu inactive
        optionsMenu.SetActive(false);
        // Set Pause Menu inactive
        pauseMenu.SetActive(false);
        // Set Player and Clock active
    }

    // Load game scene, set start menu inactive
    public void StartGame()
    {
        // Set main menu to inactive
        StartMenu.SetActive(false);
        // hide menus
        MenuCanvas.SetActive(false);
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
        // Load new scene
        SceneManager.LoadScene("MainMenu");
        // Set main menu to inactive
        StartMenu.SetActive(true);
        // Show kill count and settings button
        gameUICanvas.SetActive(false);
        // Enable pause menu to be opened
        isPaused = true;
        // Returning to main menu scene
        gameScene = false;
        // Start internal game clock (enable fog animations)
        Time.timeScale = 1f;
    }

    public void TogglePauseMenu()
    {
        Debug.Log("cat");
        if (!isPaused)
        {
            // Stop in-game clock to stop animations and updates
            Time.timeScale = 0f;
            isPaused = true;

            // clock.SetActive(false);
            MenuCanvas.SetActive(true);
            gameUICanvas.SetActive(false);
        }
        else if (isPaused && gameScene)
        {
            // Resume in game clock
            Time.timeScale = 1f;
            isPaused = false;

            // clock.SetActive(true);
            MenuCanvas.SetActive(false);
            gameUICanvas.SetActive(true);
        }
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

        state = !state;
        optionsMenu.SetActive(state);
    }

    // Exit application
    public void QuitGame()
    {
        Application.Quit();
    }
}
