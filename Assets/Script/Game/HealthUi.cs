using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUi : MonoBehaviour {

	public static HealthUi instance;
	public Text healthUi;
	private BiuldManager buildManager;
	private GameManagers gameManager;


	void Awake()
	{
		if(instance !=null)
		{
			//Debug.Log ("More Thane 1 instance");
			return;
		}
		instance = this;
	}

	void Start () {
		buildManager = BiuldManager.instance;
		gameManager = GameManagers.instance;
		ChangeHealth ();
		buildManager.SetMoneyText ();

	}
	

	public void ChangeHealth()
	{
		healthUi.text = PlayerState.health.ToString ();
		if(PlayerState.health <= 0)
		{
			gameManager.GameOver ();
		}

	}
}
