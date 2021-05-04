using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BiuldManager : MonoBehaviour {

	public static BiuldManager instance;
	public GameObject standardTurrent;
	public GameObject tirbarTurrent;
	public GameObject missileTurrent;
	private TurrentBluePrint turrentToBild;
	public Text moneyText;
	public AudioSource sounds;


	void Awake()
	{
		if(instance !=null)
		{
			Debug.Log ("More Thane 1 instance");
			return;
		}
		instance = this;
	}

	void Start()
	{
		SetMoneyText ();
	}
		
	public bool CanBuild{get { return turrentToBild != null; }}
	public bool HasMoney{get { return PlayerState.money >= turrentToBild.cost; }}

	public void SetTurrentToBuild(TurrentBluePrint turrent)
	{
		turrentToBild = turrent;
	}

	public void BuildTurrentOn(NudeSc nude)
	{

		if(PlayerState.money < turrentToBild.cost)
		{
			Debug.Log ("No Enough Gold");
			return;
		}

		PlayerState.money -= turrentToBild.cost;
		GameObject turrent = (GameObject) Instantiate(turrentToBild.prefabe , nude.GetBuildPosition(),Quaternion.identity);
		nude.turrent = turrent;
		SetMoneyText ();
		sounds.Play ();
		Debug.Log ("Turrent Build , Your Money : "+PlayerState.money);
	}

	public void SetMoneyText()
	{
		moneyText.text = PlayerState.money.ToString ();
	}
}
