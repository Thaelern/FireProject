using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    private float Health = 0f;
    [SerializeField] private float maxHealth = 100f;


    private void Start()
    {
        Health = maxHealth;
    }

    public void UpdateHealth(float mod)
    {
        Debug.Log("Speaking");
        Health += mod;

        if (Health > maxHealth)
        {
            Health = maxHealth;
        } 
        else if (Health <= 0f)
        {
            Health = 0f;
            Debug.Log("Player Respawn");
     
        }


    }


    private void Update()
    {
      
        if (Health <= 0f)
        {
            Die();
        }


    }

    public void Die()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
