using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

	BiuldManager buildManager;
	public TurrentBluePrint standardTurrent;
	public TurrentBluePrint standardMissile;
	public TurrentBluePrint standardTirbar;
	public TurrentBluePrint standardLaser;

	void Start () {

		buildManager = BiuldManager.instance;
		
	}

	public void	SelectStandardPrefabe()
	{
		buildManager.SetTurrentToBuild (standardTurrent);
		Debug.Log ("Standard turrent Selected");
	}

	public void	SelectTirbarPrefabe()
	{
		buildManager.SetTurrentToBuild (standardTirbar);
		Debug.Log ("Tirbar turrent Selected");
	}

	public void	SelectMissilePrefabe()
	{
		buildManager.SetTurrentToBuild (standardMissile);
		Debug.Log ("Missile turrent Selected");
	}

	public void	SelectLaserPrefabe()
	{
		buildManager.SetTurrentToBuild (standardLaser);
		Debug.Log ("Laser turrent Selected");
	}
}
