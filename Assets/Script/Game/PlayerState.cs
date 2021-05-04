using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour {

	public static int money;
	public int startMoney;

	public static int health;
	public int startHealth;
	public static int roundsRecord;



	void Start () {

		roundsRecord = 0;
		money = startMoney;
		health = startHealth;

		Debug.Log (money.ToString() + " " +health.ToString());
	}



}
