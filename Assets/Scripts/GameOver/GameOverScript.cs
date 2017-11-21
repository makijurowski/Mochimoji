using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public TextMesh playerScoreText;
    public TextMesh highestScoreText;


    void Start()
    {
        // Get logged username and score.
        string loggedUsername = PlayerPrefs.GetString("LoggedUser");
        int score = PlayerPrefs.GetInt("Player Score");

        // Save score to user's account file.
        System.IO.File.AppendAllText(@"C:\Desktop\MochimojiUsers\" + loggedUsername + ".txt", "\r\n" + score.ToString());

        // Get player's score from player preferences.
        playerScoreText.text = loggedUsername.ToString() + ": " + score.ToString();

        // Get highest score from player preferences.
        int highestScore = PlayerPrefs.GetInt("Highest Score");
        string highestScoredPlayer = PlayerPrefs.GetString("Highest Scored Player");
        highestScoreText.text = highestScoredPlayer.ToString() + ": " + highestScore.ToString();
    }


    // Create GUI buttons for PLAY AGAIN and LOGOUT.
    //void OnGUI()
    //{
    //    if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 6 * 5, 100, 40), "PLAY AGAIN"))
    //    {
    //        SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Single);
    //    }
    //    if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 10 * 9, 100, 40), "LOGOUT"))
    //    {
    //        SceneManager.LoadSceneAsync("LoginRegisterScene", LoadSceneMode.Single);
    //    }
    //}
}