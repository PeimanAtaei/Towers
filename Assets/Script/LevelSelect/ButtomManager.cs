using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtomManager : MonoBehaviour {

	public int levelNumber;
	public Animator buttomAnim;

	void Start () {
		if(PlayerPrefs.GetInt("levelNumber") >= levelNumber)
		{
			buttomAnim.Play ("OpenLevelAnim");
		}
		if(levelNumber == 1)
		{
			buttomAnim.Play ("OpenLevelAnim");
		}
	}
}
