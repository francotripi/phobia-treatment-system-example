using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class StreamingReciver : MonoBehaviour {

    public string IPAddress;

    private const int MAX_CONNECTION = 1;

    private int port = 5701;

    private int hostId;
    private int webHostId;

    private int reliableChannel;
    private int unreliableChannel;

    private int connectionId;

    private float connectionTime;
    private bool isConnected = false;
    private byte error;

    public void Connect()
    {
        NetworkTransport.Init();
        ConnectionConfig cc = new ConnectionConfig();

        reliableChannel = cc.AddChannel(QosType.ReliableFragmented);

        HostTopology topology = new HostTopology(cc, MAX_CONNECTION);

        hostId = NetworkTransport.AddHost(topology, 0);
        connectionId = NetworkTransport.Connect(hostId, IPAddress, port, 0, out error);
        LOG("Streaming connected: " + IPAddress + " | " + port);

        connectionTime = Time.time;
        isConnected = true;
    }

    private void Update()
    {
        if (!isConnected)
            return;

        int recHostId;
        int connectionId;
        int channelId;
        byte[] recBuffer = new byte[16384]; //16.38Kb
        int bufferSize = 16384;
        int dataSize;
        byte error;
        NetworkEventType recData = NetworkTransport.Receive(out recHostId, out connectionId, out channelId, recBuffer, bufferSize, out dataSize, out error);
        switch (recData)
        {
            case NetworkEventType.DataEvent:
                LOG("Recive datasize: " + dataSize.ToString());
                if ((NetworkError)error == NetworkError.MessageToLong)
                {
                    LOG("Message too long. BufferSize: " + bufferSize + " DataSize: " + dataSize);
                }
                this.GetComponent<DisplayStreamImage>().DisplayImageDataBytes(recBuffer);
                
                break;
        }
    }

    public Text console;
    private void LOG(string message)
    {
        Debug.Log(message);
        console.text = message;
    }
}
