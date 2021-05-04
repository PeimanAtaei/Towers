using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraController : MonoBehaviour {

	public int max, min;

	void Update () {

		if(CrossPlatformInputManager.GetAxis("Vertical")>0 && transform.position.z <= max)
		{
			transform.Translate (Vector3.forward,Space.World);
		}
		else if(CrossPlatformInputManager.GetAxis("Vertical")<0 && transform.position.z >= min )
		{
			transform.Translate (Vector3.back,Space.World);

		}


	}
}
