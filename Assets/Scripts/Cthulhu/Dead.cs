using UnityEngine;
using System.Collections;

public class Dead : MonoBehaviour 
{
	//public PlayerJump morreu;
	public GameObject retry;
	public GameObject menu;
	public GameObject flash;
	public Animator[] splash;
	public AudioClip[] audio;
	public Blur blur;
	bool morte;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(PlayerJump.player.morreu && PlayerJump.player.end == false)
		{
			Time.timeScale = 1;
		}
		if(PlayerJump.player.morreu)
		{
			flash.SetActive(true);
		}
		if(PlayerJump.player.end)
		{			
			for(int i = 0; i < splash.Length; i++)
			{
				splash[i].enabled = true;
			}
			retry.SetActive(true);
			menu.SetActive(true);
			blur.enabled = true;
			morte = true;
		}
	}
}
