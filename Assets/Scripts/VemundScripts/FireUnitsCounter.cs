using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireUnitsCounter : MonoBehaviour
{
    public GameObject FullFireCount;
   

    public int count = 0;

    //public bool TriggerisEmpty;

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("FireUnit"))
            count++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("FireUnit"))
            count--;
    }

    private void Update()
    {
        if (count >= 1)
        {

            StartCoroutine(SetAfterTime1(0));
            
        }

        if (count > 1)
        {
            count = 1;
        }

        /*
        if (TriggerisEmpty == true)
        {
            count = 0;

            



        } 


        if (TriggerisEmpty == false)
        {
            StartCoroutine(SetAfterTime1(1));
        } */

        if (count == 0)
        {
            FullFireCount.SetActive(false);
        }

    }

    /*
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("FireUnit"))
        {
            TriggerisEmpty = false;
            FullFireCount.SetActive(true);
        }
    }
    */



    IEnumerator SetAfterTime1(float time)
    {
        yield return new WaitForSeconds(0.3f);

        FullFireCount.SetActive(true);

      
    }

}
