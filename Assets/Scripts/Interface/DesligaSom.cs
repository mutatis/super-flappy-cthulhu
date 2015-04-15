using UnityEngine;
using System.Collections;

public class DesligaSom : MonoBehaviour 
{
	public GameObject x;

	void Start()
	{
		Time.timeScale = 0;
		if(PlayerPrefs.GetInt("ONOFF") == 0)
		{
			x.SetActive(false);
		}
		else
		{
			x.SetActive(true);
		}
	}

	public void OnOff()
	{
		if(PlayerPrefs.GetInt("ONOFF") == 0)
		{
			x.SetActive(false);
			PlayerPrefs.SetInt("ONOFF", 1);
		}
		else
		{
			x.SetActive(true);
			PlayerPrefs.SetInt("ONOFF", 0);
		}
	}

	void Update()
	{
		if(PlayerPrefs.GetInt("ONOFF") == 0)
		{
			x.SetActive(false);
		}
		else
		{
			x.SetActive(true);
		}
	}
}
