﻿using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class WebcamSource : MonoBehaviour, ImageSourceInterface
	{
		[Tooltip("Whether the web-camera output needs to be flipped horizontally or not.")]
		public bool flipHorizontally = false;

		[Tooltip("Selected web-camera name, if any.")]
		public string webcamName;

		// The web-camera texture
		private WebCamTexture webcamTex;

		// Whether the output aspect ratio is set
		private bool bTexResolutionSet = false;

		public static WebCamDevice[] devices;

		public virtual void Awake()
		{
			try
			{
				if (devices == null)
				{
					devices = WebCamTexture.devices;
				}
				// Get 1st webcam name, if not set
				if (string.IsNullOrEmpty(webcamName))
				{
					webcamName = devices[0].name;
				}
			}

			finally
			{
				if (devices.Length > 0 && webcamName.Length > 0)
				{
					// Print available webcams
					StringBuilder sbWebcams = new StringBuilder();
					sbWebcams.Append("Available webcams:").AppendLine();

					foreach (WebCamDevice device in devices)
					{
						sbWebcams.Append(device.name).AppendLine();
					}

					Debug.Log(sbWebcams.ToString());

					// Create webcam tex
					webcamTex = new WebCamTexture(webcamName);

					OnApplyTexture(webcamTex);

					bTexResolutionSet = false;
				}

				if (flipHorizontally)
				{
					Vector3 scale = transform.localScale;
					transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
				}

				if (HasCamera())
				{
					webcamTex.Play();
				}
			}
		}

		public virtual void Play()
		{
			try
			{
				if (devices == null)
				{
					devices = WebCamTexture.devices;
				}
				if (string.IsNullOrEmpty(webcamName))
				{
					webcamName = devices[0].name;
				}
			}

			finally
			{
				if (devices.Length > 0 && webcamName.Length > 0)
				{
					// Create webcam tex
					webcamTex = new WebCamTexture(webcamName);

					OnApplyTexture(webcamTex);

					bTexResolutionSet = false;

					if (flipHorizontally)
					{
						Vector3 scale = transform.localScale;
						transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
					}

					if (HasCamera())
					{
						webcamTex.Play();
					}
				}
			}
		}

		public void Update()
		{
			if (!bTexResolutionSet && webcamTex != null && webcamTex.isPlaying)
			{
				OnSetAspectRatio(webcamTex.width, webcamTex.height);
				bTexResolutionSet = true;
				webcamTex.Play();
			}
		}

		public void OnDisable()
		{
			if (webcamTex)
			{
				webcamTex.Stop();
				webcamTex = null;
			}
		}

		/// <summary>
		/// Gets the image as texture2d.
		/// </summary>
		/// <returns>The image.</returns>
		public Texture2D GetImage()
		{

			Texture2D snap = new Texture2D(webcamTex.width, webcamTex.height, TextureFormat.ARGB32, false);

			if (webcamTex)
			{
				snap.SetPixels(webcamTex.GetPixels());
				snap.Apply();

				if (flipHorizontally)
				{
					snap = CloudTexTools.FlipTexture(snap);
				}
			}

			return snap;
			//return _textureFromCamera;
		}

		// Check if there is web camera
		public bool HasCamera()
		{
			return webcamTex && !string.IsNullOrEmpty(webcamTex.deviceName);
		}

		public void OnApplyTexture(Texture tex)
		{
			RawImage rawimage = GetComponent<RawImage>();
			if (rawimage)
			{
				rawimage.texture = tex;
				//rawimage.material.mainTexture = tex;
			}
		}

		public void OnSetAspectRatio(int width, int height)
		{
			AspectRatioFitter ratioFitter = GetComponent<AspectRatioFitter>();
			if (ratioFitter)
			{
				ratioFitter.aspectRatio = (float) width / (float) height;
			}
		}
	}