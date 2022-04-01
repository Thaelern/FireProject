using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingRedHurtBox : MonoBehaviour
{


    private Vector3 normalizeDirection;

    public Transform target;
    public float speed = 1f;

    void Start()
    {
        normalizeDirection = (target.position - transform.position).normalized;
    }

    void Update()
    {
        transform.position += normalizeDirection * speed * Time.deltaTime;
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("A player broke");

            //Destroy(collision.gameObject); //This made the game crash.. 
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 0.0f;
        }

    }*/ //Was used as lava wall.

}
