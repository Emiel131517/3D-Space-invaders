using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LargePiggy : Enemy
{
    private float respawnTime = 5f;
    public GameObject enemyPrefab;
    public GameObject hamDrop;
    void Start()
    {
        health = 2;
        scoreWorth = 2;
        StartCoroutine(cooldownSpawner());
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Ufo.score += scoreWorth;
        }
        MoveDown(0.3f);
    }
    public void spawnEnemy()
    {
        Instantiate(enemyPrefab, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Quaternion.identity);
    }
    IEnumerator cooldownSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }

    }
    private void OnDestroy()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Ufo.score += scoreWorth;
            //32 = 3.125% chance
                                    //6.25%
            int random = Random.Range(0, 16);
            if (random == 0)
            {
                Instantiate(hamDrop, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
        }
    }
}
