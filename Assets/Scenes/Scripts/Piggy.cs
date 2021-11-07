using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Piggy : MonoBehaviour
{
    private float speed = 1;
    void Start()
    {

    }
    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * -speed;
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggerd");
        SceneManager.LoadScene("Endscreen");
    }
}
