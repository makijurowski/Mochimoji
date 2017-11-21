using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class InstructionPanel : MonoBehaviour
{
    public GameObject modalPanelObject;

    private static InstructionPanel instructionModalPanel;

    public static InstructionPanel Instance()
    {
        if (!instructionModalPanel)
        {
            instructionModalPanel = FindObjectOfType(typeof(InstructionPanel)) as InstructionPanel;
            if (!instructionModalPanel)
                Debug.LogError("There needs to be one active InstructionModalPanel script on a GameObject in your scene.");
        }

        return instructionModalPanel;
    }

    public void ShowPanel()
    {
        modalPanelObject.SetActive(true);
    }

    public void ClosePanel()
    {
        modalPanelObject.SetActive(false);
    }
}