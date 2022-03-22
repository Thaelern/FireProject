using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class CrewStatusScript : MonoBehaviour
{
    // which crew members have been rescued
    public bool crew01; // checks if crew member has been found





    private void OnEnable()
    {
        // subscribes to OnTriggerEnterCrewScripts
        OnTriggerEnterCrew.CritterKill += CrewStatus;
    }


    private void OnDisable()
    {
        OnTriggerEnterCrew.CritterKill -= CrewStatus;
    }

    private void CrewStatus()
    {
        Debug.Log("Triggering");
        crew01 = true;
    }

}
