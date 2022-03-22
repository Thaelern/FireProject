using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OnTriggerEnterShowDialogueScript : MonoBehaviour
{

    public static event Action PlayerIsInRange;
    public static event Action PlayerLeftRange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player is inside of me.");
            PlayerIsInRange.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerLeftRange.Invoke();
        }
    }
}
