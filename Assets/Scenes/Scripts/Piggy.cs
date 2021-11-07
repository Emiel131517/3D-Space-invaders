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
        transform.position += transform.forward * -speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Endscreen");
    }
}
