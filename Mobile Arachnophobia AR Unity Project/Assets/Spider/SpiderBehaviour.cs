using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SpiderBehaviour : NetworkBehaviour {

    [SyncVar]
    public bool IsSpawnOnClient;
    [SyncVar]
    public float SpiderSize;

    Animator animator;
    int jumpHash = Animator.StringToHash("Jump");
    int attackHash = Animator.StringToHash("Attack");

    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;

    public Slider slider;

    public override void OnStartClient()
    {
        IsSpawnOnClient = true;
    }

    public override void OnStartServer()
    {
       
    }

    public override void OnNetworkDestroy()
    {
        IsSpawnOnClient = false;
    }


    void Start()
    {
        animator = GetComponent<Animator>();
        SpiderSize = transform.localScale.x;
        if (isClient)
        {
            this.transform.parent = GameObject.Find("ImageTarget").transform;
        }
    }

    [ServerCallback]
    void Update()
    {
        //Translation movement
        if (Input.GetAxis("Vertical") != 0)
        {
            RpcMovement(Input.GetAxis("Vertical"), 0);
        }

        //Rotation movement
        if (Input.GetAxis("Horizontal") != 0)
        {
            RpcMovement(0, Input.GetAxis("Horizontal"));
        }

        //Attack
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            RpcAttack();
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RpcJump();
        }
    }

    public void setSpiderSize(float value)
    {
        SpiderSize = value;
        transform.localScale = new Vector3(value, value, value);
        RpcSpiderResize(transform.localScale);
    }

    
    #region RpcCalls

    [ClientRpc]
    public void RpcMovement(float vertical, float horizontal)
    {
        //Walk Animation
        animator.SetFloat("Speed", vertical);

        //Transalation
        float translation = vertical * speed;
        translation *= Time.deltaTime;
        transform.Translate(0, 0, translation);

        //Rotation
        float rotation = horizontal * rotationSpeed;
        rotation *= Time.deltaTime;
        transform.Rotate(0, rotation, 0);
    }

    [ClientRpc]
    public void RpcAttack()
    {
        animator.SetTrigger(attackHash);
    }

    [ClientRpc]
    public void RpcJump()
    {
        animator.SetTrigger(jumpHash);
    }

    [ClientRpc]
    public void RpcSpiderResize(Vector3 newSize)
    {
        transform.localScale = newSize;
    }

    #endregion
}
