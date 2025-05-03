using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.RenderGraphModule;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainNavigation : MonoBehaviour
{
    private FadingCanvas fade;

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

    [SerializeField]
    private GameObject killCount;

    [SerializeField]
    private GameObject settingsButton;

    public static bool isPaused;

    private bool gameScene;

    private bool state;

    void Awake()
    {
        state = false;
        fade = gameObject.GetComponent<FadingCanvas>();
    }

    void Start()
    {
        InitializeObjStates();
    }

    void Update()
    {
        // // // Handle keyboard input
        if (Input.GetKeyDown(KeyCode.Escape) && gameScene && gameOverMenu.activeSelf == false)
        {
            TogglePauseMenu();
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

        gameOverMenu.SetActive(false);

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
        fade.FadeOut();

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
        if (gameScene)
        {
            fade.FadeIn();
            InitializeObjStates();
        }
        else
        {
            fade.FadeIn();
            StartGame();
        }
    }

    // Load game scene, set start menu inactive
    public void StartGame()
    {
        // Show kill count and settings button
        gameUICanvas.SetActive(true);
        settingsButton.SetActive(true);
        killCount.SetActive(true);
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
        // SceneManager.LoadScene("MainMenu");
        StartCoroutine(LoadLevelASync("MainMenu"));
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
        }
    }

    public void ToggleGameOverMenu()
    {
        settingsButton.SetActive(false);
        killCount.SetActive(false);
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

        optionsMenu.SetActive(!state);

        state = !state;
    }

    // Exit application
    public void QuitGame()
    {
        Application.Quit();
    }
}
