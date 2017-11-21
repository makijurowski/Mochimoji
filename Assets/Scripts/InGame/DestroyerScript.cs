using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyerScript : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if Player has entered the Destroyer.
        if (other.tag == "Player")
        {
            SceneManager.LoadSceneAsync("GameOverScene", LoadSceneMode.Single);
        }

        // Otherwise, destroy the game object.
        if (other.gameObject.transform.parent)
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
