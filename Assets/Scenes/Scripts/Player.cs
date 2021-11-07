using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    public static float score = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    private void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.right * -speed * Time.deltaTime;
        }
    }
    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.up, out hit, 15))
        {
            if (hit.transform.CompareTag("Piggy"))
            {
                Destroy(hit.transform.gameObject);
                score++;
            }
        }
    }
}
