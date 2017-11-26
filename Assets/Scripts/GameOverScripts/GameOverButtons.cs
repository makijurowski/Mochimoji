using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour {
    public AudioClip buttonClickSound;
    private AudioSource source;

    public void playAgainButton()
    {
        source = GetComponent<AudioSource>();
        source.PlayOneShot(buttonClickSound);
        SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Single);
    }

    public void logoutButton()
    {
        source = GetComponent<AudioSource>();
        source.PlayOneShot(buttonClickSound);
        SceneManager.LoadSceneAsync("LoginRegisterScene", LoadSceneMode.Single);
    }
}