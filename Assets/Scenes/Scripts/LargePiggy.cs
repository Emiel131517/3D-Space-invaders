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
        SetEnemyHealth(2);
        StartCoroutine(cooldownSpawner());
    }

    void Update()
    {
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ufo"))
        {
            SceneManager.LoadScene("Endscreen");
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Damage(1);
            if (health == 0)
            {
                //32 = 3.125% chance
                int random = Random.Range(0, 1);
                if (random == 0)
                {
                    Instantiate(hamDrop, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                }
                Destroy(gameObject);
                Ufo.score += 2;
            }
            Destroy(collision.gameObject);
        }          
    }
}
