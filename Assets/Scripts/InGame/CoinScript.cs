using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour {
    private int coinCount = 0;
    private string[] Lines;

    public Text scoreText;

    // Audio triggers.
    public AudioClip coinSound;
    private AudioSource source;


    private void Awake()
    {
        // Get audio clip.
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        if((scoreText.text).Length == 0)
        {
            scoreText.text = "SCORE: " + coinCount.ToString();
            PlayerPrefs.SetInt("Player Score", 0);
        }
        // if (PlayerPrefs.HasKey("Player Score") && PlayerPrefs.GetInt("Player Score") > 0)
        // {
        //     coinCount = PlayerPrefs.GetInt("Player Score");
        // }
        // else
        // {
        //     coinCount = 0;
        // }
        // SetScoreText();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            collision.gameObject.SetActive(false);
            coinCount += 5;
            Debug.Log("Add 5 coins");
            SetScoreText();

            // Add audio when player collects coin.
            source.PlayOneShot(coinSound);
        }
    }

    void SetScoreText()
    {
        // Check if there's already a current score existing (this will help with the power-up score).
        if (PlayerPrefs.HasKey("Player Score"))
        {
            int currentCount = PlayerPrefs.GetInt("Player Score");
            Debug.Log("coinCount " + coinCount);
            Debug.Log("currentCount " + currentCount);
            coinCount += currentCount;
        }
        scoreText.text = "SCORE: " + coinCount.ToString();
        // Save score to player preferences.
        PlayerPrefs.SetInt("Player Score", coinCount);
        // Get logged user to use for highest score.
        string loggedUser = PlayerPrefs.GetString("LoggedUser");
        // Save highest score to player preferences.
        if (PlayerPrefs.HasKey("Highest Score"))
        {
            int highestScore = PlayerPrefs.GetInt("Highest Score");
            if (highestScore < coinCount)
            {
                PlayerPrefs.SetInt("Highest Score", coinCount);
                PlayerPrefs.SetString("Highest Scored Player", loggedUser);
            }
        }
        else
        {
            PlayerPrefs.SetInt("Highest Score", coinCount);
            PlayerPrefs.SetString("Highest Scored Player", loggedUser);
        }
        coinCount = 0;
    }
}
