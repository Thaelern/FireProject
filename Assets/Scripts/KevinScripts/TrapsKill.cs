using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapsKill : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == ("Player"))
        {
            Die();
        }



    }

    public void Die()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
