using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManagerScript : MonoBehaviour
{


    public AudioSource Music_Manager, SFX_Manager;

    public AudioClip[] trackList;

    public bool playerCanChangeSong;


    private void Start()
    {
        PlaySong(3);
    }

    private void Update()
    {
        if(playerCanChangeSong == true)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                PlaySong(0);
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                PlaySong(1);
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                PlaySong(2);
            }
        } 
    }

    private void PlaySong(int songtrack)
    {
        Music_Manager.Stop();
        Music_Manager.clip = trackList[songtrack];
        // loops the song so the player is not without music
        Music_Manager.loop = true;
        Music_Manager.Play();
    }

    

    private void OnEnable()
    {
        JukeBoxScript.OnActivateJukeBoxUI += PlayerCanChooseSongBoolFunc;
        JukeBoxScript.OnDisableJukeBoxUI += PlayerCannotChooseSongBoolFunc;
    }

    private void OnDisable()
    {
        JukeBoxScript.OnActivateJukeBoxUI -= PlayerCanChooseSongBoolFunc;
        JukeBoxScript.OnDisableJukeBoxUI -= PlayerCannotChooseSongBoolFunc;
    }



    private void PlayerCanChooseSongBoolFunc()
    {
        playerCanChangeSong = true;
    }

    private void PlayerCannotChooseSongBoolFunc()
    {
        playerCanChangeSong = false;
    }


}
