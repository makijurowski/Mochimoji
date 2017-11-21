using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {

    private InstructionPanel instructionPanel_bg;

    void Awake()
    {
        instructionPanel_bg = InstructionPanel.Instance();
    }

    public void startGameButton()
    {
        SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Single);
    }

    public void loadInstructionPanel()
    {
        instructionPanel_bg.ShowPanel();
    }

    public void ClosePanel()
    {
        instructionPanel_bg.ClosePanel();
    }
}
