using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {

    private InstructionPanel instructionPanel;

    void Awake()
    {
        instructionPanel = InstructionPanel.Instance();
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
    }
}