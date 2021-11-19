using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoosterBar : MonoBehaviour
{
    private Slider boosterSlider;

    void Start()
    {
        boosterSlider = GetComponent<Slider>();
    }
    public void SetMaxBooster(float booster)
    {
        boosterSlider.maxValue = booster;
        boosterSlider.value = booster;
    }
    public void SetBooster(float booster)
    {
        boosterSlider.value = booster;
    }
}
