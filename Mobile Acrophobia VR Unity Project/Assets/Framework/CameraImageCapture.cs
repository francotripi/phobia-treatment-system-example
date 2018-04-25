using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Este Script se encarga de renderizar y capturar en un RenderTexture la Camara
/// Ofrece un metodo para obtener el frame de la camara en una Texture2D
/// </summary>
public class CameraImageCapture : MonoBehaviour
{
    int resWidth = 256;
    int resHeight = 148;

    private Camera mainCamera;

    public RenderTexture renderTexture { get; private set; }

    Texture2D tex;

    void Start()
    {
        mainCamera = this.GetComponent<Camera>();

        renderTexture = new RenderTexture(resWidth, resHeight, 24, RenderTextureFormat.ARGB32);

        tex = new Texture2D(renderTexture.width, renderTexture.height);
    }

    void Update()
    {
        mainCamera.targetTexture = renderTexture;
        RenderTexture.active = renderTexture;

        mainCamera.Render();

        mainCamera.targetTexture = null;
    }

    public Texture2D GetTexture2D()
    {
        RenderTexture.active = renderTexture;
        tex.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        tex.Apply();
        return tex;
    }

}
