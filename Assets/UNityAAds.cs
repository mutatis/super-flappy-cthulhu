using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class UNityAAds : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		Advertisement.Initialize ("43223");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(PlayerPrefs.GetInt("Mortes") >= 5)
		{ 
			Advertisement.Show();
			PlayerPrefs.SetInt("Mortes", 0);
		}
	}
}
