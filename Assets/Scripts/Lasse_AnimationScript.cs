using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TarodevController;

public class Lasse_AnimationScript : MonoBehaviour
{
    public Animator player_animator;
    public PlayerController player;

    private void Update()
    {
        if (player.Velocity.x != 0)
        {
            player_animator.SetBool("isRunning", true);
        }
        else
        {
            player_animator.SetBool("isRunning", false);
        }
    }
}
