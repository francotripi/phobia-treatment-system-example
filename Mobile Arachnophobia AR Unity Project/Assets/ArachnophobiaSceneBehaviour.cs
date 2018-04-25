using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ArachnophobiaSceneBehaviour : NetworkBehaviour {

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    [ClientRpc]
    public void RpcLoadScene()
    {
        Instantiate(Resources.Load("CameraStreamSenderPrefab"), GameObject.Find("ARCamera").transform);
    }

    [ClientRpc]
    public void RpcShowSpider()
    {
        Instantiate(Resources.Load("SpiderPrefab"));
    }

    [ClientRpc]
    public void RpcSpiderSize(float value)
    {
        GameObject.FindGameObjectWithTag("Spider").transform.localScale = new Vector3(value, value, value);
    }

    [ClientRpc]
    public void RpcMovement(float vertical, float horizontal)
    {
        GameObject spider = GameObject.FindGameObjectWithTag("Spider");

        float speed = 2f;
        float rotationSpeed = 50f;
        //Walk Animation
        spider.GetComponent<Animator>().SetFloat("Speed", vertical);

        //Transalation
        float translation = vertical * speed;
        translation *= Time.deltaTime;
        spider.transform.Translate(0, 0, translation);

        //Rotation
        float rotation = horizontal * rotationSpeed;
        rotation *= Time.deltaTime;
        spider.transform.Rotate(0, rotation, 0);
    }

    [ClientRpc]
    public void RpcAttack()
    {
        int attackHash = Animator.StringToHash("Attack");
        GameObject.FindGameObjectWithTag("Spider").GetComponent<Animator>().SetTrigger(attackHash);
    }

    [ClientRpc]
    public void RpcJump()
    {
        int jumpHash = Animator.StringToHash("Jump");
        GameObject.FindGameObjectWithTag("Spider").GetComponent<Animator>().SetTrigger(jumpHash);
    }

}
