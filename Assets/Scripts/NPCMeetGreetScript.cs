using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class NPCMeetGreetScript : MonoBehaviour
{
    // public så each NPC dialogue can be changed in insepctor.
    public string dialogueNPCToSay;

    public static event Action OnEnterNPC;
    public static event Action OnLeaveNPC;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.CompareTag("Player");
        // Grabs reference to the UIManager, which stores the UI element to show
        // then specifies from HERE, in inspector, what the text to show should be
        UIManagerScript.Instance.NPCGreet_Text.GetComponent<TextMeshProUGUI>().text = dialogueNPCToSay;
        OnEnterNPC.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.CompareTag("Player");
        OnLeaveNPC.Invoke();
    }
}
