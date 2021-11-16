using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private float time;
    public bool timerIsActive = false;
    //getting the updater to use the update function
    private Updater updater = GameObject.Find("Updater").GetComponent<Updater>();

    //getting the update function
    public Timer()
    {
        updater.updateCaller += Update;
    }
    //if the timer is active add the time to the time variable
    private void Update()
    {
       if (timerIsActive)
        {
            time += 1 * Time.deltaTime;
        }
    }
    //start the timer
    public void StartTimer()
    {
        if (timerIsActive == false)
        {
            timerIsActive = true;
        }
    }
    //stop the timer
    public void StopTimer()
    {
        if (timerIsActive == true)
        {
            timerIsActive = false;
        }
    }
    //reset the value stored in the timer variable
    public void ResetTimer()
    {
        time = 0f;
    }
    //get if the timer is active or not
    public bool GetTimerActive()
    {
        return timerIsActive;
    }
    //get the time that is stored in the time variable
    public float CurrentTimerTime()
    {
        return time;
    }
}
