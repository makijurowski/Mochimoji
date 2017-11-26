using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{

    private InstructionPanel instructionPanel;

    // Audio triggers
    public AudioClip closePanelSound;
    private AudioSource source;

    private void Awake()
    {
        instructionPanel = InstructionPanel.Instance();
    }

    public void Start()
    {
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
        source = GetComponent<AudioSource>();
        source.PlayOneShot(closePanelSound);
        instructionPanel.ClosePanel();
    }
}