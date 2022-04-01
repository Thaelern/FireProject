using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireUnitDestroyWhenCollisionOnFireUnit : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("FireUnit"))
        {

            Debug.Log("FireUnitLandedOnFireUnit - Destroyed as result");
            //Destroy(gameObject);
            Destroy(transform.root.gameObject);

        }
    }
}
