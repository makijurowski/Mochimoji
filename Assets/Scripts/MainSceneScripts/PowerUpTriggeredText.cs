using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PowerUpTriggeredText : MonoBehaviour
{
    public static bool powerUp;
    public float powerUpStartTime;
    public Text powerUpTriggeredText;
    public GameObject powerUpBackgroundPanel;
    public GameObject powerUpImage;

    public void Start()
    {
        powerUp = TriggerPowerUpScript.powerUp;
        powerUpImage.gameObject.SetActive(true);
        powerUpBackgroundPanel.gameObject.SetActive(true);
        powerUpTriggeredText.gameObject.SetActive(true);
        powerUpStartTime = 6.0f;
    }

    public void New()
    {
        powerUp = TriggerPowerUpScript.powerUp;
        powerUpImage.gameObject.SetActive(true);
        powerUpBackgroundPanel.gameObject.SetActive(true);
        powerUpTriggeredText.gameObject.SetActive(true);
        powerUpStartTime = 6.0f;
    }

    // Display countdown timer.
    void Update()
    {
        powerUpStartTime -= Time.deltaTime;
        string pu_minutes = ((int) powerUpStartTime / 60).ToString();
        string pu_seconds = (powerUpStartTime % 60).ToString("f2");
        if (powerUpStartTime <= 0.000f)
        {
            pu_seconds = "00";
            powerUpTriggeredText.text = "Power Up Time Left: " + pu_minutes + ":" + pu_seconds;
            FinishTimer();
            return;
        }
        else
        {
            powerUpTriggeredText.text = "Power Up Time Left: " + pu_minutes + ":" + pu_seconds;
        }
    }

    // Once timer hits 0:00:00, deactivate powerUp.
    public void FinishTimer()
    {
        TriggerPowerUpScript.powerUp = false;
        powerUpImage.gameObject.SetActive(false);
        powerUpBackgroundPanel.gameObject.SetActive(false);
        powerUpTriggeredText.gameObject.SetActive(false);
        Debug.Log("PowerUp deactivated");
    }
}