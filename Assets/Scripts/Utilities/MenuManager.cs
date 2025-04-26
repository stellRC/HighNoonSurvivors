using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Menu
{
    MainMenu,
    Settings,
    PauseMenu,
    WeaponsMenu
}

public static class MenuManager
{
    public static GameObject mainMenu,
        settingsMenu,
        pauseMenu,
        weaponsMenu;

    public static void Init()
    {
        GameObject canvas = GameObject.Find("Canvas");
        mainMenu = canvas.transform.Find("MainMenu").gameObject;
        settingsMenu = canvas.transform.Find("SettingsMenu").gameObject;
        pauseMenu = canvas.transform.Find("PauseMenu").gameObject;
        weaponsMenu = canvas.transform.Find("WeaponsMenu").gameObject;
    }
}
