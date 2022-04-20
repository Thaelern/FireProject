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
    public GameObject StartMenu_Canvas;
    public GameObject LevelSelectScene_Canvas;
    public GameObject PauseMenu_Canvas;
    public GameObject Credit_Scene_Canvas;


    public bool isPauseMenuActive;

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

    private void Update()
    {
        if (Input.GetButtonDown("Cancel") && isPauseMenuActive == false )
        {
            Debug.Log("Escape pressed");
            isPauseMenuActive = true;
            // bring up pause menu
            PauseMenu_Canvas.SetActive(true);
        }
        else if(Input.GetButtonDown("Cancel") && isPauseMenuActive == true)
        {
            Debug.Log("clicked escape with bool true");
            PauseMenu_Canvas.SetActive(false);
            isPauseMenuActive = false;

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

        // listens for LevelManagerScript
        LevelManagerScript.OnStartMenu += StartMenu_CanvasOn;
        LevelManagerScript.OnStartMenuLeft += StartMenu_CanvasOff;

        // listens for level select function
        LevelManagerScript.OnLevelSelectScene += LevelMenu_CanvasOn;
        LevelManagerScript.OnLevelSelectSceneLeft += LevelMenu_CanvasOff;

        // listens for Credit_scene_canvas / settings
        LevelManagerScript.OnLeaveSettingsSceneLeft += Credit_Scene_CanvasOff;

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

        // Unsub LevelManagerScript
        LevelManagerScript.OnStartMenu -= StartMenu_CanvasOn;
        LevelManagerScript.OnStartMenuLeft -= StartMenu_CanvasOff;

        // Unsublevel select function
        LevelManagerScript.OnLevelSelectScene -= LevelMenu_CanvasOn;
        LevelManagerScript.OnLevelSelectSceneLeft -= LevelMenu_CanvasOff;
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

    private void StartMenu_CanvasOn()
    {
        StartMenu_Canvas.SetActive(true);
    }

    private void StartMenu_CanvasOff()
    {
        StartMenu_Canvas.SetActive(false);
    }

    private void LevelMenu_CanvasOn()
    {
        LevelSelectScene_Canvas.SetActive(true);
    }

    private void LevelMenu_CanvasOff()
    {
        LevelSelectScene_Canvas.SetActive(false);
    }

    public void PauseMenu_CanvasOn()
    {
        PauseMenu_Canvas.SetActive(true);
    }

    public void PauseMenu_CanvasOff()
    {
        PauseMenu_Canvas.SetActive(false);
        isPauseMenuActive = false;
    }

    public void Credit_Scene_CanvasOff()
    {
        // write to tell canvas to go off here
    }



}
