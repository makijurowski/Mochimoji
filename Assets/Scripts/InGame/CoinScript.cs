using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour {
    private int coinCount = 0;
    private string[] Lines;
    public Text scoreText;
    public AudioClip coinSound;
    private AudioSource source;


    private void Awake()
    {
        // Get audio clip
        source = GetComponent<AudioSource>();
        source.volume = 0.2f;
    }

    void Start()
    {
        if((scoreText.text).Length == 8)
        {
            PlayerPrefs.SetInt("Player Score", 0);
            scoreText.text = "SCORE:  " + coinCount.ToString();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            collision.gameObject.SetActive(false);
            coinCount += 5;
            SetScoreText();

            // Add audio when player collects coin
            source.PlayOneShot(coinSound);
        }
    }

    void SetScoreText()
    {
        // Check if there's already a current score existing
        if (PlayerPrefs.HasKey("Player Score"))
        {
            int currentCount = PlayerPrefs.GetInt("Player Score");
            coinCount += currentCount;
        }
        scoreText.text = "SCORE:  " + coinCount.ToString();
        // Save score to player preferences
        PlayerPrefs.SetInt("Player Score", coinCount);
        // Get logged user to use for highest score
        string loggedUser = PlayerPrefs.GetString("LoggedUser");
        // Save highest score to player preferences
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