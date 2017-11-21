//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using UnityEngine;
//using UnityEngine.UI;

//public class TriggerScript : MonoBehaviour {

//    private CamModalPanel modalPanel;
//    public GameObject modalPanelObject;
//    public static GameObject selectedEmoji;
//    public static GameObject CloudFaceController;
//    public static string selectedEmojiName;
//    public WebcamSource cam;

//    void Awake()
//    {
//        modalPanel = CamModalPanel.Instance();
//        cam.Awake();
//    }

//    // If Player collides with PowerUp, then text will be triggered.
//    void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.gameObject.CompareTag("Player"))
//        {
//            modalPanelObject.SetActive(true);
//            selectedEmoji = PowerUpScript.lastEmoji;
//            selectedEmojiName = PowerUpScript.selectedEmojiName;
//            cam.Awake();
//        }
//    }

//    private void OnTriggerStay2D(Collider2D collision)
//    {
//        if (collision.gameObject.CompareTag("Player"))
//        {
//            // If Player presses "x", it will load the Game Over scene.
//            if (Input.GetKeyDown(KeyCode.X))
//            {
//                // CloudFaceController = collision.transform.parent.Find("CloudFaceController").gameObject;
//                collision.GetComponent<TriggerPowerUpScript>().PowerUp();
//                collision.transform.Find("Submit").gameObject.SetActive(false);
//                collision.GetComponent<PowerUpTriggeredText>().gameObject.SetActive(true);
//                collision.GetComponent<PowerUpTriggeredText>().New();
//                collision.GetComponent<CloudFaceDetector>().ClearResultText();
//            }
//        }
//    }

//    // If Player moves away from Object, then text will disappear.
//    void OnTriggerExit2D(Collider2D collision)
//    {
//        modalPanelObject.SetActive(false);
//    }
//}