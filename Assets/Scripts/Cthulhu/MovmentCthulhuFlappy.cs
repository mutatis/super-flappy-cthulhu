using UnityEngine;
using System.Collections;

public class MovmentCthulhuFlappy : MonoBehaviour 
{
	public float vel = -0.2f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		vel = PlayerJump.player.vel;
		if(Time.timeScale == 1 && (PlayerJump.player.morreu == false || PlayerJump.player.end == false) && PlayerJump.player.cont == 0)
		{
			transform.Translate(vel * Time.deltaTime, 0, 0);
		}

		/*if(PlayerJump.player.pontos >= 2)
		{
			gameObject.SetActive(false);
		}*/
	}
}
