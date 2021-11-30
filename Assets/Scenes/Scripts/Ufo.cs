using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo : MonoBehaviour
{
    //shoot
    public GameObject forkBullet;
    public GameObject knifeBullet;
    private Timer shootTimer;
    private float shootCooldown = 0.35f;
    //movement
    private float rotationSpeed = 0.5f;
    private float moveSpeed = 5;
    //booster
    private BoosterBar boosterBar;
    public float booster = 100;
    private float boosterLoss = 50;
    private float boosterGain = 30;
    //score
    public static float score = 0;

    void Start()
    {
        GameObject newUpdater = new GameObject("Updater");
        newUpdater.AddComponent<Updater>();

        boosterBar = GameObject.Find("BoosterBar").GetComponent<BoosterBar>();
        boosterBar.SetMaxBooster(booster);

        shootTimer = new Timer();
        shootTimer.StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(shootCooldown);
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
        boosterBar.SetBooster(booster);
        transform.Rotate(0, rotationSpeed, 0);
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * -moveSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.LeftShift) && booster > 0)
        {
            moveSpeed = 10;
            booster -= boosterLoss * Time.deltaTime;
            rotationSpeed = 1;
        }
        else
        {
            moveSpeed = 5;
            if (booster <= 100)
            {
                booster += boosterGain * Time.deltaTime;
            }   
            rotationSpeed = 0.5f;
        }
    }
    private void Shoot()
    {
        int random = Random.Range(0, 2);
        if (random <= 0)
        {
            Instantiate(forkBullet, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
        }
        if (random >= 1)
        {
            Instantiate(knifeBullet, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
        }
    }
    void LateUpdate()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HamDrop"))
        {
            shootCooldown -= 0.01f;
            score += 2;
        }
    }
}
