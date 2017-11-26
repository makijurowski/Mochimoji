using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Text playerScoreText;
    public Text highestScoreText;


    void Start()
    {
        // Get logged username and score.
        string loggedUsername = PlayerPrefs.GetString("LoggedUser");
        int score = PlayerPrefs.GetInt("Player Score");

        // Save score to user's account file.
        System.IO.File.AppendAllText(@"C:\Desktop\MochimojiUsers\" + loggedUsername + ".txt", "\r\n" + score.ToString());

        // Get player's score from player preferences.
        if (loggedUsername.Length > 0)
        {
            playerScoreText.text = loggedUsername.ToString() + ": " + score.ToString();
        }
        else
        {
            playerScoreText.text = score.ToString();
        }

        // Get highest score from player preferences.
        int highestScore = PlayerPrefs.GetInt("Highest Score");
        string highestScoredPlayer = PlayerPrefs.GetString("Highest Scored Player");

        // Set highest score
        if (highestScoredPlayer.Length > 0)
        {
            highestScoreText.text = highestScoredPlayer.ToString() + ": " + highestScore.ToString();
        }
        else
        {
            highestScoreText.text = highestScore.ToString();
        }
    }
}