using UnityEngine;
using System.Collections;

public class SplashDeath : MonoBehaviour {
	
	//public PlayerJump player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerJump.player != null)
			transform.position = new Vector2 (PlayerJump.player.transform.position.x, transform.position.y);
	}

	public void Desliga()
	{
		gameObject.SetActive(false);
	}
}
