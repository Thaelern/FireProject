using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioManagerScript : MonoBehaviour
{


    public AudioSource Music_Manager, SFX_Manager;

    public AudioClip[] trackList;

    public bool playerCanChangeSong;

    private void Awake()
    {

        /*if (SceneManager.GetActiveScene().name == "tt")
        {
            Debug.Log("tt loaded");
            PlaySong(1);
        }

        if (SceneManager.GetActiveScene().name == "Lasse_MainMenu")
        {
            Debug.Log("main menu");
            PlaySong(0);
        }
        */


        PlaySong(1);

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
