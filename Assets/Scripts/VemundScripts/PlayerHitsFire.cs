using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitsFire : MonoBehaviour
{
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("A player broke");

            //Destroy(collision.gameObject); //This made the game crash.. 
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 0.0f;
        }

        if (collision.transform.CompareTag("WindCoatedField"))
        {

            Debug.Log("FireUnitBlewOut");
            //Destroy(gameObject);
            Destroy(transform.root.gameObject);

        }

        if (collision.transform.CompareTag("Water"))
        {

            Debug.Log("FireUnitDestroyedInWater");
            //Destroy(gameObject);
            Destroy(transform.root.gameObject);

        }

    }

}
