using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class NPCMeetGreetScript : MonoBehaviour
{
    public TMP_Text GreetText;
    public string dialogueNPCToSay;

    public static event Action OnEnterNPC;
    public static event Action OnLeaveNPC;



    private void Update()
    {
        GreetText.text = dialogueNPCToSay;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.CompareTag("Player");
        OnEnterNPC.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.CompareTag("Player");
        OnLeaveNPC.Invoke();
    }
}
