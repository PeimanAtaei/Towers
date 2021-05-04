
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private BiuldManager biuldManager;
	private WaveSpawne wavespawn;
	public float healthEnemy;
	public int worthPrice;
	public GameObject dieEnemyEffect;
	public float speed,startSpeed = 10f;
	public Enemy[] Enemies;

	void Start () {
		biuldManager = BiuldManager.instance;
		wavespawn = WaveSpawne.instance;
		speed = startSpeed;
	
	}

	public void TakeDamage(float amount)
	{
		healthEnemy-= amount;
		if(healthEnemy<=0)
		{
			DieEnemy ();
		}
	}

	public void Slow(float amount)
	{
		speed = startSpeed * (1f-amount);
		//Debug.Log ("Slowing");
	}

	private void DieEnemy()
	{
		PlayerState.money += worthPrice;
		biuldManager.SetMoneyText ();

		GameObject effect = (GameObject)Instantiate (dieEnemyEffect,transform.position,Quaternion.identity);
		Destroy (effect,3f);
		Enemies = FindObjectsOfType<Enemy> ();

		if(Enemies.Length <=1 && wavespawn.wavesEnded )
		{
			Debug.Log ("Level Complite");
			wavespawn.VictoryPage ();
			PlayerPrefs.SetInt ("levelNumber",wavespawn.levelNumber+1);
		}
		Destroy (gameObject);

	}
}
