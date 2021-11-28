using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown : MonoBehaviour
{
    private float cooldownTime;
    public float time { get { return cooldownTime; } }
    public bool cooldownCompelted = false;
    public bool cooldownIsActive = false;
    private Updater updater;
    public Cooldown()
    {

        updater = null;
        if (updater == null)
        {
            Debug.LogError("No updater found!");
        }
        if (updater != null)
        {
            updater.updateCaller += Update;
        }
    }
    private void Update()
    {
        cooldownTime -= 1 * Time.deltaTime;
        if (cooldownTime <= 0)
        {
            cooldownCompelted = true;
        }
    }
    public void StartCooldown(float cooldownStart)
    {
        if (cooldownIsActive == false)
        {
            cooldownIsActive = true;
            cooldownTime = cooldownStart;
            updater = GameObject.Find("Updater").GetComponent<Updater>();
        }
    }
    public void PauseCooldown()
    {
        if (cooldownIsActive == true)
        {
            cooldownIsActive = false;
            updater = null;
        }
    }
}
