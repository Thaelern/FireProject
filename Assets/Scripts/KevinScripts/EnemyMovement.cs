using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed;
    public float distance;
 

    private bool MovingRight = true;

    public Transform groundCheck;

    private void Update()
    {
        int layer_mask = LayerMask.GetMask("Ground");
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        
        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, distance, layer_mask);
        if (groundInfo.collider == false)
            if(MovingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                MovingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                {
                    MovingRight = true;
                }
            }
           










    }




















}
