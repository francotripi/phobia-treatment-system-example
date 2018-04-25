using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StreamSender : MonoBehaviour
{ 
    const int ENCODE_QUALITY = 50;
    public Camera mainCamera;

    private const int MAX_CONNECTION = 1;

    private int port = 5701;

    private int hostId;
    private int webHostId;

    private int reliableChannel;

    private bool isStarted = false;
    private byte error;

    private int clientId;
    private bool isClientConnected = false;

    private void Start()
    {
        mainCamera = this.GetComponentInParent<Camera>();
        StartStreaming();
    }

    public void StartStreaming()
    {
        NetworkTransport.Init();
        ConnectionConfig cc = new ConnectionConfig();

        reliableChannel = cc.AddChannel(QosType.ReliableFragmented);

        HostTopology topology = new HostTopology(cc, MAX_CONNECTION);

        hostId = NetworkTransport.AddHost(topology, port, null); //null acepts connection from everybody

        isStarted = true;
    }

    private void Update()
    { 
        if (!isStarted)
            return;

        int recHostId;
        int connectionId;
        int channelId;
        byte[] recBuffer = new byte[1024];
        int bufferSize = 1024;
        int dataSize;
        byte error;

        NetworkEventType recData = NetworkTransport.Receive(out recHostId, out connectionId, out channelId, recBuffer, bufferSize, out dataSize, out error);
        switch (recData)
        {
            case NetworkEventType.ConnectEvent:    //2
                Debug.Log(connectionId + " has connected");
                clientId = connectionId;
                isClientConnected = true;
                break;
            case NetworkEventType.DisconnectEvent: //4
                clientId = 0;
                isClientConnected = false;
                break;
        }

        if (!isClientConnected)
            return;

        byte[] dataBytes = mainCamera.GetComponent<CameraImageCapture>().GetTexture2D().EncodeToJPG(ENCODE_QUALITY);
        NetworkTransport.Send(hostId, clientId, channelId, dataBytes, dataBytes.Length, out error);
        Debug.Log("Send data: " + dataBytes.Length.ToString());
    }
}
