using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathBox : MonoBehaviour
{

    [SerializeField]
    public bool isDead;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision == true)
       {
            {
                isDead = true;
                Destroy(collision.gameObject);
            }
       }

    }

   
}
