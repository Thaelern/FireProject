using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OnTriggerEnterCrew : MonoBehaviour
{
    public bool isPlayerTouching;
    public LayerMask playerLayer;



    // public event
    public static event Action CritterKill;
    

    private void Update()
    {

        
        // checks circle around object. If player enters, sets bool true
        isPlayerTouching = Physics2D.OverlapCircle(gameObject.transform.position, 0.3f, playerLayer);
        if(isPlayerTouching == true)
        {
            // broadcasts that first NPC has been found
            Debug.Log("I found it");
            CritterKill.Invoke();
        }
        
    }
}
