using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AboutManager : MonoBehaviour
{
    [SerializeField]
    private Button gitBtn;

    void Awake()
    {
        gitBtn.onClick.AddListener(OpenLink);
    }

    public void OpenLink()
    {
        Application.OpenURL("https://github.com/stellRC/HighNoonSurvivors");
    }
}
