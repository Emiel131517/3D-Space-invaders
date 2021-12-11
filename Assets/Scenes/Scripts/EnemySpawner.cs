using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float respawnTime = 7.5f;
    private int largePiggySpawnChance = 15;
    private int oldScoreCheckTarget = 0;
    private int newScoreCheckTarget = 50;
    public GameObject smallPiggy;
    public GameObject largePiggy;
    void Start()
    {
        StartCoroutine(cooldownSpawner());
    }
    void Update()
    {
        if (Ufo.score > oldScoreCheckTarget && Ufo.score < newScoreCheckTarget)
        {
            respawnTime -= 0.125f;
            oldScoreCheckTarget += 50;
            newScoreCheckTarget += 50;
        }
    }

    public void spawnEnemy()
    {
        int random = Random.Range(0, largePiggySpawnChance);
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
