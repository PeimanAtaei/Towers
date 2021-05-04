using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentSc : MonoBehaviour {

	private Enemy targetEnemy;

	[Header("Fields")]
	public Transform target,partToRotation;
	public float range,turnSpeed = 10f;
	public float fireRate = 1f;
	private float fireCountDown = 0f;

	[Header("Laser")]
	public bool useLaser = false;
	public int damageOverTime;
	public LineRenderer lesarLineRenderer;
	public ParticleSystem laserInpacktEffect;
	public float slowAmount = 0.5f;

	public GameObject bulletPrefabe;
	public Transform firePoint;

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
				targetEnemy = enemy.GetComponent<Enemy> ();
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
			if(useLaser)
			{
				if(lesarLineRenderer.enabled)
				{
					lesarLineRenderer.enabled = false;
					laserInpacktEffect.Stop ();
				}
			}

			return;
		}

		LuckOnTarget ();

		if(useLaser)
		{
			Laser ();
		}
		else
		{
			if(fireCountDown <= 0f)
			{
				Shoot ();
				fireCountDown = 1f / fireRate;
			}
			fireCountDown -= Time.deltaTime;
		}

		
	}

	void LuckOnTarget()
	{
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (dir);
		Vector3 rotation = Quaternion.Lerp(partToRotation.rotation , lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotation.rotation = Quaternion.Euler(0f,rotation.y,0f);

	}

	void Laser()
	{
		
		targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
		targetEnemy.Slow (slowAmount);

		if(!lesarLineRenderer.enabled)
		{
			lesarLineRenderer.enabled = true;
			laserInpacktEffect.Play ();
		}
		lesarLineRenderer.SetPosition (0,firePoint.position);
		lesarLineRenderer.SetPosition (1,target.position);

		Vector3 dir = firePoint.position - target.position;
		laserInpacktEffect.transform.position = target.position +dir.normalized;

		laserInpacktEffect.transform.rotation = Quaternion.LookRotation (dir);


		//Debug.Log ("draw Laser");
	}

	void Shoot()
	{
		Sound.Play ();
		//Debug.Log ("Shoot");
		GameObject bulletGO = (GameObject) Instantiate(bulletPrefabe,firePoint.position,firePoint.rotation);

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
