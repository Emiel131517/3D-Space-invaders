using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piggy : Enemy
{
    private void Start()
    {
        health = 1;
        scoreWorth = 1;
    }
    private void Update()
    {
        MoveDown(0.5f);
        Debug.Log(health);
        if (health <= 0)
        {
            Destroy(gameObject);
            Ufo.score += scoreWorth;
        }
    }
}
