using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIendScreen : MonoBehaviour
{
    private Player player;
    private Text score;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "You lost. This is your score:" + player.score;
    }
}
