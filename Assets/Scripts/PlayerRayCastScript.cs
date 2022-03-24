using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerRayCastScript : MonoBehaviour
{
    public static event Action OnPlayerOnTrapPlatform;


    private void Update()
    {
        
        RaycastHit2D downHit = Physics2D.Raycast(transform.position, -Vector2.up);

        if(downHit.collider.gameObject.layer == 8)
        {
            OnPlayerOnTrapPlatform.Invoke();
        }
    }
}
