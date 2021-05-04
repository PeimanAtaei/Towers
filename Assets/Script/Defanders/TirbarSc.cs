using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirbarSc : MonoBehaviour {


	[Header("Fields")]
	public Transform target,partToRotation;
	public float range,turnSpeed = 10f;
	public float fireRate = 1f;
	private float fireCountDown = 0f;

	public GameObject bulletPrefabe;
	public Transform firePoint1;
	public Transform firePoint2;

	[Header("Setup Option")]
	public string EnemyTag = "Enemy";
	public AudioSource Sound;



	void Start () {
		InvokeRepeating ("UpdateTarget",0f,0.5f);
	}

	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag (EnemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

		foreach (GameObject enemy in enemies) {
			float distanceToEnemy = Vector3.Distance (transform.position,enemy.transform.position);

			if(distanceToEnemy <= shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}

		}

		if (nearestEnemy != null && shortestDistance <= range) {
			target = nearestEnemy.transform;
		} else {
			target = null;
		}
	}

	void Update () {

		if(target == null)
		{
			return;
		}
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (dir);
		Vector3 rotation = Quaternion.Lerp(partToRotation.rotation , lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotation.rotation = Quaternion.Euler(0f,rotation.y,0f);

		if(fireCountDown <= 0f)
		{
			ShootLeft ();
			ShootRight ();
			fireCountDown = 1f / fireRate;

		}
		fireCountDown -= Time.deltaTime;

	}

	void ShootLeft()
	{
		//Debug.Log ("Shoot");
		GameObject bulletGO = (GameObject) Instantiate(bulletPrefabe,firePoint1.position,firePoint1.rotation);
		//GameObject bulletGO2 = (GameObject) Instantiate(bulletPrefabe,firePoints[2].position,firePoints[2].rotation);

		BulletSc bulletSc = bulletGO.GetComponent<BulletSc> ();
		//BulletSc bulletSc2 = bulletGO2.GetComponent<BulletSc> ();

		if(bulletSc != null)
		{
			bulletSc.Seek (target);
		}
		/*if(bulletSc2 != null)
		{
			bulletSc2.Seek (target);
		}*/

	}

	void ShootRight()
	{
		Sound.Play ();
		GameObject bulletGO = (GameObject) Instantiate(bulletPrefabe,firePoint2.position,firePoint2.rotation);
		BulletSc bulletSc = bulletGO.GetComponent<BulletSc> ();

		if(bulletSc != null)
		{
			bulletSc.Seek (target);
		}


	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position,range	);
	}
}
