using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpScript : MonoBehaviour
{
    // public Text triggeredText;
    public GameObject[] randomEmojis;
    public GameObject selectedEmoji;
    public static GameObject lastEmoji;
    public static string selectedEmojiName;

    public GameObject modalPanelObject;
    public WebcamSource cam;

    // Audio triggers.
    public AudioClip powerUpSound;
    private AudioSource source;

    private void Awake()
    {
        // Get audio clip.
        source = GetComponent<AudioSource>();
        cam.Play();
    }

    public void Start()
    {
        selectedEmoji = randomEmojis[UnityEngine.Random.Range(0, 6)];
    }

    // If Player collides with PowerUp, then text will be triggered.
    void OnTriggerEnter2D(Collider2D collision)
    {
        selectedEmoji.gameObject.SetActive(true);
        lastEmoji = selectedEmoji.gameObject;
        selectedEmojiName = selectedEmoji.gameObject.tag;
        CloudFaceDetector.EmojiNameOnCloudScript = selectedEmojiName;
        
        if (collision.gameObject.CompareTag("Player"))
        {
            // Add audio when player collects coin.
            source.PlayOneShot(powerUpSound);

            modalPanelObject.SetActive(true);

            selectedEmoji = PowerUpScript.lastEmoji;

            cam.Play();
        }
    }


    // If Player moves away from Object, then text will disappear.
    void OnTriggerExit2D(Collider2D collision)
    {
        // triggeredText.gameObject.SetActive(false);
        // selectedEmojiName = lastEmoji.gameObject.tag;
        selectedEmoji.gameObject.SetActive(false);
        modalPanelObject.SetActive(false);
    }
}
