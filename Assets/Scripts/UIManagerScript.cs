using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class UIManagerScript : MonoBehaviour
{
    // sets static instance, this tells Unity that
    // there is only ONE instance of this script
    public static UIManagerScript Instance;

    bool _showDialogueBox;
    public GameObject dialogueBox;
    public GameObject jukeBoxUI;
    public GameObject JukeBox_UI_SongSelection;

    // canvas UI element
    public GameObject NPCGreet_Text;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

    }

    private void OnEnable()
    {
        // Listens for the script telling if to show dialoguebox
        // place this on any object that should bring up dialogue box
        OnTriggerEnterShowDialogueScript.PlayerIsInRange += DialogueBoxActivate;
        OnTriggerEnterShowDialogueScript.PlayerLeftRange += DialogueBoxDeactivate;

        //listens for jukebox
        JukeBoxScript.OnActivateJukeBoxUI += JukeBoxActivate;
        JukeBoxScript.OnDisableJukeBoxUI += JukeBoxDeactivate;

        // listens for NPC
        NPCMeetGreetScript.OnEnterNPC += NPCDialogue_TextOn;
        NPCMeetGreetScript.OnLeaveNPC += NPCDialogue_TextOff;

    }

    private void OnDisable()
    {
        OnTriggerEnterShowDialogueScript.PlayerIsInRange -= DialogueBoxActivate;
        OnTriggerEnterShowDialogueScript.PlayerLeftRange -= DialogueBoxDeactivate;

        // unsubscribes from jukebox
        JukeBoxScript.OnActivateJukeBoxUI -= JukeBoxActivate;
        JukeBoxScript.OnDisableJukeBoxUI -= JukeBoxDeactivate;

        // Unsub NPC
        NPCMeetGreetScript.OnEnterNPC -= NPCDialogue_TextOn;
        NPCMeetGreetScript.OnLeaveNPC -= NPCDialogue_TextOff;
    }


    private void JukeBoxActivate()
    {
        jukeBoxUI.SetActive(true);
        JukeBox_UI_SongSelection.SetActive(true);
    }

    private void JukeBoxDeactivate()
    {
        jukeBoxUI.SetActive(false);
        JukeBox_UI_SongSelection.SetActive(false);
    }


    private void DialogueBoxActivate()
    {
        dialogueBox.SetActive(true);
    }

    private void DialogueBoxDeactivate()
    {
        dialogueBox.SetActive(false);
    }

    private void NPCDialogue_TextOn()
    {
        NPCGreet_Text.SetActive(true);
    }

    private void NPCDialogue_TextOff()
    {
        NPCGreet_Text.SetActive(false);
    }


}
