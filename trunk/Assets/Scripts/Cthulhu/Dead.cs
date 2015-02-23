using UnityEngine;
using System.Collections;

public class Dead : MonoBehaviour 
{
	public PlayerJump morreu;
	public GameObject retry;
	public GameObject menu;
	public GameObject flash;
	public Animator[] splash;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(morreu.morreu)
		{
			flash.SetActive(true);
		}
		if(morreu.end)
		{
			for(int i = 0; i < splash.Length; i++)
			{
				splash[i].enabled = true;
			}
			retry.SetActive(true);
			menu.SetActive(true);
		}
	}
}
