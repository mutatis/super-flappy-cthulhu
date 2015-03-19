﻿using UnityEngine;
using System.Collections;

public class Gerenciador : MonoBehaviour 
{
	public GameObject[] tap;
	public GameObject[] menu;

	// Use this for initialization
	void Start () 
	{
		if(PlayerPrefs.GetInt("Retry") == 2)
		{
			for(int i = 0; i < tap.Length; i++)
			{
				tap[i].SetActive(true);
			}
			for(int i = 0; i < menu.Length; i++)
			{
				menu[i].SetActive(false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			PlayerPrefs.SetInt ("Retry", 0);
			Application.Quit(); 
		}
	}
}