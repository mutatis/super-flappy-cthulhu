using UnityEngine;
using System.Collections;

public class MovmentCthulhuFlappy : MonoBehaviour 
{
	public PlayerJump morreu;
	public float vel = -0.2f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		vel = PlayerJump.player.vel;
		if(Time.timeScale == 1 && (morreu.morreu == false || morreu.end == false))
		{
			transform.Translate(vel, 0, 0);
		}

		/*if(PlayerJump.player.pontos >= 2)
		{
			gameObject.SetActive(false);
		}*/
	}
}
