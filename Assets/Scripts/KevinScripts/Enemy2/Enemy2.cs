using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float walkSpeed;
    public float distance;

    public bool mustPatrol;
    public bool mustTurn;

    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;

    private void Start()
    {
        mustPatrol = true;
    }

    private void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        if (mustPatrol == true)
        {
            mustTurn =!Physics2D.Raycast(groundCheckPos.position, Vector2.down, distance, groundLayer);
        }
    }

    public void Patrol()
    {
        rb.velocity = new Vector2(walkSpeed * Time.deltaTime, rb.velocity.y);
        if(mustTurn || bodyCollider.IsTouchingLayers (groundLayer) == true)
        {
            Flip();
        }
       
    }

    void Flip() 
    {

        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
    }



}