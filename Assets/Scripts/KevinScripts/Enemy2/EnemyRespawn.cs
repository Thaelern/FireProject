using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float respawnTime;

    [SerializeField]
    private Transform respawnPoint;

    public bool isDead;

    private void Start()
    {
        StartCoroutine(spawnEnemy(respawnTime, enemyPrefab));
    }


    private IEnumerator spawnEnemy(float respawntime, GameObject enemy)
    {
        yield return new WaitForSeconds(respawntime);
        GameObject Enemy = Instantiate(enemyPrefab, respawnPoint.position, respawnPoint.rotation); 
        StartCoroutine(spawnEnemy(respawntime, enemy));

    }


}
