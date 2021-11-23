using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float respawnTime = 7.5f;
    public GameObject smallPiggy;
    public GameObject largePiggy;
    void Start()
    {
        StartCoroutine(cooldownSpawner());
    }
    void Update()
    {
        
    }

    public void spawnEnemy()
    {
        int random = Random.Range(0, 6);
        if (random >= 1)
        {
            Instantiate(smallPiggy, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
        if (random <= 0)
        {
            Instantiate(largePiggy, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
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
