using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FadeIn : MonoBehaviour {

	public Image blackImg;
	public AnimationCurve curve;
	public GameObject Fader;

	void Start()
	{
		StartCoroutine (Fading());
	}

	public void FadeTo(string sceneName)
	{
		Fader.SetActive (true);
		StartCoroutine (FadeOut(sceneName));
	}

	IEnumerator Fading()
	{
		float t = 1f;
		while (t>0f) {
			t -= Time.deltaTime;
			float a = curve.Evaluate (t);
			blackImg.color = new Color (0f,0f,0f,a);
			yield return 0;
		}
		Fader.SetActive (false);
	}

	IEnumerator FadeOut(string sceneName)
	{
		
		float t = 0f;
		while (t<1f) {
			t += Time.deltaTime;
			float a = curve.Evaluate (t);
			blackImg.color = new Color (0f,0f,0f,a);
			yield return 0;
		}

		SceneManager.LoadScene (sceneName);

	}

}
