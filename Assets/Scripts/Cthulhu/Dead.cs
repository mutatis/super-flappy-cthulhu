using UnityEngine;
using System.Collections;

public class Dead : MonoBehaviour 
{
	public PlayerJump dead;
	public GameObject retry;
	public GameObject menu;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(dead.end)
		{
			retry.SetActive(true);
			menu.SetActive(true);
		}
	}
}
