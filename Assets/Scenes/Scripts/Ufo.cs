using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    private int booster = 100;
    private GameObject bullet;
    private Timer timer;
    private float shootCooldown = 0.25f;

    public static float score = 0;
    void Start()
    {
        bullet = GameObject.Find("bullet");
        timer = new Timer();
        timer.StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKey(KeyCode.Space))
        {
            if (timer.CurrentTimerTime() >= shootCooldown)
            {
                timer.ResetTimer();
                Shoot();
            }
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
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
    }
    void LateUpdate()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
