using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float moveSpeed;


    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * moveSpeed);
    }

}
