using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PowerUpTriggeredText : MonoBehaviour
{
    public static bool powerUp;
    public Text powerUpTriggeredText;
    public float powerUpStartTime;

    public void Start()
    {
        powerUp = TriggerPowerUpScript.powerUp;
        powerUpStartTime = 5.0f;
    }

    public void New()
    {
        powerUp = TriggerPowerUpScript.powerUp;
        powerUpTriggeredText.gameObject.SetActive(true);
        powerUpStartTime = 5.0f;
    }

    // Display countdown timer.
    void Update()
    {
        powerUpStartTime -= Time.deltaTime;
        string pu_minutes = ((int)powerUpStartTime / 60).ToString();
        string pu_seconds = (powerUpStartTime % 60).ToString("f2");
        if (powerUpStartTime <= 0.000f)
        {
            pu_seconds = "00";
            powerUpTriggeredText.text = "POWER-UP TIMER " + pu_minutes + ":" + pu_seconds;
            FinishTimer();
            return;
        }
        else
        {
            powerUpTriggeredText.text = "POWER-UP TIMER " + pu_minutes + ":" + pu_seconds;
        }
    }

    // Once timer hits 0:00:00, deactivate powerUp.
    public void FinishTimer()
    {
        // finish = true;
        TriggerPowerUpScript.powerUp = false;
        powerUpTriggeredText.gameObject.SetActive(false);
        Debug.Log("PowerUp deactivated");
    }
}