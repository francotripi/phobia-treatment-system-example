using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowVRCamera : MonoBehaviour {

    public GameObject VRCamera;

    private void Update()
    {
        this.transform.position = VRCamera.transform.position;
        this.transform.rotation = VRCamera.transform.rotation;
    }
}
