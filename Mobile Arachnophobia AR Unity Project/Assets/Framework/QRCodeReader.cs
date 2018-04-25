using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;

public class QRCodeReader : MonoBehaviour
{

    public ClientNetworkManager ClientNetworkManager;

    private Texture2D camTexture;

    void Update()
    {
        camTexture = this.GetComponent<CameraImageCapture>().GetTexture2D();
        try
        {
            IBarcodeReader barcodeReader = new BarcodeReader();
            // decode the current frame
            var result = barcodeReader.Decode(camTexture.GetPixels32(),
              camTexture.width, camTexture.height);
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
