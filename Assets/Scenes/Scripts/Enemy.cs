﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected int health;
    protected int score;
    //set the health of the enemy
    public void SetEnemyHealth(int health)
    {
        this.health = health;
    }
    public void SetScoreWorth(int scoreWorth)
    {
        score = scoreWorth;
    }
    //damage the player
    public void Damage(int damage)
    {
        health -= damage;
    }
    //move enemy up
    public void MoveUp(float speed)
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed, Space.Self);
    }
    //move enemy down
    public void MoveDown(float speed)
    {
        transform.Translate(Vector3.up * Time.deltaTime * -speed, Space.Self);
    }
    //move enemy right
    public void MoveRight(float speed)
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed, Space.Self);
    }
    //move enemy left
    public void MoveLeft(float speed)
    {
        transform.Translate(Vector3.right * Time.deltaTime * -speed, Space.Self);
    }
/*    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Damage(1);
            if (health <= 0)
            {
                Destroy(gameObject);
                Ufo.score += score;
            }
        }
    }*/
}
