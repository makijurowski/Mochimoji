using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {

    private InstructionPanel instructionPanel;

    // Audio triggers
    public AudioClip closePanelSound;
    private AudioSource source;

    private void Awake()
    {
        instructionPanel = InstructionPanel.Instance();
        source = GetComponent<AudioSource>();
    }

    public void startGameButton()
    {
        SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Single);
    }

    public void loadInstructionPanel()
    {
        instructionPanel.ShowPanel();
    }

    public void ClosePanel()
    {
        instructionPanel.ClosePanel();
        source.PlayOneShot(closePanelSound);
    }
}