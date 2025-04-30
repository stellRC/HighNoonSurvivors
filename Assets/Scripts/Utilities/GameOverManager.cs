using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private TMP_Text killCountText;

    [SerializeField]
    private TMP_Text timeText;

    [SerializeField]
    private TMP_Text streakText;

    public void OnGameOver()
    {
        killCountText = gameManager.killCount;
    }
}
