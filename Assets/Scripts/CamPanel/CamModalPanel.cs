using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
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

    void ClosePanel()
    {
        modalPanelObject.SetActive(false);
    }
}
