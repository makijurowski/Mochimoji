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

    // Audio triggers
    public AudioClip powerUpSound;
    private AudioSource source;

    private void Awake()
    {
        // Get audio clip.
        source = GetComponent<AudioSource>();
        cam.Awake();
    }

    public void Start()
    {
        selectedEmoji = randomEmojis[UnityEngine.Random.Range(0, 7)];
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
            // Add audio when player collects coin.
            source.PlayOneShot(powerUpSound);
            modalPanelObject.SetActive(true);
            selectedEmoji = PowerUpScript.lastEmoji;
            cam.Play();
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        selectedEmoji.gameObject.SetActive(true);
        lastEmoji = selectedEmoji.gameObject;
        selectedEmojiName = selectedEmoji.gameObject.tag;
        CloudFaceDetector.EmojiNameOnCloudScript = selectedEmoji.gameObject.tag;
    }

    // If Player moves away from Object, then text will disappear.
    void OnTriggerExit2D(Collider2D collision)
    {
        selectedEmoji.gameObject.SetActive(false);
        selectedEmojiName = "";
        modalPanelObject.SetActive(false);
    }
}