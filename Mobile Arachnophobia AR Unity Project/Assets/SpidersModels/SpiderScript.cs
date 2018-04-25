using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpiderScript : MonoBehaviour {

    Animator animator;
    int jumpHash = Animator.StringToHash("Jump");
    int attackHash = Animator.StringToHash("Attack");

    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
	}
	 
	// Update is called once per frame
	void Update () {

        #region Animator
        //Walk
        float move = Input.GetAxis("Vertical");
        animator.SetFloat("Speed", move);

        //Attack
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetTrigger(attackHash);
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger(jumpHash);
        }

        #endregion

        #region Movement

        //Transalation
        float translation = Input.GetAxis("Vertical") * speed;
        translation *= Time.deltaTime;
        transform.Translate(0, 0, translation);

        //Rotation
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        rotation *= Time.deltaTime;
        transform.Rotate(0, rotation, 0);

        #endregion

    }    
   
}
