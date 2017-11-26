using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneButtons : MonoBehaviour
{
	public AudioClip buttonClickSound;
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

	public void audioButton()
	{
		source = GetComponent<AudioSource>();
		source.PlayOneShot(buttonClickSound);
	}

	public void genericButton()
	{
		source = GetComponent<AudioSource>();
		source.PlayOneShot(buttonClickSound);
	}
}