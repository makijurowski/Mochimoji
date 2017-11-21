using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour {

    public void playAgainButton()
    {
        SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Single);
    }

    public void logoutButton()
    {
        SceneManager.LoadSceneAsync("LoginRegisterScene", LoadSceneMode.Single);
    }
}
