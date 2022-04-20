using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public float walkSpeed;
    public float distance;

    public bool mustTurn;

    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;

   

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);
        {

            if (mustTurn == true)
                if (mustTurn == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    mustTurn = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);

                    mustTurn = true;

                }
        }

    }


}