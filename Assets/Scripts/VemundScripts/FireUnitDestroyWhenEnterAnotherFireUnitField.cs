using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireUnitDestroyWhenEnterAnotherFireUnitField : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("FireUnit"))
        {

            Debug.Log("FireUnitLandedOnFireUnitArea - Destroyed as result");
            //Destroy(gameObject);
            Destroy(transform.root.gameObject);

        }
    }
}
