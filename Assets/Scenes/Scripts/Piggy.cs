using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Piggy : Enemy
{
    private void Start()
    {
        SetEnemyHealth(1);
        SetScoreWorth(1);
    }
    private void Update()
    {
        MoveDown(0.5f);
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
            Ufo.score += score;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }
    }
}
