using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private MainNavigation mainNavigation;

    [SerializeField]
    private GameOverManager gameOverManager;

    public float timeCount;
    public int killCount;

    public bool isGameOver;

    private bool gameOverPanel;

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        if (isGameOver && !gameOverPanel)
        {
            gameOverManager.OnGameOver();
            mainNavigation.ToggleGameOverMenu();

            gameOverPanel = true;
        }
    }
}
