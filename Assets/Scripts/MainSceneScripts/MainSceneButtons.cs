using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneButtons : MonoBehaviour
{
	public AudioClip buttonClickSound;
	public AudioListener audioPlayer;
	private AudioSource source;

	public void loadStartSceneButton()
	{
		source = GetComponent<AudioSource>();
		source.PlayOneShot(buttonClickSound);
		SceneManager.LoadSceneAsync("GameStartScene", LoadSceneMode.Single);
	}

	public void endGameButton()
	{
		source = GetComponent<AudioSource>();
		source.PlayOneShot(buttonClickSound);
		SceneManager.LoadSceneAsync("GameOverScene", LoadSceneMode.Single);
	}

	public void quitGameButton()
	{
		source = GetComponent<AudioSource>();
		source.PlayOneShot(buttonClickSound);
		Application.Quit();
	}

	public void audioButton()
	{
		source = GetComponent<AudioSource>();
		source.ignoreListenerPause = true;
		source.PlayOneShot(buttonClickSound);
		// Accessing Audio Listener on Main Camera by type
		AudioListener.pause = !AudioListener.pause;
	}

	public void genericButton()
	{
		source = GetComponent<AudioSource>();
		source.ignoreListenerPause = true;
		source.PlayOneShot(buttonClickSound);
		// Accessing Audio Listener on Main Camera through object instance
		audioPlayer = gameObject.GetComponent<MainSceneButtons>().audioPlayer;
	}
}