using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LargePiggy : MonoBehaviour
{
    private float moveSpeed = 0.3f;
    private float respawnTime = 5f;
    public int health = 2;
    public GameObject enemyPrefab;
    void Start()
    {
        StartCoroutine(cooldownSpawner());
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * -moveSpeed, Space.Self);
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
    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Endscreen");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health--;
            if (health == 0)
            {
                int random = Random.Range(0, 32);
                Destroy(gameObject);
                Ufo.score += 2;
            }
            Destroy(collision.gameObject);
        }          
    }
}
