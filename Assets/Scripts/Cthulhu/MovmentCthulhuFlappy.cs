using UnityEngine;
using System.Collections;

public class MovmentCthulhuFlappy : MonoBehaviour 
{
	public PlayerJump morreu;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.timeScale == 1 && morreu.morreu == false)
		transform.Translate(-0.2f, 0, 0);
	}
}
