using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float respawnTime = 4;
    public GameObject enemyPrefab;
    void Start()
    {
        StartCoroutine(cooldownSpawner());
    }
    void Update()
    {
        
    }

    public void spawnEnemy()
    {
        Instantiate(enemyPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }
    IEnumerator cooldownSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }

    }

}
