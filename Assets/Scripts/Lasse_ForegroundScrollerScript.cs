using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TarodevController;

public class Lasse_ForegroundScrollerScript : MonoBehaviour
{
    public RawImage RawImage;
    public float ScrollSpeedX, ScrollSpeedY;


    public PlayerController player;

    public bool playerIsMoving;

    private void Update()
    {
        MoveForeground();
    }

    private void MoveForeground()
    {
        if (player.Velocity.x > 0)
        {
            RawImage.uvRect = new Rect(RawImage.uvRect.position + new Vector2(ScrollSpeedX, ScrollSpeedY) * Time.deltaTime, RawImage.uvRect.size);
        }
        else if (player.Velocity.x < 0)
        {
            RawImage.uvRect = new Rect(RawImage.uvRect.position + new Vector2(-ScrollSpeedX, ScrollSpeedY) * Time.deltaTime, RawImage.uvRect.size);
        }
    }
}
