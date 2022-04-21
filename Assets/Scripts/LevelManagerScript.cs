using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class LevelManagerScript : MonoBehaviour
{
    // events
    static public event Action OnStartMenu;
    static public event Action OnStartMenuLeft;
    static public event Action OnLevelSelectScene;
    static public event Action OnLevelSelectSceneLeft;
    static public event Action OnLeaveSettingsSceneLeft;


    public void FuncEnterLevel01()
    {
        SceneManager.LoadScene("tt");
    }

    public void FuncInformLeftMenu()
    {
        Debug.Log("Trying to say I left menu");
        OnStartMenuLeft.Invoke();
    }

    public void FuncLoadSettingsLevel()
    {
        SceneManager.LoadScene("Lasse_Settings_Menu");
    }


    public void FuncLoadMainMenuLevel()
    {
        SceneManager.LoadScene("Lasse_MainMenu");
        OnStartMenu.Invoke();
    }

    public void FuncLoadLevelSelectScene()
    {
        SceneManager.LoadScene("Lasse_LevelSelect_Scene");
        OnLevelSelectScene.Invoke();

    }

    public void FuncLeaveLevelSelectScene()
    {
        OnLevelSelectSceneLeft.Invoke();
    }

    public void FuncLeaveSettingsScene()
    {
        OnLeaveSettingsSceneLeft.Invoke();
    }

    public void FuncQuitGame()
    {
        Debug.Log("Qitting game");
        Application.Quit();
    }

}
