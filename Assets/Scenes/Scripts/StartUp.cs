using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject newUpdater = new GameObject("Updater");
        newUpdater.AddComponent<Updater>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
