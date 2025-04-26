using UnityEngine;

public class GameNavigation : MonoBehaviour
{
    // public List<Button> navButtons;
    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private GameObject optionsPanel;

    public void PauseGame()
    {
        pausePanel.SetActive(false);
    }

    public void OptionsMenu()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
