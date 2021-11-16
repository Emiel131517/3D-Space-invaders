using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 7;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.CompareTag("Piggy");
        Destroy(gameObject);
        Destroy(collision.gameObject);
        Ufo.score++;
    }
}
