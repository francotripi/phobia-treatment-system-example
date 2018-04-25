using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Net;
using System.Net.Sockets;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ServerNetworkManager : NetworkManager
{
    private Text clientStatus;

    void Start()
    {
        clientStatus = GameObject.FindGameObjectWithTag("ClientStatusText").GetComponent<Text>();
        StartServer();
    }

    // called when a client connects 
    public override void OnServerConnect(NetworkConnection conn)
    {
        clientStatus.text = "Client connected";
    }

    // called when a client disconnects
    public override void OnServerDisconnect(NetworkConnection conn)
    {
        NetworkServer.DestroyPlayersForConnection(conn);
        clientStatus.text = "Client disconnected";
    }

    // called when a client is ready
    public override void OnServerReady(NetworkConnection conn)
    {
        NetworkServer.SetClientReady(conn);

        clientStatus.text = "Client ready!";

        StreamingReciver streamReciverScript = GameObject.Find("StreamingRawImage").GetComponent<StreamingReciver>();
        streamReciverScript.IPAddress = conn.address.Replace("::ffff:", "");

        GameObject SceneManager = Instantiate(this.spawnPrefabs.Find(x => x.tag == "SceneManager"));
        NetworkServer.Spawn(SceneManager);
    }

    // called when a network error occurs
    public override void OnServerError(NetworkConnection conn, int errorCode)
    {
        clientStatus.text = "Client error: "+errorCode;
    }

}


