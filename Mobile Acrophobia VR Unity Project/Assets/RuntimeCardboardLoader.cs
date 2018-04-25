// Run in split-screen mode

using System.Collections;
using UnityEngine;
using UnityEngine.VR;

public class RuntimeCardboardLoader : MonoBehaviour
{
	void Start()
	{
		StartCoroutine(LoadDevice("cardboard"));
	}

	IEnumerator LoadDevice(string newDevice)
	{
		UnityEngine.XR.XRSettings.LoadDeviceByName(newDevice);
		yield return null;
		UnityEngine.XR.XRSettings.enabled = true;
	}
}
