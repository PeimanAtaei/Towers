using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawne : MonoBehaviour {

	public Wave[] waves;
	//public Transform enemyPrefabe;
	public Transform spawnePoint;
	public int enemyCounter = 0;
	public float timeBetwinWaves = 10;
	public float countDown = 20f;
	public int waveIndex = 0;
	public Text waveNumber;
	public Animator anim;
	public static WaveSpawne instance;
	public bool wavesEnded = false;
	public GameObject victoryUi;
	public Text waveCountDownTimer;
	public int levelNumber;

	void Awake()
	{
		if(instance !=null)
		{
			//Debug.Log ("More Thane 1 instance");
			return;
		}
		instance = this;
	}


	void Update () {
		if(countDown <= 0 && !wavesEnded)
		{
			StartCoroutine ("SpawnWaves");
			countDown = timeBetwinWaves;
		}

		countDown -= Time.deltaTime;
		//waveCountDownTimer.text = Mathf.Round (countDown).ToString();
		waveCountDownTimer.text = waveIndex.ToString();
	}

	public void VictoryPage()
	{
		victoryUi.SetActive (true);
	}

	IEnumerator SpawnWaves()
	{
		int wavein = waveIndex + 1;
		waveNumber.text = wavein.ToString ();
		anim.Play ("WavesAnim"); 

		PlayerState.roundsRecord = wavein;
		Wave wave = waves[waveIndex];
			
		for (int i = 0; i < wave.TypesOfEnemy; i++) {
			for (int j = 0; j < wave.count; j++) {
				SpawneEnemy (wave.enemy[i]);
				yield return new WaitForSeconds (1f/wave.rate);
			}

		}
		waveIndex++;

		if(waveIndex == waves.Length)
		{
			Debug.Log ("Waves Ended");
			Debug.Log (enemyCounter.ToString());
			//this.enabled = false;
			wavesEnded = true;
		}

		if(enemyCounter <= 0)
		{
			Debug.Log ("Enemy 0");

		}


	}

	void SpawneEnemy(GameObject enemyPrefabe)
	{
		//Debug.Log ("Waves Are Comming");
		Instantiate (enemyPrefabe , spawnePoint.position,spawnePoint.rotation);
		enemyCounter++;
		Debug.Log (enemyCounter.ToString());

	}


}
