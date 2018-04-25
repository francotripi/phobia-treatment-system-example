using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vuforia;

public class ClientNetworkManager : NetworkManager {

    public void ConnectClient(string IPAddress)
    {
        this.networkAddress = IPAddress;
        this.StartClient();
    }

    // called when connected to a server
    public override void OnClientConnect(NetworkConnection conn)
    {
        ClientScene.Ready(conn);
    }

    // called when disconnected from a server
    public override void OnClientDisconnect(NetworkConnection conn)
    {
        StopClient();
    }

    // called when a network error occurs
    public override void OnClientError(NetworkConnection conn, int errorCode) { }

    // called when told to be not-ready by a server
    public override void OnClientNotReady(NetworkConnection conn) { }

}
