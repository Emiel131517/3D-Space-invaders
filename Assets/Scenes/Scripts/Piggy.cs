using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Piggy : MonoBehaviour
{
    private float speed = 0.5f;
    public int health = 1;
    void Start()
    {

    }
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * -speed, Space.Self);
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
                Destroy(gameObject);
                Ufo.score++;
            }
            Destroy(collision.gameObject);
        }
    }
}
