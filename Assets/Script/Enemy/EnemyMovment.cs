using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Enemy))]
public class EnemyMovment : MonoBehaviour {

	private Transform target;
	private int wayPointIndex = 0;
	private HealthUi healthUi;
	private Enemy enemy;
	public Enemy[] Enemies;
	private WaveSpawne wavespawn;

	void Start () {
		wavespawn = WaveSpawne.instance;
		enemy = GetComponent<Enemy> ();
		target = WayPointsSc.points[0];
		healthUi = HealthUi.instance;
	}

	void Update () {
		Vector3 dir = target.position - transform.position;
		transform.Translate (dir.normalized * enemy.speed * Time.deltaTime);

		if(Vector3.Distance(transform.position,target.position) <= 0.4f)
		{
			GetNextWayPoint ();
		}

		enemy.speed = enemy.startSpeed;

	}

	void GetNextWayPoint()
	{

		if(wayPointIndex >= WayPointsSc.points.Length -1)
		{
			EndPath ();
			return;
		}
		wayPointIndex++;
		target = WayPointsSc.points[wayPointIndex];
	}

	void EndPath()
	{
		Destroy (gameObject);
		if(PlayerState.health>0)
		{
			PlayerState.health--;
			healthUi.ChangeHealth ();

			Enemies = FindObjectsOfType<Enemy> ();
			if(Enemies.Length <=1 && wavespawn.wavesEnded)
			{
				Debug.Log ("Level Complite");
				PlayerPrefs.SetInt ("levelNumber",wavespawn.levelNumber+1);
				wavespawn.VictoryPage ();

			}
		}

	}

}
