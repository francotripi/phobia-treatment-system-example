using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class AcrophobiaSceneBehaviour : NetworkBehaviour{

    [ClientRpc]
    public void RpcLoadScene() { }

    [ClientRpc]
    public void RpcShowFloor() { }

    [ClientRpc]
    public void RpcHideFloor() { }

    [ClientRpc]
    public void RpcShowRail() { }

    [ClientRpc]
    public void RpcHideRail() { }

    [ClientRpc]
    public void RpcBuildingHeight(float value) { }
}
