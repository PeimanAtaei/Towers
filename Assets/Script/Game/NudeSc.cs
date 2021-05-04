using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NudeSc : MonoBehaviour {

	public GameObject turrent;
	public  Vector3 turrentPositionOfset;

	private Renderer rend;
	public Color hoverColor,startColor;


	private BiuldManager buildManager;


	void Start () {
		buildManager = BiuldManager.instance;
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;
	}


	void OnMouseDown()
	{
		if(EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}

		if(!buildManager.CanBuild)
		{
			Debug.Log ("Select A Wipen");
			return;
		}

		if(turrent !=null)
		{
			Debug.Log ("Cant Biuld threr");
			return;
		}

		buildManager.BuildTurrentOn (this);
	}

	void OnMouseEnter()
	{
		if(EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}

		if(!buildManager.CanBuild)
		{
			Debug.Log ("Select A Wipen");
			return;
		}

		if (buildManager.HasMoney) {
			rend.material.color = hoverColor;
		} else {
			rend.material.color = Color.red;
		}



	}

	void OnMouseExit()
	{
		rend.material.color = startColor;
	}

	public Vector3 GetBuildPosition()
	{
		return transform.position + turrentPositionOfset;
	}
}
