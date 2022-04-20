using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : MonoBehaviour
{

    public float walkSpeed;
    public float distance;

    public bool mustTurn;

    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;


    public void Update()
    {
        
        if ((bodyCollider.IsTouchingLayers(groundLayer) == true))
        {
            Flip();
        }

        {
            transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);
            if (mustTurn == false)
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
       
    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustTurn = false;
    }















}