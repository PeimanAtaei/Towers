using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public FadeIn fading;

	public void SelectLevel(int number)
	{
        if (PlayerPrefs.GetInt("levelNumber") == 0)
            PlayerPrefs.SetInt("levelNumber", 1);
        
        if (PlayerPrefs.GetInt("levelNumber") >= number)
        {
            fading.FadeTo("Level" + number);
        }
		
	}

	public void LoadMenu()
	{
		fading.FadeTo ("MainMenu");	
	}

}
