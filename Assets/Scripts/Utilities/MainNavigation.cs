using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainNavigation : MonoBehaviour
{
    public List<GameObject> canvasPanels;

    public List<GameObject> inactiveObjects;

    private bool state;

    void Start()
    {
        // Set initial state value
        state = false;

        InitializeObjStates();
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
        canvasPanels[0].SetActive(state);
        SceneManager.LoadScene("Level_One");
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

    // Exit application
    public void QuitGame()
    {
        Application.Quit();
    }

    // Set objects visible / hidden
    private void ToggleObjectState(List<GameObject> list)
    {
        foreach (var obj in list)
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
        list[menuID].SetActive(state);
    }
}
