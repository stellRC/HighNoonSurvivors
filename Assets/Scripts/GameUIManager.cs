using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text KillCountText;

    private GameManager gameManager;

    void Awake()
    {
        gameManager = gameObject.GetComponent<GameManager>();
    }

    private void Update()
    {
        KillCountText.text = gameManager.killCount.ToString();
    }
}
