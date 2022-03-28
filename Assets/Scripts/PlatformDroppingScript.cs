using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDroppingScript : MonoBehaviour
{

    private Rigidbody2D boxRB;

    private void Start()
    {
        boxRB = GetComponent<Rigidbody2D>();
    }


    private void OnEnable()
    {
        PlatFormManagerScript.OnOrderPlatformDrop += SetBoxRBDynamic;
    }

    private void OnDisable()
    {
        PlatFormManagerScript.OnOrderPlatformDrop -= SetBoxRBDynamic;
    }

    void SetBoxRBDynamic()
    {
        Debug.Log("Platform ordered to drop");
        boxRB.bodyType = RigidbodyType2D.Dynamic;
    }

}
