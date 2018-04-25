using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Este Script se encarga de procesar una imagen desde un arreglo de bytes y de crear un
/// arreglo de bytes a partir de una imagen
/// </summary>

public class DisplayStreamImage : MonoBehaviour {

    private RawImage rawImage;
    private Texture2D texture2D;

    void Start()
    {
        rawImage = this.GetComponent<RawImage>();
        texture2D = new Texture2D(0, 0);
    }

    public void DisplayImageDataBytes(byte[] imageDataBytes)
    {
        texture2D.LoadImage(imageDataBytes);
        rawImage.texture = texture2D;
    }

}
