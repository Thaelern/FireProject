using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class LevelManagerScript : MonoBehaviour
{
    static public event Action OnStartMenu;
    static public event Action OnStartMenuLeft;
    static public event Action OnLevelSelectScene;
    static public event Action OnLevelSelectSceneLeft;


    public void FuncEnterLevel01()
    {
        SceneManager.LoadScene("Vetle_Level01");
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



}
