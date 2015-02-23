using UnityEngine;
using System.Collections;

public class FlappyChao : MonoBehaviour {

	public PlayerJump player;
	public Transform posX;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(player.cont == 0)
		{
			transform.Translate(-0.2f, 0, 0);
			if(transform.position.x <= posX.position.x)
			{
				transform.position = new Vector3(104, transform.position.y, transform.position.z);
			}
		}
	}
}
