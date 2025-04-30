using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private MainNavigation mainNavigation;

    [SerializeField]
    private GameOverManager gameOverManager;

    public float timeCount;
    public int killCount;

    public bool isGameOver;

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
        isGameOver = playerController.IsDead;

        if (isGameOver)
        {
            gameOverManager.OnGameOver();
        }
    }
}
