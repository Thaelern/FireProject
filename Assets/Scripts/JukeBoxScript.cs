using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JukeBoxScript : MonoBehaviour
{
    public static event Action OnActivateJukeBoxUI;
    public static event Action OnDisableJukeBoxUI;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnActivateJukeBoxUI.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnDisableJukeBoxUI.Invoke();
        }
    }
}
