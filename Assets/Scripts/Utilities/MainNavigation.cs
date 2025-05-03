using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainNavigation : MonoBehaviour
{
    [Header("Canvas Groups")]
    [SerializeField]
    private GameObject menuCanvas;

    [SerializeField]
    private GameObject gameUICanvas;

    [SerializeField]
    private GameObject loadingCanvas;

    [Header("UI Elements")]
    [SerializeField]
    private GameObject StartMenu;

    [SerializeField]
    private GameObject optionsMenu;

    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private GameObject gameOverMenu;

    [SerializeField]
    private Slider loadingSlider;

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
            // pauseMenu.SetActive(true);
            // optionsMenu.SetActive(false);
            // Set Player and Clock active
        }
    }

    private void InitializeObjStates()
    {
        menuCanvas.SetActive(true);
        // hide kill count and settings button
        loadingCanvas.SetActive(false);
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

    public void LoadGame()
    {
        // Set main menu to inactive
        StartMenu.SetActive(false);
        // hide menus
        menuCanvas.SetActive(false);
        loadingCanvas.SetActive(true);

        // Run Async
        StartCoroutine(LoadLevelASync("Level_One"));
    }

    IEnumerator LoadLevelASync(string levelToLoad)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);

        // While not finished loading
        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            loadingSlider.value = progressValue;
            yield return null;
        }
        StartGame();
    }

    // Load game scene, set start menu inactive
    public void StartGame()
    {
        // Show kill count and settings button
        gameUICanvas.SetActive(true);
        // Load new scene
        // SceneManager.LoadScene("Level_One");
        loadingCanvas.SetActive(false);

        // Enable pause menu to be opened
        isPaused = false;
        // Starting game scene
        gameScene = true;
    }

    // Return to main menu from pause screen
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");

        InitializeObjStates();
    }

    public void TogglePauseMenu()
    {
        if (!gameScene)
            return;

        if (!isPaused)
        {
            // Stop in-game clock to stop animations and updates
            Time.timeScale = 0f;
            isPaused = true;

            // clock.SetActive(false);
            menuCanvas.SetActive(true);
            pauseMenu.SetActive(true);
            gameUICanvas.SetActive(false);
            optionsMenu.SetActive(false);
        }
        else if (isPaused)
        {
            // Resume in game clock
            Time.timeScale = 1f;
            isPaused = false;

            // clock.SetActive(true);
            menuCanvas.SetActive(false);
            gameUICanvas.SetActive(true);
            optionsMenu.SetActive(false);
        }
    }

    public void ToggleGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    public void ToggleOptionsMenu()
    {
        if (gameScene)
        {
            pauseMenu.SetActive(false);
        }
        else
        {
            StartMenu.SetActive(false);
        }

        if (optionsMenu.activeSelf)
        {
            optionsMenu.SetActive(false);
        }
        else
        {
            optionsMenu.SetActive(true);
        }

        // state = !state;
    }

    // Exit application
    public void QuitGame()
    {
        Application.Quit();
    }
}
