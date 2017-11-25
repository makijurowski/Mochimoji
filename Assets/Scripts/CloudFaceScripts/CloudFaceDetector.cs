using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class CloudFaceDetector : MonoBehaviour
{
    [Tooltip("Image source component used for making camera shots.")]
    public WebcamSource imageSource;

    [Tooltip("Image component used for rendering camera shots")]
    public RawImage cameraShot;

    [Tooltip("Whether to recognize the emotions of the detected faces, or not.")]
    public bool recognizeEmotions = false;

    [Tooltip("Text component used for displaying hints and status messages.")]
    public Text hintText;

    // Initial hint message
    public string hintMessage;

    [Tooltip("Text component used to display face-detection results.")]
    public Text resultText;

    // Whether webcamSource has been set or there is web camera at all
    private bool hasCamera = false;

    // AspectRatioFitter component;
    private AspectRatioFitter ratioFitter;

    // Name of current emoji
    public static string EmojiNameOnCloudScript;

    // Submit button
    public Button submitButton;

    // Audio for camera click
    public AudioClip cameraClickSound;

    // Initialize audio source
    private AudioSource source;

    void Start()
    {
        if (cameraShot)
        {
            ratioFitter = cameraShot.GetComponent<AspectRatioFitter>();
        }
        hasCamera = imageSource != null && imageSource.HasCamera();
        source = GetComponent<AudioSource>();
    }

    public void Update()
    {
        hintMessage = hasCamera ? "Click on the camera image to take a picture.\nTry to match your face to " + EmojiNameOnCloudScript + "!" : "No camera found";
        SetHintText(hintMessage);
    }

    // Camera panel on-click event handler
    public void OnCameraClick()
    {
        source.PlayOneShot(cameraClickSound);
        hintText.gameObject.SetActive(false);
        if (!hasCamera)
            return;

        if (DoCameraShot())
        {
            ClearResultText();
            StartCoroutine(DoFaceDetection());
        }
    }

    // Camera-shot panel on-click event handler
    public void OnShotClick()
    {
        if (DoImageImport())
        {
            ClearResultText();
            StartCoroutine(DoFaceDetection());
        }
    }

    // Camera shot step
    private bool DoCameraShot()
    {
        if (cameraShot != null && imageSource != null)
        {
            SetShotImageTexture(imageSource.GetImage());
            return true;
        }

        return false;
    }

    // Imports image and displays it on the camera-shot object
    private bool DoImageImport()
    {
        Texture2D tex = FaceDetectionUtils.ImportImage();
        if (!tex) return false;

        SetShotImageTexture(tex);

        return true;
    }

    // Perform face detection
    public IEnumerator DoFaceDetection()
    {
        // Get the image to detect
        Face[] faces = null;
        Texture2D texCamShot = null;

        if (cameraShot)
        {
            texCamShot = (Texture2D) cameraShot.texture;
            SetHintText("Wait...");
        }

        // Get the face manager instance
        CloudFaceManager faceManager = CloudFaceManager.Instance;

        if (!faceManager)
        {
            SetHintText("Check if the FaceManager component exists in the scene.");
        }
        else if (texCamShot)
        {
            byte[] imageBytes = texCamShot.EncodeToJPG();
            yield return null;

            AsyncTask<Face[]> taskFace = new AsyncTask<Face[]>(() =>
            {
                return faceManager.DetectFaces(imageBytes);
            });

            taskFace.Start();
            yield return null;

            while (taskFace.State == TaskState.Running)
            {
                yield return null;
            }

            if (string.IsNullOrEmpty(taskFace.ErrorMessage))
            {
                faces = taskFace.Result;

                if (faces != null && faces.Length > 0)
                {
                    // Stick to detected face rectangles
                    FaceRectangle[] faceRects = new FaceRectangle[faces.Length];

                    for (int i = 0; i < faces.Length; i++)
                    {
                        faceRects[i] = faces[i].faceRectangle;
                    }

                    yield return null;

                    // Get facial emotions
                    if (recognizeEmotions)
                    {
                        // Emotion[] emotions = faceManager.RecognizeEmotions(texCamShot, faceRects);
                        AsyncTask<Emotion[]> taskEmot = new AsyncTask<Emotion[]>(() =>
                        {
                            return faceManager.RecognizeEmotions(imageBytes, faceRects);
                        });

                        taskEmot.Start();
                        yield return null;

                        while (taskEmot.State == TaskState.Running)
                        {
                            yield return null;
                        }

                        if (string.IsNullOrEmpty(taskEmot.ErrorMessage))
                        {
                            Emotion[] emotions = taskEmot.Result;
                            int matched = faceManager.MatchEmotionsToFaces(ref faces, ref emotions);

                            if (matched != faces.Length)
                            {
                                Debug.Log(string.Format("Matched {0}/{1} emotions to {2} faces.", matched, emotions.Length, faces.Length));
                            }
                        }
                        else
                        {
                            SetHintText(taskEmot.ErrorMessage);
                        }
                    }

                    CloudFaceManager.DrawFaceRects(texCamShot, faces, FaceDetectionUtils.FaceColors);
                    SetHintText(hintMessage);
                    SetResultText(faces);
                }
                else
                {
                    SetHintText("No face(s) detected.");
                }
            }
            else
            {
                SetHintText(taskFace.ErrorMessage);
            }
        }

        yield return null;
    }

    // Display image on the camera-shot object
    public void SetShotImageTexture(Texture2D tex)
    {
        if (ratioFitter)
        {
            ratioFitter.aspectRatio = (float) tex.width / (float) tex.height;
        }

        if (cameraShot)
        {
            cameraShot.texture = tex;
        }
    }

    // Display results
    public void SetResultText(Face[] faces)
    {
        StringBuilder sbResult = new StringBuilder();
        submitButton.gameObject.SetActive(true);

        if (faces != null && faces.Length > 0)
        {
            for (int i = 0; i < 1; i++)
            {
                Face face = faces[i];
                string faceColorName = FaceDetectionUtils.FaceColorNames[i % FaceDetectionUtils.FaceColors.Length];

                string res = FaceDetectionUtils.FaceToString(face, faceColorName);

                sbResult.Append(string.Format("<color={0}>{1}</color>", faceColorName, res));
            }
        }

        string result = sbResult.ToString();

        if (resultText)
        {
            resultText.text = result;
        }
        else
        {
            Debug.Log(result);
        }
    }

    // Clear result
    public void ClearResultText()
    {
        hintText.gameObject.SetActive(true);
        if (resultText)
        {
            resultText.text = "";
            SetHintText(hintMessage);
        }
    }

    // Displays hint or status text
    public void SetHintText(string sHintText)
    {
        if (hintText)
        {
            hintText.text = sHintText;
        }
        else
        {
            Debug.Log(sHintText);
        }
    }
}