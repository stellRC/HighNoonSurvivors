using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainNavigation : MonoBehaviour
{
    public List<GameObject> canvasPanels;

    public List<GameObject> inactiveObjects;

    private bool state;

    public static bool isPaused;

    private bool gameScene;

    void Start()
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    private void InitializeObjStates()
    {
        // Set Start Menu active
        canvasPanels[0].SetActive(!state);
        // Set Options Menu inactive
        canvasPanels[1].SetActive(state);
        // Set Pause Menu inactive
        canvasPanels[2].SetActive(state);
        // Set Player and Clock active
        inactiveObjects[0].SetActive(!state);
        // Set Player and clock inactive
        inactiveObjects[1].SetActive(!state);
    }

    // Load game scene, set start menu inactive
    public void StartGame()
    {
        // Set main menu to inactive
        canvasPanels[0].SetActive(state);
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
        // Set main menu to inactive
        canvasPanels[0].SetActive(!state);
        // Load new scene
        SceneManager.LoadScene("MainMenu");
        // Enable pause menu to be opened
        isPaused = true;
        // Returning to main menu scene
        gameScene = false;
        Time.timeScale = 1f;
    }

    public void TogglePauseMenu()
    {
        if (!isPaused)
        {
            // Stop in-game clock to stop animations and updates
            Time.timeScale = 0f;
            isPaused = true;
            ToggleMenu(2);
        }
        else if (isPaused && gameScene)
        {
            // Resume in game clock
            Time.timeScale = 1f;
            isPaused = false;
            ToggleMenu(2);
        }
    }

    // Exit application
    public void QuitGame()
    {
        Application.Quit();
    }

    // MenuID 0 = Start
    // menuID 1 = Options
    // menuID 2 = Pause
    // Open and close options menu
    public void ToggleMenu(int menuID)
    {
        TogglePanelState(canvasPanels, menuID);
        ToggleObjectState(inactiveObjects);
    }

    // Set objects visible / hidden
    private void ToggleObjectState(List<GameObject> list)
    {
        foreach (var obj in list)
        {
            if (obj != null)
            {
                if (obj.activeSelf)
                {
                    obj.SetActive(!state);
                }
                else
                {
                    obj.SetActive(state);
                }
            }
        }
    }

    private void TogglePanelState(List<GameObject> list, int menuID)
    {
        // Set all panels to inactive
        foreach (var obj in list)
        {
            if (obj.activeSelf)
            {
                obj.SetActive(state);
            }
        }

        // Set specific panel to active
        list[menuID].SetActive(!state);
    }
}
