using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class TriggerPowerUpScript : MonoBehaviour {
	[SerializeField] public static bool powerUp;
	public static float PowerSpeed;
    public static string currentEmoji;
	public Text scoreText;
	private int coinCount;
	private int coinBonus;
	public static float emotionScore;
	private static Scores currentScores;

	void Start()
	{
	}

    // Changes powerUp to true
    public void PowerUp()
    {
		// Set powerUp to true
        powerUp = true;
		Debug.Log("Power Up activated!");

		// Identify currentEmoji & currentScores
        currentEmoji = PowerUpScript.selectedEmojiName;
		Debug.Log("currentEmoji from TriggerPowerUpScript: " + currentEmoji);
		currentScores = FaceDetectionUtils.currentScores;

		// Determine player score for current emoji
		StringBuilder emotStr = new StringBuilder();
		switch(currentEmoji)
		{
			case "AngryEmoji":
				emotStr.Append(string.Format("AngryEmoji & Anger Score: {0:F0}%", currentScores.anger * 100f)).AppendLine();
				emotionScore = currentScores.anger;
				break;
			case "ContemptEmoji":
				emotStr.Append(string.Format(" ContemptEmoji & Contempt Score: {0:F0}%", currentScores.contempt * 100f)).AppendLine();
				emotionScore = currentScores.contempt;
				break;
			case "FrowningEmoji":
				emotStr.Append(string.Format(" FrowningEmoji & Disgust Score: {0:F0}%", currentScores.disgust * 100f)).AppendLine();
				emotionScore = currentScores.disgust;
				break;
			case "NeutralEmoji":
				emotStr.Append(string.Format(" NeutralEmoji & Neutral Score: {0:F0}%", currentScores.neutral * 100f)).AppendLine();
				emotionScore = currentScores.neutral;
				break;
			case "SadCryingEmoji":
				emotStr.Append(string.Format(" SadCryingEmoji & Sadness Score: {0:F0}%", currentScores.sadness * 100f)).AppendLine();
				emotionScore = currentScores.sadness;
				break;
			case "SmileEmoji":
				emotStr.Append(string.Format(" SmileEmoji & Happiness Score: {0:F0}%", currentScores.happiness * 100f)).AppendLine();
				emotionScore = currentScores.happiness;
				break;
			case "SurprisedEmoji":
				emotStr.Append(string.Format(" SurprisedEmoji & Surprise Score: {0:F0}%", currentScores.surprise * 100f)).AppendLine();
				emotionScore = currentScores.surprise;
				break;
			default:
				Debug.Log("Broken!");
				break;
		}

		// De-activate currentEmoji
		PowerUpScript.lastEmoji.transform.parent.Find("PowerUp").gameObject.SetActive(false);

		// TODO remove debug statements
		Debug.Log("********************");
		Debug.Log("********************");

		// Current emoji & emotion scores
		Debug.Log("currentEmoji: " + currentEmoji);
		Debug.Log("EmotionScores: " + emotStr);

		// Add Speed Boost
		PowerSpeed = ((emotionScore/2f) + 1.2f);
		Debug.Log("Power Speed Boost: " + (PowerSpeed) + " and Power Speed: " + (PowerSpeed * 8f));
		
		// Current coins
		coinCount = PlayerPrefs.GetInt("Player Score");
		Debug.Log("Current coin count: " + coinCount);

		// Calculate coin bonus
		coinBonus = (20 + Mathf.RoundToInt(emotionScore * 50));
		coinCount = coinCount + (UnityEngine.Random.Range(coinBonus - 10, coinBonus + 10));
		Debug.Log("coinCount Min: " + (coinBonus - 10));
		Debug.Log("coinCount Max: "+ (coinBonus + 10));

		// Set score
		PlayerPrefs.SetInt("Player Score", coinCount);
		scoreText.text = "SCORE: " + coinCount.ToString();
		Debug.Log("coinCount Actual: " + coinCount);
		Debug.Log("********************");
		Debug.Log("********************");
		
		// Reset coinCount
		coinCount = 0;
	}
}