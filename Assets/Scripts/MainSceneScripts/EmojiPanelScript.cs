using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmojiPanelScript : MonoBehaviour 
{
	public GameObject[] emojiPanelList;
	public static GameObject[] staticEmojiPanelList;
	public static string currentEmojiName;
	public GameObject currentEmoji;
	public GameObject currentEmojiPanel;
	public static GameObject staticCurrentEmoji;

	// Update is called once per frame
	public void Update() 
	{

	}

	public void ShowEmojiImage(Collider2D collision)
	{
		currentEmojiName = CloudFaceDetector.EmojiNameOnCloudScript;
		System.Console.WriteLine(currentEmojiName + " image opened");
		switch (currentEmojiName)
		{
			case "Fear Emoji":
				currentEmoji = emojiPanelList[0];
				break;
			case "Happiness Emoji":
				currentEmoji = emojiPanelList[1];
				break;
			case "Neutral Emoji":
				currentEmoji = emojiPanelList[2];
				break;
			case "Disgust Emoji":
				currentEmoji = emojiPanelList[3];
				break;
			case "Contempt Emoji":
				currentEmoji = emojiPanelList[4];
				break;
			case "Surprise Emoji":
				currentEmoji = emojiPanelList[5];
				break;
			case "Sadness Emoji":
				currentEmoji = emojiPanelList[6];
				break;
			case "Anger Emoji":
				currentEmoji = emojiPanelList[7];
				break;
			default:
				System.Console.WriteLine("This did not work");
				break;
		}
		currentEmoji.gameObject.SetActive(true);
		currentEmoji.gameObject.transform.SetAsLastSibling();
	}

	public void HideEmojiImage(Collider2D collision)
	{
		currentEmoji.gameObject.SetActive(false);
		System.Console.WriteLine("Emoji image closed");
	}
}
