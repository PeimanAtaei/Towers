using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagers : MonoBehaviour {

	public static GameManagers instance;
	public static bool gameIsOver;
	public GameObject gameOverUi,puseUi;
	public Text roundRecord;
	public FadeIn fading;


	void Awake()
	{
		if(instance !=null)
		{
			//Debug.Log ("More Thane 1 instance");
			return;
		}
		instance = this;
	}

	void Start()
	{
		gameIsOver = false;
	}

	public void GameOver()
	{
		Debug.Log ("Game Over");
		gameOverUi.SetActive (true);
		gameIsOver = true;
		roundRecord.text = PlayerState.roundsRecord.ToString();
	}

	public void ResetGame()
	{
		//SceneManager.LoadScene ();
		Time.timeScale = 1f;
		fading.FadeTo (SceneManager.GetActiveScene().name);
	}

	public void LoadMenu()
	{
		Time.timeScale = 1f;
		fading.FadeTo ("MainMenu");	
	}

	public void LoadMap()
	{
		Time.timeScale = 1f;
		fading.FadeTo ("LevelSelect");	
	}

	public void PuseGame()
	{
		puseUi.SetActive (!puseUi.activeSelf);
		if(puseUi.activeSelf)
		{
			StartCoroutine ("Pusing");

		}else{
			Time.timeScale = 1f;
		}
	}

	IEnumerator Pusing()
	{
		yield return new WaitForSeconds (1f);
		Time.timeScale = 0f;

	}
}
