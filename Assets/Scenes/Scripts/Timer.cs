using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private float timerTime = 0;
    public bool timerIsActive = false;
/*    private List<Timer> timerList;*/
    //getting the updater to use the update function
    private Updater updater;

    //getting the update function
    public Timer()
    {
        //timerList = new List<Timer>();

        updater = GameObject.Find("Updater").GetComponent<Updater>();
        if (updater == null)
        {
            Debug.LogError("No updater found!");
        }
        if (updater != null)
        {
            updater.updateCaller += Update;
        }
    }
    //if the timer is active add the time to the time variable
    private void Update()
    {
        timerTime += 1 * Time.deltaTime;
    }
    //start the timer
    public void StartTimer()
    {
        if (timerIsActive == false)
        {
            timerIsActive = true;
            updater = GameObject.Find("Updater").GetComponent<Updater>();
        }
    }
    //stop the timer
    public void PauseTimer()
    {
        if (timerIsActive == true)
        {
            timerIsActive = false;
            updater = null;
        }
    }
    //reset the value stored in the timer variable
    public void ResetTimer()
    {
        timerTime = 0f;
    }
    //get if the timer is active or not
    public bool GetTimerActive()
    {
        return timerIsActive;
    }
    //get the time that is stored in the time variable
    public float CurrentTimerTime()
    {
        return timerTime;
    }
    //adds time to the timer
    public float AddTimeToTimer(float timeAmount)
    {
        timerTime += timeAmount;
        return timerTime;
    }
    //remove time from the timer
    public float RemoveTimeFromTimer(float timeAmount)
    {
        timerTime -= timeAmount;
        return timerTime;
    }
/*    public void AddTimerToList(Timer timer)
    {   
        timerList.Add(timer);
    }
    public void RemoveTimerFromList(Timer timer)
    {
        timerList.Remove(timer);
    }
    public List<Timer> GetTimerList()
    {
        return timerList;
    }*/
}
