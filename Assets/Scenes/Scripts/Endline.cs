using UnityEngine;
using UnityEngine.SceneManagement;

public class Endline : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("Endscreen");
        }
    }
}
