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
        // Set Player and Clock active
        inactiveObjects[0].SetActive(!state);
        // Set Player and clock inactive
        inactiveObjects[1].SetActive(!state);
    }

    // Load game scene
    public void StartGame()
    {
        canvasPanels[0].SetActive(state);
        SceneManager.LoadScene("Level_One");
    }

    // Open and close options menu
    public void ToggleOptionsMenu()
    {
        ToggleState(canvasPanels);
        ToggleState(inactiveObjects);
    }

    // Exit application
    public void QuitGame()
    {
        Application.Quit();
    }

    // Set objects visible / hidden
    private void ToggleState(List<GameObject> list)
    {
        foreach (var obj in list)
        {
            switch (obj.activeSelf)
            {
                case false:
                    obj.SetActive(!state);
                    break;
                default:
                    obj.SetActive(state);
                    break;
            }
        }
    }
}
