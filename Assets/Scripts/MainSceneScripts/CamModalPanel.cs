using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class CamModalPanel : MonoBehaviour
{
    public GameObject modalPanelObject;

    private static CamModalPanel modalPanel;

    public static CamModalPanel Instance()
    {
        if (!modalPanel)
        {
            modalPanel = FindObjectOfType(typeof(CamModalPanel)) as CamModalPanel;
            if (!modalPanel)
                Debug.LogError("There needs to be one active CamModalPanel script on a GameObject in your scene.");
        }

        return modalPanel;
    }

    public void ClosePanel()
    {
        modalPanelObject.SetActive(false);
    }
}
