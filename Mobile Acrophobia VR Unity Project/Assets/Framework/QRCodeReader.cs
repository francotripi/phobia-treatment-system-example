using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;

public class QRCodeReader : MonoBehaviour
{
    public ClientNetworkManager ClientNetworkManager;
    public RawImage camImage;

    public WebCamTexture webCam { get; private set; }

    private void Start()
    {
        webCam = new WebCamTexture();
        //webCam.deviceName = WebCamTexture.devices[WebCamTexture.devices.Length - 1].name;
        webCam.deviceName = WebCamTexture.devices[0].name;
        camImage.texture = webCam;
        webCam.Play();
    }

    void Update()
    {
        try
        {
            IBarcodeReader barcodeReader = new BarcodeReader();
            // decode the current frame
            var result = barcodeReader.Decode(webCam.GetPixels32(),
              webCam.width, webCam.height);
            if (result != null)
            {
                Debug.Log("DECODED TEXT FROM QR: " + result.Text);
                ClientNetworkManager.ConnectClient(result.Text);
                this.enabled = false;
            }
        }
        catch (Exception ex) { Debug.LogWarning(ex.Message); }

    }
}
