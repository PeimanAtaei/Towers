using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public string startLevelName;
	public FadeIn fading;

	public void PlayGame()
	{
		//SceneManager.LoadScene (startLevelName);
		fading.FadeTo (startLevelName);
	}

	public void ExitGame()
	{
		Application.Quit ();
	}

}
