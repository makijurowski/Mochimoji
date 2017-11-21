using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerText : MonoBehaviour
{

    public Text timerText;
    public float StartTime;
    //public bool finish = false;

    void Start()
    {
        StartTime = 60.0f;
    }

    // Display countdown timer.
    void Update()
    {
        StartTime -= Time.deltaTime;
        string minutes = ((int)StartTime / 60).ToString();
        string seconds = (StartTime % 60).ToString("f2");
        if (StartTime <= 0.000f)
        {
            seconds = "00";
            timerText.text = "TIMER: " + minutes + ":" + seconds;
            FinishTimer();
            return;
        }
        else
        {
            timerText.text = "TIMER: " + minutes + ":" + seconds;
        }
    }

    // Once timer hits 0:00:00, load Game Over scene.
    public void FinishTimer()
    {
        //finish = true;
        timerText.color = Color.yellow;
        SceneManager.LoadSceneAsync("GameOverScene", LoadSceneMode.Single);
    }
}

