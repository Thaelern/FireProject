using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject bullet;
    public float bulletDespawnTimer;


    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // shooting pew
            GameObject bulletdespawn =  Instantiate(bullet, gameObject.transform.position, bullet.transform.rotation);
            Destroy(bulletdespawn, bulletDespawnTimer);
        }
    }
}
