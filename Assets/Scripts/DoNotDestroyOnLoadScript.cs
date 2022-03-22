using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyOnLoadScript : MonoBehaviour
{

    public static DoNotDestroyOnLoadScript Instance;



    // checks if the game manager exists in the scene. If it does,
    // then it destroys the object. If it does not, then it lets the
    // object remain in the scene. 
    private void Awake()
    {
        if( Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
}
