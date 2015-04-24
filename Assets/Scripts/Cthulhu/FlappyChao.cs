using UnityEngine;
using System.Collections;

public class FlappyChao : MonoBehaviour {

	//public PlayerJump player;
	public Transform posX;
	float vel = -0.2f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
	{
		vel = PlayerJump.player.vel;
		if(PlayerJump.player.cont == 0)
		{
			transform.Translate(vel * Time.deltaTime, 0, 0);
			if(transform.position.x <= posX.position.x)
			{
				transform.position = new Vector3(104, transform.position.y, transform.position.z);
			}
		}
	}
}
