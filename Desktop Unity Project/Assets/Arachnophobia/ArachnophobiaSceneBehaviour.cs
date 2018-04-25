using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ArachnophobiaSceneBehaviour : NetworkBehaviour {
    
    [ClientRpc]
    public void RpcLoadScene() { }

    [ClientRpc]
    public void RpcShowSpider() { }

    [ClientRpc]
    public void RpcSpiderSize(float value) { }

    [ClientRpc]
    public void RpcMovement(float vertical, float horizontal) { }

    [ClientRpc]
    public void RpcAttack() { }

    [ClientRpc]
    public void RpcJump() { }
}
