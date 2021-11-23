using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamDrop : MonoBehaviour
{
    private float moveSpeed = 0.5f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * -moveSpeed, Space.Self);
    }
}
