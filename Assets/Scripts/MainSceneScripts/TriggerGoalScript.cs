using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TriggerGoalScript : MonoBehaviour {

    public Text triggeredText;

    // Audio triggers
    // public AudioClip goalSound;
    private AudioSource source;


    // If Player collides with Object, then text will be triggered.
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            triggeredText.gameObject.SetActive(true);

            // Add audio when player triggers treasure chest.
            // source = GetComponent<AudioSource>();
            // source.PlayOneShot(goalSound);
            SceneManager.LoadSceneAsync("GameOverScene", LoadSceneMode.Single);
        }
    }

    // If Player moves away from Object, then text will disappear.
    void OnTriggerExit2D(Collider2D collision)
    {
        triggeredText.gameObject.SetActive(false);
    }
}
