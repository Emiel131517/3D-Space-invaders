using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
        Ufo.score = 0;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("StartScreen");
        Ufo.score = 0;
    }
}
