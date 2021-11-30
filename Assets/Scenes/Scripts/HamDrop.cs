using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamDrop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Endline"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Ufo"))
        {
            Destroy(gameObject);
        }
    }
}
