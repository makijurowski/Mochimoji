using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpScript : MonoBehaviour
{
    public GameObject[] randomEmojis;
    public GameObject selectedEmoji;
    public static GameObject lastEmoji;
    public static string selectedEmojiName;
    public GameObject modalPanelObject;
    public WebcamSource cam;

    private void Awake()
    {
        try 
        {
            cam.Awake();
        }
        catch 
        {
            Debug.Log("No cam to awaken.");
        }
    }

    public void Start()
    {
        selectedEmoji = randomEmojis[UnityEngine.Random.Range(0, 8)];
    }

    // If Player collides with PowerUp, then text will be triggered.
    void OnTriggerEnter2D(Collider2D collision)
    {
        selectedEmoji.gameObject.SetActive(true);
        lastEmoji = selectedEmoji.gameObject;
        selectedEmojiName = selectedEmoji.gameObject.tag;
        CloudFaceDetector.EmojiNameOnCloudScript = selectedEmoji.gameObject.tag;

        if (collision.gameObject.CompareTag("Player"))
        {
            // Add audio when player collides with powerUp
            modalPanelObject.SetActive(true);
            selectedEmoji = PowerUpScript.lastEmoji;
            try
            {
                cam.gameObject.SetActive(true);
                cam.enabled = true;
                cam.Play();
            }
            catch
            {
                Debug.Log("No cam to play.");
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        cam.gameObject.SetActive(true);
        cam.enabled = true;
        selectedEmoji.gameObject.SetActive(true);
        lastEmoji = selectedEmoji.gameObject;
        selectedEmojiName = selectedEmoji.gameObject.tag;
        CloudFaceDetector.EmojiNameOnCloudScript = selectedEmoji.gameObject.tag;
    }

    // If the player moves away from object, then the emoji disappears
    void OnTriggerExit2D(Collider2D collision)
    {
        selectedEmoji.gameObject.SetActive(false);
        selectedEmojiName = "";
        cam.enabled = false;
        modalPanelObject.gameObject.SetActive(false);
    }
}