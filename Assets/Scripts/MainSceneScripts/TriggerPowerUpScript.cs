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
		currentScores = FaceDetectionUtils.currentScores;

		// Determine player score for current emoji
		StringBuilder emotStr = new StringBuilder();
		switch(currentEmoji)
		{
			case "Anger Emoji":
				emotStr.Append(string.Format("Anger Emoji & Anger Score: {0:F0}%", currentScores.anger * 100f)).AppendLine();
				emotionScore = currentScores.anger;
				break;
			case "Contempt Emoji":
				emotStr.Append(string.Format(" Contempt Emoji & Contempt Score: {0:F0}%", currentScores.contempt * 100f)).AppendLine();
				emotionScore = currentScores.contempt;
				break;
			case "Disgust Emoji":
				emotStr.Append(string.Format(" Disgust Emoji & Disgust Score: {0:F0}%", currentScores.disgust * 100f)).AppendLine();
				emotionScore = currentScores.disgust;
				break;
			case "Fear Emoji":
				emotStr.Append(string.Format(" Fear Emoji & Fear Score: {0:F0}%", currentScores.fear * 100f)).AppendLine();
				emotionScore = currentScores.disgust;
				break;
			case "Happiness Emoji":
				emotStr.Append(string.Format(" Happiness Emoji & Happiness Score: {0:F0}%", currentScores.happiness * 100f)).AppendLine();
				emotionScore = currentScores.happiness;
				break;
			case "Neutral Emoji":
				emotStr.Append(string.Format(" Neutral Emoji & Neutral Score: {0:F0}%", currentScores.neutral * 100f)).AppendLine();
				emotionScore = currentScores.neutral;
				break;
			case "Sadness Emoji":
				emotStr.Append(string.Format(" Sadness Emoji & Sadness Score: {0:F0}%", currentScores.sadness * 100f)).AppendLine();
				emotionScore = currentScores.sadness;
				break;
			case "Surprise Emoji":
				emotStr.Append(string.Format(" Surprise Emoji & Surprise Score: {0:F0}%", currentScores.surprise * 100f)).AppendLine();
				emotionScore = currentScores.surprise;
				break;
			default:
				Debug.Log("Broken!");
				break;
		}

		// De-activate currentEmoji
		PowerUpScript.lastEmoji.transform.parent.Find("PowerUp").gameObject.SetActive(false);

		// Current emoji & emotion scores
		Debug.Log("CurrentEmoji: " + currentEmoji);
		Debug.Log("EmotionScores: " + emotStr);

		// Add Speed Boost
		PowerSpeed = ((emotionScore/2f) + 1.2f);
		Debug.Log("PowerSpeed Multiplier: " + (PowerSpeed) + " / PowerSpeed: " + (PowerSpeed * 8f));
		
		// Current coins
		coinCount = PlayerPrefs.GetInt("Player Score");

		// Calculate coin bonus
		coinBonus = (20 + Mathf.RoundToInt(emotionScore * 50));
		coinCount = coinCount + (UnityEngine.Random.Range(coinBonus - 10, coinBonus + 10));

		// Set score
		PlayerPrefs.SetInt("Player Score", coinCount);
		scoreText.text = "SCORE: " + coinCount.ToString();
		
		// Reset coinCount
		coinCount = 0;
	}
}