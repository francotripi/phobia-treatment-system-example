using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;
using System.Net;
using System.Net.Sockets;

public class QRCodeGenerator : MonoBehaviour
{
    private Texture QRCodeTexture;

    private void Start()
    {
        this.GetComponent<RawImage>().texture = (Texture2D) generateQR(localIPAddress());
    }

    private static Color32[] Encode(string textForEncoding, int width, int height)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };
        return writer.Write(textForEncoding);
    }

    private Texture2D generateQR(string text)
    {
        var encoded = new Texture2D(256, 256);
        var color32 = Encode(text, encoded.width, encoded.height);
        encoded.SetPixels32(color32);
        encoded.Apply();
        return encoded;
    }

    private string localIPAddress()
    {
        string localIP = "";
        IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                localIP = ip.ToString();
                break;
            }
        }
        return localIP;
    }
}


