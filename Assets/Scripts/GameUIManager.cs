using TMPro;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text KillCountText;

    private GameManager gameManager;

    void Awake()
    {
        gameManager = gameObject.GetComponentInParent<GameManager>();
    }

    private void Update()
    {
        KillCountText.text = gameManager.killCount.ToString();
    }
}
