using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class LevelManagerScript : MonoBehaviour
{
    static public event Action OnStartMenu;
    static public event Action OnStartMenuLeft;


    private void Start()
    {
        
    }

    private void Update()
    {
 
    }

    public void FuncEnterLevel01()
    {
        SceneManager.LoadScene("Intro_Level_Lasse");
    }

    public void FuncInformLeftMenu()
    {
        Debug.Log("Trying to say I left menu");
        OnStartMenuLeft.Invoke();
    }

}
