using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlatFormManagerScript : MonoBehaviour
{
    public static event Action OnOrderPlatformDrop;



    private void OnEnable()
    {
        PlayerRayCastScript.OnPlayerOnTrapPlatform += FuncOrderDropPlatDrop;
    }

    private void OnDisable()
    {
        PlayerRayCastScript.OnPlayerOnTrapPlatform -= FuncOrderDropPlatDrop;
    }


    private void FuncOrderDropPlatDrop()
    {
        OnOrderPlatformDrop.Invoke();
    }

}
