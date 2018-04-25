using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MoveSpider : MonoBehaviour {

    void Update()
    {
        //Translation movement
        if (Input.GetAxis("Vertical") != 0)
        {
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<ArachnophobiaSceneBehaviour>().RpcMovement(Input.GetAxis("Vertical"), 0);
        }

        //Rotation movement
        if (Input.GetAxis("Horizontal") != 0)
        {
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<ArachnophobiaSceneBehaviour>().RpcMovement(0, Input.GetAxis("Horizontal"));
        }

        //Attack
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<ArachnophobiaSceneBehaviour>().RpcAttack();
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<ArachnophobiaSceneBehaviour>().RpcJump();
        }
    }
}
