using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class TriggerGoalScript : MonoBehaviour {

    public Text triggeredText;

    // Audio triggers.
    public AudioClip goalSound;
    private AudioSource source;

    private void Awake()
    {
        // Get audio clip.
        source = GetComponent<AudioSource>();
    }

    // If Player collides with Object, then text will be triggered.
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            triggeredText.gameObject.SetActive(true);

            // Add audio when player triggers treasure chest.
            source.PlayOneShot(goalSound);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            triggeredText.gameObject.SetActive(true);

            // If Player presses "x", it will load the Game Over scene.
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadSceneAsync("GameOverScene", LoadSceneMode.Single);
            }
        }
    }

    // If Player moves away from Object, then text will disappear.
    void OnTriggerExit2D(Collider2D collision)
    {
        triggeredText.gameObject.SetActive(false);
    }
}
