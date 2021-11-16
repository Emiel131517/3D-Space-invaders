using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Updater : MonoBehaviour
{
    public Action updateCaller;
    public void AddUpdater(Action updateMethod)
    {
        updateCaller += updateMethod;
    }
    void Update()
    {
        updateCaller();
    }
}
