using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathText : MonoBehaviour
{
    private TextMeshProUGUI deathText;
    // Start is called before the first frame update
    void Start()
    {
        deathText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        deathText.text = "You lost! your score was: " + Ufo.score;
    }
}
