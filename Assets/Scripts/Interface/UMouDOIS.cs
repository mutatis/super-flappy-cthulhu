using UnityEngine;
using System.Collections;

public class UMouDOIS : MonoBehaviour 
{
	public GameObject[] obj;

	// Use this for initialization
	void Start () 
	{
		if(PlayerPrefs.GetInt("OBJ") >= 2)
		{
			PlayerPrefs.SetInt("OBJ", 0);
		}
		else
		{
			PlayerPrefs.SetInt("OBJ", (PlayerPrefs.GetInt("OBJ") + 1));
		}
		Debug.Log(PlayerPrefs.GetInt("OBJ"));
		if(PlayerPrefs.GetInt("Retry") != 2)
		{
			obj[PlayerPrefs.GetInt("OBJ")].SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
