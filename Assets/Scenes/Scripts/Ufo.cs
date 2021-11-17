using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5;
    private int booster = 100;
    public GameObject bullet;
    private Timer shootTimer;
    private Timer boostTimer;
    private float shootCooldown = 0.25f;

    public static float score = 0;
    void Start()
    {
        shootTimer.StartTimer();
        boostTimer.StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKey(KeyCode.Space))
        {
            if (shootTimer.CurrentTimerTime() >= shootCooldown)
            {
                Shoot();
                shootTimer.ResetTimer();
            }
        }
    }
    private void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.right * -moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftShift) && booster > 0)
        {
            moveSpeed = 10;
            booster--;
        }
        else
        {
            moveSpeed = 5;
            booster++;
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
